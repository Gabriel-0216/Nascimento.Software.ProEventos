using Infra.Context.Mapping;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace Infra.Context;

public class AppDbContext : DbContext
{
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Palestrante> Palestrantes { get; set; }
    public DbSet<RedeSocial> RedesSociais { get; set; }
    public DbSet<Lote> Lotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            @"Server=localhost,1433;Database=ProEventos-App;User ID=sa;Password=1q2w3e4r@#$; TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EventoMap());
        modelBuilder.ApplyConfiguration(new LoteMap());
        modelBuilder.ApplyConfiguration(new RedeSocialMap());
        modelBuilder.ApplyConfiguration(new PalestranteMap());
    }
}