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
        public string StatusDescricao { get { return Status.ToDescriptionEmum(); } }

        [JsonProperty(PropertyName = "idUsuario")]
        public int IDUsuario { get; set; }

        [JsonProperty(PropertyName = "idVendedor")]
        public int IDVendedor { get; set; }

        [JsonProperty(PropertyName = "vendedorNome")]
        public string VendedorNome { get; set; }

        [JsonProperty(PropertyName = "pedidoVendaItens")]
        public List<PedidoVendaItemVM> PedidoVendaItens { get; set; }
    }
}
