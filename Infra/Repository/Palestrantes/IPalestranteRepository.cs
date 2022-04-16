using ProEventos.Domain.Models;

namespace Infra.Repository.Palestrantes;

public interface IPalestranteRepository : IRepository<Palestrante>
{
    Task<IEnumerable<Palestrante>> SelecionarPalestrantesPorEventoId(int eventoId);
    Task<IEnumerable<Palestrante>> SelecionarPalestrantes();
    Task<Palestrante?> GetPalestranteById(int id);
    
}