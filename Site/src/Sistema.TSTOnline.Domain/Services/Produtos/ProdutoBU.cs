using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;

namespace Sistema.TSTOnline.Domain.Services.Produtos
{
    public class ProdutoBU
    {
        private readonly IRepository<ProdutoEN> _repositoryProduto;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoBU(IRepository<ProdutoEN> repositoryProduto, IUnitOfWork unitOfWork)
        {
            _repositoryProduto = repositoryProduto;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDProduto, string SKU, string Nome, string Descricao, int IDForncedor, int IDCategoria, int IDSubCategoria, decimal Preco)
        {
            ProdutoEN produtoEN = _repositoryProduto.GetByID(IDProduto);

            if (produtoEN != null)
            {
                produtoEN.UpdateProperties
                    (
                        SKU,
                        Nome,
                        Descricao,
                        IDForncedor,
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
                        SKU,
                        Nome,
                        Descricao,
                        IDForncedor,
                        IDCategoria,
                        IDSubCategoria,
                        Preco
                    );

                _repositoryProduto.Save(produtoEN);
            }

            _unitOfWork.Commit();
        }
    }
}
