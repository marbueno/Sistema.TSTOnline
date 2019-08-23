using Sistema.TSTOnline.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.PedidoVenda
{
    public class PedidoVendaEN
    {
        [Key]
        public int IDPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataVenda { get; set; }
        public PedidoVendaStatusEnum Status { get; set; }
        public int IDUsuario { get; set; }
        public int IDVendedor { get; set; }

        public PedidoVendaEN()
        {
            DataVenda = DateTime.Now;
        }

        public PedidoVendaEN(DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor)
        {
            ValidateAndSetProperties(DataVenda, Status, IDUsuario, IDVendedor);
        }

        public void UpdateProperties(DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor)
        {
            ValidateAndSetProperties(DataVenda, Status, IDUsuario, IDVendedor);
        }

        private void ValidateAndSetProperties(DateTime DataVenda, PedidoVendaStatusEnum Status, int IDUsuario, int IDVendedor)
        {
            DomainException.When(DataVenda == DateTime.MinValue, "Data da Venda Inválida.");
            DomainException.When(Status == 0, "Status não informado.");
            DomainException.When(IDVendedor == 0, "Vendedor não informado.");

            this.DataVenda = DataVenda;
            this.Status = Status;
            this.IDUsuario = IDUsuario;
            this.IDVendedor = IDVendedor;
        }
    }
}
