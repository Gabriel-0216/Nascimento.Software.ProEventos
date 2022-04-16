using MediatR;
using ProEventos.Domain.Models;

namespace Application.Queries.Query;

public class ListarEventosQuery : IRequest<IEnumerable<Evento>>
{
    public ListarEventosQuery(bool incluirPalestrantes, bool incluirLotes, bool incluirRedesSociais)
    {
        IncluirLotes = incluirLotes;
        IncluirPalestrantes = incluirPalestrantes;
        IncluirRedesSociais = incluirRedesSociais;
    }

    public bool IncluirPalestrantes { get; set; }
    public bool IncluirLotes { get; set; }
    public bool IncluirRedesSociais { get; set; }
}