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

    public int Id { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public bool Success { get; private set; }
    public IList<Error> Errors { get; } = new List<Error>();

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

    public void AddErrors(IList<string> errors)
    {
        foreach (var item in errors) Errors.Add(new Error(item));
    }

    public void AddError(string error)
    {
        Errors.Add(new Error(error));
    }

    public record Error(string Mensagem);
}