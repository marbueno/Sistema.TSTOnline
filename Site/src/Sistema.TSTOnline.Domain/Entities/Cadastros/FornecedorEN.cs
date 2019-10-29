using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{
    public class FornecedorEN
    {
        [Key]
        public int IDFornecedor { get; set; }
        public int IDUser { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }

        private FornecedorEN() { }

        public FornecedorEN (int IDUser, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp) 
        {
            ValidateAndSetProperties(IDUser, CNPJ, RazaoSocial, NomeFantasia, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);
        }

        public void UpdateProperties (int IDUser, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp)
        {
            ValidateAndSetProperties(IDUser, CNPJ, RazaoSocial, NomeFantasia, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);
        }

        private void ValidateAndSetProperties (int IDUser, string CNPJ, string RazaoSocial, string NomeFantasia, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp)
        {
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

            this.IDUser = IDUser;
            this.CNPJ = CNPJ;
            this.RazaoSocial = RazaoSocial;
            this.NomeFantasia = NomeFantasia;
            this.CEP = CEP;
            this.Endereco = Endereco;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.UF = UF;
            this.NomeContato = NomeContato;
            this.Telefone = Telefone;
            this.WhatsApp = WhatsApp;
        }
    }
}