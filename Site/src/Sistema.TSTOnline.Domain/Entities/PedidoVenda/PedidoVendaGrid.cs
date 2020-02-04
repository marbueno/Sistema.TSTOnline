using System;
using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Domain.Entities.PedidoVenda
{
    public class PedidoVendaGrid
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "idPedido")]
        public int IDPedido { get; set; }

        [JsonProperty(PropertyName = "dataVenda")]
        public DateTime DataVenda { get; set; }

        [JsonProperty(PropertyName = "status")]
        public PedidoVendaStatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "statusDescricao")]
        public string StatusDescricao { get { return Status.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "vendedorNome")]
        public string VendedorNome { get; set; }

        [JsonProperty(PropertyName = "tipoPagamento")]
        public TipoPagamentoEnum TipoPagamento { get; set; }

        [JsonProperty(PropertyName = "vendaExpress")]
        public bool VendaExpress { get; set; }

        [JsonProperty(PropertyName = "tipoPagamentoDescricao")]
        public string TipoPagamentoDescricao { get { return TipoPagamento.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "valorTotal")]
        public decimal ValorTotal { get; set; }

        [JsonProperty(PropertyName = "valorTotalFormatado")]
        public string ValorTotalFormatado { get { return Sistema.Utils.Helper.FormatReal(ValorTotal, true); } }
    }
}
