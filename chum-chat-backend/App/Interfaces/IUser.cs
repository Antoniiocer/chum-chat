using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces;

public interface IUser
{
    string Id { get; }
    string Username { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    DateTime CreatedAt { get; }
    List<Chat> Chats { get; }
    List<FriendRequest> SentFriendRequests { get; }
    List<FriendRequest> ReceivedFriendRequests { get; }
}