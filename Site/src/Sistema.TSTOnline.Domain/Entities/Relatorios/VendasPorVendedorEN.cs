using Sistema.TSTOnline.Domain.Utils;
using System;

namespace Sistema.TSTOnline.Domain.Entities.Relatorios
{
    public class VendasPorVendedorEN
    {
        public int Id { get; set; }
        public int IDPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVenda { get; set; }
        public PedidoVendaStatusEnum Status { get; set; }
        public int IDVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string EmailVendedor { get; set; }
    }
}
