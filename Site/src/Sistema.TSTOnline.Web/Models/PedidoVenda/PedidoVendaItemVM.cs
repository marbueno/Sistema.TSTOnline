using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.PedidoVenda
{
    public class PedidoVendaItemVM
    {
        [JsonProperty(PropertyName = "idPedidoItem")]
        public int IDPedidoItem { get; set; }

        [JsonProperty(PropertyName = "idPedido")]
        public int IDPedido { get; set; }

        [JsonProperty(PropertyName = "item")]
        public int Item { get; set; }

        [JsonProperty(PropertyName = "idProduto")]
        public int IDProduto { get; set; }

        [JsonProperty(PropertyName = "produtoNome")]
        public string ProdutoNome { get; set; }

        [JsonProperty(PropertyName = "qtde")]
        public int Qtde { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public decimal Valor { get; set; }

        [JsonProperty(PropertyName = "valorTotal")]
        public decimal ValorTotal
        {
            get { return Qtde * Valor; }
        }
    }
}
