using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Estoque
{
    public class EstoqueEN
    {
        [Key]
        public int IDProduto { get; set; }
        public int IDCompany { get; set; }
        public int IDUser { get; set; }
        public int Qtde { get; set; }

        private EstoqueEN() { }

        public EstoqueEN(int IDCompany, int IDUser, int IDProduto, int Qtde)
        {
            ValidateAndSetProperties(IDCompany, IDUser, IDProduto, Qtde);
        }

        public void UpdateProperties(int IDCompany, int IDUser, int IDProduto, int Qtde)
        {
            ValidateAndSetProperties(IDCompany, IDUser, IDProduto, Qtde);
        }

        private void ValidateAndSetProperties(int IDCompany, int IDUser, int IDProduto, int Qtde)
        {
            DomainException.When(IDCompany == 0, "Compania não informada.");
            DomainException.When(IDUser == 0, "Usuário não informado.");
            DomainException.When(IDProduto == 0, "Produto não informado.");
            DomainException.When(Qtde < 0, "Qtde não pode ser negativa.");

            this.IDCompany = IDCompany;
            this.IDUser = IDUser;
            this.IDProduto = IDProduto;
            this.Qtde = Qtde;
        }
    }
}
