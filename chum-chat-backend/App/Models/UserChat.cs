using System.Text.Json.Serialization;
using chum_chat_backend.App.Interfaces.Models;

namespace chum_chat_backend.App.Models;

public class UserChat: IUserChat
{
    public required string UserId { get; set; }
    public required string ChatId { get; set; }
    
    //Navigation properties
    public User? User { get; set; } 
    
    public Chat? Chat { get; set; }
    
    public UserChatRole? Role { get; set; } = UserChatRole.Regular;

}