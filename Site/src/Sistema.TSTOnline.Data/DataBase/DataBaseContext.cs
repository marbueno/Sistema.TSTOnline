using Microsoft.EntityFrameworkCore;
using Sistema.TSTOnline.Domain.Entities.Cadastros;
using Sistema.TSTOnline.Domain.Entities.Produtos;
using Sistema.TSTOnline.Domain.Entities.PedidoVenda;
using Sistema.TSTOnline.Domain.Entities.OrdemServico;
using Sistema.TSTOnline.Domain.Entities.Estoque;
using Sistema.TSTOnline.Domain.Entities.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Entities.Relatorios;

namespace Sistema.TSTOnline.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        #region Cadastros

        public DbSet<EmpresaEN> tbcadempresas { get; set; }
        public DbSet<VendedorEN> tbcadvendedor { get; set; }
        public DbSet<ResponsavelEN> tbresponsavel { get; set; }
        public DbSet<FornecedorEN> tbcadfornecedor { get; set; }

        #endregion Cadastros

        #region Produtos

        public DbSet<ProdutoEN> tbproduto { get; set; }
        public DbSet<CategoriaEN> tbprodutocategoria { get; set; }
        public DbSet<SubCategoriaEN> tbprodutosubcategoria { get; set; }

        #endregion Produtos

        #region Pedidos de Venda

        public DbSet<PedidoVendaEN> tbpedidovenda { get; set; }
        public DbSet<PedidoVendaItemEN> tbpedidovendaitem { get; set; }

        #endregion Pedidos de Venda

        #region Ordem de Servi�o

        public DbSet<OrdemServicoEN> tbos { get; set; }
        public DbSet<OrdemServicoItemEN> tbositem { get; set; }
        public DbSet<TipoServicoEN> tbcadtiposervico { get; set; }
        public DbSet<LocalServicoEN> tbcadlocalservico { get; set; }

        #endregion Ordem de Servi�o

        #region Estoque

        public DbSet<EstoqueEN> tbestoque { get; set; }
        public DbSet<MovimentoEstoqueEN> tbmovimentoestoque { get; set; }

        #endregion Estoque

        #region Movimenta��o Financeira

        public DbSet<ContasReceberEN> tbcontasreceber { get; set; }
        public DbSet<FluxoCaixaEN> tbfluxocaixa { get; set; }

        #endregion Movimenta��o Financeira

        #region Relat�rios

        public DbSet<VendasPorVendedorEN> VendasPorVendedor { get; set; }

        #endregion Relat�rios
    }
}