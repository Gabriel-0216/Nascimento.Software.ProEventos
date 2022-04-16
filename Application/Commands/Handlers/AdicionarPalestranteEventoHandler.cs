using Application.Commands.Requests;
using Application.Commands.Responses;
using Infra.Repository.Eventos;
using Infra.Repository.Palestrantes;
using MediatR;

namespace Application.Commands.Handlers;

public class
    AdicionarPalestranteEventoHandler : IRequestHandler<AdicionarPalestranteEventoRequest,
        AdicionarPalestranteEventoResponse>
{
    private readonly IEventoRepository _eventoRepository;
    private readonly IPalestranteRepository _palestranteRepository;

    public AdicionarPalestranteEventoHandler(IEventoRepository eventoRepository,
        IPalestranteRepository palestranteRepository)
    {
        _eventoRepository = eventoRepository;
        _palestranteRepository = palestranteRepository;
    }

    public async Task<AdicionarPalestranteEventoResponse> Handle(AdicionarPalestranteEventoRequest request,
        CancellationToken cancellationToken)
    {
        var response = new AdicionarPalestranteEventoResponse();
        var evento = await _eventoRepository.GetById(request.EventoId, false);
        if (evento is null)
        {
            response.AddError("Evento não encontrado");
            return response;
        }

        var palestrante = await _palestranteRepository.GetPalestranteById(request.PalestranteId, false);
        if (palestrante is null)
        {
            response.AddError("Palestrante não encontrado.");
            return response;
        }

        evento.AdicionarPalestrante(palestrante);
        if (!evento.IsValid)
        {
            response.AddErrors(evento.Notifications.Select(p => $"{p.Key}, {p.Message}").ToList());
            return response;
        }

        if (!await _eventoRepository.Update(evento)) return response;

        response.SetSuccess();
        return response;
    }
}