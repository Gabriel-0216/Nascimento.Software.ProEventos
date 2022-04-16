using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain.Models;

namespace Infra.Context.Mapping;

public class PalestranteMap : IEntityTypeConfiguration<Palestrante>
{
    public void Configure(EntityTypeBuilder<Palestrante> builder)
    {
        builder.ToTable("Palestrantes");

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

        builder.Property(p => p.Descricao)
            .HasColumnName("Descricao")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(p => p.ImagemUrl)
            .HasColumnName("ImagemUrl")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.OwnsOne(p => p.Telefone, telefone =>
        {
            telefone.Property(p => p.NumeroTelefone)
                .HasColumnName("NumeroTelefone")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);

            telefone.Ignore(p => p.Notifications);
        });
        builder.OwnsOne(p => p.Email, email =>
        {
            email.Property(p => p.EmailAddress)
                .HasColumnName("EmailAddress")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            email.Ignore(p => p.Notifications);
        });

        builder.HasMany(p => p.RedesSociais)
            .WithOne(p => p.Palestrante);

        builder.HasMany(p => p.Eventos)
            .WithMany(p => p.Palestrantes)
            .UsingEntity<Dictionary<string, object>>("PalestranteEvento",
                evento => evento.HasOne<Evento>()
                    .WithMany()
                    .HasForeignKey("EventoId")
                    .HasConstraintName("FK_PalestranteEvento_EventoId")
                    .OnDelete(DeleteBehavior.NoAction),
                palestrante => palestrante.HasOne<Palestrante>()
                    .WithMany()
                    .HasForeignKey("PalestranteId")
                    .HasConstraintName("FK_PalestranteEvento_PalestranteId")
                    .OnDelete(DeleteBehavior.NoAction));
        
        builder.Ignore(p => p.Notifications);


    }
}