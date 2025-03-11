using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Models;

public interface IUserCall
{
    string UserId { get; set; }
    string CallId { get; set; }
    User? User { get; set; }
    Call? Call { get; set; }
}