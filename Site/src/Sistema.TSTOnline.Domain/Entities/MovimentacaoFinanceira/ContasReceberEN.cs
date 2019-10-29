using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira
{
    public class ContasReceberEN
    {
        [Key]
        public int IDContasReceber { get; set; }
        public int IDUser { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IDEmpresa { get; set; }
        public string NumeroTitulo { get; set; }
        public int Seq { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }
        public OrigemContasReceberEnum Origem { get; set; }
        public int Chave { get; set; }
        public string LinkFatura { get; set; }
        public ContasReceberStatusEnum Status { get; set; }

        public ContasReceberEN() { }

        public ContasReceberEN(int IDUser, int IDEmpresa, string NumeroTitulo, int Seq, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, int Chave, string LinkFatura, ContasReceberStatusEnum Status)
        {
            ValidateAndSetProperties(IDUser, IDEmpresa, NumeroTitulo, Seq, DataVencimento, Valor, ValorPago, Origem, Chave, LinkFatura, Status);
        }

        public void UpdateProperties(int IDUser, int IDEmpresa, string NumeroTitulo, int Seq, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, int Chave, string LinkFatura, ContasReceberStatusEnum Status)
        {
            ValidateAndSetProperties(IDUser, IDEmpresa, NumeroTitulo, Seq, DataVencimento, Valor, ValorPago, Origem, Chave, LinkFatura, Status);
        }

        private void ValidateAndSetProperties(int IDUser, int IDEmpresa, string NumeroTitulo, int Seq, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, int Chave, string LinkFatura, ContasReceberStatusEnum Status)
        {
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(IDEmpresa == 0, "Cliente não informado.");
            DomainException.When(string.IsNullOrEmpty(NumeroTitulo), "Número do Título não informado.");
            DomainException.When(Seq == 0, "Sequência não informada.");
            DomainException.When(DataVencimento == DateTime.MinValue, "Data da Vencimento Inválida.");
            DomainException.When(Valor == 0, "Valor do Título não informado.");

            this.IDUser = IDUser;
            this.IDEmpresa = IDEmpresa;
            this.NumeroTitulo = NumeroTitulo;
            this.Seq = Seq;
            this.DataVencimento = DataVencimento;
            this.Valor = Valor;
            this.ValorPago = ValorPago;
            this.Origem = Origem;
            this.Chave = Chave;
            this.LinkFatura = LinkFatura;
            this.Status = Status;
        }
    }
}
