using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sistema.TSTOnline.Data;
using Microsoft.AspNetCore.Http;
using Sistema.TSTOnline.Domain.Interfaces;
using Sistema.TSTOnline.Domain.Services.Cadastros;
using Sistema.TSTOnline.Domain.Services.Produtos;
using Sistema.TSTOnline.Domain.Services.PedidoVenda;
using Sistema.TSTOnline.Domain.Services.OrdemServico;
using Sistema.TSTOnline.Domain.Services.Estoque;
using Sistema.TSTOnline.Domain.Services.MovimentacaoFinanceira;
using Sistema.TSTOnline.Domain.Services.Fluxo;

namespace Sistema.TSTOnline.DI
{
    public class InjectDependencies
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataBaseContext>(opt => opt.UseMySql(connectionString));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            #region Cadastros

            services.AddTransient(typeof(EmpresaBU));
            services.AddTransient(typeof(VendedorBU));
            services.AddTransient(typeof(FornecedorBU));

            #endregion Cadastros

            #region Produtos

            services.AddTransient(typeof(ProdutoBU));
            services.AddTransient(typeof(CategoriaBU));
            services.AddTransient(typeof(SubCategoriaBU));

            #endregion Produtos

            #region Pedidos de Venda

            services.AddTransient(typeof(PedidoVendaBU));
            services.AddTransient(typeof(PedidoVendaItemBU));

            #endregion Pedidos de Venda

            #region Ordem de Serviço

            services.AddTransient(typeof(OrdemServicoBU));
            services.AddTransient(typeof(OrdemServicoItemBU));
            services.AddTransient(typeof(TipoServicoBU));
            services.AddTransient(typeof(LocalServicoBU));

            #endregion Ordem de Serviço

            #region Estoque

            services.AddTransient(typeof(EstoqueBU));
            services.AddTransient(typeof(MovimentoEstoqueBU));

            #endregion Estoque

            #region Movimentação Financeira

            services.AddTransient(typeof(ContasReceberBU));

            #endregion Movimentação Financeira

            #region Fluxo Sistema

            services.AddTransient(typeof(FluxoBU));

            #endregion Fluxo Sistema
        }
    }
}
