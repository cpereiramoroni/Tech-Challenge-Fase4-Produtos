using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Repository;
using Microsoft.Extensions.Caching.Memory;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;



namespace App.Test._4_Infra._4._1_Data
{
    public class AplicacoesRepositoryTest : IDisposable
    {
        public IAplicacoesRepository _Repository;
        public IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions { });
        public CacheSettings _cacheSettings = new CacheSettings { Size = 10, TimeOut = 1 };
        private readonly IMongoDbContext _context;


        public AplicacoesRepositoryTest()
        {
            List<AplicacaoBD> listArquivos = new();
            var item = new AplicacaoBD()
            {
                Id = ObjectId.GenerateNewId(),
                IdAplicacao = $"x",
                IdMarca = "1",
                Tipo = Domain.Models.Enum.TypeCrypt.AES.ToString()
            };
            listArquivos.Add(item);
            item = new AplicacaoBD()
            {
                Id = ObjectId.GenerateNewId(),
                IdAplicacao = $"x",
                IdMarca = "1",
                Tipo = Domain.Models.Enum.TypeCrypt.RSA.ToString()
            };
            listArquivos.Add(item);
            _context = new App.Test.Fixtures.Mongo2GoFixture<AplicacaoBD>(listArquivos);
            _Repository = new AplicacoesRepository(_context
                , _memoryCache, _cacheSettings
                );
        }

        [Trait("Categoria", "AplicacoesRepository")]
        [Fact]
        public async Task Detail_Valida_OK()
        {
            //Act
            var rtn = await _Repository.Detail("x", 1);
            var rtnCache = await _Repository.Detail("x", 1);
            //Assert
            Assert.NotNull(rtn);
            Assert.NotNull(rtn.IdAplicacao);
            Assert.NotNull(rtnCache);
            Assert.NotNull(rtnCache.IdAplicacao);


        }


        [Trait("Categoria", "AplicacoesRepository")]
        [Fact]
        public async Task GetAll_Filtro_Vazio()
        {
            //Act
            var rtn = await _Repository.Detail("IdAplicacao-5011", 1);
            //Assert
            Assert.Equal(default, rtn);
        }



        #region [Dispose]

        [Trait("Categoria", "LiberarsRepository")]
        [Fact]
        public void DisposeBase()
        {

            _Repository.Dispose();
            Assert.NotNull(_Repository);


        }

        public void Dispose()
        {
            _Repository.Dispose();
            _context.Dispose();

        }

        #endregion

    }
}
