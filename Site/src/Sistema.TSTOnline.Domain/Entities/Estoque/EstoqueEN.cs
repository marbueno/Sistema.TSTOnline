using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Estoque
{
    public class EstoqueEN
    {
        [Key]
        public int IDProduto { get; set; }
        public int Qtde { get; set; }

        private EstoqueEN() { }

        public EstoqueEN(int IDProduto, int Qtde)
        {
            ValidateAndSetProperties(IDProduto, Qtde);
        }

        public void UpdateProperties(int IDProduto, int Qtde)
        {
            ValidateAndSetProperties(IDProduto, Qtde);
        }

        private void ValidateAndSetProperties(int IDProduto, int Qtde)
        {
            DomainException.When(IDProduto == 0, "Produto não informado.");
            DomainException.When(Qtde <= 0, "Qtde não pode ser menor ou igual a zero.");

            this.IDProduto = IDProduto;
            this.Qtde = Qtde;
        }
    }
}
