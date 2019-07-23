using Sistema.Competicao.Domain.Entities.OrdemServico;
using Sistema.Competicao.Domain.Interfaces;

namespace Sistema.Competicao.Domain.Services.OrdemServico
{
    public class OrdemServicoItemBU
    {
        private readonly IRepository<OrdemServicoItemEN> _repositoryOrdemServicoItem;
        private readonly IUnitOfWork _unitOfWork;

        public OrdemServicoItemBU(IRepository<OrdemServicoItemEN> repositoryOrdemServicoItem, IUnitOfWork unitOfWork)
        {
            _repositoryOrdemServicoItem = repositoryOrdemServicoItem;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDOrdemServicoItem, int IDOrdemServico, int Item, int IDServico)
        {
            OrdemServicoItemEN ordemServicoItemEN = _repositoryOrdemServicoItem.GetByID(IDOrdemServicoItem);

            if (ordemServicoItemEN != null)
            {
                ordemServicoItemEN.UpdateProperties
                    (
                        IDOrdemServico,
                        Item,
                        IDServico
                    );

                _repositoryOrdemServicoItem.Edit(ordemServicoItemEN);
            }
            else
            {
                ordemServicoItemEN = new OrdemServicoItemEN
                    (
                        IDOrdemServico,
                        Item,
                        IDServico
                    );

                _repositoryOrdemServicoItem.Save(ordemServicoItemEN);
            }

            _unitOfWork.Commit();
        }
    }
}
