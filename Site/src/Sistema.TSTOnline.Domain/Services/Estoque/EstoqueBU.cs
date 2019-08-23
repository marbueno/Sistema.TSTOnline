using Sistema.TSTOnline.Domain.Entities.Estoque;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Domain.Services.Estoque
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

        public void AtualizarEstoque(int IDProduto, TipoMovimentoEstoqueEnum Tipo, int Qtde)
        {
            EstoqueEN estoqueEN = _repositoryEstoque.GetByID(IDProduto);

            if (estoqueEN != null)
            {
                int _qtde = estoqueEN.Qtde;

                if (Tipo == TipoMovimentoEstoqueEnum.Entrada)
                    _qtde += Qtde;
                else
                    _qtde -= Qtde;

                estoqueEN.UpdateProperties
                    (
                        IDProduto,
                        _qtde
                    );

                _repositoryEstoque.Edit(estoqueEN);
            }
            else
            {
                estoqueEN = new EstoqueEN
                    (
                        IDProduto,
                        Qtde
                    );

                _repositoryEstoque.Save(estoqueEN);
            }
        }
    }
}
