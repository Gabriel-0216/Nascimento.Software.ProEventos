using Flunt.Notifications;

namespace ProEventos.Domain.Models.ValueObjects;

public class Telefone : Notifiable<Notification>
{
    public string NumeroTelefone { get; private set; }

    public Telefone()
    {
        
    }

    public Telefone(int ddd, string numero)
    {
        if(ddd > 100) AddNotification("Ddd", "O DDD deve ser menor que três números");
        if(string.IsNullOrWhiteSpace(numero)) AddNotification("Numero", "número de telefone deve ser preenchido.");

        if (IsValid)
        {
            NumeroTelefone = string.Concat($"({ddd})", numero);
        }
    }
    
}