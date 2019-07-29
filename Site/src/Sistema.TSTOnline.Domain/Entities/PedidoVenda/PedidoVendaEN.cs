using System;
using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.PedidoVenda
{
    public class PedidoVendaEN
    {
        [Key]
        public int IDPedido { get; set; }
        public DateTime DataVenda { get; set; }
        public int Status { get; set; }
        public int IDUsuario { get; set; }
        public int IDVendedor { get; set; }

        private PedidoVendaEN()
        {
            DataVenda = DateTime.Now;
        }

        public PedidoVendaEN(int Status, int IDUsuario, int IDVendedor)
        {
            ValidateAndSetProperties(Status, IDUsuario, IDVendedor);
        }

        public void UpdateProperties(int Status, int IDUsuario, int IDVendedor)
        {
            ValidateAndSetProperties(Status, IDUsuario, IDVendedor);
        }

        private void ValidateAndSetProperties(int Status, int IDUsuario, int IDVendedor)
        {
            DomainException.When(Status == 0, "Status não informado.");
            DomainException.When(IDVendedor == 0, "Vendedor não informado.");

            this.Status = Status;
            this.IDUsuario = IDUsuario;
            this.IDVendedor = IDVendedor;
        }
    }
}
