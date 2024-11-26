using App.Application.Interfaces;
using App.Domain.Interfaces;
using App.Infra.CrossCutting.IoC;
using App.Test.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace App.Test._4_Infra._4._2___CrossCutting
{
    public class NativeInjectorBootStrapperTest
    {
        public IServiceCollection services;

        public NativeInjectorBootStrapperTest()
        {
            services = new ServiceCollection();
            NativeInjectorBootStrapper.RegisterServices(services);
        }

        [Trait("Categoria", "NativeInjectorBootStrapper")]
        [Theory(DisplayName = "NativeInjectorBootStrapper")]
        [InlineData(typeof(IHealthCheckService))]

        [InlineData(typeof(IHealthCheckRepository))]



        public void NativeInjectorBootStrapperValido(System.Type type)
        {

            var isValid = services.GetEnumerator().ToList().Any(_ => _.ServiceType == type);
            Assert.NotNull(services);
            Assert.True(isValid);
        }
    }
}
