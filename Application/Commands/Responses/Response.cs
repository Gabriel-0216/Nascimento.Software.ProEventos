namespace Application.Commands.Responses;

public class Response
{
    protected Response(int id, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    protected Response()
    {
        
    }

    public void SetSuccess(int id, DateTime createdAt, DateTime updatedAt)
    {
        if (Errors.Count > 0) return;

        Success = true;
    }

    public void SetSuccess()
    {
        if (Errors.Count > 0) return;
        
        Success = true;
    }

    public void AddError(string error) => Errors.Add(new Error(error));
    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public bool Success { get; private set; } = false;
    public IList<Error> Errors { get; private set; } = new List<Error>();

    public record Error(string Mensagem);
}