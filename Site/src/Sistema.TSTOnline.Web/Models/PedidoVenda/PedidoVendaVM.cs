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

        [JsonProperty(PropertyName = "vendaExpress")]
        public bool VendaExpress { get; set; }

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
