namespace ProEventos.Domain.Models;

public class Lote : BaseEntity
{
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime? DataFim { get; private set; }
    public int Quantidade { get; private set; }
    public int EventoId { get; private set; }
    public Evento Evento { get; private set; }

    public Lote()
    {
        
    }

    public Lote(string nome, decimal preco, DateTime dataInicio, DateTime? dataFim, int qtdeIngressos, Evento evento)
    {
        if(string.IsNullOrWhiteSpace(nome)) AddNotification("Nome", VazioNuloMensagem);
        if(dataInicio <= DateTime.UtcNow) AddNotification("DataInicio", "Data inicio não pdoe ser inferior a data atual");
        if(dataInicio > dataFim) AddNotification("DataFim", "Data inicial não pode ser maior que data final.");

        if (!IsValid) return;

        Nome = nome;
        Preco = preco;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Quantidade = qtdeIngressos;
        EventoId = evento.Id;
        Evento = evento;

    }
}