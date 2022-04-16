using Application.Commands.Requests;
using Application.Commands.Responses;
using Infra.Repository.Eventos;
using MediatR;
using ProEventos.Domain.Models;

namespace Application.Commands.Handlers;

public class AdicionarLoteEventoHandler : IRequestHandler<AdicionarLoteEventoRequest, AdicionarLoteEventoResponse>
{
    private readonly IEventoRepository _eventoRepository;

    public AdicionarLoteEventoHandler(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public async Task<AdicionarLoteEventoResponse> Handle(AdicionarLoteEventoRequest request, CancellationToken cancellationToken)
    {
        var adicionarLoteResponse = new AdicionarLoteEventoResponse();
        var evento = await _eventoRepository.GetById(request.EventoId, true);
        if (evento is null)
        {
            adicionarLoteResponse.AddError("Evento não existe");
            return adicionarLoteResponse;
        }
        
        var lote = new Lote(request.Nome, request.Preco, request.DataInicio,
            request.DataFim, request.Quantidade, evento);
        if (!lote.IsValid)
        {
            foreach (var item in lote.Notifications)
            {
                adicionarLoteResponse.AddError($"{item.Key}, {item.Message}");
                return adicionarLoteResponse;
            }
        }
                
        evento.AdicionarLote(lote);
        var inserted = await _eventoRepository.Update(evento);
        if (inserted)
        {
            var response = new AdicionarLoteEventoResponse(lote.Id, evento.Id, lote.CreatedAt, lote.UpdatedAt);
            response.SetSuccess();
            return response;
        }
        adicionarLoteResponse.AddError("Não foi possível adicionar");
        return adicionarLoteResponse;
    }
}