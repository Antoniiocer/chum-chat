using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Services;

public interface IFriendRequestService
{
    Task<FriendRequest> CreateFriendRequest(FriendRequestCreate friendReq);
    Task<bool> DeleteFriendRequest(FriendRequestDelete friendReq);
    
    Task<FriendRequest?> GetFriendRequest(string id);
    Task<List<FriendRequest>> GetFriendRequests(string chatId);
    Task<Message> UpdateMessage(MessageUpdate message);
}