using ProEventos.Domain.Models;

namespace Infra.Repository.Lotes;

public interface ILoteRepository : IRepository<Lote>
{
    Task<IEnumerable<Lote>> GetLotesByEventoId(int eventoId);
    Task<Lote?> GetLoteById(int id);
}