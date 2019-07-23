using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.OrdemServico
{
    public class LocalServicoEN
    {
        [Key]
        public int IDLocal { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        private LocalServicoEN() { }

        public LocalServicoEN(string Nome, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF) 
        {
            ValidateAndSetProperties(Nome, Endereco, Numero, Complemento, Bairro, Cidade, UF);
        }

        public void UpdateProperties (string Nome, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF) 
        {
            ValidateAndSetProperties(Nome, Endereco, Numero, Complemento, Bairro, Cidade, UF);
        }

        private void ValidateAndSetProperties (string Nome, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF) 
        {
            DomainException.When(string.IsNullOrEmpty(Nome), "Nome não informado.");
            DomainException.When(string.IsNullOrEmpty(Endereco), "Endereço não informado.");
            DomainException.When(string.IsNullOrEmpty(Numero), "Número não informado.");
            DomainException.When(string.IsNullOrEmpty(Bairro), "Bairro não informado.");
            DomainException.When(string.IsNullOrEmpty(Cidade), "Cidade não informada.");
            DomainException.When(string.IsNullOrEmpty(UF), "UF não informada.");

            this.Nome = Nome;
            this.Endereco = Endereco;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.UF = UF;
        }
    }
}