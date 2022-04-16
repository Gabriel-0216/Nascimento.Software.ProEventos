using Application.Commands.Requests;
using Application.Commands.Responses;
using Infra.Repository.Palestrantes;
using MediatR;
using ProEventos.Domain.Models;

namespace Application.Commands.Handlers;

public class AdicionarPalestranteHandler : IRequestHandler<AdicionarPalestranteRequest, AdicionarPalestranteResponse>
{
    private readonly IPalestranteRepository _palestranteRepository;

    public AdicionarPalestranteHandler(IPalestranteRepository palestranteRepository)
    {
        _palestranteRepository = palestranteRepository;
    }

    public async Task<AdicionarPalestranteResponse> Handle(AdicionarPalestranteRequest request,
        CancellationToken cancellationToken)
    {
        var response = new AdicionarPalestranteResponse();
        var palestrante = new Palestrante(request.Nome, request.Descricao, request.ImagemUrl);
        if (request.EmailAddress is not null) palestrante.AdicionarEmailPalestrante(request.EmailAddress.EmailAddress);
        if (request.TelefoneNumero is not null)
            palestrante.AdicionarTelefonePalestrante(request.TelefoneNumero.Ddd, request.TelefoneNumero.Numero);

        if (!palestrante.IsValid)
        {
            foreach (var item in palestrante.Notifications) response.AddError($"{item.Key}, {item.Message}");

            return response;
        }

        if (await _palestranteRepository.Add(palestrante))
        {
            response.SetSuccess(palestrante.Id, palestrante.CreatedAt, palestrante.UpdatedAt);
            return response;
        }

        response.AddError("Internal server error");
        return response;
    }
}