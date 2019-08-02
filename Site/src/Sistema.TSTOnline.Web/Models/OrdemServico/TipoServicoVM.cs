using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.OrdemServico
{
    public class TipoServicoVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDTipoServico { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }
    }
}
