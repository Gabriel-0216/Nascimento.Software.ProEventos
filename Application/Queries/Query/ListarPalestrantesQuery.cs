using MediatR;
using ProEventos.Domain.Models;

namespace Application.Queries.Query;

public class ListarPalestrantesQuery : IRequest<IEnumerable<Palestrante>>
{
    public ListarPalestrantesQuery(bool incluirEventos, bool incluirRedeSocial)
    {
        IncluirEventos = incluirEventos;
        IncluirRedeSocial = incluirRedeSocial;
    }

    public bool IncluirEventos { get; set; }
    public bool IncluirRedeSocial { get; set; }
}