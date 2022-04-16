namespace Application.Commands.Responses;

public class AdicionarEventoResponse : Response
{
    public AdicionarEventoResponse(int id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
    {
        
    }

    public AdicionarEventoResponse()
    {
        
    }
}