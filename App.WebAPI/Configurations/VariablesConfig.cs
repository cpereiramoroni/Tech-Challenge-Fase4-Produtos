using App.Application.ViewModels.Cripto;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Service.Api.Configurations
{

    public static class VariablesConfig
    {
        public static void AddVariablesConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<ConfigCript>(_ =>
             new ConfigCript
             {
                 KeyInternal = Environment.GetEnvironmentVariable("KEY_INTERNA"),
             });
        }

    }
}
