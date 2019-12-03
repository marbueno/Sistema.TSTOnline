using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.TSTOnline.Domain.Entities.Cadastros
{
    public class VendedorEN
    {
        [Key]
        public int IDVendedor { get; set; }
        public int IDUser { get; set; }
        public int IDCompany { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int IDEmpresa { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public string WhatsApp { get; set; }
        public string Observacao { get; set; }

        private VendedorEN() { }

        public VendedorEN (int IDCompany, int IDUser, string Nome, string RG, string CPF, DateTime DataNascimento, string Email, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, int IDEmpresa, string NomeContato, string Telefone, string WhatsApp, string Observacao) 
        {
            ValidateAndSetProperties(IDCompany, IDUser, Nome, RG, CPF, DataNascimento, Email, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, IDEmpresa, NomeContato, Telefone, WhatsApp, Observacao);
        }

        public void UpdateProperties (int IDCompany, int IDUser, string Nome, string RG, string CPF, DateTime DataNascimento, string Email, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, int IDEmpresa, string NomeContato, string Telefone, string WhatsApp, string Observacao)
        {
            ValidateAndSetProperties(IDCompany, IDUser, Nome, RG, CPF, DataNascimento, Email, CEP, Endereco, Numero, Complemento, Bairro, Cidade, UF, IDEmpresa, NomeContato, Telefone, WhatsApp, Observacao);
        }

        private void ValidateAndSetProperties (int IDCompany, int IDUser, string Nome, string RG, string CPF, DateTime DataNascimento, string Email, string CEP, string Endereco, string Numero, string Complemento, string Bairro, string Cidade, string UF, int IDEmpresa, string NomeContato, string Telefone, string WhatsApp, string Observacao)
        {
            DomainException.When(IDCompany == 0, "Compania não informada.");
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(string.IsNullOrEmpty(Nome), "Nome não informado.");
            DomainException.When(string.IsNullOrEmpty(RG), "RG não informado.");
            DomainException.When(string.IsNullOrEmpty(CPF), "CPF não informado.");
            DomainException.When(string.IsNullOrEmpty(Email), "E-mail não informado.");
            DomainException.When(IDEmpresa == 0, "Empresa não informada.");
            //DomainException.When(string.IsNullOrEmpty(CEP), "CEP não informado.");
            //DomainException.When(string.IsNullOrEmpty(Endereco), "Endereço não informado.");
            //DomainException.When(string.IsNullOrEmpty(Numero), "Número não informado.");
            //DomainException.When(string.IsNullOrEmpty(Bairro), "Bairro não informado.");
            //DomainException.When(string.IsNullOrEmpty(Cidade), "Cidade não informada.");
            //DomainException.When(string.IsNullOrEmpty(UF), "UF não informada.");

            this.IDCompany = IDCompany;
            this.IDUser = IDUser;
            this.Nome = Nome;
            this.RG = RG;
            this.CPF = CPF;
            this.DataNascimento = DataNascimento;
            this.Email = Email;
            this.CEP = CEP;
            this.Endereco = Endereco;
            this.Numero = Numero;
            this.Complemento = Complemento;
            this.Bairro = Bairro;
            this.Cidade = Cidade;
            this.UF = UF;
            this.IDEmpresa = IDEmpresa;
            this.NomeContato = NomeContato;
            this.Telefone = Telefone;
            this.WhatsApp = WhatsApp;
            this.Observacao = Observacao;
        }
    }
}