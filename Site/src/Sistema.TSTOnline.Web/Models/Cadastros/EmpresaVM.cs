using Newtonsoft.Json;

namespace Sistema.Competicao.Web.Areas.Admin.Models.Cadastros
{
    public class EmpresaVM
    {
        [JsonProperty(PropertyName = "codigo")]
        public int IDEmpresa { get; set; }

        [JsonProperty(PropertyName = "statusEmpresa")]
        public string StatusEmpresa { get; set; }

        [JsonProperty(PropertyName = "situacao")]
        public string Situacao { get; set; }

        [JsonProperty(PropertyName = "codigoUsuario")]
        public int IDUser { get; set; }

        [JsonProperty(PropertyName = "nomeContato")]
        public string NomeContato { get; set; }

        [JsonProperty(PropertyName = "cpfContato")]
        public string CPFContato { get; set; }

        [JsonProperty(PropertyName = "telContato")]
        public string TelContato { get; set; }

        [JsonProperty(PropertyName = "nomeRespEmpresa")]
        public string NomeRespEmpresa { get; set; }

        [JsonProperty(PropertyName = "cpfResponsavel")]
        public string CPFResponsavel { get; set; }

        [JsonProperty(PropertyName = "telResponsavel")]
        public string TelResponsavel { get; set; }

        [JsonProperty(PropertyName = "nitResponsavel")]
        public string NITResponsavel { get; set; }

        [JsonProperty(PropertyName = "emailResponsavel")]
        public string EmailResponsavel { get; set; }

        [JsonProperty(PropertyName = "codigoEmpresa")]
        public int CodEmpresa { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "nomeFantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty(PropertyName = "tipoMatricula")]
        public string TipoMatricula { get; set; }

        [JsonProperty(PropertyName = "nrMatricula")]
        public string NRMatricula { get; set; }

        [JsonProperty(PropertyName = "cnae")]
        public string CNAE { get; set; }

        [JsonProperty(PropertyName = "cnaeDescricao")]
        public string CNAEDesc { get; set; }

        [JsonProperty(PropertyName = "cep")]
        public string CEP { get; set; }

        [JsonProperty(PropertyName = "uf")]
        public string UF { get; set; }

        [JsonProperty(PropertyName = "cidade")]
        public string Cidade { get; set; }

        [JsonProperty(PropertyName = "bairro")]
        public string Bairro { get; set; }

        [JsonProperty(PropertyName = "endereco")]
        public string Endereco { get; set; }

        [JsonProperty(PropertyName = "numero")]
        public string Numero { get; set; }

        [JsonProperty(PropertyName = "complemento")]
        public string Complemento { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "celular")]
        public string Celular { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
    }
}
