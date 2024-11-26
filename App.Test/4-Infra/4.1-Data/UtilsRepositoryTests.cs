//using App.Domain.Interfaces;
//using App.Domain.Models;
//using App.Infra.Data;
//using App.Infra.Data.Repository;
//using App.Test._4_Infra._4._1_Data.Context;
//using App.Test.MockObjects;
//using Dapper;
//using Microsoft.Extensions.Configuration;
//using Moq;
//using Moq.Dapper;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;

//namespace App.Test._4_Infra._4._1_Data
//{
//    public  class UtilsRepositoryTests : SqlBDCorpContextTests
//    {
//        public IUtilsRepository _repository;

//        private readonly Mock<IDbConnectionFactory> _connectionFactory = new Mock<IDbConnectionFactory>();
//        private readonly Mock<IDbConnection> _connection = new Mock<IDbConnection>();

//        private readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
//        public UtilsRepositoryTests() : base()
//        {
//            _connectionFactory.Setup(x => x.CreateDbConnection(It.IsAny<string>()))
//                .Returns(_connection.Object);
//            _repository = new UtilsRepository(_connectionFactory.Object, _configuration.Object);
//        }

//        #region GetUtilsById

//        [Trait("Categoria","UtilsRepository")]
//        [Fact(DisplayName = "SP_LOGIN OK")]
//        public async Task SP_LOGIN_OK()
//        {
//            var list = BaseMockTest.ListNewModelMock<SpCpLogin>(1);

//            _connection.SetupDapperAsync(c => c.QuerySingleAsync<SpCpLogin>(
//                                                 It.IsAny<string>(),
//                                                 It.IsAny<object[]>(),
//                                                 null,
//                                                 null, It.IsAny<CommandType>())).ReturnsAsync(list.FirstOrDefault());
//            //Act
//            var result = await _repository.SP_LOGIN(10);

//            //Assert
//            Assert.True(result!=null);
//        }

//        #endregion


//        #region [Dispose]

//        [Trait("Categoria", "Dispose")]
//        [Fact(DisplayName = "DisposeBase ")]
//        public void DisposeBase()
//        {
//            //act
//            _repository.Dispose();
//            Assert.NotNull(_repository);


//        }

//        #endregion
//    }
//}
