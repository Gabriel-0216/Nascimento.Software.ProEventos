using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain.Models;

namespace Infra.Context.Mapping;

public class RedeSocialMap : IEntityTypeConfiguration<RedeSocial>
{
    public void Configure(EntityTypeBuilder<RedeSocial> builder)
    {
        builder.ToTable("RedesSociais");

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
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Url)
            .HasColumnName("Url")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Ignore(p => p.Notifications);
    }
}