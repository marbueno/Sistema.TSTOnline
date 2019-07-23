﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sistema.Competicao.Data;
using Microsoft.AspNetCore.Http;
using Sistema.Competicao.Domain.Interfaces;
using Sistema.Competicao.Domain.Services.Cadastros;
using Sistema.Competicao.Domain.Services.Produtos;
using Sistema.Competicao.Domain.Services.PedidoVenda;
using Sistema.Competicao.Domain.Services.OrdemServico;

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

            #region Pedidos de Venda

            services.AddTransient(typeof(PedidoVendaBU));
            services.AddTransient(typeof(PedidoVendaItemBU));

            #endregion Pedidos de Venda

            #region Ordem de Serviço

            services.AddTransient(typeof(OrdemServicoBU));
            services.AddTransient(typeof(OrdemServicoItemBU));
            services.AddTransient(typeof(ServicoBU));
            services.AddTransient(typeof(LocalServicoBU));

            #endregion Ordem de Serviço
        }
    }
}
