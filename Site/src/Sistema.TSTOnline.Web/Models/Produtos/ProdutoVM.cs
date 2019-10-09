using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Produtos
{
    public class ProdutoVM
    {
        [JsonProperty(PropertyName = "idProduto")]
        public int IDProduto { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string SKU { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        [JsonProperty(PropertyName = "idFornecedor")]
        public int IDFornecedor { get; set; }

        [JsonProperty(PropertyName = "fornecedorRazaoSocial")]
        public string FornecedorRazaoSocial { get; set; }

        [JsonProperty(PropertyName = "idCategoria")]
        public int IDCategoria { get; set; }

        [JsonProperty(PropertyName = "categoriaDescricao")]
        public string CategoriaDescricao { get; set; }

        [JsonProperty(PropertyName = "idSubCategoria")]
        public int IDSubCategoria { get; set; }

        [JsonProperty(PropertyName = "subCategoriaDescricao")]
        public string SubCategoriaDescricao { get; set; }

        [JsonProperty(PropertyName = "preco")]
        public decimal Preco { get; set; }
    }
}
