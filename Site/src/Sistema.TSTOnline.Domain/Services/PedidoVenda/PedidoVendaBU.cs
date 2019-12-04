using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema.TSTOnline.Domain.Services.PedidoVenda
{
    public class PedidoVendaBU
    {
        private readonly IRepository<PedidoVendaEN> _repositoryPedidoVenda;
        private readonly IRepository<PedidoVendaItemEN> _repositoryPedidoVendaItem;
        private readonly PedidoVendaItemBU _pedidoVendaItemBU;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoVendaBU
            (
                IRepository<PedidoVendaEN> repositoryPedidoVenda, 
                IRepository<PedidoVendaItemEN> repositoryPedidoVendaItem, 
                PedidoVendaItemBU pedidoVendaItemBU,
                IUnitOfWork unitOfWork
            )
        {
            _repositoryPedidoVenda = repositoryPedidoVenda;
            _repositoryPedidoVendaItem = repositoryPedidoVendaItem;
            _pedidoVendaItemBU = pedidoVendaItemBU;
            _unitOfWork = unitOfWork;
        }

        public int Save(int IDPedidoVenda, int IDCompany, int IDUser, DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor, int IDEmpresa, TipoPagamentoEnum TipoPagamento, QtdeParcelasEnum QtdeParcelas, string Observacao, List<PedidoVendaItemEN> ListPedidoVendaItens)
        {
            int idPedido = 0;

            _unitOfWork.BeginTransaction();

            try
            {
                PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);

                if (pedidoVendaEN != null)
                {

                    if (pedidoVendaEN.Status != PedidoVendaStatusEnum.Aberto)
                    {
                        pedidoVendaEN.UpdateProperties
                        (
                            IDCompany,
                            IDUser,
                            pedidoVendaEN.DataVenda,
                            pedidoVendaEN.Status,
                            pedidoVendaEN.IDUsuario,
                            pedidoVendaEN.IDVendedor,
                            pedidoVendaEN.IDEmpresa,
                            pedidoVendaEN.TipoPagamento,
                            pedidoVendaEN.QtdeParcelas,
                            Observacao
                        );
                    }
                    else
                    {
                        pedidoVendaEN.UpdateProperties
                        (
                            IDCompany,
                            IDUser,
                            DataVenda,
                            Status,
                            IDUsuario,
                            IDVendedor,
                            IDEmpresa,
                            TipoPagamento,
                            QtdeParcelas,
                            Observacao
                        );
                    }

                    _repositoryPedidoVenda.Edit(pedidoVendaEN);
                }
                else
                {
                    pedidoVendaEN = new PedidoVendaEN
                        (
                            IDCompany,
                            IDUser,
                            DataVenda,
                            Status,
                            IDUsuario,
                            IDVendedor,
                            IDEmpresa,
                            TipoPagamento,
                            QtdeParcelas,
                            Observacao
                        );
                    pedidoVendaEN.DataCadastro = DateTime.Now.ToLocalTime();

                    _repositoryPedidoVenda.Save(pedidoVendaEN);
                }

                _unitOfWork.Commit();

                if (pedidoVendaEN.Status == PedidoVendaStatusEnum.Aberto)
                {
                    idPedido = pedidoVendaEN.IDPedido;

                    List<PedidoVendaItemEN> listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == idPedido).ToList();

                    //VERIFICA SE ALGUM ITEM FOI EXCLUÍDO
                    foreach (var itemPedidoBD in listPedidoVendaItem)
                    {
                        var itemPedido = ListPedidoVendaItens.Where(obj => obj.IDProduto == itemPedidoBD.IDProduto).FirstOrDefault();

                        if (itemPedido == null)
                        {
                            _pedidoVendaItemBU.RemoveItem(itemPedidoBD);
                        }
                    }

                    listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == idPedido).ToList();

                    int item = 0;
                    foreach (var itemPedido in ListPedidoVendaItens)
                    {
                        var itemPedidoBD = listPedidoVendaItem.Where(obj => obj.IDProduto == itemPedido.IDProduto).FirstOrDefault();

                        int pedidoItem = 0;

                        if (itemPedidoBD != null)
                        {
                            pedidoItem = itemPedidoBD.IDPedidoItem;
                            item = itemPedidoBD.Item;
                        }
                        else
                        {
                            pedidoItem = itemPedido.IDPedidoItem;

                            item++;
                        }

                        _pedidoVendaItemBU.Save(pedidoItem, idPedido, item, itemPedido.IDProduto, itemPedido.Qtde, itemPedido.Valor);

                        if (pedidoItem != 0)
                            item = listPedidoVendaItem.Count();
                    }
                }

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
                throw new DomainException("Erro ao salvar pedido. Tente novamente mais tarde");
            }

            return idPedido;
        }
    }
}
