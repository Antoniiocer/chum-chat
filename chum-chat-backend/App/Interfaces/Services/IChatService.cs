using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Services;

public interface IChatService
{
    Task<Chat> CreateChat(ChatCreate chat);
    Task<bool> DeleteChat(string id);
    
    Task<ChatUserDto?> GetChat(string id);
    Task<List<ChatUserDto>> GetChats(string id);
    Task<Chat> UpdateChat(ChatUpdate chat);
}