using Application.Commands.Requests;
using Application.Commands.Responses;
using Infra.Repository.Eventos;
using MediatR;

namespace Application.Commands.Handlers;

public class EditarEventoHandler : IRequestHandler<EditarEventoRequest, EditarEventoResponse>
{
    private readonly IEventoRepository _eventoRepository;

    public EditarEventoHandler(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    public async Task<EditarEventoResponse> Handle(EditarEventoRequest request, CancellationToken cancellationToken)
    {
        var response = new EditarEventoResponse();

        var eventoExists = await _eventoRepository.GetById(request.Id, true);
        if (eventoExists == null)
        {
            response.AddError("Esse evento não existe.");
            return response;
        }

        eventoExists.EditarDadosEvento(request.Tema, request.Local, request.QuantidadePessoas, request.DataEvento,
            request.ImagemUrl);
        eventoExists.AdicionaTelefoneEvento(request.Telefone.Ddd, request.Telefone.Numero);
        eventoExists.AdicionaEmailEvento(request.Email.Email);
        if (!eventoExists.IsValid)
            foreach (var item in eventoExists.Notifications)
            {
                response.AddError($"{item.Key}, {item.Message}");
                return response;
            }

        var updated = await _eventoRepository.Update(eventoExists);
        if (!updated)
        {
            response.AddError("Erro interno do servidor.");
            return response;
        }

        response.SetSuccess(eventoExists.Id, eventoExists.CreatedAt, eventoExists.UpdatedAt);
        return response;
    }
}