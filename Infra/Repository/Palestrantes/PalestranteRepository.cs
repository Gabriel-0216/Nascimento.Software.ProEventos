using Infra.Context;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace Infra.Repository.Palestrantes;

public class PalestranteRepository : IPalestranteRepository
{
    private readonly AppDbContext _context;

    public PalestranteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Palestrante entity)
    {
        await _context.Palestrantes.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Palestrante entity)
    {
        _context.Palestrantes.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(Palestrante entity)
    {
        _context.Palestrantes.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Palestrante>> SelecionarPalestrantesPorEventoId(int eventoId)
    {
        return await _context
            .Palestrantes
            .Include(p => p.Eventos.Where(id =>
                id.Id == eventoId))
            .ToListAsync();
    }

    public async Task<IEnumerable<Palestrante>> SelecionarPalestrantes(bool incluirRedeSocial, bool incluirEventos)
    {
        IQueryable<Palestrante> query = _context.Palestrantes;
        if (incluirEventos) query = query.Include(p => p.Eventos);
        if (incluirRedeSocial) query = query.Include(p => p.RedesSociais);

        return await query.ToListAsync();
    }

    public async Task<Palestrante?> GetPalestranteById(int id, bool asNoTracking)
    {
        IQueryable<Palestrante> query = _context.Palestrantes;
        if (!asNoTracking) query = query.AsNoTracking();
        return await query.Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}