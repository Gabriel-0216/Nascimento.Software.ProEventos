using ProEventos.Domain.Models.ValueObjects;

namespace ProEventos.Domain.Models;

public class Evento : BaseEntity
{
    public Evento()
    {
    }

    public Evento(string tema, string local, int qtdePessoas,
        DateTime dataEvento, string imagemUrl)
    {
        ValidarDados(tema, local, qtdePessoas, dataEvento, imagemUrl);

        if (!IsValid) return;

        Tema = tema;
        Local = local;
        QuantidadePessoas = qtdePessoas;
        DataEvento = dataEvento;
        ImagemUrl = imagemUrl;
    }

    public string Tema { get; private set; } = string.Empty;
    public string Local { get; private set; } = string.Empty;
    public int QuantidadePessoas { get; private set; }
    public DateTime DataEvento { get; private set; }
    public string ImagemUrl { get; private set; } = string.Empty;

    public Telefone? Telefone { get; set; }
    public Email? Email { get; set; }

    public IList<Lote> Lotes { get; } = new List<Lote>();
    public IList<RedeSocial> RedesSociais { get; } = new List<RedeSocial>();
    public IList<Palestrante> Palestrantes { get; } = new List<Palestrante>();

    public bool EditarDadosEvento(string tema, string local, int qtdePessoas, DateTime dataEvento, string imagemUrl)
    {
        ValidarDados(tema, local, qtdePessoas, dataEvento, imagemUrl);

        if (!IsValid) return false;

        Tema = tema;
        Local = local;
        QuantidadePessoas = qtdePessoas;
        DataEvento = dataEvento;
        ImagemUrl = imagemUrl;
        UpdatedAt = DateTime.UtcNow;
        return true;
    }

    public bool AdicionaTelefoneEvento(int ddd, string numero)
    {
        var telefone = new Telefone(ddd, numero);
        if (!telefone.IsValid)
        {
            AddNotifications(telefone.Notifications);
            return false;
        }

        Telefone = telefone;
        return true;
    }

    public bool AdicionaEmailEvento(string emailAddress)
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

    public bool AdicionarLote(Lote lote)
    {
        if (!lote.IsValid)
        {
            AddNotification("Lote", "Não foi possível adicionar o lote");
            AddNotifications(lote.Notifications);
        }

        if (Lotes.Count > 0)
        {
            var qtdeIngressosLotes = Lotes.Sum(item => item.Quantidade);
            if (qtdeIngressosLotes >= QuantidadePessoas || qtdeIngressosLotes + lote.Quantidade >= QuantidadePessoas)
            {
                AddNotification("Quantidade Pessoas", @"A quantidade de ingressos posta a venda é superior a quantidade 
                                        sde pessoas permitidas do evento.");
                return false;
            }
        }

        if (lote.Quantidade > QuantidadePessoas)
            AddNotification("Quantidade pessoas",
                @"Quantidade de ingressos do lote superior a qtde de pessoas permitida.");
        Lotes.Add(lote);
        return true;
    }

    public bool AdicionarPalestrante(Palestrante palestrante)
    {
        if (!palestrante.IsValid)
        {
            AddNotifications(palestrante.Notifications);
            return false;
        }

        Palestrantes.Add(palestrante);
        return true;
    }

    public bool AdicionaRedeSocial(RedeSocial redeSocial)
    {
        if (!redeSocial.IsValid)
        {
            AddNotifications(redeSocial.Notifications);
            return false;
        }

        RedesSociais.Add(redeSocial);
        return true;
    }

    private void ValidarDados(string tema, string local, int qtdePessoas,
        DateTime dataEvento, string imagemUrl)
    {
        if (string.IsNullOrWhiteSpace(tema)) AddNotification("Tema", VazioNuloMensagem);
        if (string.IsNullOrWhiteSpace(local)) AddNotification("local", VazioNuloMensagem);
        if (string.IsNullOrWhiteSpace(imagemUrl)) AddNotification("imagemUrl", VazioNuloMensagem);
        if (dataEvento < DateTime.UtcNow)
            AddNotification("Data Evento", "A data do evento não pode ser menor que a data atual.");
        if (qtdePessoas <= 0)
            AddNotification("QtdePessoas", "Um evento não pode ter quantidade de pessoas menor que zero.");
    }
}