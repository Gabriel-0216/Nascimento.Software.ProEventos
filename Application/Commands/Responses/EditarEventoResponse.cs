namespace Application.Commands.Responses;

public class EditarEventoResponse : Response
{
    public EditarEventoResponse()
    {
    }

    public EditarEventoResponse(int id, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
    {
    }
}