using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces;

public interface ICall
{
    string Id { get; }
    TimeSpan Duration { get; }
    List<User> UserList { get; }
    
}