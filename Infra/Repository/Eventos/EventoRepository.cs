using Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

    public async Task<IEnumerable<Evento>> GetAll(int skip, int take)
    {
        return await _context.Eventos.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Evento?> GetById(int id, bool asNoTracking)
    {
        return await _context
            .Eventos.Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }
}