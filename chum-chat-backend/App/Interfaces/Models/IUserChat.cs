using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Models;

public enum UserChatRole
{
    Regular,
    Admin
}

public interface IUserChat
{
    string UserId { get; set; }
    User? User { get; set; }
    string ChatId { get; set; }
    Chat? Chat { get; set; }
    UserChatRole? Role { get; set; }
}