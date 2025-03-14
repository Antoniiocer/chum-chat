using chum_chat_backend.App.Database;
using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Services;

public class ChatService(ChumChatContext context) : IChatService
{
    public async Task<Chat> CreateChat(ChatCreate chat)
    {
        var createdChat = new Chat { Name = chat.Name, Description = chat.Description, Image = chat.Image };
        context.Chats.Add(createdChat);
        
        var users = await context.Users
            .Where(u => chat.UserIds.Contains(u.Id))
            .ToListAsync();
        
        if (users.Count != chat.UserIds.Count)
        {
            throw new ArgumentException("Uno o más usuarios no existen.");
        }

       
        var userChats = users.Select(user => new UserChat
        {
            UserId = user.Id,
            User = user,
            Chat = createdChat,
            ChatId = createdChat.Id
        }).ToList();

        context.UserChat.AddRange(userChats);
        await context.SaveChangesAsync();

        return createdChat;
    }

    public async Task<ChatUserDto?> GetChat(string id)
    {
        var foundChat = await context.Chats
            .Include(c => c.Users)
            .Include(c => c.Messages)
            .Where(c => c.Id == id)
            .Select(c => new ChatUserDto
            {
                Id = c.Id,
                Description = c.Description,
                Image = c.Image,
                Name = c.Name,
                Messages = c.Messages,
                Users = c.Users.Select(u => new UserChatDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Username = u.Username,
                    Disabled = u.Disabled
                }).ToList()
            })
            .FirstOrDefaultAsync();
        if (foundChat == null) throw new InvalidOperationException("The Chat does not exist.");
        return foundChat;
        
    }
    
    public async Task<List<ChatUserDto>> GetChats(string id)
    {
        return await context.Chats
            .Include(c => c.Users) 
            .Where(c => c.Users.Any(u => u.Id == id))
            .Select(c => new ChatUserDto
            {
                Id = c.Id,
                Description = c.Description,
                Image = c.Image,
                Name = c.Name,
                Users = c.Users.Select(u => new UserChatDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Username = u.Username,
                    Disabled = u.Disabled
                }).ToList()
            })
            .ToListAsync();
    }



    public async Task<bool> DeleteChat(string id)
    {
        var foundChat = await context.Chats.FindAsync(id);
        if (foundChat == null) throw new InvalidOperationException("The Chat does not exist.");
        context.Chats.Remove(foundChat);
        return true;
    }

    public async Task<Chat> UpdateChat(ChatUpdate chat)
    {
        var updatedChat = await context.Chats.FindAsync(chat.Id);
        if (updatedChat == null) throw new InvalidOperationException("The Chat does not exist.");
        updatedChat.Name = chat.Name ?? updatedChat.Name;
        updatedChat.Description = chat.Description ?? updatedChat.Description;
        updatedChat.Image = chat.Image ?? updatedChat.Image;
        if (chat.UserIds != null)
        {
            var usersList = new List<User>();
            foreach (var userId in chat.UserIds)
            {
                var foundUser = await context.Users.FindAsync(userId);
                if (foundUser == null) throw new InvalidOperationException("Some of the users provided could not be found.");
                usersList.Add(foundUser);
            }
            updatedChat.Users = usersList;
        }
        context.Update(updatedChat);
        await context.SaveChangesAsync();
        return updatedChat;
    }
}