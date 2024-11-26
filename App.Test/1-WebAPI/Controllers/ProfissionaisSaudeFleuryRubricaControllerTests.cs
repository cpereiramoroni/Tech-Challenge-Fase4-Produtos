using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using App.WebAPI.Controllers;
using Corporativo.Result;
using Fleury.Tests;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._1_WebAPI.Controllers
{
    public class ProfissionaisSaudeFleuryRubricaControllerTests
    {
        public ProfissionaisSaudeRubricaController controller;
        private readonly Mock<IProfissionaisSaudeRubricaAppService> _appService = new();

        public ProfissionaisSaudeFleuryRubricaControllerTests()
        {
            controller = new ProfissionaisSaudeRubricaController(_appService.Object);
            ControllerBaseTest.GenerateBaseContext(controller);
        }

        #region [Bearer Token]
        [Trait("Categoria", "ProfissionaisSaudeFleuryRubricaController")]
        [Fact(DisplayName = "Token OK ")]
        public void ProfissionaisSaudeFleuryRubricaController_DeveContem_Token()
        {
            ControllerBaseTest.Controller_DeveContem_Token(controller);
        }

        [Trait("Categoria", "ProfissionaisSaudeFleuryRubricaController")]
        [Fact(DisplayName = "Token Error ")]
        public void ProfissionaisSaudeFleuryRubricaController_NaoDeveContem_Token()
        {
            ControllerBaseTest.Controller_NaoContem_Token(controller);
        }
        #endregion

        #region POST
        [Trait("Categoria", "ProfissionaisSaudeFleuryRubricaController")]
        [Fact(DisplayName = "Post OK")]
        public async Task ProfissionaisSaudeFleuryRubricaController_Post_Ok()
        {
            // Arrange
            var postRubricaProfissionalSaudeFleury = new PostRubricaProfissionalSaude
            {
                idProfissionalSaude = 404,
                idProfissionalSaudeFleury = 505,
                base64RubricaGif = "1456da321d56sa4ds21a654dsa231d56sa=",
                base64RubricaPng = "fds564fd56f1523ds1f685ds4f6sd156sd4="
            };

            _appService.Setup(x => x.PostRubrica(It.IsAny<PostRubricaProfissionalSaude>()))
                .ReturnsAsync(new CreatedResult<string>(string.Empty));

            // Act
            var result = await controller.PostRubricaProfissionalSaude(postRubricaProfissionalSaudeFleury);
            var statusCodeResult = result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(201, statusCodeResult.StatusCode);
        }


        [Trait("Categoria", "ProfissionaisSaudeFleuryRubricaController")]
        [Fact(DisplayName = "Post PreconditionFailed ")]
        public async Task ProfissionaisSaudeFleuryRubricaController_Post_PreconditionFailed()
        {
            //Arrange
            var postRubricaProfissionalSaudeFleury = new PostRubricaProfissionalSaude
            {
                idProfissionalSaude = 404,
                idProfissionalSaudeFleury = 505,
                base64RubricaGif = "1456da321d56sa4ds21a654dsa231d56sa=",
                base64RubricaPng = "fds564fd56f1523ds1f685ds4f6sd156sd4="
            };

            controller.BindViewModelState(postRubricaProfissionalSaudeFleury);

            //Act
            var result = await controller.PostRubricaProfissionalSaude(postRubricaProfissionalSaudeFleury);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }
        #endregion

        #region PUT
        [Trait("Categoria", "ProfissionaisSaudeFleuryRubricaController")]
        [Fact(DisplayName = "PUT OK")]
        public async Task ProfissionaisSaudeFleuryRubricaController_Put_Ok()
        {
            // Arrange
            int idProfissionalSaudeFleury = 123;

            var putRubricaProfissionalSaudeFleury = new PutRubricaProfissionalSaude
            {
                base64RubricaGif = "1456da321d56sa4ds21a654dsa231d56sa=",
                base64RubricaPng = "fds564fd56f1523ds1f685ds4f6sd156sd4="
            };

            _appService.Setup(x => x.PutRubrica(idProfissionalSaudeFleury, It.IsAny<PutRubricaProfissionalSaude>()))
                .ReturnsAsync(new SuccessResult<string>(null));

            // Act
            var result = await controller.PutRubricaProfissionalSaude(idProfissionalSaudeFleury, putRubricaProfissionalSaudeFleury);
            var statusCodeResult = result as IStatusCodeActionResult;

            // Assert
            Assert.Equal(200, statusCodeResult.StatusCode);
        }


        [Trait("Categoria", "ProfissionaisSaudeFleuryRubricaController")]
        [Fact(DisplayName = "Put PreconditionFailed ")]
        public async Task ProfissionaisSaudeFleuryRubricaController_Put_PreconditionFailed()
        {
            //Arrange
            int idProfissionalSaudeFleury = 123;

            var putRubricaProfissionalSaudeFleury = new PutRubricaProfissionalSaude
            {
                base64RubricaGif = "1456da321d56sa4ds21a654dsa231d56sa=",
                base64RubricaPng = "fds564fd56f1523ds1f685ds4f6sd156sd4="
            };

            controller.BindViewModelState(putRubricaProfissionalSaudeFleury);

            //Act
            var result = await controller.PutRubricaProfissionalSaude(idProfissionalSaudeFleury, putRubricaProfissionalSaudeFleury);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
