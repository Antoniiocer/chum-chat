using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Models;

public enum FriendRequestStatus
{
    Pending,
    Accepted,
    Rejected
}

public interface IFriendRequest
{
    string Id { get; set; }
    FriendRequestStatus Status { get; set; }
    DateTime CreatedAt { get; set; }
    string ReceiverId { get; set; }
    string SenderId { get; set; }
}


public interface IFriendRequestCreator
{
    string? Id { get; set; }
    FriendRequestStatus? Status { get; set; }
    DateTime? CreatedAt { get; set; }
    string ReceiverId { get; set; }
    string SenderId { get; set; }
}

public interface IFriendRequestCreateDto
{
    string ReceiverId { get; set; }
    string SenderId { get; set; }
}

public interface IFriendRequestUpdateDto
{
    string Id { get; set; }
    public FriendRequestStatus Status { get; set; }
}

public interface IFriendRequestDeleteDto
{
    string Id { get; set; }
}