using App.Infra.Data.Dapper;
using App.Infra.Data.Enum;
using System.Collections.Generic;
using Xunit;

namespace App.Test._4_Infra._4._1_Data.Dapper
{
    public class DapperDbConnectionFactoryTests
    {
        private IDbConnectionFactory _dbConnectionFactory;

        [Trait("Categoria", "DapperDbConnectionFactoryTests")]
        [Fact(DisplayName = "CreateDbConnection")]
        public void CreateDbConnection()
        {
            //  Arrange
            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.BDCORP,  "Data Source=moroni.db" }
            };

            _dbConnectionFactory = new DapperDbConnectionFactory(connectionDict);
            var rtn = _dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.BDCORP);

            Assert.NotNull(rtn);
        }

        [Trait("Categoria", "DapperDbConnectionFactoryTests")]
        [Fact(DisplayName = "CreateDbConnection Null")]
        public void CreateDbConnection_null()
        {
            //  Arrange
            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            { };

            _dbConnectionFactory = new DapperDbConnectionFactory(connectionDict);
            var rtn = _dbConnectionFactory.CreateDbConnection(DatabaseConnectionName.BDCORP);

            Assert.Null(rtn);
        }

    }
}
