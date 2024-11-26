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
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._1_WebAPI.Controllers
{
    public class ProfissionaisSaudeControllerTests
    {
        public ProfissionaisSaudeController controller;
        private readonly Mock<IPSAppService> _appService = new Mock<IPSAppService>();

        public ProfissionaisSaudeControllerTests()
        {
            controller = new ProfissionaisSaudeController(_appService.Object);
            ControllerBaseTest.GenerateBaseContext(controller);
        }

        #region [Bearer Token]

        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "Token OK ")]
        public void ProfissionaisSaudesController_DeveContem_Token()
        {
            ControllerBaseTest.Controller_DeveContem_Token(controller);
        }

        [Trait("Categoria", "ProfissionaisSaudesController")]
        [Fact(DisplayName = "Token Error ")]
        public void ProfissionaisSaudesController_NaoDeveContem_Token()
        {
            ControllerBaseTest.Controller_NaoContem_Token(controller);
        }

        #endregion

        #region POST

        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "Post OK")]

        public async Task ProfissionaisSaudeController_Post_Ok()
        {
            //Arrange
            var postProfissionalSaude = MockPostPF.OK().FirstOrDefault();

            var rtn = BaseMockTest.NewModelMock<ProfissionalSaude>(true);
            _appService.Setup(x => x.Post(It.IsAny<PostProfissionalSaude>()))
                .ReturnsAsync(new CreatedResult<ProfissionalSaude>(rtn));

            //Act

            var result = await controller.Post(postProfissionalSaude);
            var statusCodeResult = result as IStatusCodeActionResult;
            //Assert

            Assert.Equal(201, statusCodeResult.StatusCode);
        }


        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "Post PreconditionFailed ")]
        public async Task ProfissionaisSaudesController_Post_PreconditionFailed()
        {


            var observacao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = "12",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "asdf",
                anoFormacao = 1998,
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = "123",
                numeroFicha = observacao,
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            controller.BindViewModelState(postProfissionalSaude);


            //Act
            var result = await controller.Post(postProfissionalSaude);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }


        #endregion

        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "Post PreconditionFailed ")]
        public async Task ProfissionaisSaudesController_Post_PreconditionFailed_Automatizado()
        {
            foreach (var item in MockPostPF.PreCondition())
            {
                controller.BindViewModelState(item);


                //Act
                var result = await controller.Post(item);
                var statusCodeResult = result as IStatusCodeActionResult;

                //Assert
                Assert.NotNull(result);
                Assert.Equal(412, statusCodeResult.StatusCode);
            }
        }

        #region Post TermoAceite
        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "PostTermoAceite OK")]

        public async Task ProfissionaisSaudeController_PostTermoAceite_Ok()
        {
            //Arrange
            var postTermo = MockPostPF.OkTermo();
            var idProfissionalSaude = MockPostPF.OKIdLogin();

            _appService.Setup(x => x.PostTermoAceite(It.IsAny<IdProfissionalSaude>(), It.IsAny<PostTermoAceite>()))
                .ReturnsAsync(new CreatedResult<string>("Criado com sucesso."));

            //Act
            var result = await controller.PostTermoAceite(idProfissionalSaude, postTermo);
            var statusCodeResult = result as IStatusCodeActionResult;
            //Assert

            Assert.Equal(201, statusCodeResult.StatusCode);
        }

        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "PostTermo PreconditionFailed ")]
        public async Task ProfissionaisSaudesTermo_Post_PreconditionFailed()
        {

            //Arrange
            var idProfissionalSaude = MockPostPF.OKIdLogin();
            var postTermo = new PostTermoAceite
            {
                idFicha = "123",
                idItem = 1,
                idStatus = null,
                numeroIp = null
            };
            controller.BindViewModelState(postTermo);


            //Act
            var result = await controller.PostTermoAceite(idProfissionalSaude, postTermo);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }

        #endregion

        #region PATCH /profissionais-saude/{idProfissionalSaude}
        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "PATCH profissionais-saude OK")]

        public async Task ProfissionaisSaudePatch_Controller_Ok()
        {
            //Arrange
            var idProfissionalSaude = MockPostPF.OKIdLogin();

            var patch = new PatchProfissionalSaude
            {
                idUsuarioAlteracao = 123,
                motivoAlteracao = "motivo"
            };

            controller.BindViewModelState(idProfissionalSaude);
            controller.BindViewModelState(patch);


            _appService.Setup(x => x.PatchProfissionalSaude(It.IsAny<IdProfissionalSaude>(), It.IsAny<PatchProfissionalSaude>()))
                .ReturnsAsync(new SuccessResult<string>("atualizado"));

            //Act
            var result = await controller.PatchProfissionalSaude(idProfissionalSaude, patch);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Trait("Categoria", "ProfissionaisSaudeController")]
        [Fact(DisplayName = "PATCH profissionais-saud PreconditionFailed ")]
        public async Task ProfissionaisSaudePatch_Controller_PreconditionFailed()
        {
            //Arrange
            var idProfissionalSaude = MockPostPF.OKIdLogin();
            var patch = new PatchProfissionalSaude
            {
                idUsuarioAlteracao = 123,
                motivoAlteracao = null,
                conselhoRegional = null,
                numeroCertificado = null,
                ufCertificado = null,
                idStatus = 6
            };
            controller.BindViewModelState(patch);

            //Act
            var result = await controller.PatchProfissionalSaude(idProfissionalSaude, patch);
            var statusCodeResult = result as IStatusCodeActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(412, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
