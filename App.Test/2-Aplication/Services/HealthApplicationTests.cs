using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace App.Test.ApplicationTest.Health
{
    public class HealthApplicationTests
    {
        private readonly IHealthCheckService _AppServices;
        private readonly Mock<IHealthCheckRepository> _Repository = new Mock<IHealthCheckRepository>();


        public HealthApplicationTests()
        {
            _AppServices = new HealthCheckAppService(_Repository.Object);
        }

        [Trait("Categoria", "HealthApplication")]
        [Fact(DisplayName = "Health Application - OK  ")]

        public async Task Health_Validar_DeveEstarValido()
        {
            // Arrange 

            _Repository
                .Setup(c => c.Reading())
                                .ReturnsAsync(true);

            // Act
            var result = await _AppServices.HealthCheck();
            // Assert
            Assert.True(result);

        }


        [Trait("Categoria", "HealthApplication")]
        [Fact(DisplayName = "Health Application - Error  ")]
        public async Task Health_Validar_NaoDeveEstarValido()
        {
            // Arrange 

            _Repository
                  .Setup(c => c.Reading())
                                .ReturnsAsync(false);

            // Act
            var result = await _AppServices.HealthCheck();
            // Assert
            Assert.False(result);

        }

        [Trait("Categoria", "HealthApplication")]
        [Fact(DisplayName = "Health Application - Exception  ")]
        public async Task Health_Validar_Exception()
        {
            // Arrange 
            _Repository
               .Setup(c => c.Reading())
                              .Throws(new Exception("Error"));
            // Act
            var exception =
                await Assert.ThrowsAsync<Exception>(() =>
                    _AppServices.HealthCheck());


            // Assert
            Assert.Equal("Error", exception.Message);

        }

        #region [Dispose]
        [Trait("Categoria", "Service")]
        [Fact(DisplayName = "Dispose ")]
        public void Dispose()
        {
            //act
            _AppServices.Dispose();
            Assert.NotNull(_AppServices);

        }

        #endregion
    }
}
