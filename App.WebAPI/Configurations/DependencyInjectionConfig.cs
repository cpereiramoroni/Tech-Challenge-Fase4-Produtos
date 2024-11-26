using App.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace App.WebAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
