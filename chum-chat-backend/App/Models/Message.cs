using chum_chat_backend.App.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Models
{
    public class Message : IMessage
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        private string _text = string.Empty;
        public DateTime Date { get; private set; } = DateTime.UtcNow;

        public string? SenderId { get; private set; }
        public string? ChatId { get; private set; }

        public User? Sender { get; private set; }
        public Chat? Chat { get; private set; }

        public Message() {}
        
        public Message(Chat chat, User sender, string text)
        {
            Sender = sender;
            Chat = chat;
            _text = TextValidator(text);
            SenderId = sender.Id;
            ChatId = chat.Id;
        }

        public string Text 
        {
            get => _text; 
            set => _text = TextValidator(value); 
        }

        private static string TextValidator(string text)
        {
            if (text.Length <= 100) return text;
            throw new ArgumentException("Text must be between 100 characters.");
        }
    }
    
}
