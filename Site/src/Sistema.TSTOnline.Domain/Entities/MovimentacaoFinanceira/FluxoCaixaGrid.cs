using System;
using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira
{
    public class FluxoCaixaGrid
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "idFluxoCaixa")]
        public int IDFluxoCaixa { get; set; }

        [JsonProperty(PropertyName = "dataLancamento")]
        public DateTime DataLancamento { get; set; }

        [JsonProperty(PropertyName = "tipoLancamento")]
        public TipoLancamentoFluxoCaixaEnum TipoLancamento { get; set; }

        [JsonProperty(PropertyName = "tipoLancamentoDescricao")]
        public string TipoLancamentoDescricao { get { return TipoLancamento.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "origem")]
        public OrigemFluxoCaixaEnum Origem { get; set; }

        [JsonProperty(PropertyName = "origemDescricao")]
        public string OrigemDescricao { get { return Origem.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "pedidoVendaNumero")]
        public string PedidoVendaNumero { get; set; }

        [JsonProperty(PropertyName = "contasReceberParcela")]
        public string ContasReceberParcela { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public decimal Valor { get; set; }
    }
}
