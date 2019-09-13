﻿using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Services.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Utils;
using Sistema.Pagamentos.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using Sistema.Pagamentos.Interface;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Entities.Cadastros;

namespace Sistema.TSTOnline.Domain.Services.Fluxo
{
    public class FluxoBU
    {
        private readonly IRepository<PedidoVendaEN> _repositoryPedidoVenda;
        private readonly IRepository<PedidoVendaItemEN> _repositoryPedidoVendaItem;
        private readonly IRepository<ContasReceberEN> _repositoryContasReceber;
        private readonly IRepository<ProdutoEN> _repositoryProduto;
        private readonly IRepository<EmpresaEN> _repositoryEmpresa;
        private readonly MovimentoEstoqueBU _movimentoEstoqueBU;
        private readonly ContasReceberBU _contasReceberBU;
        private readonly FluxoCaixaBU _fluxoCaixaBU;
        private readonly IIntegracaoPagamento _integracaoIUGU;
        private readonly IUnitOfWork _unitOfWork;

        public FluxoBU
            (
                IRepository<PedidoVendaEN> repositoryPedidoVenda, 
                IRepository<PedidoVendaItemEN> repositoryPedidoVendaItem, 
                IRepository<ContasReceberEN> repositoryContasReceber,
                IRepository<ProdutoEN> repositoryProduto,
                IRepository<EmpresaEN> repositoryEmpresa,
                MovimentoEstoqueBU movimentoEstoqueBU,
                ContasReceberBU contasReceberBU,
                FluxoCaixaBU fluxoCaixaBU,
                IIntegracaoPagamento integracaoIUGU,
                IUnitOfWork unitOfWork
            )
        {
            _repositoryPedidoVenda = repositoryPedidoVenda;
            _repositoryPedidoVendaItem = repositoryPedidoVendaItem;
            _repositoryContasReceber = repositoryContasReceber;
            _repositoryProduto = repositoryProduto;
            _repositoryEmpresa = repositoryEmpresa;
            _movimentoEstoqueBU = movimentoEstoqueBU;
            _contasReceberBU = contasReceberBU;
            _fluxoCaixaBU = fluxoCaixaBU;
            _integracaoIUGU = integracaoIUGU;
            _unitOfWork = unitOfWork;
        }

        public void FluxoPedido(int IDPedidoVenda, PedidoVendaStatusEnum Status, bool inTransaction = false)
        {
            PedidoVendaEN pedidoVendaEN = _repositoryPedidoVenda.GetByID(IDPedidoVenda);

            bool atualizaEstoque = true;

            if (pedidoVendaEN.Status == PedidoVendaStatusEnum.Aberto)
                atualizaEstoque = false;

            pedidoVendaEN.Status = Status;

            if (inTransaction == false)
                _unitOfWork.BeginTransaction();

            try
            {
                _repositoryPedidoVenda.Edit(pedidoVendaEN);

                _unitOfWork.Commit();

                if (atualizaEstoque && Status == PedidoVendaStatusEnum.Cancelado)
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
                            pedidoVendaEN.IDEmpresa,
                            $"PED{pedidoVendaEN.IDPedido.ToString("00000")}",
                            pedidoVendaEN.DataCadastro.AddDays(10),
                            listPedidoVendaItem.Sum(obj => obj.ValorTotal),
                            0,
                            OrigemContasReceberEnum.PedidoVenda,
                            string.Empty,
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
                    {
                        FluxoPedido(contasReceberEN.Chave, PedidoVendaStatusEnum.Finalizado, true);
                    }

                    else if (Status == ContasReceberStatusEnum.Cancelado)
                        FluxoPedido(contasReceberEN.Chave, PedidoVendaStatusEnum.Cancelado, true);
                }


                if (Status == ContasReceberStatusEnum.Baixado)
                {
                    _fluxoCaixaBU.Save
                        (
                            0,
                            DateTime.Now,
                            TipoLancamentoFluxoCaixaEnum.Entrada,
                            OrigemFluxoCaixaEnum.ContasReceber,
                            contasReceberEN.IDContasReceber,
                            contasReceberEN.Valor,
                            "ENTRADA DE VALOR VIA CONTAS A RECEBER"
                        );
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

        public void GerarFatura(int IDContasReceber, string EmailCopia)
        {
            var contasReceberEN = _repositoryContasReceber.GetByID(IDContasReceber);
            List<PedidoVendaItemEN> listPedidoVendaItem = _repositoryPedidoVendaItem.Where(obj => obj.IDPedido == contasReceberEN.Chave).ToList();

            _unitOfWork.BeginTransaction();

            try
            {
                List<Item> listItens = new List<Item>();
                if (listPedidoVendaItem != null && listPedidoVendaItem.Count > 0)
                {
                    foreach (var itemPedido in listPedidoVendaItem)
                    {
                        var produtoEN = _repositoryProduto.GetByID(itemPedido.IDProduto);
                        listItens.Add(new Item()
                        {
                            Descricao = produtoEN.Nome,
                            Qtde = itemPedido.Qtde,
                            Valor = int.Parse(itemPedido.Valor.ToString("#0.00").Replace(",", "").Replace(".",""))
                        });
                    }
                }
                else
                {
                    listItens.Add(new Item()
                    {
                        Descricao = $"Título: [{contasReceberEN.NumeroTitulo}]",
                        Qtde = 1,
                        Valor = int.Parse(contasReceberEN.Valor.ToString("#0.00").Replace(",", "").Replace(".", ""))
                    });
                }

                var empresaEN = _repositoryEmpresa.GetByID(contasReceberEN.IDEmpresa);
                var emailCopia = EmailCopia;

                FaturaRequest fatura = new FaturaRequest()
                {
                    EmailCliente = string.IsNullOrEmpty(empresaEN.Email) ? emailCopia : empresaEN.Email,
                    EmailComCopiaPara = emailCopia,
                    DataVencimento = contasReceberEN.DataVencimento.ToString("yyyy-MM-dd"),
                    ConsiderarSomenteDiasUteis = true,
                    ListItensCobranca = listItens,
                    ListParametros = new List<CustomVariables>(),
                    Pagador = new Pagador()
                    {
                        CpfCnpj = empresaEN.NrMatricula,
                        Nome = empresaEN.RazaoSocial,
                        Endereco = new Endereco()
                        {
                            CEP = empresaEN.Cep,
                            Logradouro = empresaEN.Endereco,
                            Numero = empresaEN.Numero,
                            Complemento = empresaEN.Complemento,
                            Bairro = empresaEN.Bairro,
                            Estado = empresaEN.UF,
                            Cidade = empresaEN.Cidade
                        }
                    },
                    CodigoPedido = contasReceberEN.NumeroTitulo
                };

                var faturaResult = _integracaoIUGU.GerarBoleto(fatura);

                if (faturaResult.ListErros != null)
                {
                    string erros = string.Empty;
                    foreach (var item in faturaResult.ListErros)
                    {
                        erros += $"{item} | ";
                    }

                    if (!string.IsNullOrEmpty(erros))
                        throw new DomainException(erros);
                }

                _repositoryContasReceber.Edit(contasReceberEN);
                contasReceberEN.LinkFatura = faturaResult.LinkFatura;

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
                throw new DomainException("Erro ao Gerar Fatura. Tente novamente mais tarde");
            }
        }
    }
}
