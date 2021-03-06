namespace ProEventos.Domain.Models;

public class RedeSocial : BaseEntity
{
    public RedeSocial()
    {
    }

    public RedeSocial(string nome, string url)
    {
        if (string.IsNullOrWhiteSpace(nome)) AddNotification("Nome", VazioNuloMensagem);
        if (string.IsNullOrWhiteSpace(url)) AddNotification("Url", VazioNuloMensagem);

        if (!IsValid) return;

        Nome = nome;
        Url = url;
    }

    public string Nome { get; }
    public string Url { get; }
    public int? EventoId { get; private set; }
    public Evento? Evento { get; private set; }
    public int? PalestranteId { get; private set; }
    public Palestrante? Palestrante { get; private set; }

    public bool AdicionarRedeSocialPalestrante(Palestrante palestrante)
    {
        if (!palestrante.IsValid) return false;

        PalestranteId = palestrante.Id;
        Palestrante = palestrante;
        return true;
    }

    public bool AdicionarRedeSocialEvento(Evento evento)
    {
        if (!evento.IsValid) return false;

        EventoId = evento.Id;
        Evento = evento;
        return true;
    }
}