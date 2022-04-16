using ProEventos.Domain.Models.ValueObjects;

namespace ProEventos.Domain.Models;

public class Palestrante : BaseEntity
{
    public Palestrante()
    {
    }

    public Palestrante(string nome, string descricao, string imagemUrl)
    {
        ValidarDados(nome, descricao, imagemUrl);
        if (!IsValid) return;

        Nome = nome;
        Descricao = descricao;
        ImagemUrl = imagemUrl;
    }

    public string Nome { get; private set; } = string.Empty;
    public string Descricao { get; private set; } = string.Empty;
    public string ImagemUrl { get; private set; } = string.Empty;
    public Telefone? Telefone { get; private set; }
    public Email? Email { get; private set; }

    public IList<RedeSocial> RedesSociais { get; } = new List<RedeSocial>();
    public IList<Evento> Eventos { get; } = new List<Evento>();

    public void AlterarDados(string nome, string descricao, string imagemUrl)
    {
        ValidarDados(nome, descricao, imagemUrl);
        if (!IsValid) return;

        Nome = nome;
        Descricao = descricao;
        ImagemUrl = imagemUrl;
    }

    public bool AdicionarTelefonePalestrante(int ddd, string numeroTelefone)
    {
        var telefone = new Telefone(ddd, numeroTelefone);
        if (!telefone.IsValid)
        {
            AddNotifications(telefone.Notifications);
            return false;
        }

        Telefone = telefone;
        return true;
    }

    public bool AdicionarEmailPalestrante(string emailAddress)
    {
        var email = new Email(emailAddress);
        if (!email.IsValid)
        {
            AddNotifications(email.Notifications);
            return false;
        }

        Email = email;
        return true;
    }

    public void AdicionarRedeSocial(RedeSocial redeSocial)
    {
        if (!redeSocial.IsValid) AddNotifications(redeSocial.Notifications);
        RedesSociais.Add(redeSocial);
    }

    public void AdicionaEvento(Evento evento)
    {
        Eventos.Add(evento);
    }

    private void ValidarDados(string nome, string descricao, string imagemUrl)
    {
        if (string.IsNullOrWhiteSpace(nome)) AddNotification("Nome", VazioNuloMensagem);
        if (string.IsNullOrWhiteSpace(descricao)) AddNotification("Descrição", VazioNuloMensagem);
        if (string.IsNullOrWhiteSpace(imagemUrl)) AddNotification("ImagemUrl", VazioNuloMensagem);
    }
}