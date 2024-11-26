using App.Domain.Models;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data.Context
{
    public class SqlBDFichContextTests : IDisposable
    {
        public SqlBDFichContext _persist;


        public SqlBDFichContextTests()
        {
            var databaseName = "TesteBDFich" + Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<SqlBDFichContext>()
                    .UseInMemoryDatabase(databaseName: databaseName)
                    .Options;
            _persist =
                    new SqlBDFichContext(options);

            InitializeBDAsync();
        }

        #region [Test SqlBDFichContext]
        [Trait("Categoria", "SqlBDFichContext")]
        [Fact(DisplayName = "SqlBDFichContext Valido ")]
        public async Task Context_Validar_DeveEstarValido()
        {
            //act       
            var result = await _persist.TermosAceite.AnyAsync();

            //asset
            Assert.True(result);

        }
        #endregion

        #region InitializeBD
        private void InitializeBDAsync()
        {

            _persist.TermosAceite.Add(new TermoAceiteBD
            {
                ID_FICH_NR_FICHA = 1234567,
                ID_UNID_CD_UNIDADE_FICHA = 500,
                ID_ITEM_NR_ITEM = 1,
                ID_ITEM_NR_SUBITEM = 0,
                ID_PRSA_CD_PROF_SAUDE = 1,
                ID_STIF_CD_STATUS = 20,
                TAMI_DH_ACEITE = DateTime.Now,
                TAMI_NR_IP = "10.55.55.55"

            });
            _persist.SaveChanges();

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

        }
    }
}

