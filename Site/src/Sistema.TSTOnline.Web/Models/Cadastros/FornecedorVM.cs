using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Cadastros
{
    public class FornecedorVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDFornecedor { get; set; }

        [JsonProperty(PropertyName = "cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "nomeFantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty(PropertyName = "cep")]
        public string CEP { get; set; }

        [JsonProperty(PropertyName = "endereco")]
        public string Endereco { get; set; }

        [JsonProperty(PropertyName = "numero")]
        public string Numero { get; set; }

        [JsonProperty(PropertyName = "complemento")]
        public string Complemento { get; set; }

        [JsonProperty(PropertyName = "bairro")]
        public string Bairro { get; set; }

        [JsonProperty(PropertyName = "cidade")]
        public string Cidade { get; set; }

        [JsonProperty(PropertyName = "uf")]
        public string UF { get; set; }

        [JsonProperty(PropertyName = "nomeContato")]
        public string NomeContato { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "whatsApp")]
        public string WhatsApp { get; set; }
    }
}
