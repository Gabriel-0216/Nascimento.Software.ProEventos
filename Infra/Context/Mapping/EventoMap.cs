using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEventos.Domain.Models;

namespace Infra.Context.Mapping;

public class EventoMap : IEntityTypeConfiguration<Evento>
{
    public void Configure(EntityTypeBuilder<Evento> builder)
    {
        builder.ToTable("Eventos");

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
        
        builder.Property(p => p.Tema)
            .HasMaxLength(100)
            .HasColumnName("Tema")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder.Property(p => p.Local)
            .HasMaxLength(100)
            .HasColumnName("Local")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder.Property(p => p.QuantidadePessoas)
            .HasColumnName("QuantidadePessoas")
            .HasColumnType("INT")
            .IsRequired();

        builder.Property(p => p.DataEvento)
            .HasColumnName("DataEvento")
            .HasColumnType("DATETIME")
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

        builder.HasMany(p => p.Lotes)
            .WithOne(p => p.Evento);

        builder.HasMany(p => p.RedesSociais)
            .WithOne(p => p.Evento);

        builder.HasMany(p => p.Palestrantes)
            .WithMany(p => p.Eventos)
            .UsingEntity<Dictionary<string, object>>("PalestranteEvento",
                palestrante => palestrante.HasOne<Palestrante>()
                    .WithMany()
                    .HasForeignKey("PalestranteId")
                    .HasConstraintName("FK_PalestranteEvento_PalestranteId")
                    .OnDelete(DeleteBehavior.NoAction),
                evento => evento.HasOne<Evento>()
                    .WithMany()
                    .HasForeignKey("EventoId")
                    .HasConstraintName("FK_PalestranteEvento_EventoId")
                    .OnDelete(DeleteBehavior.NoAction));

        builder.Ignore(p => p.Notifications);
        
        

    }
}