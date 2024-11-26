using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using App.Application.ViewModels.Response;
using App.Test.MockObjects;
using App.WebAPI.Controllers;
using Corporativo.Result;
using Corporativo.Util.Enum;
using Fleury.Tests;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._1_WebAPI.Controllers
{
    public class ProfissionaisSaudeFleuryControllerTests
    {
        public ProfissionaisSaudeFleuryController controller;
        private readonly Mock<IPSFleuryAppService> _appService = new Mock<IPSFleuryAppService>();

        public ProfissionaisSaudeFleuryControllerTests()
        {
            controller = new ProfissionaisSaudeFleuryController(_appService.Object);
            ControllerBaseTest.GenerateBaseContext(controller);
        }

        #region [Bearer Token]

        [Trait("Categoria", "ProfissionaisSaudeFleuryController")]
        [Fact(DisplayName = "Token OK ")]
        public void ProfissionaisSaudeFleuryController_DeveContem_Token()
        {
            ControllerBaseTest.Controller_DeveContem_Token(controller);
        }

        [Trait("Categoria", "ProfissionaisSaudeFleuryController")]
        [Fact(DisplayName = "Token Error ")]
        public void ProfissionaisSaudeFleuryController_NaoDeveContem_Token()
        {
            ControllerBaseTest.Controller_NaoContem_Token(controller);
        }

        #endregion

        #region POST

        [Trait("Categoria", "ProfissionaisSaudeFleuryController")]
        [Fact(DisplayName = "Post OK")]

        public async Task ProfissionaisSaudeFleuryController_Post_Ok()
        {
            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,

            };

            var rtn = BaseMockTest.NewModelMock<ProfissionalSaudeFleury>(true);
            _appService.Setup(x => x.PostPsFleury(It.IsAny<PostProfissionalSaudeFleury>()))
                .ReturnsAsync(new CreatedResult<ProfissionalSaudeFleury>(rtn));


            //Act

            var result = await controller.PostPsFleury(postProfissionalSaudeFleury);
            var statusCodeResult = result as IStatusCodeActionResult;
            //Assert

            Assert.Equal(201, statusCodeResult.StatusCode);
        }


        [Trait("Categoria", "ProfissionaisSaudeFleuryController")]
        [Fact(DisplayName = "Post PreconditionFailed ")]
        public async Task ProfissionaisSaudeFleuryController_Post_PreconditionFailed()
        {



            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 0,
                categoriaFleury = CategoriaFleury.P,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = null,
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = null,
                divulgaDataNascimento = Status.Nao,
            };
            controller.BindViewModelState(postProfissionalSaudeFleury);


            //Act
            var result = await controller.PostPsFleury(postProfissionalSaudeFleury);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }


        #endregion
    }
}
