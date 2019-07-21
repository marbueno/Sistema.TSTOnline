using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Data;
using Microsoft.AspNetCore.Http;
using Sistema.Competicao.Domain.Interfaces;
using Sistema.Competicao.Domain.Services.Cadastros;

namespace Sistema.Competicao.DI
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
            services.AddTransient(typeof(EstoqueBU));
            services.AddTransient(typeof(CategoriaBU));
            services.AddTransient(typeof(SubCategoriaBU));

            #endregion Produtos
        }
    }
}
