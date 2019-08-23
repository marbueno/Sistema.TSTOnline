using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Estoque
{
    public class EstoqueVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDProduto { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string SKU { get; set; }

        [JsonProperty(PropertyName = "produtoNome")]
        public string ProdutoNome { get; set; }

        [JsonProperty(PropertyName = "qtde")]
        public int Qtde { get; set; }
    }
}
