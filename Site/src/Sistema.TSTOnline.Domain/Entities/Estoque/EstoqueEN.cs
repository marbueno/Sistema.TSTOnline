using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Estoque
{
    public class EstoqueEN
    {
        [Key]
        public int IDProduto { get; set; }
        public int IDUser { get; set; }
        public int Qtde { get; set; }

        private EstoqueEN() { }

        public EstoqueEN(int IDUser, int IDProduto, int Qtde)
        {
            ValidateAndSetProperties(IDUser, IDProduto, Qtde);
        }

        public void UpdateProperties(int IDUser, int IDProduto, int Qtde)
        {
            ValidateAndSetProperties(IDUser, IDProduto, Qtde);
        }

        private void ValidateAndSetProperties(int IDUser, int IDProduto, int Qtde)
        {
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(IDProduto == 0, "Produto não informado.");
            DomainException.When(Qtde < 0, "Qtde não pode ser negativa.");

            this.IDUser = IDUser;
            this.IDProduto = IDProduto;
            this.Qtde = Qtde;
        }
    }
}
