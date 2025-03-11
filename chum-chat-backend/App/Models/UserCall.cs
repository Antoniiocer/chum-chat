using System.Text.Json.Serialization;
using chum_chat_backend.App.Interfaces.Models;

namespace chum_chat_backend.App.Models;

public class UserCall: IUserCall
{
    public required string UserId { get; set; }
    public required string CallId { get; set; }
    
    //Navigation properties
    public User? User { get; set; }
    public Call? Call { get; set; }
    
}