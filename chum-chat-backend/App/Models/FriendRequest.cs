using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public class FriendRequest : IFriendRequest
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string UserId { get; private set; } = string.Empty;
    public string FriendId { get; private set; } = string.Empty;

    public User? User { get; set; }
    public User? Friend { get; set; }

    public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Pending;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public FriendRequest() {}

    public FriendRequest(string userId, string friendId)
    {
        UserId = userId;
        FriendId = friendId;
    }
}