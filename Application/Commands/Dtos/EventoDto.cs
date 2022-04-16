namespace Application.Commands.Dtos;

public class EventoDto
{
    public string Tema { get; set; } = string.Empty;
    public string Local { get; set; } = string.Empty;
    public int QuantidadePessoas { get; set; }
    public DateTime DataEvento { get; set; } = DateTime.UtcNow;
    public string ImagemUrl { get; set; } = string.Empty;
    public TelefoneDto Telefone { get; set; } = new(000, "0000-0000");
    public EmailDto Email { get; set; } = new(string.Empty);

    public record TelefoneDto(int Ddd, string Numero);

    public record EmailDto(string Email);
}