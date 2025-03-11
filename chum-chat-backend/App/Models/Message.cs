using System.Text.Json.Serialization;
using chum_chat_backend.App.Interfaces.Models;
using static chum_chat_backend.App.Utils.Validators;


namespace chum_chat_backend.App.Models
{
    public class Message : IMessage
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        private string _text = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public string ChatId { get; set; }
    
        //Navigation properties
        public User? User { get; set; }
        public Chat? Chat { get; set; }

        
        
        public Message() {}
        
        public Message(IMessageCreator message)
        {
            Id = message.Id ?? Guid.NewGuid().ToString();
            Text = message.Text;
            CreatedAt = message.CreatedAt ?? DateTime.UtcNow;
            UserId = message.UserId;
            ChatId = message.ChatId;
        }

        public string Text 
        {
            get => _text; 
            set => _text = TextValidator(value); 
        }
        
    }

    public class MessageCreate : IMessageCreateDto
    {
        public required string Text { get; set; }
        public required string UserId { get; set; }
        public required string ChatId { get; set; }
    }

    public class MessageUpdate : IMessageUpdateDto
    {
        public required string Id { get; set; }
        public required string Text { get; set; }
    }

    public class MessageDelete : IMessageDeleteDto
    {
        public required string Id { get; set; }
    }
}
