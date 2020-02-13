using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Cadastros
{
    public class AmbienteVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDAmbiente { get; set; }

        [JsonProperty(PropertyName = "nomeEstabelecimento")]
        public string NomeEstabelecimento { get; set; }

        [JsonProperty(PropertyName = "cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "cep")]
        public string Cep { get; set; }

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

        [JsonProperty(PropertyName = "UF")]
        public string UF { get; set; }
    }
}
