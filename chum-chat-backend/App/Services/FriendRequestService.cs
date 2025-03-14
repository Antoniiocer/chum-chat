using chum_chat_backend.App.Database;
using chum_chat_backend.App.Interfaces.Models;
using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Services;

public class FriendRequestService(ChumChatContext context) : IFriendRequestService
{

    public async Task<FriendRequest> CreateFriendRequest(FriendRequestCreate friendReq)
    {
        var alreadyHasFriendRequest = await context.FriendRequests
            .FirstOrDefaultAsync(fr => 
                (fr.SenderId == friendReq.SenderId && fr.ReceiverId == friendReq.ReceiverId) ||
                (fr.SenderId == friendReq.ReceiverId && fr.ReceiverId == friendReq.SenderId));

        if (alreadyHasFriendRequest != null) 
            throw new Exception("Friend request already exists");

        var newFriendReq = new FriendRequest 
        { 
            SenderId = friendReq.SenderId, 
            ReceiverId = friendReq.ReceiverId 
        };

        context.FriendRequests.Add(newFriendReq);
        await context.SaveChangesAsync();
        return newFriendReq;
    }


    public async Task<FriendRequest?> GetFriendRequest(string id)
    {
        var friendReq = await context.FriendRequests.FindAsync(id);
        if (friendReq == null) throw new InvalidOperationException("Friend Request not found");
        return friendReq;
    }

    public async Task<List<FriendRequestUserDto>> GetFriendRequests(string userId)
    {
        return await context.FriendRequests
            .Include(fr => fr.Sender)
            .Include(fr => fr.Receiver)
            .Where(r => r.SenderId == userId || r.ReceiverId == userId && r.Status != FriendRequestStatus.Accepted)
            .Select(r => new FriendRequestUserDto
            {
                Id = r.Id, 
                Status = r.Status,
                Receiver = new UserChatDto
                {
                    Id = r.Receiver.Id, 
                    Disabled = r.Receiver.Disabled, 
                    Auth0Id = r.Receiver.Auth0Id,
                    Name =  r.Receiver.Name, 
                    Username =  r.Receiver.Username
                },
                Sender = new UserChatDto
                {
                    Id = r.Sender.Id, 
                    Auth0Id = r.Sender.Auth0Id,
                    Disabled = r.Sender.Disabled, 
                    Name =  r.Sender.Name, 
                    Username =  r.Sender.Username
                }
            })
            .ToListAsync();
    }

    public async Task<List<FriendRequestUserDto>> GetFriends(string userId)
    {
        return await context.FriendRequests
            .Include(fr => fr.Sender)
            .Include(fr => fr.Receiver)
            .Where(r => r.SenderId == userId || r.ReceiverId == userId && r.Status == FriendRequestStatus.Accepted)
            .Select(r => new FriendRequestUserDto
            {
                Id = r.Id, 
                Status = r.Status,
                Receiver = new UserChatDto
                {
                    Id = r.Receiver.Id, 
                    Disabled = r.Receiver.Disabled, 
                    Auth0Id = r.Receiver.Auth0Id,
                    Name =  r.Receiver.Name, 
                    Username =  r.Receiver.Username
                },
                Sender = new UserChatDto
                {
                    Id = r.Sender.Id, 
                    Auth0Id = r.Sender.Auth0Id,
                    Disabled = r.Sender.Disabled, 
                    Name =  r.Sender.Name, 
                    Username =  r.Sender.Username
                }
            }).ToListAsync();
    }

    public async Task<bool> DeleteFriendRequest(FriendRequestDelete friendReq)
    {
        var friendReqToDelete = await context.FriendRequests.FindAsync(friendReq.Id);
        if (friendReqToDelete == null) throw new InvalidOperationException("Friend Request not found");
        context.FriendRequests.Remove(friendReqToDelete);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<FriendRequest> UpdateFriendRequest(FriendRequestUpdate friendReq)
    {
        var friendReqToUpdate = await context.FriendRequests.FindAsync(friendReq.Id);
        if (friendReqToUpdate == null) throw new InvalidOperationException("Friend Request not found");
        friendReqToUpdate.Status = friendReq.Status;
        context.FriendRequests.Update(friendReqToUpdate);
        await context.SaveChangesAsync();
        return friendReqToUpdate;
    }
}