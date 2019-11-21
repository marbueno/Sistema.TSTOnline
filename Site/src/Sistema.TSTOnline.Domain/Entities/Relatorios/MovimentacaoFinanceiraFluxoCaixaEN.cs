using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class MovimentacaoFinanceiraFluxoCaixaEN
    {
        public int Id { get; set; }
        public int IDFluxoCaixa { get; set; }
        public int? IDPedido { get; set; }
        public DateTime DataLancamento { get; set; }
        public string NumeroTitulo { get; set; }
        public int? Parcela { get; set; }
        public string RazaoSocial { get; set; }
        public TipoLancamentoFluxoCaixaEnum TipoLancamento { get; set; }
        public OrigemFluxoCaixaEnum Origem { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
    }
}
