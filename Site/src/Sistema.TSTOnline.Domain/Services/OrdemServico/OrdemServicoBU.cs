using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Services.OrdemServico
{
    public class OrdemServicoBU
    {
        private readonly IRepository<OrdemServicoEN> _repositoryOrdemServico;
        private readonly IUnitOfWork _unitOfWork;

        public OrdemServicoBU(IRepository<OrdemServicoEN> repositoryOrdemServico, IUnitOfWork unitOfWork)
        {
            _repositoryOrdemServico = repositoryOrdemServico;
            _unitOfWork = unitOfWork;
        }

        public void Save(int IDOrdemServico, DateTime DataServico, OrdemServicoStatusEnum Status, int IDResp, int IDLocal)
        {
            OrdemServicoEN ordemServicoEN = _repositoryOrdemServico.GetByID(IDOrdemServico);

            if (ordemServicoEN != null)
            {
                ordemServicoEN.UpdateProperties
                    (
                        DataServico,
                        Status,
                        IDResp,
                        IDLocal
                    );

                _repositoryOrdemServico.Edit(ordemServicoEN);
            }
            else
            {
                ordemServicoEN = new OrdemServicoEN
                    (
                        DataServico,
                        Status,
                        IDResp,
                        IDLocal
                    );

                _repositoryOrdemServico.Save(ordemServicoEN);
            }

            _unitOfWork.Commit();
        }

        public void UpdateStatus(int IDOrdemServico, OrdemServicoStatusEnum Status)
        {
            OrdemServicoEN ordemServicoEN = _repositoryOrdemServico.GetByID(IDOrdemServico);

            ordemServicoEN.Status = Status;

            _repositoryOrdemServico.Edit(ordemServicoEN);
        }
    }
}
