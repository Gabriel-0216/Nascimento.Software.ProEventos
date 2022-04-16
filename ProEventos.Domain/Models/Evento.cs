using ProEventos.Domain.Models.ValueObjects;

namespace ProEventos.Domain.Models;

public class Evento : BaseEntity
{
    
    public string Tema { get; private set; } = string.Empty;
    public string Local { get; private set; } = string.Empty;
    public int QuantidadePessoas { get; private set; }
    public DateTime DataEvento { get; private set; } 
    public string ImagemUrl { get; private set; } = string.Empty;

    public Telefone? Telefone { get; set; } 
    public Email? Email { get; set; }

    public IList<Lote> Lotes { get; private set; } = new List<Lote>();
    public IList<RedeSocial> RedesSociais { get; private set; } = new List<RedeSocial>();
    public IList<Palestrante> Palestrantes { get; private set; } = new List<Palestrante>();

    public Evento()
    {
        
    }
    public Evento(string tema, string local, int qtdePessoas,
        DateTime dataEvento, string imagemUrl)
    {
        if(string.IsNullOrWhiteSpace(tema)) AddNotification("Tema", VazioNuloMensagem);
        if(string.IsNullOrWhiteSpace(local)) AddNotification("local", VazioNuloMensagem);
        if(string.IsNullOrWhiteSpace(imagemUrl)) AddNotification("imagemUrl", VazioNuloMensagem);
        
        if(qtdePessoas <= 0) AddNotification("QtdePessoas", "Um evento não pode ter quantidade de pessoas menor que zero.");

        if (!IsValid) return;

        Tema = tema;
        Local = local;
        QuantidadePessoas = qtdePessoas;
        DataEvento = dataEvento;
        ImagemUrl = imagemUrl;
    }

    public bool AdicionaTelefoneEvento(int ddd, string numero)
    {
        var telefone = new Telefone(ddd, numero);
        if (!telefone.IsValid) return false;

        Telefone = telefone;
        return true;

    }

    public bool AdicionaEmailEvento(string emailAddress)
    {
        var email = new Email(emailAddress);
        if (!email.IsValid) return false;

        Email = email;
        return true;
    }

    public bool AdicionarLote(Lote lote)
    {
        Lotes.Add(lote);
        return true;
    }

    public bool AdicionarPalestrante(Palestrante palestrante)
    {
        Palestrantes.Add(palestrante);
        return true;
    }

    public bool AdicionaRedeSocial(RedeSocial redeSocial)
    {
        RedesSociais.Add(redeSocial);
        return true;
    }

    
    
    
    
}