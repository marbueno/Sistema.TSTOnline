using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.OrdemServico
{
    public class OrdemServicoItemVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDOrdemServicoItem { get; set; }

        [JsonProperty(PropertyName = "codigoOrdemServico")]
        public int IDOrdemServico { get; set; }

        [JsonProperty(PropertyName = "item")]
        public int Item { get; set; }

        [JsonProperty(PropertyName = "codigoTipoServico")]
        public int IDTipoServico { get; set; }

        [JsonProperty(PropertyName = "tipoServicoDescricao")]
        public string TipoServicoDescricao { get; set; }

        [JsonProperty(PropertyName = "observacao")]
        public string Observacao { get; set; }

        [JsonProperty(PropertyName = "concluido")]
        public bool Concluido { get; set; }
    }
}
