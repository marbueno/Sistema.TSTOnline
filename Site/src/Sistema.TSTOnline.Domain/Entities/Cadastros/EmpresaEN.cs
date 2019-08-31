using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{    
    public class EmpresaEN
    {
        #region Properties

        [Key]
        public int IDEmpresa { get; set; }
        //public string StatusEmpresa { get; set; }
        //public string Situacao { get; set; }
        //public int IDUser { get; set; }
        //public string NomeContato { get; set; }
        //public string CPFContato { get; set; }
        //public string TelContato { get; set; }
        //public string NomeRespEmpresa { get; set; }
        //public string CPFResponsavel { get; set; }
        //public string TelResponsavel { get; set; }
        //public string NITResponsavel { get; set; }
        //public string EmailResponsavel { get; set; }
        //public int CodEmpresa { get; set; }
        //public int IDCompany { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        //public string TipoMatricula { get; set; }
        //public string NRMatricula { get; set; }
        //public string InscEstadual { get; set; }
        //public string CodNatJurid { get; set; }
        //public string NatJuridica { get; set; }
        //public string DescNatJurid { get; set; }
        //public string CNAE { get; set; }
        //public string CNAEDesc { get; set; }
        //public string CEP { get; set; }
        //public string UF { get; set; }
        //public string Cidade { get; set; }
        //public string Bairro { get; set; }
        //public string Endereco { get; set; }
        //public string Numero { get; set; }
        //public string Complemento { get; set; }
        //public string Telefone { get; set; }
        //public string Celular { get; set; }
        //public string Email { get; set; }
        //public string QtdEmpregados { get; set; }
        //public string Cipa { get; set; }
        //public string Observacoes { get; set; }
        //public string HorarioDeTrabalho { get; set; }
        //public string IDRiscoEmp { get; set; }
        //public DateTime DataCad { get; set; }
        //public int StatusPCMSO { get; set; }
        //public int ResponsavelPCMSO { get; set; }
        //public int IDPCMSO { get; set; }
        //public string EstabeTerceiro { get; set; }
        //public string CnpjTerceiro { get; set; }
        //public string NomeTerceiro { get; set; }
        //public string EmailTerceiro { get; set; }
        //public string TelefoneTerceiro { get; set; }
        //public string CelularTerceiro { get; set; }
        //public string UFTerceiro { get; set; }
        //public string CidadeTerceiro { get; set; }
        //public string EnderecoTerceiro { get; set; }
        //public string BairroTerceiro { get; set; }
        //public string CEPTerceiro { get; set; }
        //public string NumeroTerceiro { get; set; }
        //public string ComplementoTerceiro { get; set; }

        #endregion Properties

        #region Constructor

        public EmpresaEN()
        {
            //DataCad = DateTime.Now;
        }

        #endregion Constructor

        #region Methods

        //public EmpresaEN
        //    (
        //        string StatusEmpresa,
        //        string Situacao,
        //        int IDUser,
        //        string NomeContato,
        //        string CPFContato,
        //        string TelContato,
        //        string NomeRespEmpresa,
        //        string CPFResponsavel,
        //        string TelResponsavel,
        //        string NITResponsavel,
        //        string EmailResponsavel,
        //        int CodEmpresa,
        //        int IDCompany,
        //        string RazaoSocial,
        //        string NomeFantasia,
        //        string TipoMatricula,
        //        string NRMatricula,
        //        string InscEstadual,
        //        string CodNatJurid,
        //        string NatJuridica,
        //        string DescNatJurid,
        //        string CNAE,
        //        string CNAEDesc,
        //        string CEP,
        //        string UF,
        //        string Cidade,
        //        string Bairro,
        //        string Endereco,
        //        string Numero,
        //        string Complemento,
        //        string Telefone,
        //        string Celular,
        //        string Email,
        //        string QtdEmpregados,
        //        string Cipa,
        //        string Observacoes,
        //        string HorarioDeTrabalho,
        //        string IDRiscoEmp,
        //        DateTime DataCad,
        //        int StatusPCMSO,
        //        int ResponsavelPCMSO,
        //        int IDPCMSO,
        //        string EstabeTerceiro,
        //        string CnpjTerceiro,
        //        string NomeTerceiro,
        //        string EmailTerceiro,
        //        string TelefoneTerceiro,
        //        string CelularTerceiro,
        //        string UFTerceiro,
        //        string CidadeTerceiro,
        //        string EnderecoTerceiro,
        //        string BairroTerceiro,
        //        string CEPTerceiro,
        //        string NumeroTerceiro,
        //        string ComplementoTerceiro
        //    )
        //{
        //    ValidateAndSetProperties
        //        (
        //            StatusEmpresa,
        //            Situacao,
        //            IDUser,
        //            NomeContato,
        //            CPFContato,
        //            TelContato,
        //            NomeRespEmpresa,
        //            CPFResponsavel,
        //            TelResponsavel,
        //            NITResponsavel,
        //            EmailResponsavel,
        //            CodEmpresa,
        //            IDCompany,
        //            RazaoSocial,
        //            NomeFantasia,
        //            TipoMatricula,
        //            NRMatricula,
        //            InscEstadual,
        //            CodNatJurid,
        //            NatJuridica,
        //            DescNatJurid,
        //            CNAE,
        //            CNAEDesc,
        //            CEP,
        //            UF,
        //            Cidade,
        //            Bairro,
        //            Endereco,
        //            Numero,
        //            Complemento,
        //            Telefone,
        //            Celular,
        //            Email,
        //            QtdEmpregados,
        //            Cipa,
        //            Observacoes,
        //            HorarioDeTrabalho,
        //            IDRiscoEmp,
        //            DataCad,
        //            StatusPCMSO,
        //            ResponsavelPCMSO,
        //            IDPCMSO,
        //            EstabeTerceiro,
        //            CnpjTerceiro,
        //            NomeTerceiro,
        //            EmailTerceiro,
        //            TelefoneTerceiro,
        //            CelularTerceiro,
        //            UFTerceiro,
        //            CidadeTerceiro,
        //            EnderecoTerceiro,
        //            BairroTerceiro,
        //            CEPTerceiro,
        //            NumeroTerceiro,
        //            ComplementoTerceiro
        //        );
        //}

        //public void UpdateProperties
        //    (
        //        string StatusEmpresa,
        //        string Situacao,
        //        int IDUser,
        //        string NomeContato,
        //        string CPFContato,
        //        string TelContato,
        //        string NomeRespEmpresa,
        //        string CPFResponsavel,
        //        string TelResponsavel,
        //        string NITResponsavel,
        //        string EmailResponsavel,
        //        int CodEmpresa,
        //        int IDCompany,
        //        string RazaoSocial,
        //        string NomeFantasia,
        //        string TipoMatricula,
        //        string NRMatricula,
        //        string InscEstadual,
        //        string CodNatJurid,
        //        string NatJuridica,
        //        string DescNatJurid,
        //        string CNAE,
        //        string CNAEDesc,
        //        string CEP,
        //        string UF,
        //        string Cidade,
        //        string Bairro,
        //        string Endereco,
        //        string Numero,
        //        string Complemento,
        //        string Telefone,
        //        string Celular,
        //        string Email,
        //        string QtdEmpregados,
        //        string Cipa,
        //        string Observacoes,
        //        string HorarioDeTrabalho,
        //        string IDRiscoEmp,
        //        DateTime DataCad,
        //        int StatusPCMSO,
        //        int ResponsavelPCMSO,
        //        int IDPCMSO,
        //        string EstabeTerceiro,
        //        string CnpjTerceiro,
        //        string NomeTerceiro,
        //        string EmailTerceiro,
        //        string TelefoneTerceiro,
        //        string CelularTerceiro,
        //        string UFTerceiro,
        //        string CidadeTerceiro,
        //        string EnderecoTerceiro,
        //        string BairroTerceiro,
        //        string CEPTerceiro,
        //        string NumeroTerceiro,
        //        string ComplementoTerceiro
        //    )
        //{
        //    ValidateAndSetProperties
        //        (
        //            StatusEmpresa,
        //            Situacao,
        //            IDUser,
        //            NomeContato,
        //            CPFContato,
        //            TelContato,
        //            NomeRespEmpresa,
        //            CPFResponsavel,
        //            TelResponsavel,
        //            NITResponsavel,
        //            EmailResponsavel,
        //            CodEmpresa,
        //            IDCompany,
        //            RazaoSocial,
        //            NomeFantasia,
        //            TipoMatricula,
        //            NRMatricula,
        //            InscEstadual,
        //            CodNatJurid,
        //            NatJuridica,
        //            DescNatJurid,
        //            CNAE,
        //            CNAEDesc,
        //            CEP,
        //            UF,
        //            Cidade,
        //            Bairro,
        //            Endereco,
        //            Numero,
        //            Complemento,
        //            Telefone,
        //            Celular,
        //            Email,
        //            QtdEmpregados,
        //            Cipa,
        //            Observacoes,
        //            HorarioDeTrabalho,
        //            IDRiscoEmp,
        //            DataCad,
        //            StatusPCMSO,
        //            ResponsavelPCMSO,
        //            IDPCMSO,
        //            EstabeTerceiro,
        //            CnpjTerceiro,
        //            NomeTerceiro,
        //            EmailTerceiro,
        //            TelefoneTerceiro,
        //            CelularTerceiro,
        //            UFTerceiro,
        //            CidadeTerceiro,
        //            EnderecoTerceiro,
        //            BairroTerceiro,
        //            CEPTerceiro,
        //            NumeroTerceiro,
        //            ComplementoTerceiro
        //        );
        //}

        //private void ValidateAndSetProperties
        //    (

        //        string StatusEmpresa,
        //        string Situacao,
        //        int IDUser,
        //        string NomeContato,
        //        string CPFContato,
        //        string TelContato,
        //        string NomeRespEmpresa,
        //        string CPFResponsavel,
        //        string TelResponsavel,
        //        string NITResponsavel,
        //        string EmailResponsavel,
        //        int CodEmpresa,
        //        int IDCompany,
        //        string RazaoSocial,
        //        string NomeFantasia,
        //        string TipoMatricula,
        //        string NRMatricula,
        //        string InscEstadual,
        //        string CodNatJurid,
        //        string NatJuridica,
        //        string DescNatJurid,
        //        string CNAE,
        //        string CNAEDesc,
        //        string CEP,
        //        string UF,
        //        string Cidade,
        //        string Bairro,
        //        string Endereco,
        //        string Numero,
        //        string Complemento,
        //        string Telefone,
        //        string Celular,
        //        string Email,
        //        string QtdEmpregados,
        //        string Cipa,
        //        string Observacoes,
        //        string HorarioDeTrabalho,
        //        string IDRiscoEmp,
        //        DateTime DataCad,
        //        int StatusPCMSO,
        //        int ResponsavelPCMSO,
        //        int IDPCMSO,
        //        string EstabeTerceiro,
        //        string CnpjTerceiro,
        //        string NomeTerceiro,
        //        string EmailTerceiro,
        //        string TelefoneTerceiro,
        //        string CelularTerceiro,
        //        string UFTerceiro,
        //        string CidadeTerceiro,
        //        string EnderecoTerceiro,
        //        string BairroTerceiro,
        //        string CEPTerceiro,
        //        string NumeroTerceiro,
        //        string ComplementoTerceiro
        //    )
        //{
        //    DomainException.When(string.IsNullOrEmpty(RazaoSocial), "Razão Social não informada.");
        //    DomainException.When(string.IsNullOrEmpty(NomeFantasia), "Nome Fantasia não informada.");
        //    DomainException.When(string.IsNullOrEmpty(NomeRespEmpresa), "Nome do Responsável da Empresa não informado.");
        //    DomainException.When(string.IsNullOrEmpty(CPFResponsavel), "CPF do Responsável da Empresa não informado.");
        //    DomainException.When(string.IsNullOrEmpty(TelResponsavel), "Telefone do Responsável da Empresa não informado.");
        //    DomainException.When(string.IsNullOrEmpty(EmailResponsavel), "E-mail do Responsável da Empresa não informado.");
        //    DomainException.When(string.IsNullOrEmpty(CEP), "CEP não informado.");
        //    DomainException.When(string.IsNullOrEmpty(UF), "UF não informado.");
        //    DomainException.When(string.IsNullOrEmpty(Cidade), "Cidade não informado.");
        //    DomainException.When(string.IsNullOrEmpty(Bairro), "Bairro não informado.");
        //    DomainException.When(string.IsNullOrEmpty(Endereco), "Endereço não informado.");
        //    DomainException.When(string.IsNullOrEmpty(Numero), "Número não informado.");

        //    this.StatusEmpresa = StatusEmpresa;
        //    this.Situacao = Situacao;
        //    this.IDUser = IDUser;
        //    this.NomeContato = NomeContato;
        //    this.CPFContato = CPFContato;
        //    this.TelContato = TelContato;
        //    this.NomeRespEmpresa = NomeRespEmpresa;
        //    this.CPFResponsavel = CPFResponsavel;
        //    this.TelResponsavel = TelResponsavel;
        //    this.NITResponsavel = NITResponsavel;
        //    this.EmailResponsavel = EmailResponsavel;
        //    this.CodEmpresa = CodEmpresa;
        //    this.IDCompany = IDCompany;
        //    this.RazaoSocial = RazaoSocial;
        //    this.NomeFantasia = NomeFantasia;
        //    this.TipoMatricula = TipoMatricula;
        //    this.NRMatricula = NRMatricula;
        //    this.InscEstadual = InscEstadual;
        //    this.CodNatJurid = CodNatJurid;
        //    this.NatJuridica = NatJuridica;
        //    this.DescNatJurid = DescNatJurid;
        //    this.CNAE = CNAE;
        //    this.CNAEDesc = CNAEDesc;
        //    this.CEP = CEP;
        //    this.UF = UF;
        //    this.Cidade = Cidade;
        //    this.Bairro = Bairro;
        //    this.Endereco = Endereco;
        //    this.Numero = Numero;
        //    this.Complemento = Complemento;
        //    this.Telefone = Telefone;
        //    this.Celular = Celular;
        //    this.Email = Email;
        //    this.QtdEmpregados = QtdEmpregados;
        //    this.Cipa = Cipa;
        //    this.Observacoes = Observacoes;
        //    this.HorarioDeTrabalho = HorarioDeTrabalho;
        //    this.IDRiscoEmp = IDRiscoEmp;
        //    this.DataCad = DataCad;
        //    this.StatusPCMSO = StatusPCMSO;
        //    this.ResponsavelPCMSO = ResponsavelPCMSO;
        //    this.IDPCMSO = IDPCMSO;
        //    this.EstabeTerceiro = EstabeTerceiro;
        //    this.CnpjTerceiro = CnpjTerceiro;
        //    this.NomeTerceiro = NomeTerceiro;
        //    this.EmailTerceiro = EmailTerceiro;
        //    this.TelefoneTerceiro = TelefoneTerceiro;
        //    this.CelularTerceiro = CelularTerceiro;
        //    this.UFTerceiro = UFTerceiro;
        //    this.CidadeTerceiro = CidadeTerceiro;
        //    this.EnderecoTerceiro = EnderecoTerceiro;
        //    this.BairroTerceiro = BairroTerceiro;
        //    this.CEPTerceiro = CEPTerceiro;
        //    this.NumeroTerceiro = NumeroTerceiro;
        //    this.ComplementoTerceiro = ComplementoTerceiro;
        //}

        #endregion Methods
    }
}