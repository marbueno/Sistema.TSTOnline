using System;
using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Models.MovimentacaoFinanceira
{
    public class FluxoCaixaVM
    {
        [JsonProperty(PropertyName = "idFluxoCaixa")]
        public int IDFluxoCaixa { get; set; }

        [JsonProperty(PropertyName = "dataLancamento")]
        public DateTime DataLancamento { get; set; }

        [JsonProperty(PropertyName = "tipoLancamento")]
        public TipoLancamentoFluxoCaixaEnum TipoLancamento { get; set; }

        [JsonProperty(PropertyName = "tipoLancamentoDescricao")]
        public string TipoLancamentoDescricao { get { return TipoLancamento.ToDescriptionEmum(); } }

        [JsonProperty(PropertyName = "origem")]
        public OrigemFluxoCaixaEnum Origem { get; set; }

        [JsonProperty(PropertyName = "origemDescricao")]
        public string OrigemDescricao { get { return Origem.ToDescriptionEmum(); } }

        [JsonProperty(PropertyName = "chave")]
        public int Chave { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public decimal Valor { get; set; }

        [JsonProperty(PropertyName = "observacao")]
        public string Observacao { get; set; }
    }
}
