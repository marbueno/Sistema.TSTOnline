using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class MovimentacaoFinanceiraContasReceberEN
    {
        public int Id { get; set; }
        public int IDContasReceber { get; set; }
        public int? IDPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVencimento { get; set; }
        public string NumeroTitulo { get; set; }
        public int Parcela { get; set; }
        public string RazaoSocial { get; set; }
        public OrigemContasReceberEnum Origem { get; set; }
        public ContasReceberStatusEnum Status { get; set; }
        public decimal ValorTitulo { get; set; }
        public decimal ValorPago { get; set; }
    }
}
