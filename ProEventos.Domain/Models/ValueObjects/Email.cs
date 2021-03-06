using Flunt.Notifications;

namespace ProEventos.Domain.Models.ValueObjects;

public class Email : Notifiable<Notification>
{
    public Email(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress)) AddNotification("Email", "Email can't be empty or null");
        if (IsValid) EmailAddress = emailAddress;
    }

    public Email()
    {
    }

    public string EmailAddress { get; }
}