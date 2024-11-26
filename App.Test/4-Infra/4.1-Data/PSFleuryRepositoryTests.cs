using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using App.Test.MockObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class PSFleuryTests : SqlBDCorpContextTests
    {
        private readonly IPSFleuryRepository _repository;


        public PSFleuryTests() : base()
        {
            _repository = new PSFleuryRepository(base._read, base._persist);
        }

        #region GetProfissionaisSaudeById
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetProfissionaisSaudeById OK")]

        public async Task GetProfissionalSaudeById()
        {
            //Arrange
            var idProfissionalSaude = 431;

            //Act
            var result = await _repository.GetProfissionalSaudeById(idProfissionalSaude);

            //Assert

            Assert.Null(result);
        }
        #endregion

        #region GetPSFleuryByIdProfissionalSaude
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetProfissionaisSaudeById OK")]

        public async Task GetPSFleuryByIdProfissionalSaude_OK()
        {
            //Arrange
            var idProfissionalSaude = 451;

            //Act
            var result = await _repository.GetPSFleuryByIdProfissionalSaude(idProfissionalSaude);

            //Assert
            Assert.NotNull(result);
        }
        #endregion

        #region AddProfissionalSaudeFleury
        [Trait("Categoria", "ProfissionalSaudeFleury")]
        [Fact(DisplayName = "AddProfissionalSaudeFleury OK")]
        public async Task AddProfissionalSaudeFleury_OK()
        {
            //Arrange
            ProfissionalSaudeFleury profissionalSaudeFleury = BaseMockTest.NewModelMock<ProfissionalSaudeFleury>();

            //Act
            await _repository.AddProfissionalSaudeFleury(profissionalSaudeFleury);

            //Assert
            Assert.NotNull(_repository);
        }
        #endregion


        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetProfissionalSaudeFleuryById OK")]
        public async Task GetProfissionalSaudeFleuryById_OK()
        {
            // Arrange
            int idProfissionalSaudeFleury = 123;

            // Act
            IList<ProfissionalSaudeFleury> result = await _repository.GetProfissionalSaudeFleuryById(idProfissionalSaudeFleury);

            // Assert
            Assert.NotNull(result);
        }

        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetProfissionaisSaudeFleuryByListId OK")]
        public async Task GetProfissionaisSaudeFleuryByListId_OK()
        {
            // Arrange
            List<int> listIdsProfissionalSaudeFleury = new List<int> { 123, 456 }; // Defina uma lista de IDs válidos para teste

            // Act
            IList<ProfissionalSaudeFleury> result = await _repository.GetProfissionaisSaudeFleuryByListId(listIdsProfissionalSaudeFleury);

            // Assert
            Assert.NotNull(result);
        }

        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetIdMedicoFleuryByIdProfissionalSaude OK")]
        public async Task GetIdMedicoFleuryByIdProfissionalSaude_OK()
        {
            // Arrange
            int idProfissionalSaude = 123; // Defina um ID válido para teste

            // Act
            IList<ProfissionalSaudeFleury> result = await _repository.GetIdMedicoFleuryByIdProfissionalSaude(idProfissionalSaude);

            // Assert
            Assert.NotNull(result);
        }

        #region [Dispose]
        [Trait("Categoria", "LiberarsRepository")]
        [Fact(DisplayName = "DisposeBase ")]
        public void DisposeBase()
        {
            //act
            _repository.Dispose();
            Assert.NotNull(_repository);
        }
        #endregion
    }
}
