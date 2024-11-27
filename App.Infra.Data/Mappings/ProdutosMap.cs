using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Mappings
{
    public class ProdutosMap : IEntityTypeConfiguration<ProdutoBD>
    {
        public ProdutosMap()
        {

        }
        public void Configure(EntityTypeBuilder<ProdutoBD> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Preco)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CategoriaId)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();

            builder.ToTable("Produtos");
        }
    }
}
