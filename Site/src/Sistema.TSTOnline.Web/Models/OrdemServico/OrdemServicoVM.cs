using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Models.OrdemServico
{
    public class OrdemServicoVM
    {
        [JsonProperty(PropertyName = "idOrdemServico")]
        public int IDOrdemServico { get; set; }

        [JsonProperty(PropertyName = "dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty(PropertyName = "dataServico")]
        public DateTime DataServico { get; set; }

        [JsonProperty(PropertyName = "horarioServico")]
        public string HorarioServico { get; set; }

        [JsonProperty(PropertyName = "status")]
        public OrdemServicoStatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "statusDescricao")]
        public string StatusDescricao { get { return Status.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "osExpress")]
        public bool OsExpress { get; set; }

        [JsonProperty(PropertyName = "idEmpresa")]
        public int IDEmpresa { get; set; }

        [JsonProperty(PropertyName = "tipoPessoa")]
        public TipoPessoa TipoPessoa { get; set; }

        [JsonProperty(PropertyName = "cpf")]
        public string CPF { get; set; }

        [JsonProperty(PropertyName = "cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty(PropertyName = "nomeOuRazaoSocial")]
        public string NomeOuRazaoSocial { get; set; }

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

        [JsonProperty(PropertyName = "telefoneOE")]
        public string TelefoneOE { get; set; }

        [JsonProperty(PropertyName = "whatsAppOE")]
        public string WhatsAppOE { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "idResp")]
        public int IDResp { get; set; }

        [JsonProperty(PropertyName = "responsavelNome")]
        public string ResponsavelNome { get; set; }

        [JsonProperty(PropertyName = "idLocal")]
        public int IDLocal { get; set; }

        [JsonProperty(PropertyName = "localDescricao")]
        public string LocalDescricao { get; set; }

        [JsonProperty(PropertyName = "nomeContato")]
        public string NomeContato { get; set; }

        [JsonProperty(PropertyName = "telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "whatsApp")]
        public string WhatsApp { get; set; }

        [JsonProperty(PropertyName = "ordemServicoItens")]
        public List<OrdemServicoItemVM> OrdemServicoItens { get; set; }
    }
}
