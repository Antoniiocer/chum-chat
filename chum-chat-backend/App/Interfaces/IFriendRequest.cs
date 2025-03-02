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
    IUser User { get; }
    IUser Friend { get; }
    FriendRequestStatus Status { get; set; }
    DateTime CreatedAt { get; }
}