using App.Domain.Models.BDLog;
using App.Infra.Data.Context;
using App.Test.MockObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data.Context
{
    public class SqlBDCorpLOGContextTests
    {
        public SqlBDCorpLOGContext _contextoMemory;
        public SqlBDCorpLOGContextTests()
        {
            _contextoMemory =
                    new SqlBDCorpLOGContext(new DbContextOptionsBuilder<SqlBDCorpLOGContext>()
                    .UseInMemoryDatabase(databaseName: "TesteBDCorpLog" + Guid.NewGuid().ToString())
                    .Options
                );
            InitializeBDAsync();
        }

        #region [Test SqlBDCorpContext]
        [Trait("Categoria", "SqlDBCorpContext")]
        [Fact(DisplayName = "SqlDBCorpContext Valido ")]
        public async Task Context_Validar_DeveEstarValido()
        {
            //act
            var list = await _contextoMemory.LogsProfissionaisSaude.AnyAsync();
            //asset
            Assert.True(list);
        }
        #endregion

        #region MOCK DB
        private void InitializeBDAsync()
        {
            _contextoMemory.LogsProfissionaisSaude.AddRange(BaseMockTest.ListNewModelMock<LogProfissionalSaude>(10));
            _contextoMemory.SaveChanges();
        }
        #endregion
    }
}
