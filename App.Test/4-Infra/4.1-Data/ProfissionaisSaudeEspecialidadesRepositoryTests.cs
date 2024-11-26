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
    public class ProfissionaisEspecialidadesRepositoryTests : SqlBDCorpContextTests
    {
        private IProfissionaisEspecialidadesRepository _repository;


        public ProfissionaisEspecialidadesRepositoryTests()
        {
            _repository = new ProfissionaisEspecialidadesRepository(base._persist);
        }

        #region InserirProfissionaisEspecialidades

        [Trait("Categoria", "ProfissionaisEspecialidadesRepository")]
        [Fact(DisplayName = "InserirProfissionalEspecialidade OK")]
        public async Task InserirProfissionaisEspecialidades_OK()
        {
            //Arrange
            var profissionalEspecialidade = new ProfissionalSaudeEspecialidade
            {
                ID_ESPE_CD_ESPEC_MED = 123,
                ID_PRSA_CD_PROF_SAUDE = 123
            };
            var listProfissionaisEspecialidades = new List<ProfissionalSaudeEspecialidade> { profissionalEspecialidade };

            //Act
            await _repository.InserirProfissionaisEspecialidades(listProfissionaisEspecialidades);

            //Assert
            Assert.NotNull(_repository);
        }

        #endregion

        #region GetEspecialidadesCadastradas

        [Trait("Categoria", "ProfissionaisEspecialidadesRepository")]
        [Fact(DisplayName = "GetEspecialidadesCadastradas OK")]
        public async Task GetEspecialidadesCadastradas_OK()
        {
            //Arrange
            var listIdsProfissionaisSaude = new List<int> { 1 };
            var listIdsEspecialidades = new List<int> { 1 };

            //Act
            var result = await _repository.GetEspecialidadesCadastradas(listIdsProfissionaisSaude, listIdsEspecialidades);

            //Assert
            Assert.True(result.Count == 1);
        }


        #endregion

        #region Delete

        [Trait("Categoria", "ProfissionaisEspecialidadesRepository")]
        [Fact(DisplayName = "DeleteEspecialidades Ok")]
        public void DeleteEspecialidades_OK()
        {
            //Arrange
            var vinculos = BaseMockTest.ListNewModelMock<ProfissionalSaudeEspecialidade>(2);

            //Act
            _repository.DeleteEspecialidades(vinculos);

            //Assert
            Assert.NotNull(_repository);
        }

        #endregion

        #region [Dispose]

        [Trait("Categoria", "ProfissionaisEspecialidadesRepository")]
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
