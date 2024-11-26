using App.WebAPI;
using App.WebAPI.Configurations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using System;
using Xunit;

namespace App.Test._1_Service
{
    public class StartupTests
    {
        [Trait("Categoria", "StartupTests")]
        [Fact(DisplayName = "AllSarttup")]
        public void ConfigureServices()
        {
            //  Arrange
            Environment.SetEnvironmentVariable("BDCORP", "teste");

            Mock<IHostEnvironment> configurationStub = new Mock<IHostEnvironment>();

            IServiceCollection _services = new ServiceCollection();
            var _startup = new Startup(configurationStub.Object);

            //  Act
            _startup.ConfigureServices(_services);

            var serviceProvider = _services.BuildServiceProvider();

            var options = serviceProvider.GetService<IOptions<DefaultModelBindingMessageProvider>>();


            Assert.NotNull(options);
            Assert.NotNull(_startup.Configuration);
        }


        [Trait("Categoria", "StartupTests")]
        [Fact(DisplayName = "MVCCONFIG")]
        public void AddMvcConfiguration()
        {
            //  Arrange
            IServiceCollection _services = new ServiceCollection();
            //  Act
            MvcConfig.AddMvcConfiguration(_services);

            var serviceProvider = _services.BuildServiceProvider();

            var options = serviceProvider.GetService<IOptions<DefaultModelBindingMessageProvider>>();

            foreach (var item in options.Value.ValueIsInvalidAccessor.GetInvocationList())
            {
                Assert.NotNull(item);
            }




        }






    }
}
