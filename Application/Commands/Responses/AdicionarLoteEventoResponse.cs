namespace Application.Commands.Responses;

public class AdicionarLoteEventoResponse : Response
{
    public AdicionarLoteEventoResponse()
    {
    }

    public AdicionarLoteEventoResponse(int id, int eventoId, DateTime createdAt, DateTime updatedAt) : base(id,
        createdAt, updatedAt)
    {
        EventoId = eventoId;
    }

    public int EventoId { get; }
}