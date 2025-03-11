using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Services;
public interface IMessageService
{
    Task<Message> CreateMessage(MessageCreate message);
    Task<bool> DeleteMessage(MessageDelete message);
    
    Task<Message?> GetMessage(string id);
    Task<List<Message>> GetMessages(string chatId);
    Task<Message> UpdateMessage(MessageUpdate message);
}