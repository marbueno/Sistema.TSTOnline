using Sistema.TSTOnline.Domain.Entities.Estoque;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Domain.Services.Estoque
{
    public class EstoqueBU
    {
        private readonly IRepository<EstoqueEN> _repositoryEstoque;
        private readonly IRepository<ProdutoEN> _repositoryProduto;
        private readonly IUnitOfWork _unitOfWork;

        public EstoqueBU(IRepository<EstoqueEN> repositoryEstoque, IRepository<ProdutoEN> repositoryProduto, IUnitOfWork unitOfWork)
        {
            _repositoryEstoque = repositoryEstoque;
            _repositoryProduto = repositoryProduto;
            _unitOfWork = unitOfWork;
        }

        public void AtualizarEstoque(int IDUser, int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde, bool doCommit = false)
        {
            EstoqueEN estoqueEN = _repositoryEstoque.GetByID(IDProduto);

            if (estoqueEN != null)
            {
                int _qtde = estoqueEN.Qtde;

                if (Tipo == TipoMovimentoEstoqueEnum.Entrada)
                    _qtde += Qtde;
                else
                    _qtde -= Qtde;

                if (_qtde <= 0 && Tipo == TipoMovimentoEstoqueEnum.Saida)
                {
                    ProdutoEN produtoEN = _repositoryProduto.GetByID(IDProduto);
                    throw new DomainException($"Estoque do produto [{produtoEN.Nome}] Insuficiente");
                }
                else
                {
                    estoqueEN.UpdateProperties
                    (
                        IDUser,
                        IDProduto,
                        _qtde
                    );
                }

                _repositoryEstoque.Edit(estoqueEN);
            }
            else
            {
                estoqueEN = new EstoqueEN
                    (
                        IDUser,
                        IDProduto,
                        Qtde
                    );

                _repositoryEstoque.Save(estoqueEN);
            }

            if (doCommit)
                _unitOfWork.Commit();
        }
    }
}
