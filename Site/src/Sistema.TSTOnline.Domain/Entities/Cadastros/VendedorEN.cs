using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.Cadastros
{
    public class VendedorEN
    {
        [Key]
        public int IDVendedor { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        private VendedorEN() { }

        public VendedorEN (string Nome, string CPF, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF) 
        {
            ValidateAndSetProperties(Nome, CPF, Endereco, Numero, Complemento, Bairro, Cidade, UF);
        }

        public void UpdateProperties (string Nome, string CPF, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF) 
        {
            ValidateAndSetProperties(Nome, CPF, Endereco, Numero, Complemento, Bairro, Cidade, UF);
        }

        private void ValidateAndSetProperties (string Nome, string CPF, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF) 
        {
            DomainException.When(string.IsNullOrEmpty(Nome), "Nome não informado.");
            DomainException.When(string.IsNullOrEmpty(CPF), "CPF não informado.");
            DomainException.When(string.IsNullOrEmpty(Endereco), "Endereço não informado.");
            DomainException.When(string.IsNullOrEmpty(Numero), "Número não informado.");
            DomainException.When(string.IsNullOrEmpty(Bairro), "Bairro não informado.");
            DomainException.When(string.IsNullOrEmpty(Cidade), "Cidade não informada.");
            DomainException.When(string.IsNullOrEmpty(UF), "UF não informada.");

            this.Nome = Nome;
            this.CPF = CPF;
            this.Endereco = Endereco;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.UF = UF;
        }
    }
}