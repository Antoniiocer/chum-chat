using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces;

public interface IMessage
{
    string Id { get; }
    string Text { get;set; }
    DateTime Date { get; }
    User? Sender { get; }
    Chat? Chat { get; }
}