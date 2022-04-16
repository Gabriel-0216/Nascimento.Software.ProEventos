using Application.Queries.Query;
using Infra.Repository.Palestrantes;
using MediatR;
using ProEventos.Domain.Models;

namespace Application.Queries.Handlers;

public class ListarPalestrantesHandler : IRequestHandler<ListarPalestrantesQuery, IEnumerable<Palestrante>>
{
    private readonly IPalestranteRepository _palestranteRepository;

    public ListarPalestrantesHandler(IPalestranteRepository palestranteRepository)
    {
        _palestranteRepository = palestranteRepository;
    }

    public async Task<IEnumerable<Palestrante>> Handle(ListarPalestrantesQuery request,
        CancellationToken cancellationToken)
    {
        return await _palestranteRepository.SelecionarPalestrantes(request.IncluirRedeSocial, request.IncluirEventos);
    }
}