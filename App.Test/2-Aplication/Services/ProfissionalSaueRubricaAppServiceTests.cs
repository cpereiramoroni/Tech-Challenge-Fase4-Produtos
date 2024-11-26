
using App.Application.Interfaces;
using App.Application.Services;
using App.Application.ViewModels.Request;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Test.MockObjects;
using Corporativo.Result;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._2_Aplication.Services
{
    public class ProfissionalSaueRubricaAppServiceTests
    {
        private readonly IProfissionaisSaudeRubricaAppService _appService;

        private readonly Mock<IPSRepository> _psRepository = new();
        private readonly Mock<IPSFleuryRepository> _psFleuryRepository = new();
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly Mock<IRubricaRepository> _rubricaRepository = new();

        public ProfissionalSaueRubricaAppServiceTests()
        {
            _appService = new ProfissionaisSaudeRubricaAppService(_rubricaRepository.Object,
                                                                  _unitOfWork.Object,
                                                                  _psRepository.Object,
                                                                  _psFleuryRepository.Object
                                                                  );
        }

        #region post ProfissionalSaudeFleury
        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "ProfissionaisSaudeRubricaAppService Profissional Saude Fleury Inexistente")]
        public async Task PostRubrica_ProfissionalSaudeFleuryInexistente()
        {
            //Arrange
            var postRubrica = new PostRubricaProfissionalSaude()
            {
                idProfissionalSaude = 498,
                idProfissionalSaudeFleury = 798,
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaude>());

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>());

            //Act
            var result = await _appService.PostRubrica(postRubrica);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }
        #endregion

        #region PostRubrica
        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "ProfissionaisSaudeRubricaAppService Profissional Fleury Inexistente")]
        public async Task PostRubrica_ProfissionalFleuryInexistente()
        {
            //Arrange
            var postRubrica = new PostRubricaProfissionalSaude()
            {
                idProfissionalSaudeFleury = 123,
                idProfissionalSaude = 498,
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaude>());

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaudeFleury>(0));

            //Act
            var result = await _appService.PostRubrica(postRubrica);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "ProfissionaisSaudeRubricaAppService Profissional Saude Inexistente")]
        public async Task PostRubrica_ProfissionalSaudeInexistente()
        {
            //Arrange
            var postRubrica = new PostRubricaProfissionalSaude()
            {
                idProfissionalSaude = 498,
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaude>());

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>());

            //Act
            var result = await _appService.PostRubrica(postRubrica);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "ProfissionaisSaudeRubricaAppService Profissional Saude Fleury Criado")]
        public async Task PostRubrica_ProfissionalSaudeFleuryCriado()
        {
            //Arrange            
            var postRubrica = new PostRubricaProfissionalSaude()
            {
                idProfissionalSaude = 29374,
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));

            _psFleuryRepository.Setup(x => x.GetPSFleuryByIdProfissionalSaude(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaudeFleury>(0));

            _psFleuryRepository.Setup(x => x.AddProfissionalSaudeFleury(It.IsAny<ProfissionalSaudeFleury>()));

            _psFleuryRepository.Setup(s => s.GetIdMedicoFleuryByIdProfissionalSaude(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>
                {
                    new() { ID_MDFL_CD_MEDICO_FLEURY = 8, ID_PRSA_CD_PROF_SAUDE = 101 }
                });

            //Act            
            var result = await _appService.PostRubrica(postRubrica);

            //Assert            
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "ProfissionaisSaudeRubricaAppService Profissional Saude Fleury Inexistente")]
        public async Task PostRubrica_IdProfissionalSaudeFleuryInexistente()
        {
            var postRubrica = new PostRubricaProfissionalSaude()
            {
                idProfissionalSaude = 29374,
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));

            _psFleuryRepository.Setup(x => x.GetPSFleuryByIdProfissionalSaude(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaudeFleury>(0));

            _psFleuryRepository.Setup(x => x.AddProfissionalSaudeFleury(It.IsAny<ProfissionalSaudeFleury>()));

            _psFleuryRepository.Setup(s => s.GetIdMedicoFleuryByIdProfissionalSaude(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>());

            //Act            
            var result = await _appService.PostRubrica(postRubrica);

            //Assert            
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "ProfissionaisSaudeRubricaAppService Rubrica Existente")]
        public async Task PostRubrica_RubricaJaExistente()
        {
            // Arrange
            var postRubrica = new PostRubricaProfissionalSaude
            {
                idProfissionalSaude = 29374,
                base64RubricaGif = "base64RubricaGif",
                base64RubricaPng = "base64RubricaPng"
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));

            _psFleuryRepository.Setup(x => x.GetPSFleuryByIdProfissionalSaude(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaudeFleury>(0));

            _psFleuryRepository.Setup(x => x.AddProfissionalSaudeFleury(It.IsAny<ProfissionalSaudeFleury>()));

            _psFleuryRepository.Setup(s => s.GetIdMedicoFleuryByIdProfissionalSaude(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>
                {
                    new() { ID_MDFL_CD_MEDICO_FLEURY = 8, ID_PRSA_CD_PROF_SAUDE = 101 }
                });

            _rubricaRepository.Setup(r => r.ExisteRubrica(It.IsAny<int>()))
                              .ReturnsAsync(true); // Simula que a rubrica já existe

            // Act
            var result = await _appService.PostRubrica(postRubrica);

            // Assert
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }
        #endregion

        #region PutRubrica
        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "PUT ProfissionaisSaudeRubricaAppService Profissional Saude Inexistente")]
        public async Task PutRubrica_ProfissionalSaudeInexistente()
        {
            //Arrange
            int idProfSaudeFleury = 123;

            var putRubrica = new PutRubricaProfissionalSaude()
            {
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>());

            //Act
            var result = await _appService.PutRubrica(idProfSaudeFleury, putRubrica);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "PUT ProfissionaisSaudeRubricaAppService Profissional Saude Fleury Sucesso")]
        public async Task PutRubrica_ProfissionalSaudeFleurySucesso()
        {
            // Arrange
            int idProfSaudeFleury = 123;

            var putRubrica = new PutRubricaProfissionalSaude()
            {
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>
                {
                new() { ID_MDFL_CD_MEDICO_FLEURY = 123, ID_PRSA_CD_PROF_SAUDE = 101 }
                });

            _rubricaRepository.Setup(r => r.ExisteProfissionalSaudeFleuryNaRubrica(It.IsAny<int>()))
                              .ReturnsAsync(true); // Simula que as rubricas existem.

            // Act
            var result = await _appService.PutRubrica(idProfSaudeFleury, putRubrica);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Success, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "PUT ProfissionaisSaudeRubricaAppService Profissional Saude Fleury Inexistente")]
        public async Task PutRubrica_IdProfissionalSaudeFleuryInexistente()
        {
            //Arrange
            int idProfSaudeFleury = 123;

            var putRubrica = new PutRubricaProfissionalSaude()
            {
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>
                {
                new() { ID_MDFL_CD_MEDICO_FLEURY = 8, ID_PRSA_CD_PROF_SAUDE = 101 }
                });

            //Act            
            var result = await _appService.PutRubrica(idProfSaudeFleury, putRubrica);

            //Assert            
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "PUT ProfissionaisSaudeRubricaAppService Profissional Saude Fleury menor ou igual a zero")]
        public async Task PutRubrica_IdProfissionalSaudeFleuryMenorQueZero()
        {
            //Arrange
            int idProfSaudeFleury = -123;

            var putRubrica = new PutRubricaProfissionalSaude()
            {
                base64RubricaGif = "string",
                base64RubricaPng = "dadsadsa546456d4a="
            };

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>
                {
                new() { ID_MDFL_CD_MEDICO_FLEURY = 8, ID_PRSA_CD_PROF_SAUDE = 101 }
                });

            //Act            
            var result = await _appService.PutRubrica(idProfSaudeFleury, putRubrica);

            //Assert            
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeRubricaAppService")]
        [Fact(DisplayName = "PUT ProfissionaisSaudeRubricaAppService Rubrica Nao Existente")]
        public async Task PutRubrica_RubricaNaoExistente()
        {
            // Arrange
            int idProfSaudeFleury = 123;

            var putRubrica = new PutRubricaProfissionalSaude
            {
                base64RubricaGif = "base64RubricaGif",
                base64RubricaPng = "base64RubricaPng"
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaude>());

            _psFleuryRepository.Setup(x => x.GetProfissionalSaudeFleuryById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaudeFleury>
                {
                new() { ID_MDFL_CD_MEDICO_FLEURY = 123, ID_PRSA_CD_PROF_SAUDE = 101 }
                });

            _rubricaRepository.Setup(r => r.ExisteProfissionalSaudeFleuryNaRubrica(It.IsAny<int>()))
                              .ReturnsAsync(false); // Simula que as rubricas não existe.
            // Act
            var result = await _appService.PutRubrica(idProfSaudeFleury, putRubrica);

            // Assert
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }
        #endregion

        #region [Dispose]
        [Trait("Categoria", "Service")]
        [Fact(DisplayName = "Dispose ")]
        public void Dispose()
        {
            //act
            _appService.Dispose();
            Assert.NotNull(_appService);
        }
        #endregion

    }
}