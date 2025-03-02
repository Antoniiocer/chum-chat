using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public class Message(IChat chat, IUser sender, string text) : IMessage
{
    public string Id { get; }  = Guid.NewGuid().ToString();
    private string _text = TextValidator(text);
    public DateTime Date { get; } = DateTime.UtcNow;
    
    public IUser Sender { get; } = sender;
    public IChat Chat { get; } = chat;
    
    
    public string Text { get => _text; set => _text = TextValidator(value); }

    private static string TextValidator(string text)
    {
        if (text.Length <= 100) return text;
        throw new ArgumentException("Text must be between 100 characters.");
    }
}