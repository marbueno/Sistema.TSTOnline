using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain.Entities.PedidoVenda
{
    public class PedidoVendaItemEN
    {
        [Key]
        public int IDPedidoItem { get; set; }
        public int IDPedido { get; set; }
        public int Item { get; set; }
        public int IDProduto { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorTotal
        {
            get { return Qtde * Valor; }
        }

        private PedidoVendaItemEN() { }

        public PedidoVendaItemEN(int IDPedido, int Item, int IDProduto, int Qtde, decimal Valor)
        {
            ValidateAndSetProperties(IDPedido, Item, IDProduto, Qtde, Valor);
        }

        public void UpdateProperties(int IDPedido, int Item, int IDProduto, int Qtde, decimal Valor)
        {
            ValidateAndSetProperties(IDPedido, Item, IDProduto, Qtde, Valor);
        }

        private void ValidateAndSetProperties(int IDPedido, int Item, int IDProduto, int Qtde, decimal Valor)
        {
            DomainException.When(IDPedido == 0, "Código do Pedido não informado.");
            DomainException.When(Item == 0, "Número do Item não informado.");
            DomainException.When(IDProduto == 0, "Código do Produto não informado.");
            DomainException.When(Qtde == 0, "Qtde não informada.");
            DomainException.When(Valor == 0, "Valor não informado.");

            this.IDPedido = IDPedido;
            this.Item = Item;
            this.IDProduto = IDProduto;
            this.Qtde = Qtde;
            this.Valor = Valor;
        }
    }
}
