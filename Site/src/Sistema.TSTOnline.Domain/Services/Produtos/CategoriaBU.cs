using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;

namespace Sistema.TSTOnline.Domain.Services.Produtos
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

        public void Save(int IDCategoria, int IDUser, string Descricao)
        {
            CategoriaEN categoriaEN = _repositoryCategoria.GetByID(IDCategoria);

            if (categoriaEN != null)
            {
                categoriaEN.UpdateProperties
                    (
                        IDUser,
                        Descricao
                    );

                _repositoryCategoria.Edit(categoriaEN);
            }
            else
            {
                categoriaEN = new CategoriaEN
                    (
                        IDUser,
                        Descricao
                    );

                _repositoryCategoria.Save(categoriaEN);
            }

            _unitOfWork.Commit();
        }
    }
}
