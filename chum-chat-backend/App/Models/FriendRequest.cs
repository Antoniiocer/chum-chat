using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public class FriendRequest(IUser user, IUser friend) : IFriendRequest
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public IUser User { get; } = user;
    public IUser Friend { get; } = friend;
    public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Pending;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}