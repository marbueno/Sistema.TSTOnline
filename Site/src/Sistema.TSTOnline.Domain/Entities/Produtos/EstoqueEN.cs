using System.ComponentModel.DataAnnotations;


namespace Sistema.Competicao.Domain.Entities.Produtos
{
    public class EstoqueEN
    {
        [Key]
        public int IDProduto { get; set; }
        public double Qtde { get; set; }

        private EstoqueEN() { }

        public EstoqueEN(double Qtde)
        {
            ValidateAndSetProperties(Qtde);
        }

        public void UpdateProperties(double Qtde)
        {
            ValidateAndSetProperties(Qtde);
        }

        private void ValidateAndSetProperties(double Qtde)
        {
            DomainException.When(Qtde < 0, "Qtde não pode ser negativa.");

            this.Qtde = Qtde;
        }
    }
}
