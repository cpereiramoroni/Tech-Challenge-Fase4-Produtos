using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
using App.Infra.Data.Repository;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace App.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            ///     variables
            ///     


            ////=======================================================================
            ///
            ///  INSTACIAS DE SERVICES
            /// 
            ///
            services.AddScoped<IHealthCheckService, HealthCheckService>();
            services.AddScoped<IProdutosService, ProdutosService>();
            ////=======================================================================
            ///
            ///  INSTACIAS DE REPOSITORY
            /// 
            ///
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
            services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();
            ////=======================================================================
            ///
            ///  INSTACIAS DE CONTEXTO
            /// 
            ///
            services.AddDbContext<MySQLContext>(options =>
              options.UseMySql(
                  config["ConnectionProdutos"],
                  ServerVersion.AutoDetect(config["ConnectionProdutos"])
              ));
            services.AddScoped<MySQLContext>();




        }
    }
}
