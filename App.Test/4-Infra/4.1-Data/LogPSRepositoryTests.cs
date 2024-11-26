using App.Domain.Interfaces;

using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class LogPSRepositoryTests : SqlBDCorpLOGContextTests
    {
        public ILogPSRepository _repository;
        public LogPSRepositoryTests() : base()
        {
            _repository = new LogPSRepository(base._contextoMemory);
        }

        #region GetLogPSById

        [Trait("Categoria", "LogPSRepository")]
        [Fact(DisplayName = "InsertLog OK")]
        public async Task InsertLog_OK()
        {
            Environment.SetEnvironmentVariable("UserBD", "teste_user");
            //Act
            await _repository.InsertLog(10, null, null, true);

            //Assert
            Assert.True(base._contextoMemory.LogsProfissionaisSaude.Any(z => z.ID_PRSA_CD_PROF_SAUDE == 10));
        }

        #endregion


        #region [Dispose]

        [Trait("Categoria", "Dispose")]
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
