using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Domain.Entities.Cadastros;
using Sistema.Competicao.Domain.Entities.Produtos;
using Sistema.Competicao.Domain.Entities.PedidoVenda;
using Sistema.Competicao.Domain.Entities.OrdemServico;

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

        #region Pedidos de Venda

        public DbSet<PedidoVendaEN> tbPedidoVenda { get; set; }
        public DbSet<PedidoVendaItemEN> tbPedidoVendaItem { get; set; }

        #endregion Pedidos de Venda

        #region Ordem de Servi�o

        public DbSet<OrdemServicoEN> tbOs { get; set; }
        public DbSet<OrdemServicoItemEN> tbOsItem { get; set; }
        public DbSet<ServicoEN> tbCadServico { get; set; }
        public DbSet<LocalServicoEN> tbCadLocalServico { get; set; }

        #endregion Ordem de Servi�o
    }
}