namespace Nascimento.Software.ProEventos.WebApi.Dtos.EventosDto;

public class EventoLoteDto
{
    public int EventoId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public int Quantidade { get; set; }
}