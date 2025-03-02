using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces;

public enum FriendRequestStatus
{
    Pending,
    Accepted,
    Rejected
}

public interface IFriendRequest
{
    string Id { get; }
    User? User { get; set; } 
    User? Friend { get; set; } 
    FriendRequestStatus Status { get; set; }
    DateTime CreatedAt { get; }
}