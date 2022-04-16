namespace Application.Commands.Responses;

public class AdicionarPalestranteEventoResponse : Response
{
    public int EventoId { get; set; }
    public int PalestranteId { get; set; }
}