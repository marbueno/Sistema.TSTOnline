using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Interfaces;

namespace Sistema.TSTOnline.Domain.Services.Produtos
{
    public class SubCategoriaBU
    {
        private readonly IRepository<SubCategoriaEN> _repositorySubCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoriaBU(IRepository<SubCategoriaEN> repositorySubCategoria, IUnitOfWork unitOfWork)
        {
            _repositorySubCategoria = repositorySubCategoria;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDSubCategoria, int IDUser, int IDCategoria, string Descricao)
        {
            SubCategoriaEN subCategoriaEN = _repositorySubCategoria.GetByID(IDSubCategoria);

            if (subCategoriaEN != null)
            {
                subCategoriaEN.UpdateProperties
                    (
                        IDUser,
                        IDCategoria,
                        Descricao
                    );

                _repositorySubCategoria.Edit(subCategoriaEN);
            }
            else
            {
                subCategoriaEN = new SubCategoriaEN
                    (
                        IDUser,
                        IDCategoria,
                        Descricao
                    );

                _repositorySubCategoria.Save(subCategoriaEN);
            }

            _unitOfWork.Commit();
        }
    }
}
