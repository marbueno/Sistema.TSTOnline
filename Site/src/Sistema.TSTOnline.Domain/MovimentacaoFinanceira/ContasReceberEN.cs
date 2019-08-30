using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira
{
    public class ContasReceberEN
    {
        [Key]
        public int IDContasReceber { get; set; }
        public DateTime DataCadastro { get; set; }
        public string NumeroTitulo { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }
        public OrigemContasReceberEnum Origem { get; set; }
        public int Chave { get; set; }
        public ContasReceberStatusEnum Status { get; set; }

        public ContasReceberEN() { }

        public ContasReceberEN(string NumeroTitulo, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, int Chave, ContasReceberStatusEnum Status)
        {
            ValidateAndSetProperties(NumeroTitulo, DataVencimento, Valor, ValorPago, Origem, Chave, Status);
        }

        public void UpdateProperties(string NumeroTitulo, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, int Chave, ContasReceberStatusEnum Status)
        {
            ValidateAndSetProperties(NumeroTitulo, DataVencimento, Valor, ValorPago, Origem, Chave, Status);
        }

        private void ValidateAndSetProperties(string NumeroTitulo, DateTime DataVencimento, decimal Valor, decimal ValorPago, OrigemContasReceberEnum Origem, int Chave, ContasReceberStatusEnum Status)
        {
            DomainException.When(string.IsNullOrEmpty(NumeroTitulo), "Número do Título não informado.");
            DomainException.When(DataVencimento == DateTime.MinValue, "Data da Vencimento Inválida.");
            DomainException.When(Valor == 0, "Valor do Título não informado.");

            this.NumeroTitulo = NumeroTitulo;
            this.DataVencimento = DataVencimento;
            this.Valor = Valor;
            this.ValorPago = ValorPago;
            this.Origem = Origem;
            this.Chave = Chave;
            this.Status = Status;
        }
    }
}
