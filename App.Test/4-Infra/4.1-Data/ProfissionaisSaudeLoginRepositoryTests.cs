using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Dapper;
using App.Infra.Data.Enum;
using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using App.Test.MockObjects;
using Dapper;
using Moq;
using Moq.Dapper;
using System.Data;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class ProfissionaisSaudeLoginRepositoryTests : SqlBDCorpContextTests
    {
        private readonly IProfissionaisSaudeLoginRepository _repository;
        private readonly Mock<IDbConnection> _connection = new();
        private readonly Mock<IDbConnectionFactory> _connectionFactory = new();

        public ProfissionaisSaudeLoginRepositoryTests()
        {
            _connectionFactory.Setup(c => c.CreateDbConnection(It.IsAny<DatabaseConnectionName>())).Returns(_connection.Object);
            _repository = new ProfissionaisSaudeLoginRepository(base._persist, _connectionFactory.Object);
        }


        #region AddLoginProfissional

        [Trait("Categoria", "ProfissionalSaudeLoginRepository")]
        [Fact(DisplayName = "LoginProfissional OK")]
        public async Task LoginProfissional_OK()
        {
            //Arrange
            LoginUsuario prsa = BaseMockTest.NewModelMock<LoginUsuario>();
            //Act
            await _repository.AddLoginProfissionalSaude(prsa);
            //Assert
            Assert.NotNull(_repository);
        }

        #endregion

        [Trait("Categoria", "ProfissionalSaudeLogin")]
        [Fact(DisplayName = "GetPrsaById")]
        public async Task GetPrsaById_OK()
        {
            // arrange
            var mockRtn = new ProfissionalSaude
            {
                ID_PRSA_CD_PROF_SAUDE = 12345
            };

            _connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<ProfissionalSaude>(
                                              It.IsAny<string>(),
                                              It.IsAny<object[]>(),
                                              null,
                                              null, It.IsAny<CommandType>())).ReturnsAsync(mockRtn);
            // act
            var result = await _repository.GetProfissionalSaudePrsa(1);

            // assert
            Assert.NotNull(result);

        }

        [Trait("Categoria", "ProfissionalSaudeLogin")]
        [Fact(DisplayName = "GetPrsaIdun")]
        public async Task GetPrsaIdun_OK()
        {
            // arrange
            var mockRtn = new LoginUsuario
            {
                ID_IDUN_CD_USUARIO_GEN = 12345
            };

            _connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<LoginUsuario>(
                                              It.IsAny<string>(),
                                              It.IsAny<object[]>(),
                                              null,
                                              null, It.IsAny<CommandType>())).ReturnsAsync(mockRtn);
            // act
            var result = await _repository.GetProfissionalSaudeIdun(1);

            // assert
            Assert.NotNull(result);

        }

        #region [Dispose]
        [Trait("Categoria", "RubricaRepository")]
        [Fact(DisplayName = "Dispose Deve Ser Bem Sucedido")]
        public void Dispose_DeveSerBemSucedido()
        {
            //act
            _repository.Dispose();
            Assert.NotNull(_repository);
        }
        #endregion
    }
}
