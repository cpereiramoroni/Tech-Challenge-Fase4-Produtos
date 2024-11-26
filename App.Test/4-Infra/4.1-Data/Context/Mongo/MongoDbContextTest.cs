using App.Domain.Interfaces;
using App.Domain.Models;
using App.Domain.Models.MongoSettings;
using App.Infra.Data.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4___Infra._4._1_Data.Repository.Mongo
{
    /// <summary>
    /// mock banco usando findasync com o tempo deve se atualizar novos metodos
    /// </summary>
    /// 



    public class MongoExemploContextTest
    {
        public IMongoDbContext mongoDbContext;
        private readonly Mock<IMongoDatabase> _Database = new Mock<IMongoDatabase>();
        private Mock<IMongoClient> _mockClient = new Mock<IMongoClient>();


        public MongoExemploContextTest()
        {

        }

        #region [GetExemploMongo]

        [Trait("Categoria", "Collection")]
        [Fact(DisplayName = "Collection Tudo  OK ")]
        public async Task GetExemploMongo_DeveEstarValido()
        {
            //arrange

            MongoDbSettings settings = GenerateMockMongo();

            var context = new MongoDbContext(settings);
            var myCollection = context.Collection<AplicacaoBD>();

            Assert.NotNull(myCollection);


        }


        [Trait("Categoria", "Collection")]
        [Fact(DisplayName = "Collection Conexao ja existente ")]
        public async Task GetExemploMongo_Exist_Connection()
        {
            //arrange

            MongoDbSettings settings = GenerateMockMongo();

            var context = new MongoDbContext(settings);
            var myCollection = context.Collection<AplicacaoBD>();
            var myCollection2 = context.Collection<AplicacaoBD>();
            Assert.NotNull(myCollection2);
            Assert.NotNull(myCollection);


        }
        [Trait("Categoria", "GetDatabase")]
        [Fact(DisplayName = "GetDatabase OK ")]
        public async Task GetDatabase_OK()
        {
            //arrange

            MongoDbSettings settings = GenerateMockMongo();

            var context = new MongoDbContext(settings);
            var database = context.GetDatabase();
            Assert.NotNull(database);
        }

        private MongoDbSettings GenerateMockMongo()
        {
            var settings = new MongoDbSettings()
            {
                ConnectionString = "mongodb://tes123",
                DatabaseName = "TestDB"
            };

            _mockClient.Setup(c => c
            .GetDatabase(It.IsAny<string>(), It.IsAny<MongoDatabaseSettings>()))
            .Returns(_Database.Object);

            var list = new List<AplicacaoBD>();
            for (int i = 0; i < 30; i++)
            {
                list.Add(new AplicacaoBD()
                {
                    Id = ObjectId.GenerateNewId(),
                    IdAplicacao = $"IdAplicacao-{i}",
                    IdMarca = i.ToString(),
                    IdSenhaSegura = i + 100.ToString()

                });
            }



            var collection = new Mock<IMongoCollection<AplicacaoBD>>();

            collection.Setup(collection => collection.FindAsync<AplicacaoBD>(It.IsAny<FilterDefinition<AplicacaoBD>>(), null, It.IsAny<CancellationToken>()))
              .ReturnsAsync(
                (FilterDefinition<AplicacaoBD> expression, FindOptions options, CancellationToken token)
                => MongoDbFakeContext.CreateCursor<AplicacaoBD>(list, expression)
                )
                ;


            _Database.Setup(d => d.GetCollection<AplicacaoBD>(It.IsAny<string>(), It.IsAny<MongoCollectionSettings>()))
                .Returns(collection.Object);
            return settings;
        }


        #endregion


        #region [Dispose]

        [Trait("Categoria", "LiberarsRepository")]
        [Fact(DisplayName = "DisposeBase ")]
        public void DisposeBase()
        {
            //act
            MongoDbSettings settings = GenerateMockMongo();
            var context = new MongoDbContext(settings);
            context.Dispose();
            Assert.NotNull(context);


        }

        #endregion
    }
}
