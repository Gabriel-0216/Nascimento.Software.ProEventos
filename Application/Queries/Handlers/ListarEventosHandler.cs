using Application.Queries.Query;
using Infra.Repository.Eventos;
using MediatR;
using ProEventos.Domain.Models;

namespace Application.Queries.Handlers;

public class ListarEventosHandler : IRequestHandler<ListarEventosQuery, IEnumerable<Evento>>
{
    private readonly IEventoRepository _eventoRepository;

    public ListarEventosHandler(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public async Task<IEnumerable<Evento>> Handle(ListarEventosQuery request, CancellationToken cancellationToken)
    {
        return await _eventoRepository.ListarEventos(request.IncluirRedesSociais, request.IncluirPalestrantes,
            request.IncluirLotes);
    }
}