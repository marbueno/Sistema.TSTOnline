using Newtonsoft.Json;
using System;

namespace Sistema.TSTOnline.Web.Models.Cadastros
{
    public class VendedorVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDVendedor { get; set; }

        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "rg")]
        public string RG { get; set; }

        [JsonProperty(PropertyName = "cpf")]
        public string CPF { get; set; }

        [JsonProperty(PropertyName = "dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

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
