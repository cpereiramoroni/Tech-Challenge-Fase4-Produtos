using App.Domain.Interfaces;

using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class EspecialidadesRepositoryTests : SqlBDCorpContextTests
    {
        public IEspecialidadesRepository _repository;
        public EspecialidadesRepositoryTests() : base()
        {
            _repository = new EspecialidadesRepository(base._persist);
        }

        #region GetEspecialidadesById

        [Trait("Categoria", "EspecialidadesRepository")]
        [Fact(DisplayName = "GetEspecialidadesById OK")]
        public async Task GetEspecialidadesById_OK()
        {
            //Arrange
            var listIdsEspecialidades = new List<int> { 1, 2 };

            //Act
            var result = await _repository.GetEspecialidadesById(listIdsEspecialidades);

            //Assert
            Assert.True(result.Count == 2);
        }

        #endregion

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
