using Infra.Context;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace Infra.Repository.Eventos;

public class EventoRepository : IEventoRepository
{
    private readonly AppDbContext _context;

    public EventoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Evento entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Evento entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(Evento entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Evento>> ListarEventos(bool incluirRedesSociais, bool incluirPalestrantes,
        bool incluirLotes)
    {
        IQueryable<Evento> query = _context.Eventos;
        if (incluirLotes) query = query.Include(p => p.Lotes);
        if (incluirPalestrantes) query = query.Include(p => p.Palestrantes);
        if (incluirRedesSociais) query = query.Include(p => p.RedesSociais);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Evento>> GetAll(int skip, int take)
    {
        return await _context.Eventos.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Evento?> GetById(int id, bool asNoTracking)
    {
        IQueryable<Evento> query = _context.Eventos;
        if (!asNoTracking) query = query.AsNoTracking();
        return await query.Where(p => p.Id == id).FirstOrDefaultAsync();
    }
}