using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.OrdemServico
{
    public class LocalServicoVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDLocal { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

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
    }
}
