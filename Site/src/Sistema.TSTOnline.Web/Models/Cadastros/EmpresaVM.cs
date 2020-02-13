using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Cadastros
{
    public class EmpresaVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDEmpresa { get; set; }

        [JsonProperty(PropertyName = "cpfCnpj")]
        public string CpfCnpj { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "nomeFantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty(PropertyName = "nomeRespEmpresa")]
        public string NomeRespEmpresa { get; set; }

        [JsonProperty(PropertyName = "cpfResponsavel")]
        public string CPFResponsavel { get; set; }

        [JsonProperty(PropertyName = "telResponsavel")]
        public string TelResponsavel { get; set; }

        [JsonProperty(PropertyName = "celular")]
        public string Celular { get; set; }

        [JsonProperty(PropertyName = "nitResponsavel")]
        public string NitResponsavel { get; set; }

        [JsonProperty(PropertyName = "emailResponsavel")]
        public string EmailResponsavel { get; set; }

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

        [JsonProperty(PropertyName = "uf")]
        public string UF { get; set; }
    }
}
