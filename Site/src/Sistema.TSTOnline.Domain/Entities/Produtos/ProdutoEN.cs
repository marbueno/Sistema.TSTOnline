using System.ComponentModel.DataAnnotations;


namespace Sistema.TSTOnline.Domain.Entities.Produtos
{
    public class ProdutoEN
    {
        [Key]
        public int IDProduto { get; set; }
        public int IDCompany { get; set; }
        public int IDUser { get; set; }
        public string SKU { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IDFornecedor { get; set; }
        public int IDCategoria { get; set; }
        public int IDSubCategoria { get; set; }
        public decimal Preco { get; set; }

        private ProdutoEN() { }

        public ProdutoEN(int IDCompany, int IDUser, string SKU, string Nome, string Descricao, int IDFornecedor, int IDCategoria, int IDSubCategoria, decimal Preco)
        {
            ValidateAndSetProperties(IDCompany, IDUser, SKU, Nome, Descricao, IDFornecedor, IDCategoria, IDSubCategoria, Preco);
        }

        public void UpdateProperties(int IDCompany, int IDUser, string SKU, string Nome, string Descricao, int IDFornecedor, int IDCategoria, int IDSubCategoria, decimal Preco)
        {
            ValidateAndSetProperties(IDCompany, IDUser, SKU, Nome, Descricao, IDFornecedor, IDCategoria, IDSubCategoria, Preco);
        }

        private void ValidateAndSetProperties(int IDCompany, int IDUser, string SKU, string Nome, string Descricao, int IDFornecedor, int IDCategoria, int IDSubCategoria, decimal Preco)
        {
            DomainException.When(IDCompany == 0, "Compania não informada.");
            DomainException.When(IDUser == 0, "Usuário não informado.");
            //DomainException.When(string.IsNullOrEmpty(SKU), "SKU não informado.");
            DomainException.When(string.IsNullOrEmpty(Nome), "Nome não informado.");
            DomainException.When(string.IsNullOrEmpty(Descricao), "Descrição não informada.");
            DomainException.When(IDFornecedor == 0, "Fornecedor não informado.");
            DomainException.When(IDCategoria == 0, "Categoria não informada.");
            DomainException.When(Preco == 0, "Preço não informado.");

            this.IDCompany = IDCompany;
            this.IDUser = IDUser;
            this.SKU = SKU;
            this.Nome = Nome;
            this.Descricao = Descricao;
            this.IDFornecedor = IDFornecedor;
            this.IDCategoria = IDCategoria;
            this.IDSubCategoria = IDSubCategoria;
            this.Preco = Preco;
        }
    }
}
