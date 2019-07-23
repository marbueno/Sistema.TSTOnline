using Sistema.Competicao.Domain.Entities.Produtos;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Produtos
{
    public class EstoqueBU
    {
        private readonly IRepository<EstoqueEN> _repositoryEstoque;
        private readonly IUnitOfWork _unitOfWork;

        public EstoqueBU(IRepository<EstoqueEN> repositoryEstoque, IUnitOfWork unitOfWork)
        {
            _repositoryEstoque = repositoryEstoque;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDProduto, double Qtde)
        {
            EstoqueEN estoqueEN = _repositoryEstoque.GetByID(IDProduto);

            if (estoqueEN != null)
            {
                estoqueEN.UpdateProperties
                    (
                        Qtde
                    );

                _repositoryEstoque.Edit(estoqueEN);
            }
            else
            {
                estoqueEN = new EstoqueEN
                    (
                        Qtde
                    );

                _repositoryEstoque.Save(estoqueEN);
            }

            _unitOfWork.Commit();
        }
    }
}
