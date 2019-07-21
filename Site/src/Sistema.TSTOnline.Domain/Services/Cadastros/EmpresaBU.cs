using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Interfaces;
using System;

namespace Sistema.Competicao.Domain.Services.Cadastros
{
    public class EmpresaBU
    {
        private readonly IRepository<EmpresaEN> _empresaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmpresaBU(IRepository<EmpresaEN> empresaRepository, IUnitOfWork unitOfWork)
        {
            _empresaRepository = empresaRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save
            (
                int IDEmpresa,
                string StatusEmpresa,
                string Situacao,
                int IDUser,
                string NomeContato,
                string CPFContato,
                string TelContato,
                string NomeRespEmpresa,
                string CPFResponsavel,
                string TelResponsavel,
                string NITResponsavel,
                string EmailResponsavel,
                int CodEmpresa,
                int IDCompany,
                string RazaoSocial,
                string NomeFantasia,
                string TipoMatricula,
                string NRMatricula,
                string InscEstadual,
                string CodNatJurid,
                string NatJuridica,
                string DescNatJurid,
                string CNAE,
                string CNAEDesc,
                string CEP,
                string UF,
                string Cidade,
                string Bairro,
                string Endereco,
                string Numero,
                string Complemento,
                string Telefone,
                string Celular,
                string Email,
                string QtdEmpregados,
                string Cipa,
                string Observacoes,
                string HorarioDeTrabalho,
                string IDRiscoEmp,
                DateTime DataCad,
                int StatusPCMSO,
                int ResponsavelPCMSO,
                int IDPCMSO,
                string EstabeTerceiro,
                string CnpjTerceiro,
                string NomeTerceiro,
                string EmailTerceiro,
                string TelefoneTerceiro,
                string CelularTerceiro,
                string UFTerceiro,
                string CidadeTerceiro,
                string EnderecoTerceiro,
                string BairroTerceiro,
                string CEPTerceiro,
                string NumeroTerceiro,
                string ComplementoTerceiro
            )
        {
            EmpresaEN empresaEN = _empresaRepository.GetByID(IDEmpresa);

            if (empresaEN != null)
            {
                empresaEN.UpdateProperties
                    (
                        StatusEmpresa,
                        Situacao,
                        IDUser,
                        NomeContato,
                        CPFContato,
                        TelContato,
                        NomeRespEmpresa,
                        CPFResponsavel,
                        TelResponsavel,
                        NITResponsavel,
                        EmailResponsavel,
                        CodEmpresa,
                        IDCompany,
                        RazaoSocial,
                        NomeFantasia,
                        TipoMatricula,
                        NRMatricula,
                        InscEstadual,
                        CodNatJurid,
                        NatJuridica,
                        DescNatJurid,
                        CNAE,
                        CNAEDesc,
                        CEP,
                        UF,
                        Cidade,
                        Bairro,
                        Endereco,
                        Numero,
                        Complemento,
                        Telefone,
                        Celular,
                        Email,
                        QtdEmpregados,
                        Cipa,
                        Observacoes,
                        HorarioDeTrabalho,
                        IDRiscoEmp,
                        DataCad,
                        StatusPCMSO,
                        ResponsavelPCMSO,
                        IDPCMSO,
                        EstabeTerceiro,
                        CnpjTerceiro,
                        NomeTerceiro,
                        EmailTerceiro,
                        TelefoneTerceiro,
                        CelularTerceiro,
                        UFTerceiro,
                        CidadeTerceiro,
                        EnderecoTerceiro,
                        BairroTerceiro,
                        CEPTerceiro,
                        NumeroTerceiro,
                        ComplementoTerceiro
                    );

                _empresaRepository.Edit(empresaEN);
            }
            else
            {
                empresaEN = new EmpresaEN
                    (
                        StatusEmpresa,
                        Situacao,
                        IDUser,
                        NomeContato,
                        CPFContato,
                        TelContato,
                        NomeRespEmpresa,
                        CPFResponsavel,
                        TelResponsavel,
                        NITResponsavel,
                        EmailResponsavel,
                        CodEmpresa,
                        IDCompany,
                        RazaoSocial,
                        NomeFantasia,
                        TipoMatricula,
                        NRMatricula,
                        InscEstadual,
                        CodNatJurid,
                        NatJuridica,
                        DescNatJurid,
                        CNAE,
                        CNAEDesc,
                        CEP,
                        UF,
                        Cidade,
                        Bairro,
                        Endereco,
                        Numero,
                        Complemento,
                        Telefone,
                        Celular,
                        Email,
                        QtdEmpregados,
                        Cipa,
                        Observacoes,
                        HorarioDeTrabalho,
                        IDRiscoEmp,
                        DataCad,
                        StatusPCMSO,
                        ResponsavelPCMSO,
                        IDPCMSO,
                        EstabeTerceiro,
                        CnpjTerceiro,
                        NomeTerceiro,
                        EmailTerceiro,
                        TelefoneTerceiro,
                        CelularTerceiro,
                        UFTerceiro,
                        CidadeTerceiro,
                        EnderecoTerceiro,
                        BairroTerceiro,
                        CEPTerceiro,
                        NumeroTerceiro,
                        ComplementoTerceiro
                    );

                _empresaRepository.Save(empresaEN);
            }

            _unitOfWork.Commit();
        }
    }
}