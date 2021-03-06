using Application.Commands.Dtos;
using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class AdicionarEventoRequest : EventoDto, IRequest<AdicionarEventoResponse>
{
}