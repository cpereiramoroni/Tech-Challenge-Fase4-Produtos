using App.Domain.Models;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data.Context
{
    public class SqlBDCorpCentdiagContextTests : IDisposable
    {
        public SqlBDCorpCentdiagContext _persist;
        public SqlBDCorpCentdiagReadContext _read;

        public SqlBDCorpCentdiagContextTests()
        {
            var databaseName = "TesteBDCentdiag" + Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<SqlBDCorpCentdiagContext>()
                    .UseInMemoryDatabase(databaseName: databaseName)
                    .Options;
            _persist =
                    new SqlBDCorpCentdiagContext(options);

            _read = new SqlBDCorpCentdiagReadContext(options);
            InitializeBDAsync();
        }

        #region [Test SqlBDCorpContext]
        [Trait("Categoria", "SqlDBCorpContext")]
        [Fact(DisplayName = "SqlDBCorpContext Valido ")]
        public async Task Context_Validar_DeveEstarValido()
        {
            //act
            var resultRubricaProfissionaisSaude = await _persist.RubricaProfissionalSaude.AnyAsync();

            //asset
            Assert.True(resultRubricaProfissionaisSaude);
        }
        #endregion

        #region Test SqlBdCorpReadContext
        [Trait("Categoria", "SqlDBCorpReadContext")]
        [Fact(DisplayName = "SqlDBCorpReadContext ")]
        public async Task ReadContext_Validar_DeveEstarValido()
        {
            //act
            var resultProfissionaisSaude = await _read.RubricaProfissionalSaude.AnyAsync();

            //asset
            Assert.True(resultProfissionaisSaude);
        }
        #endregion

        #region InitializeBD
        private void InitializeBDAsync()
        {
            var listRubricas = new List<RubricaProfissionalSaude>();
            for (int i = 1; i < 11; i++)
            {
                listRubricas.Add(new RubricaProfissionalSaude
                {
                    ID_MDFL_CD_MEDICO_FLEURY = i,
                });
            }

            _persist.RubricaProfissionalSaude.AddRange(listRubricas);

            _persist.SaveChanges();
            CloneForContextRead();
        }

        private void CloneForContextRead()
        {
            _read.RubricaProfissionalSaude = _persist.RubricaProfissionalSaude;
            _read.SaveChanges();
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _persist.Dispose();
            _read.Dispose();
        }
    }
}

