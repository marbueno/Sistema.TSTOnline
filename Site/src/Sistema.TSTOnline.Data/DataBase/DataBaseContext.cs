using Microsoft.EntityFrameworkCore;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;

namespace Sistema.TSTOnline.Data
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

        #region Ordem de Serviço

        public DbSet<OrdemServicoEN> tbOs { get; set; }
        public DbSet<OrdemServicoItemEN> tbOsItem { get; set; }
        public DbSet<TipoServicoEN> tbCadTipoServico { get; set; }
        public DbSet<LocalServicoEN> tbCadLocalServico { get; set; }

        #endregion Ordem de Serviço
    }
}