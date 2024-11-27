using App.Application.Interfaces;
using App.Domain.Interfaces;
using App.Infra.Data.Context;
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

            services.AddScoped<IProdutosService, ProdutosService>();
            ////=======================================================================
            ///
            ///  INSTACIAS DE REPOSITORY
            /// 
            ///
            services.AddScoped<IProdutosRepository, ProdutosRepository>();

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
