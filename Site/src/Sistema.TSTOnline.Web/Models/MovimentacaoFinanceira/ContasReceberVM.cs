using System;
using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Models.MovimentacaoFinanceira
{
    public class ContasReceberVM
    {
        [JsonProperty(PropertyName = "idContasReceber")]
        public int IDContasReceber { get; set; }

        [JsonProperty(PropertyName = "dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty(PropertyName = "idEmpresa")]
        public int IDEmpresa { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "numeroTitulo")]
        public string NumeroTitulo { get; set; }

        [JsonProperty(PropertyName = "dataVencimento")]
        public DateTime DataVencimento { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public decimal Valor { get; set; }

        [JsonProperty(PropertyName = "valorPago")]
        public decimal ValorPago { get; set; }

        [JsonProperty(PropertyName = "origem")]
        public OrigemContasReceberEnum Origem { get; set; }

        [JsonProperty(PropertyName = "origemDescricao")]
        public string OrigemDescricao { get { return Origem.ToDescriptionEmum(); } }

        [JsonProperty(PropertyName = "chave")]
        public int Chave { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ContasReceberStatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "statusDescricao")]
        public string StatusDescricao { get { return Status.ToDescriptionEmum(); } }
    }
}
