using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.OrdemServico
{
    public class LocalServicoEN
    {
        [Key]
        public int IDLocal { get; set; }
        public string Nome { get; set; }
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

        private LocalServicoEN() { }

        public LocalServicoEN(string Nome, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp) 
        {
            ValidateAndSetProperties(Nome, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);
        }

        public void UpdateProperties (string Nome, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp) 
        {
            ValidateAndSetProperties(Nome, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, NomeContato, Telefone, WhatsApp);
        }

        private void ValidateAndSetProperties (string Nome, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, string NomeContato, string Telefone, string WhatsApp) 
        {
            DomainException.When(string.IsNullOrEmpty(Nome), "Nome não informado.");
            DomainException.When(string.IsNullOrEmpty(CEP), "CEP não informado.");
            DomainException.When(string.IsNullOrEmpty(Endereco), "Endereço não informado.");
            DomainException.When(string.IsNullOrEmpty(Numero), "Número não informado.");
            DomainException.When(string.IsNullOrEmpty(Bairro), "Bairro não informado.");
            DomainException.When(string.IsNullOrEmpty(Cidade), "Cidade não informada.");
            DomainException.When(string.IsNullOrEmpty(UF), "UF não informada.");

            this.Nome = Nome;
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