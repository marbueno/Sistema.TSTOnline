using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class VendasPorClienteEN
    {
        public int Id { get; set; }
        public int IDPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVenda { get; set; }
        public PedidoVendaStatusEnum Status { get; set; }
        public int IDEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string ResponsavelEmpresaNome { get; set; }
        public string NomeVendedor { get; set; }
    }
}
