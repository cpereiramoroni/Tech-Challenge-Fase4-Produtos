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
    public class RubricaRepositoryTests : SqlBDCorpCentdiagContextTests
    {
        private readonly IRubricaRepository _repository;
        private readonly Mock<IDbConnection> _connection = new();
        private readonly Mock<IDbConnectionFactory> _connectionFactory = new();

        public RubricaRepositoryTests()
        {
            _connectionFactory.Setup(c => c.CreateDbConnection(It.IsAny<DatabaseConnectionName>())).Returns(_connection.Object);
            _repository = new RubricaRepository(base._read, base._persist, _connectionFactory.Object);
        }

        #region ExisteRubrica
        [Trait("Categoria", "RubricaRepository")]
        [Fact(DisplayName = "ExisteRubrica Deve Retornar FALSE Quando Rubrica Inexistetente")]
        public async Task ExisteRubrica_DeveRetornarFalseQuandoRubricaInexistente()
        {
            // Arrange
            int idProfissionalSaudeFleuryExistente = 8; // Defina um ID válido para a rubrica existente no banco de dados de teste

            // Act
            var result = await _repository.ExisteRubrica(idProfissionalSaudeFleuryExistente);

            // Assert
            Assert.False(result);
        }
        #endregion

        #region NaoExisteRubrica
        [Trait("Categoria", "RubricaRepository")]
        [Fact(DisplayName = "Nao ExisteRubrica Deve Retornar FALSE Quando Rubrica Inexistetente")]
        public async Task ExistemRubricas_DeveRetornarFalseQuandoRubricaInexistente()
        {
            // Arrange
            int idProfissionalSaudeFleuryExistente = 0; // Defina um ID válido para a rubrica existente no banco de dados de teste

            // Act
            var result = await _repository.ExisteProfissionalSaudeFleuryNaRubrica(idProfissionalSaudeFleuryExistente);

            // Assert
            Assert.False(result);
        }
        #endregion

        #region CallRubricaProcedure
        [Trait("Categoria", "RubricaRepository")]
        [Fact(DisplayName = "CallRubricaProcedure Deve Executar Com Sucesso")]
        public async Task CallRubricaProcedure_DeveExecutarComSucesso()
        {
            // Arrange
            var idProfissionalSaudeFleury = 456;
            var base64RubricaGif = "R0lGODlhAQABAIAAAAUEBAAAACwAAAAAAQABAAACAkQBADs=";
            var base64RubricaPng = "iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==";

            var RubricaPF = BaseMockTest.NewModelMock<RubricaProfissionalSaude>();

            _connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<RubricaProfissionalSaude>(It.IsAny<string>(),
                                                It.IsAny<DynamicParameters>(),
                                                It.IsAny<IDbTransaction>(),
                                                It.IsAny<int>(),
                                                It.IsAny<CommandType>())).ReturnsAsync(RubricaPF);

            // Act
            var result = await _repository.CallRubricaProcedure(idProfissionalSaudeFleury, base64RubricaGif, base64RubricaPng);

            // Assert
            Assert.NotNull(result);
        }
        #endregion

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
