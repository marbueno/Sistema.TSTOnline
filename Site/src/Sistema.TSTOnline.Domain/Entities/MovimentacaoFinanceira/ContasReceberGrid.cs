using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira
{
    public class ContasReceberGrid
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "idContasReceber")]
        public int IDContasReceber { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "numeroTitulo")]
        public string NumeroTitulo { get; set; }

        [JsonProperty(PropertyName = "seq")]
        public int Seq { get; set; }

        [JsonProperty(PropertyName = "dataVencimento")]
        public DateTime DataVencimento { get; set; }

        [JsonProperty(PropertyName = "valor")]
        public decimal Valor { get; set; }

        [JsonProperty(PropertyName = "valorPago")]
        public decimal ValorPago { get; set; }

        [JsonProperty(PropertyName = "status")]
        public ContasReceberStatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "statusDescricao")]
        public string StatusDescricao { get { return Status.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "linkFatura")]
        public string LinkFatura { get; set; }
    }
}
