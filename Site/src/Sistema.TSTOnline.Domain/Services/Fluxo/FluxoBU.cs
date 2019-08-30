using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Services.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.Fluxo
{
    public class FluxoBU
    {
        private readonly IRepository<PedidoVendaEN> _repositoryPedidoVenda;
        private readonly IRepository<PedidoVendaItemEN> _repositoryPedidoVendaItem;
        private readonly IRepository<ContasReceberEN> _repositoryContasReceber;
        private readonly MovimentoEstoqueBU _movimentoEstoqueBU;
        private readonly ContasReceberBU _contasReceberBU;
        private readonly IUnitOfWork _unitOfWork;

        public FluxoBU
            (
                IRepository<PedidoVendaEN> repositoryPedidoVenda, 
                IRepository<PedidoVendaItemEN> repositoryPedidoVendaItem, 
                IRepository<ContasReceberEN> repositoryContasReceber,
                MovimentoEstoqueBU movimentoEstoqueBU,
                ContasReceberBU contasReceberBU,
                IUnitOfWork unitOfWork
            )
        {
            _repositoryPedidoVenda = repositoryPedidoVenda;
            _repositoryPedidoVendaItem = repositoryPedidoVendaItem;
            _repositoryContasReceber = repositoryContasReceber;
            _movimentoEstoqueBU = movimentoEstoqueBU;
            _contasReceberBU = contasReceberBU;
            _unitOfWork = unitOfWork;
        }

        public void FluxoPedido(int IDPedidoVenda, PedidoVendaStatusEnum Status, bool inTransaction = false)
        {
            PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);

            pedidoVendaEN.Status = Status;

            if (inTransaction == false)
                _unitOfWork.BeginTransaction();

            try
            {
                _repositoryPedidoVenda.Edit(pedidoVendaEN);

                _unitOfWork.Commit();

                if (Status == PedidoVendaStatusEnum.Cancelado)
                {
                    List<PedidoVendaItemEN> listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == pedidoVendaEN.IDPedido).ToList();

                    foreach (var itemPedido in listPedidoVendaItem)
                    {
                        _movimentoEstoqueBU.Save
                            (
                                OrigemMovimentoEstoqueEnum.PedidoVenda,
                                itemPedido.IDPedido,
                                itemPedido.IDProduto,
                                TipoMovimentoEstoqueEnum.Entrada,
                                itemPedido.Qtde,
                                "Pedido de Venda [CANCELAMENTO]"
                            );
                    }
                }

                else if (Status == PedidoVendaStatusEnum.AguardandoPagamento)
                {
                    var listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == IDPedidoVenda).ToList();

                    foreach (var itemPedido in listPedidoVendaItem)
                    {
                        //Criação Movimentação e Atualiza Estoque
                        _movimentoEstoqueBU.Save
                            (
                                OrigemMovimentoEstoqueEnum.PedidoVenda,
                                IDPedidoVenda,
                                itemPedido.IDProduto,
                                TipoMovimentoEstoqueEnum.Saida,
                                itemPedido.Qtde,
                                string.Format("Pedido de Venda")
                            );
                    }

                    //GRAVA O TÍTULO NO CONTAS A RECEBER
                    _contasReceberBU.Save
                        (
                            0,
                            $"PED{pedidoVendaEN.IDPedido.ToString("00000")}",
                            pedidoVendaEN.DataCadastro.AddDays(10),
                            listPedidoVendaItem.Sum(obj => obj.ValorTotal),
                            0,
                            OrigemContasReceberEnum.PedidoVenda,
                            pedidoVendaEN.IDPedido
                        );
                }

                if (inTransaction == false)
                    _unitOfWork.CommitTransaction();
            }
            catch (DomainException ex)
            {
                if (inTransaction == false)
                    _unitOfWork.RollbackTransaction();

                throw new DomainException(ex.Message);
            }
            catch
            {
                if (inTransaction == false)
                    _unitOfWork.RollbackTransaction();

                throw new DomainException("Erro ao atualizar status do pedido. Tente novamente mais tarde");
            }
        }

        public void FluxoContasReceber(int IDContasReceber, ContasReceberStatusEnum Status)
        {
            ContasReceberEN contasReceberEN = _repositoryContasReceber.GetByID(IDContasReceber);

            contasReceberEN.Status = Status;

            _unitOfWork.BeginTransaction();

            try
            {
                _repositoryContasReceber.Edit(contasReceberEN);

                if (contasReceberEN.Origem == OrigemContasReceberEnum.PedidoVenda && (Status == ContasReceberStatusEnum.Baixado || Status == ContasReceberStatusEnum.Cancelado))
                {
                    if (Status == ContasReceberStatusEnum.Baixado)
                        FluxoPedido(contasReceberEN.Chave, PedidoVendaStatusEnum.Finalizado, true);

                    else if (Status == ContasReceberStatusEnum.Cancelado)
                        FluxoPedido(contasReceberEN.Chave, PedidoVendaStatusEnum.Cancelado, true);
                }

                _unitOfWork.Commit();

                _unitOfWork.CommitTransaction();
            }
            catch (DomainException ex)
            {
                Console.Write(ex);
                _unitOfWork.RollbackTransaction();
                throw new DomainException(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                _unitOfWork.RollbackTransaction();
                throw new DomainException("Erro ao atualizar status do título. Tente novamente mais tarde");
            }
        }
    }
}
