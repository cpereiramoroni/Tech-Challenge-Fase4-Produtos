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
    public class TermoAceiteRepositoryTests : SqlBDFichContextTests
    {
        private readonly ITermoAceiteRepository _repository;
        private readonly Mock<IDbConnection> _connection = new();
        private readonly Mock<IDbConnectionFactory> _connectionFactory = new();

        public TermoAceiteRepositoryTests() : base()
        {
            _connectionFactory.Setup(c => c.CreateDbConnection(It.IsAny<DatabaseConnectionName>())).Returns(_connection.Object);
            _repository = new TermoAceiteRepository(_connectionFactory.Object, base._persist);
        }


        #region AddTermoAceite
        [Trait("Categoria", "TermoAceiteRepository")]
        [Fact(DisplayName = "AddTermoAceite OK")]
        public async Task AddTermo_OK()
        {
            //Arrange
            TermoAceiteBD termo = BaseMockTest.NewModelMock<TermoAceiteBD>();
            //Act
            await _repository.AddTermoAceite(termo);
            //Assert
            Assert.NotNull(_repository);
        }
        #endregion

        #region Get FichaItem
        [Trait("Categoria", "TermoAceite")]
        [Fact(DisplayName = "GetFichaItem")]
        public async Task GetFichaItem_OK()
        {
            // arrange
            var mockRtn = new TermoAceiteBD
            {
                ID_FICH_NR_FICHA = 1234567,
                ID_UNID_CD_UNIDADE_FICHA = 500,
                ID_ITEM_NR_ITEM = 1,
                ID_ITEM_NR_SUBITEM = 0,
                ID_PRSA_CD_PROF_SAUDE = 5,
                ID_STIF_CD_STATUS = 20,
                TAMI_DH_ACEITE = System.DateTime.Now,
                TAMI_NR_IP = "10.55.55.55"

            };

            _connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<TermoAceiteBD>(
                                              It.IsAny<string>(),
                                              It.IsAny<object[]>(),
                                              null,
                                              null, It.IsAny<CommandType>())).ReturnsAsync(mockRtn);
            // act
            var result = await _repository.GetFichaItem(1, 1, 1, 1);

            // assert
            Assert.NotNull(result);

        }
        #endregion

        #region Get Status
        [Trait("Categoria", "TermoAceite")]
        [Fact(DisplayName = "GetStatus")]
        public async Task GetStatus_OK()
        {
            // arrange
            var mockRtn = new TermoAceiteBD
            {
                ID_FICH_NR_FICHA = 1234567,
                ID_UNID_CD_UNIDADE_FICHA = 500,
                ID_ITEM_NR_ITEM = 1,
                ID_ITEM_NR_SUBITEM = 0,
                ID_PRSA_CD_PROF_SAUDE = 5,
                ID_STIF_CD_STATUS = 20,
                TAMI_DH_ACEITE = System.DateTime.Now,
                TAMI_NR_IP = "10.55.55.55"

            };

            _connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<TermoAceiteBD>(
                                              It.IsAny<string>(),
                                              It.IsAny<object[]>(),
                                              null,
                                              null, It.IsAny<CommandType>())).ReturnsAsync(mockRtn);
            // act
            var result = await _repository.GetStatus(1);

            // assert
            Assert.NotNull(result);

        }
        #endregion

        #region Get Termos
        [Trait("Categoria", "TermoAceite")]
        [Fact(DisplayName = "GetTermos")]
        public async Task GetTermos_OK()
        {
            // arrange
            var mockRtn = new TermoAceiteBD
            {
                ID_FICH_NR_FICHA = 1234567,
                ID_UNID_CD_UNIDADE_FICHA = 500,
                ID_ITEM_NR_ITEM = 1,
                ID_ITEM_NR_SUBITEM = 0,
                ID_PRSA_CD_PROF_SAUDE = 5,
                ID_STIF_CD_STATUS = 0,
                TAMI_DH_ACEITE = System.DateTime.Now,
                TAMI_NR_IP = "10.55.55.55"

            };

            _connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<TermoAceiteBD>(
                                              It.IsAny<string>(),
                                              It.IsAny<object[]>(),
                                              null,
                                              null, It.IsAny<CommandType>())).ReturnsAsync(mockRtn);
            // act
            var result = await _repository.GetTermos(1, 1, 1, 1, 1);

            // assert
            Assert.NotNull(result);

        }
        #endregion

        #region [Dispose]
        [Trait("Categoria", "TermoAceiteRepository")]
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
