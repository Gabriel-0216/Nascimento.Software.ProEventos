using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain.Models;

namespace Infra.Context.Mapping;

public class LoteMap : IEntityTypeConfiguration<Lote>
{
    public void Configure(EntityTypeBuilder<Lote> builder)
    {
        builder.ToTable("Lotes");

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(p => p.UpdatedAt)
            .HasColumnName("UpdatedAt")
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Preco)
            .HasColumnName("Preco")
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(p => p.DataInicio)
            .HasColumnName("DataInicio")
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(p => p.DataFim)
            .HasColumnName("DataFim")
            .HasColumnType("DATETIME");

        builder.Property(p => p.Quantidade)
            .HasColumnName("Quantidade")
            .HasColumnType("INT")
            .IsRequired();

        builder.HasOne(p => p.Evento)
            .WithMany(p => p.Lotes);


        builder.Ignore(p => p.Notifications);
    }
}