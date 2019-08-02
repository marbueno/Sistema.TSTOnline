using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Produtos
{
    public class CategoriaVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDCategoria { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }
    }
}
