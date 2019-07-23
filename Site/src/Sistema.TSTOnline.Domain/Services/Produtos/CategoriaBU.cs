using Sistema.Competicao.Domain.Entities.Produtos;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.Produtos
{
    public class CategoriaBU
    {
        private readonly IRepository<CategoriaEN> _repositoryCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaBU(IRepository<CategoriaEN> repositoryCategoria, IUnitOfWork unitOfWork)
        {
            _repositoryCategoria = repositoryCategoria;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDCategoria, string Descricao)
        {
            CategoriaEN categoriaEN = _repositoryCategoria.GetByID(IDCategoria);

            if (categoriaEN != null)
            {
                categoriaEN.UpdateProperties
                    (
                        Descricao
                    );

                _repositoryCategoria.Edit(categoriaEN);
            }
            else
            {
                categoriaEN = new CategoriaEN
                    (
                        Descricao
                    );

                _repositoryCategoria.Save(categoriaEN);
            }

            _unitOfWork.Commit();
        }
    }
}
