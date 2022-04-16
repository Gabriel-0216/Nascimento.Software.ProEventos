using Flunt.Notifications;

namespace ProEventos.Domain.Models;

public class BaseEntity : Notifiable<Notification>
{
    public const string VazioNuloMensagem = "Valor não poder ser nulo ou vazio";

    public int Id { get; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}