using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class MovimentacaoEstoqueEN
    {
        public int Id { get; set; }
        public int? IDPedido { get; set; }
        public DateTime DataMovimento { get; set; }
        public OrigemMovimentoEstoqueEnum Origem { get; set; }
        public TipoMovimentoEstoqueEnum Tipo { get; set; }
        public string Produto { get; set; }
        public int Qtde { get; set; }
        public string Observacao { get; set; }
    }
}
