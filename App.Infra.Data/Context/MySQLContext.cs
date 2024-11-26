using App.Domain.Models;
using App.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;


namespace App.Infra.Data.Context
{
    public class MySQLContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MySQLContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionStringMysql = _configuration.GetConnectionString("ConnectionProdutos");
        //    optionsBuilder.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(connectionStringMysql));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProdutosMap());
        }

        public DbSet<ProdutoBD> Produtos { get; set; }
    }
}
