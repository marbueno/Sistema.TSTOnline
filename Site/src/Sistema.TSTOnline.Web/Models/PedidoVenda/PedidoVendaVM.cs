using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sistema.TSTOnline.Domain.Utils;

namespace Sistema.TSTOnline.Web.Models.PedidoVenda
{
    public class PedidoVendaVM
    {
        [JsonProperty(PropertyName = "idPedido")]
        public int IDPedido { get; set; }

        [JsonProperty(PropertyName = "dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty(PropertyName = "dataVenda")]
        public DateTime DataVenda { get; set; }

        [JsonProperty(PropertyName = "status")]
        public PedidoVendaStatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "statusDescricao")]
        public string StatusDescricao { get { return Status.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "idUsuario")]
        public int IDUsuario { get; set; }

        [JsonProperty(PropertyName = "idVendedor")]
        public int IDVendedor { get; set; }

        [JsonProperty(PropertyName = "vendedorNome")]
        public string VendedorNome { get; set; }

        [JsonProperty(PropertyName = "idEmpresa")]
        public int IDEmpresa { get; set; }

        [JsonProperty(PropertyName = "tipoPagamento")]
        public TipoPagamentoEnum TipoPagamento { get; set; }

        [JsonProperty(PropertyName = "tipoPagamentoDescricao")]
        public string TipoPagamentoDescricao { get { return TipoPagamento.ToDescriptionEnum(); } }

        [JsonProperty(PropertyName = "qtdeParcelas")]
        public QtdeParcelasEnum QtdeParcelas { get; set; }

        [JsonProperty(PropertyName = "razaoSocial")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "responsavelEmpresaNome")]
        public string ResponsavelEmpresaNome { get; set; }

        [JsonProperty(PropertyName = "responsavelEmpresaCPF")]
        public string ResponsavelEmpresaCPF { get; set; }

        [JsonProperty(PropertyName = "responsavelEmpresaTelefone")]
        public string ResponsavelEmpresaTelefone { get; set; }

        [JsonProperty(PropertyName = "responsavelEmpresaNIT")]
        public string ResponsavelEmpresaNIT { get; set; }

        [JsonProperty(PropertyName = "responsavelEmpresaEmail")]
        public string ResponsavelEmpresaEmail { get; set; }

        [JsonProperty(PropertyName = "observacao")]
        public string Observacao { get; set; }

        [JsonProperty(PropertyName = "valorTotal")]
        public string ValorTotal { get; set; }

        [JsonProperty(PropertyName = "pedidoVendaItens")]
        public List<PedidoVendaItemVM> PedidoVendaItens { get; set; }
    }
}
