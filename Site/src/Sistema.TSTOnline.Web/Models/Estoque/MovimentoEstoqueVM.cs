using Sistema.TSTOnline.Domain.Utils;
using System;
using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Estoque
{
    public class MovimentoEstoqueVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDMovimento { get; set; }

        [JsonProperty(PropertyName = "dataMovimento")]
        public DateTime DataMovimento { get; set; }

        [JsonProperty(PropertyName = "origem")]
        public OrigemMovimentoEstoqueEnum Origem { get; set; }

        [JsonProperty(PropertyName = "origemDescricao")]
        public string OrigemDescricao { get { return Origem.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "chave")]
        public int Chave { get; set; }

        [JsonProperty(PropertyName = "idProduto")]
        public int IDProduto { get; set; }

        [JsonProperty(PropertyName = "sku")]
        public string SKU { get; set; }

        [JsonProperty(PropertyName = "produtoNome")]
        public string ProdutoNome { get; set; }

        [JsonProperty(PropertyName = "tipo")]
        public TipoMovimentoEstoqueEnum Tipo { get; set; }

        [JsonProperty(PropertyName = "tipoDescricao")]
        public string TipoDescricao { get { return Tipo.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "qtde")]
        public int Qtde { get; set; }

        [JsonProperty(PropertyName = "observacao")]
        public string Observacao { get; set; }
    }
}
