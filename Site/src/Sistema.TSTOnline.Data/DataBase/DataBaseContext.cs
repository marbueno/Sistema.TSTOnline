using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Entities.Produtos;

namespace Sistema.Competicao.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        #region Cadastros

        public DbSet<EmpresaEN> tbCadEmpresas { get; set; }
        public DbSet<VendedorEN> tbCadVendedor { get; set; }
        public DbSet<ResponsavelEN> tbResponsavel { get; set; }
        public DbSet<FornecedorEN> tbCadFornecedor { get; set; }

        #endregion Cadastros

        #region Produtos

        public DbSet<ProdutoEN> tbProduto { get; set; }
        public DbSet<EstoqueEN> tbEstoque { get; set; }
        public DbSet<CategoriaEN> tbProdutoCategoria { get; set; }
        public DbSet<SubCategoriaEN> tbProdutoSubCategoria { get; set; }

        #endregion Produtos
    }
}