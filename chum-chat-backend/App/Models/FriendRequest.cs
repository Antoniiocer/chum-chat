using chum_chat_backend.App.Interfaces.Models;

namespace chum_chat_backend.App.Models;

public class FriendRequest: IFriendRequest
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    
    //Navigation properties
    public User Sender { get; set; }
    public User Receiver { get; set; }
    

    public FriendRequest() {}

    public FriendRequest(IFriendRequestCreator friendRequest)
    {
       Id = friendRequest.Id ?? Guid.NewGuid().ToString();
       Status = friendRequest.Status ?? FriendRequestStatus.Pending;
       CreatedAt = friendRequest.CreatedAt ?? DateTime.UtcNow;
       SenderId = friendRequest.SenderId;
       ReceiverId = friendRequest.ReceiverId;
    }
}

public class FriendRequestCreate: IFriendRequestCreateDto
{
    public required string SenderId { get; set; }
    public required string ReceiverId { get; set; }
}

public class FriendRequestUpdate : IFriendRequestUpdateDto
{
    public required string Id { get; set; }
    public required FriendRequestStatus Status { get; set; }
}

public class FriendRequestDelete : IFriendRequestDeleteDto
{
    public required string Id { get; set; }
}

public class FriendRequestUserDto : IFriendRequestUserDto
{
    public required string Id { get; set; }
    public required FriendRequestStatus Status { get; set; }
    public required UserChatDto Receiver { get; set; }
    public required UserChatDto Sender { get; set; }
    
}