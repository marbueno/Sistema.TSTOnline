using Sistema.Documentos.Interface;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
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

        public OrdemServicoBU
            (
                IRepository<OrdemServicoEN> repositoryOrdemServico, 
                IDocumento documentoService, 
                IRepository<ResponsavelEN> responsavelRepository,
                IRepository<EmpresaEN> empresaRepository,
                IUnitOfWork unitOfWork
            )
        {
            _repositoryOrdemServico = repositoryOrdemServico;
            _unitOfWork = unitOfWork;
        }

        public int Save(int IDOrdemServico, int IDCompany, int IDUser, DateTime DataServico, OrdemServicoStatusEnum Status, int IDEmpresa, int IDResp, int IDLocal, string NomeContato, string Telefone, string WhatsApp)
        {
            OrdemServicoEN ordemServicoEN = _repositoryOrdemServico.GetByID(IDOrdemServico);

            if (ordemServicoEN != null)
            {
                ordemServicoEN.UpdateProperties
                    (
                        IDCompany,
                        IDUser,
                        DataServico,
                        Status,
                        IDEmpresa,
                        IDResp,
                        IDLocal,
                        NomeContato, 
                        Telefone, 
                        WhatsApp
                    );

                _repositoryOrdemServico.Edit(ordemServicoEN);
            }
            else
            {
                ordemServicoEN = new OrdemServicoEN
                    (
                        IDCompany,
                        IDUser,
                        DataServico,
                        Status,
                        IDEmpresa,
                        IDResp,
                        IDLocal,
                        NomeContato,
                        Telefone,
                        WhatsApp
                    );
                ordemServicoEN.DataCadastro = DateTime.Now.ToLocalTime();

                _repositoryOrdemServico.Save(ordemServicoEN);
            }

            _unitOfWork.Commit();

            return ordemServicoEN.IDOrdemServico;
        }

        public void UpdateStatus(int IDOrdemServico, OrdemServicoStatusEnum Status)
        {
            OrdemServicoEN ordemServicoEN = _repositoryOrdemServico.GetByID(IDOrdemServico);

            ordemServicoEN.Status = Status;

            _repositoryOrdemServico.Edit(ordemServicoEN);

            _unitOfWork.Commit();
        }
    }
}
