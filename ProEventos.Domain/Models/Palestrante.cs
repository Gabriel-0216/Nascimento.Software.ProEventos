using ProEventos.Domain.Models.ValueObjects;

namespace ProEventos.Domain.Models;

public class Palestrante : BaseEntity
{

    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string ImagemUrl { get; private set; }
    public Telefone? Telefone { get; private set; }
    public Email? Email { get; private set; }
    
    public IList<RedeSocial> RedesSociais { get; private set; }
    public IList<Evento> Eventos { get; private set; }

    public Palestrante()
    {
        
    }

    public Palestrante(string nome, string descricao, string imagemUrl)
    {
        if(string.IsNullOrWhiteSpace(nome)) AddNotification("Nome", VazioNuloMensagem);
        if(string.IsNullOrWhiteSpace(descricao)) AddNotification("Descrição", VazioNuloMensagem);
        if(string.IsNullOrWhiteSpace(imagemUrl)) AddNotification("ImagemUrl", VazioNuloMensagem);

        if (IsValid)
        {
            Nome = nome;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
        }
    }

    public bool AdicionarTelefonePalestrante(int ddd, string numeroTelefone)
    {
        var telefone = new Telefone(ddd, numeroTelefone);
        if (!telefone.IsValid) return false;
        
        Telefone = telefone;
        return true;
    }

    public bool AdicionarEmailPalestrante(string emailAddress)
    {
        var email = new Email(emailAddress);
        if (!email.IsValid) return false;

        Email = email;
        return true;
    }

    public void AdicionarRedeSocialPalestrante()
    {
        
    }
    public void AdicionarPalestranteEvento(Evento evento)
    {
        Eventos.Add(evento);
    }
    
}