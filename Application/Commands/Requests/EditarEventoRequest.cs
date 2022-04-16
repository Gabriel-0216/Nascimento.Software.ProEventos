using Application.Commands.Dtos;
using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class EditarEventoRequest : EventoDto, IRequest<EditarEventoResponse>
{
    public int Id { get; set; }
}