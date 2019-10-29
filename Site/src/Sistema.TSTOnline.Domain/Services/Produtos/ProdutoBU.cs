using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Utils;
using System;
using System.Transactions;

namespace Sistema.TSTOnline.Domain.Services.Produtos
{
    public class ProdutoBU
    {
        private readonly IRepository<ProdutoEN> _repositoryProduto;
        private readonly EstoqueBU _estoqueBU;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoBU(IRepository<ProdutoEN> repositoryProduto, EstoqueBU estoqueBU, IUnitOfWork unitOfWork)
        {
            _repositoryProduto = repositoryProduto;
            _estoqueBU = estoqueBU;
            _unitOfWork = unitOfWork;
        }

        public int Save(int IDProduto, int IDUser, string SKU, string Nome, string Descricao, int IDFornecedor, int IDCategoria, int IDSubCategoria, decimal Preco)
        {
            int idProduto = 0;

            _unitOfWork.BeginTransaction();

            try
            {
                ProdutoEN produtoEN = _repositoryProduto.GetByID(IDProduto);

                if (produtoEN != null)
                {
                    produtoEN.UpdateProperties
                        (
                            IDUser,
                            SKU,
                            Nome,
                            Descricao,
                            IDFornecedor,
                            IDCategoria,
                            IDSubCategoria,
                            Preco
                        );

                    _repositoryProduto.Edit(produtoEN);
                }
                else
                {
                    produtoEN = new ProdutoEN
                        (
                            IDUser,
                            SKU,
                            Nome,
                            Descricao,
                            IDFornecedor,
                            IDCategoria,
                            IDSubCategoria,
                            Preco
                        );

                    _repositoryProduto.Save(produtoEN);
                }

                _unitOfWork.Commit();

                idProduto = produtoEN.IDProduto;

                _estoqueBU.AtualizarEstoque(IDUser, idProduto, TipoMovimentoEstoqueEnum.Entrada, 0, true);

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

            return idProduto;
        }
    }
}
