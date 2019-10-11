using Newtonsoft.Json;

namespace Sistema.TSTOnline.Web.Models.Cadastros
{
    public class EmpresaVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDEmpresa { get; set; }

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

        [JsonProperty(PropertyName = "nitResponsavel")]
        public string NitResponsavel { get; set; }

        [JsonProperty(PropertyName = "emailResponsavel")]
        public string EmailResponsavel { get; set; }
    }
}
