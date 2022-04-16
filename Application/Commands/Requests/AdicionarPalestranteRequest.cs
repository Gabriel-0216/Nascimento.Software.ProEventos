using Application.Commands.Responses;
using MediatR;

namespace Application.Commands.Requests;

public class AdicionarPalestranteRequest : IRequest<AdicionarPalestranteResponse>
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string ImagemUrl { get; set; } = string.Empty;
    public Telefone? TelefoneNumero { get; set; }
    public Email? EmailAddress { get; set; }

    public record Telefone(int Ddd, string Numero);

    public record Email(string EmailAddress);
}