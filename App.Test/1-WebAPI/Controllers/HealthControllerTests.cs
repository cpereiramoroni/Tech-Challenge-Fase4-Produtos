using App.Application.Interfaces;
using App.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._1_WEBAI
{

    public class HealthControllerTests

    {

        private readonly HealthController _controller;
        private readonly Mock<IHealthCheckService> _AppService = new Mock<IHealthCheckService>();


        public HealthControllerTests()
        {
            _controller = new HealthController(_AppService.Object);
        }

        [Fact(DisplayName = "Health Live Ok ")]
        [Trait("Categoria", "Controller - Health OK ")]
        public void HealthLive_Deve_Ok()
        {
            // Arrange
            // Act
            var result = _controller.Live();
            var resultStatus = result as ObjectResult;
            //assert 
            Assert.NotNull(resultStatus);

        }


        [Fact(DisplayName = "Health Read Ok ")]
        [Trait("Categoria", "Controller - Read OK ")]
        public async Task HealthRead_Deve_Ok()
        {
            // Arrange
            _AppService
              .Setup(c => c.HealthCheck()).ReturnsAsync(true);
            // Act
            var result = await _controller.Read();
            var resultStatus = result as StatusCodeResult;

            //assert 
            Assert.NotNull(resultStatus);
            Assert.Equal(202, resultStatus.StatusCode);

        }

        [Fact(DisplayName = "Health Read Error ")]
        [Trait("Categoria", "Controller - Read OK ")]
        public async Task HealthRead_Deve_Error()
        {
            // Arrange
            _AppService.Setup(c => c.HealthCheck())
                              .ReturnsAsync(false);
            // Act
            var result = await _controller.Read();
            var resultStatus = result as BadRequestResult;

            //assert 
            Assert.NotNull(resultStatus);
            Assert.Equal(400, resultStatus.StatusCode);

        }

        [Fact(DisplayName = "Health Read Exception ")]
        [Trait("Categoria", "Controller - Read Exception ")]
        public async Task HealthRead_Deve_Exception()
        {

            // Arrange
            _AppService
                .Setup(c => c.HealthCheck())
                              .Throws(new Exception("Error"));
            var exception = await Assert.ThrowsAsync<Exception>(() => _controller.Read());


            // Assert
            Assert.Equal("Error", exception.Message);


        }
    }
}
