using Application.Commands.Requests;
using Application.Commands.Responses;
using Infra.Repository.Eventos;
using MediatR;
using ProEventos.Domain.Models;

namespace Application.Commands.Handlers;

public class AdicionarEventoHandler : IRequestHandler<AdicionarEventoRequest, AdicionarEventoResponse>
{
    private readonly IEventoRepository _eventoRepository;

    public AdicionarEventoHandler(IEventoRepository context)
    {
        _eventoRepository = context;
    }

    public async Task<AdicionarEventoResponse> Handle(AdicionarEventoRequest request, CancellationToken cancellationToken)
    {
        var response = new AdicionarEventoResponse();
        
        var eventoModel = new Evento(request.Tema, request.Local, request.QuantidadePessoas, request.DataEvento, request.ImagemUrl);
        eventoModel.AdicionaTelefoneEvento(request.Telefone.Ddd, request.Telefone.Numero);
        eventoModel.AdicionaEmailEvento(request.Email.Email);

        if (!eventoModel.IsValid)
        {
            foreach (var item in eventoModel.Notifications)
            {
                response.AddError($"{item.Key}, {item.Message}");
            }

            return response;
        }

        var inserted = await _eventoRepository.Add(eventoModel);
        if (!inserted)
        {
            response.AddError("Erro ao adicionar");
            return response;
        }
        response.SetSuccess(eventoModel.Id, eventoModel.CreatedAt, eventoModel.UpdatedAt);
        return response;
    }
}