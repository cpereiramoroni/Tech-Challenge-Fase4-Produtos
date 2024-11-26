using App.Domain.Models.MongoSettings;
using App.Infra.Data.Context;
using App.Infra.Data.Dapper;
using App.Infra.Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace App.WebAPI.Configurations
{
    public static class DatabaseConfig
    {
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void AddDatabaseConfiguration(this IServiceCollection services)
        {

            services.AddDbContext<SqlBDCorpContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("BDCORP")));

            services.AddDbContext<SqlBDFichContext>(options =>
               options.UseSqlServer(Environment.GetEnvironmentVariable("BDFICH")));

            services.AddDbContext<SqlBDCorpReadContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("BDCORP") + ";ApplicationIntent=ReadOnly"));

            services.AddDbContext<SqlBDCorpLOGContext>(options =>
             options.UseSqlServer(Environment.GetEnvironmentVariable("BDCORP_LOG")));

            services.AddDbContext<SqlBDCorpCentdiagContext>(options =>
             options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CENTDIAG")));

            services.AddDbContext<SqlBDCorpCentdiagReadContext>(options =>
             options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CENTDIAG") + ";ApplicationIntent=ReadOnly"));

            var CENTDIAG = Environment.GetEnvironmentVariable("DB_CENTDIAG");

            var connectionDict = new Dictionary<DatabaseConnectionName, string>
            {
                { DatabaseConnectionName.BDCORP,  Environment.GetEnvironmentVariable("BDCORP") },
                { DatabaseConnectionName.DBCENTDIAG , CENTDIAG }
            };
            services.AddSingleton<IDictionary<DatabaseConnectionName, string>>(connectionDict);
            services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();

            services.AddSingleton<IMongoDbSettings>(_ => new MongoDbSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("MONGODB"),
                DatabaseName = Environment.GetEnvironmentVariable("DATABASE")
            });
        }
    }
}
