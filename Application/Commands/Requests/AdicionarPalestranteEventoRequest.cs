using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class AdicionarPalestranteEventoRequest : IRequest<AdicionarPalestranteEventoResponse>
{
    public int PalestranteId { get; set; }
    public int EventoId { get; set; }
}