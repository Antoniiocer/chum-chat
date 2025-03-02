using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces;

public interface IChat
{
    string Id { get; }
    string Name { get;set; }
    string Description { get;set; }
    string Image { get;set; }
    List<User> UserList { get;set; }
    List<Message> MessageList { get;set; }
}