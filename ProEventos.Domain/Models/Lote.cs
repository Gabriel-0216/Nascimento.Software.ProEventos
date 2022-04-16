namespace ProEventos.Domain.Models;

public class Lote : BaseEntity
{
    public Lote()
    {
    }

    public Lote(string nome, decimal preco, DateTime dataInicio, DateTime? dataFim, int qtdeIngressos, Evento evento)
    {
        if (string.IsNullOrWhiteSpace(nome)) AddNotification("Nome", VazioNuloMensagem);
        if (dataInicio <= DateTime.UtcNow)
            AddNotification("DataInicio", "Data inicio não pdoe ser inferior a data atual");
        if (dataInicio > dataFim) AddNotification("DataFim", "Data inicial não pode ser maior que data final.");

        if (!IsValid) return;

        Nome = nome;
        Preco = preco;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Quantidade = qtdeIngressos;
        EventoId = evento.Id;
        Evento = evento;
    }

    public string Nome { get; }
    public decimal Preco { get; }
    public DateTime DataInicio { get; }
    public DateTime? DataFim { get; }
    public int Quantidade { get; }
    public int EventoId { get; }
    public Evento Evento { get; }
}