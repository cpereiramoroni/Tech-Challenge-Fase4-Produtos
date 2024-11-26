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
    public class ProfissionaisSaudeEspecialidadesControllerTests
    {
        private readonly ProfissionaisSaudeEspecialidades _controller;
        private readonly Mock<IProfissionaisSaudeEspecialidadesAppService> _appService = new Mock<IProfissionaisSaudeEspecialidadesAppService>();

        public ProfissionaisSaudeEspecialidadesControllerTests()
        {
            _controller = new ProfissionaisSaudeEspecialidades(_appService.Object);
            ControllerBaseTest.GenerateBaseContext(_controller);
        }
        #region [Bearer Token]

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadesController")]
        [Fact(DisplayName = "Token OK ")]
        public void ProfissionaisSaudesController_DeveContem_Token()
        {
            ControllerBaseTest.Controller_DeveContem_Token(_controller);
        }

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadesController")]
        [Fact(DisplayName = "Token Error ")]
        public void ProfissionaisSaudesController_NaoDeveContem_Token()
        {
            ControllerBaseTest.Controller_NaoContem_Token(_controller);
        }

        #endregion

        #region VincularEspecialidade

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadesController")]
        [Fact(DisplayName = "Vincular Especialidade OK ")]
        public async Task ProfissionaisSaudesController_VincularEspecialidade_OK()
        {
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "1,2,3"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades
            {
                motivoAlteracao = "teste",
                idUsuarioAlteracao = 123
            };
            _controller.BindViewModelState(postEspecialidade);

            _appService.Setup(x => x.Post(It.IsAny<IdProfissionalSaude>(), It.IsAny<IdEspecialidade>(), It.IsAny<ProfissionalEspecialidades>()))
                .ReturnsAsync(new CreatedResult<string>(string.Empty));

            _controller.BindViewModelState(profissionalSaude);
            _controller.BindViewModelState(especialidade);
            _controller.BindViewModelState(postEspecialidade);

            //Act
            var result = await _controller.VincularEspecialidades(profissionalSaude, especialidade, postEspecialidade);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadesController")]
        [Fact(DisplayName = "Vincular Especialidade Invalido ")]
        public async Task ProfissionaisSaudesController_VincularEspecialidade_Invalido()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "a"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades
            {
                motivoAlteracao = "teste",
                idUsuarioAlteracao = 123
            };
            _controller.BindViewModelState(profissionalSaude);
            _controller.BindViewModelState(especialidade);
            _controller.BindViewModelState(postEspecialidade);

            //Act
            var result = await _controller.VincularEspecialidades(profissionalSaude, especialidade, postEspecialidade);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }

        #endregion

        #region DeleteEspecialidade
        [Trait("Categoria", "ProfissionaisSaudeEspecialidadesController")]
        [Fact(DisplayName = "DeleteEspecialidade StatusCode 200")]
        public async Task DeleteEspecialidade_StatusCode_200()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var deleteEspecialidade = new DeleteEspecialidade
            {
                idEspecialidade = "1,2,3",
                idUsuarioAlteracao = 1,
                motivoAlteracao = "teste"
            };
            _controller.BindViewModelState(profissionalSaude);
            _controller.BindViewModelState(deleteEspecialidade);

            _appService.Setup(s => s.DeleteEspecialidade(It.IsAny<IdProfissionalSaude>(), It.IsAny<DeleteEspecialidade>()))
                .ReturnsAsync(new SuccessResult<string>("ok"));

            //Act
            var result = await _controller.DeleteEspecialidade(profissionalSaude, deleteEspecialidade);
            var statusCodeResult = result as IStatusCodeActionResult;
            //Assert

            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadesController")]
        [Fact(DisplayName = "DeleteEspecialidade StatusCode 412")]
        public async Task DeleteEspecialidade_StatusCode_412()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {

            };
            var deleteEspecialidade = new DeleteEspecialidade
            {

            };
            _controller.BindViewModelState(profissionalSaude);
            _controller.BindViewModelState(deleteEspecialidade);

            _appService.Setup(s => s.DeleteEspecialidade(It.IsAny<IdProfissionalSaude>(), It.IsAny<DeleteEspecialidade>()))
                .ReturnsAsync(new SuccessResult<string>("ok"));

            //Act
            var result = await _controller.DeleteEspecialidade(profissionalSaude, deleteEspecialidade);
            var statusCodeResult = result as IStatusCodeActionResult;
            //Assert

            Assert.Equal(412, statusCodeResult.StatusCode);
        }


        #endregion
    }
}
