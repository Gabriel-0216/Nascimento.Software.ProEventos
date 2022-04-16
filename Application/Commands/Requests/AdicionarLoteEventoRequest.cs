using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class AdicionarLoteEventoRequest : IRequest<AdicionarLoteEventoResponse>
{
    public int EventoId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public int Quantidade { get; set; }
}