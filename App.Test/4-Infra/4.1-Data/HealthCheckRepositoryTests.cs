using App.Domain.Interfaces;
using App.Infra.Data.Context;
using App.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace App.Test.ApplicationTest.Unidade
{
    public class HealthCheckRepositoryTests
    {
        public IHealthCheckRepository _Repository;
        private readonly SqlBDCorpContext _contextoMemory;

        public HealthCheckRepositoryTests()
        {
            _contextoMemory = new SqlBDCorpContext(new DbContextOptionsBuilder<SqlBDCorpContext>()
        .UseInMemoryDatabase(databaseName: "TesteBDCorp" + Guid.NewGuid().ToString())
        .Options
            );
            _Repository = new HealthCheckRepository(_contextoMemory);
        }


        [Trait("Categoria", "HealthCheckRepository")]
        [Fact(DisplayName = "Reading Tudo  OK ")]
        public async Task Reading_Validar_DeveEstarValido()
        {
            //asset
            Assert.True(await _Repository.Reading());
        }



        [Trait("Categoria", "UnidadeRepository")]
        [Fact(DisplayName = "Dispose ")]
        public void Dispose()
        {
            //act
            _Repository.Dispose();
            Assert.NotNull(_Repository);
        }


    }
}
