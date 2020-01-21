using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{    
    public class EmpresaEN
    {
        #region Properties

        [Key]
        public int IDEmpresa { get; set; }
        public int IDUser { get; set; }
        public int IDCompany { get; set; }
        public string StatusEmpresa { get; set; }
        public string NrMatricula { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public string NomeContato { get; set; }
        public string CPFContato { get; set; }
        public string TelContato { get; set; }
        public string TipoEmp { get; set; }
        public string NomeRespEmpresa { get; set; }
        public string CPFResponsavel { get; set; }
        public string TelResponsavel { get; set; }
        public string NitResponsavel { get; set; }
        public string EmailResponsavel { get; set; }
        public string DescNatJurid { get; set; }
        public string CnaeDesc { get; set; }

        #endregion Properties

        #region Constructor

        public EmpresaEN() { }

        public EmpresaEN(int IDCompany, int IDUser, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string Telefone, string Celular)
        {
            ValidateAndSetProperties(IDCompany, IDUser, CNPJ, RazaoSocial, NomeFantasia, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, Telefone, Celular);
        }

        public void UpdateProperties(int IDCompany, int IDUser, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string Telefone, string Celular)
        {
            ValidateAndSetProperties(IDCompany, IDUser, CNPJ, RazaoSocial, NomeFantasia, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, Telefone, Celular);
        }

        private void ValidateAndSetProperties(int IDCompany, int IDUser, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string Telefone, string Celular)
        {
            DomainException.When(IDCompany == 0, "Compania não informada.");
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(CNPJ), "CNPJ não informado.");
            DomainException.When(string.IsNullOrEmpty(RazaoSocial), "Razão Social não informada.");
            DomainException.When(string.IsNullOrEmpty(NomeFantasia), "Nome Fantasia não informada.");
            DomainException.When(string.IsNullOrEmpty(CEP), "CEP não informado.");
            DomainException.When(string.IsNullOrEmpty(Endereco), "Endereço não informado.");
            DomainException.When(string.IsNullOrEmpty(Numero), "Número não informado.");
            DomainException.When(string.IsNullOrEmpty(Bairro), "Bairro não informado.");
            DomainException.When(string.IsNullOrEmpty(Cidade), "Cidade não informada.");
            DomainException.When(string.IsNullOrEmpty(UF), "UF não informada.");

            this.IDCompany = IDCompany;
            this.IDUser = IDUser;
            this.StatusEmpresa = "a";
            this.NrMatricula = CNPJ;
            this.RazaoSocial = RazaoSocial;
            this.NomeFantasia = NomeFantasia;
            this.Cep = CEP;
            this.Endereco = Endereco;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.UF = UF;
            this.Telefone = Telefone;
            this.Celular = Celular;
            this.NomeContato = "";
            this.CPFContato = "";
            this.TelContato = "";
            this.TipoEmp = "";
            this.NomeRespEmpresa = "";
            this.CPFResponsavel = "";
            this.TelResponsavel = "";
            this.NitResponsavel = "";
            this.EmailResponsavel = "";
            this.DescNatJurid = "";
            this.CnaeDesc = "";
    }

        #endregion Constructor
    }
}