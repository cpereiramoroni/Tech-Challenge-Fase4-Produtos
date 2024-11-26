using App.Application.Services.Util;
using Xunit;

namespace App.Test._2_Aplication.Services
{
    public class ProfissionaisSaudeUtilTests
    {
        private readonly ProfissionaisSaudeUtil _appService;


        public ProfissionaisSaudeUtilTests()
        {
            _appService = new();
        }

        [Trait("Categoria", "ProfissionaisSaudeUtil")]
        [Fact(DisplayName = "IdProfissionalSaudeInexistente OK")]
        public void IdProfissionalSaudeInexistente_OK()
        {


            //Act
            var result = _appService.IdProfissionalSaudeInexistente<string>();

            //Assert
            Assert.True(result != null);
        }


        [Trait("Categoria", "ProfissionaisSaudeUtil")]
        [Fact(DisplayName = "ErrorCTPFNotFound OK")]
        public void ErrorCTPFNotFound_OK()
        {


            //Act
            var result = _appService.ErrorCTPFNotFound<string>();

            //Assert
            Assert.True(result != null);
        }

        [Trait("Categoria", "ProfissionaisSaudeUtil")]
        [Fact(DisplayName = "ErrorIndicacaoNotFound OK")]
        public void ErrorIndicacaoNotFound_OK()
        {


            //Act
            var result = _appService.ErrorIndicacaoNotFound<string>();

            //Assert
            Assert.True(result != null);
        }


        [Trait("Categoria", "ProfissionaisSaudeUtil")]
        [Fact(DisplayName = "ErrorPefiNotFound OK")]
        public void ErrorPefiNotFound_OK()
        {


            //Act
            var result = _appService.ErrorPefiNotFound<string>();

            //Assert
            Assert.True(result != null);
        }

        [Trait("Categoria", "ProfissionaisSaudeUtil")]
        [Fact(DisplayName = " OK")]
        public void ErrorUsuarioNotFound_OK()
        {


            //Act
            var result = _appService.ErrorUsuarioNotFound();

            //Assert
            Assert.True(result != null);
        }



        [Trait("Categoria", "ProfissionaisSaudeUtil")]
        [Fact(DisplayName = "ErrorPRSAduplicated OK")]
        public void ErrorPRSAduplicated_OK()
        {
            var list = MockObjects.BaseMockTest.ListNewModelMock<Domain.Models.ProfissionalSaude>(5);


            //Act
            var result = _appService.ErrorPRSAduplicated<string>(list, "erroTestee");

            //Assert
            Assert.True(result != null);
        }

        [Trait("Categoria", "ProfissionaisSaudeUtil")]
        [Fact(DisplayName = "ErrorMDFLduplicatedFleury OK")]
        public void ErrorMDFLduplicatedFleury_OK()
        {
            var list = MockObjects.BaseMockTest.ListNewModelMock<Domain.Models.ProfissionalSaudeFleury>(5);


            //Act
            var result = _appService.ErrorMDFLduplicatedFleury<string>(list, "erroTestee");

            //Assert
            Assert.True(result != null);
        }
    }
}
