using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Produtos
{
    public class SubCategoriaVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDSubCategoria { get; set; }

        [JsonProperty(PropertyName = "idCategoria")]
        public int IDCategoria { get; set; }

        [JsonProperty(PropertyName = "categoriaDescricao")]
        public string CategoriaDescricao { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }
    }
}
