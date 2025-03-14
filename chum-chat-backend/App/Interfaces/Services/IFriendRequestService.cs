using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Services;

public interface IFriendRequestService
{
    Task<FriendRequest> CreateFriendRequest(FriendRequestCreate friendReq);
    Task<FriendRequest?> GetFriendRequest(string id);
    Task<List<FriendRequestUserDto>> GetFriendRequests(string userId);
    Task<List<FriendRequestUserDto>> GetFriends(string userId);
    Task<bool> DeleteFriendRequest(FriendRequestDelete friendReq);
    Task<FriendRequest> UpdateFriendRequest(FriendRequestUpdate friendReq);
}