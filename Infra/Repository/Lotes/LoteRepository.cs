using Infra.Context;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Models;

namespace Infra.Repository.Lotes;

public class LoteRepository : ILoteRepository
{
    private readonly AppDbContext _context;

    public LoteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Add(Lote entity)
    {
        await _context.Lotes.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Lote entity)
    {
        _context.Lotes.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(Lote entity)
    {
        _context.Lotes.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Lote>> GetLotesByEventoId(int eventoId)
    {
        return await _context
            .Lotes
            .Where(p => p.EventoId == eventoId)
            .ToListAsync();
    }

    public async Task<Lote?> GetLoteById(int id)
    {
        return await _context.Lotes
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }
}