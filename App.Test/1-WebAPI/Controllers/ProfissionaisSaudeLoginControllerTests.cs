using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using App.Application.ViewModels.Request.Base;
using App.Application.ViewModels.Response;
using App.WebAPI.Controllers;
using Corporativo.Result;
using Fleury.Tests;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._1_WebAPI.Controllers
{
    public class ProfissionaisSaudeLoginControllerTests
    {
        public ProfissionaisSaudeLoginController controller;
        private readonly Mock<IProfissionaisSaudeLoginAppService> _appService = new();

        public ProfissionaisSaudeLoginControllerTests()
        {
            controller = new ProfissionaisSaudeLoginController(_appService.Object);
            ControllerBaseTest.GenerateBaseContext(controller);
        }

        #region [Bearer Token]
        [Trait("Categoria", "ProfissionaisSaudeLoginController")]
        [Fact(DisplayName = "Token OK ")]
        public void ProfissionaisSaudeLoginController_DeveContem_Token()
        {
            ControllerBaseTest.Controller_DeveContem_Token(controller);
        }

        [Trait("Categoria", "ProfissionaisSaudeLoginController")]
        [Fact(DisplayName = "Token Error ")]
        public void ProfissionaisSaudeLoginController_NaoDeveContem_Token()
        {
            ControllerBaseTest.Controller_NaoContem_Token(controller);
        }
        #endregion

        #region POST login
        [Trait("Categoria", "ProfissionaisSaudeLoginController")]
        [Fact(DisplayName = "Post OK")]
        public async Task ProfissionaisSaudeLoginController_Post_Ok()
        {
            // Arrange
            var aplicacao = new PostAplicacao
            {
                idAplicacao = "app",
                idMarca = 1
            };

            var id = new IdProfissionalSaude
            {
                idProfissionalSaude = 12345
            };

            _appService.Setup(c => c.PostLogin(It.IsAny<IdProfissionalSaude>(), It.IsAny<PostAplicacao>()))
               .ReturnsAsync(new SuccessResult<LoginCriptografado>(new LoginCriptografado { idProfissionalSaude = 10 }));

            // Act
            var result = await controller.PostLogin(aplicacao, id);
            var statusCodeResult = result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(200, statusCodeResult.StatusCode);
        }


        [Trait("Categoria", "ProfissionaisSaudeLoginController")]
        [Fact(DisplayName = "Post PreconditionFailed ")]
        public async Task ProfissionaisSaudeLoginController_Post_PreconditionFailed()
        {
            //Arrange
            var aplicacao = new PostAplicacao
            {
                idAplicacao = "app",
                idMarca = 1
            };

            var id = new IdProfissionalSaude
            {

            };

            controller.BindViewModelState(aplicacao);
            controller.BindViewModelState(id);

            //Act
            var result = await controller.PostLogin(aplicacao, id);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }
        #endregion


    }
}
