using chum_chat_backend.App.Database;
using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Services;

public class MessageService(ChumChatContext context): IMessageService
{
    public async Task<Message> CreateMessage(MessageCreate message)
    {
        var messageToCreate = new Message{ Text = message.Text, UserId = message.UserId, ChatId = message.ChatId };
        var createdMessage = context.Messages.Add(messageToCreate);
        await context.SaveChangesAsync();

        return createdMessage.Entity;
    }

    public async Task<bool> DeleteMessage(MessageDelete message)
    {
        var messageToDelete = await context.Messages.FindAsync(message.Id);
        if(messageToDelete == null) throw new InvalidOperationException("Message not found");
        context.Messages.Remove(messageToDelete);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Message?> GetMessage(string id)
    {
        var message = await context.Messages.FindAsync(id);
        if(message == null) throw new InvalidOperationException("Message not found");
        return message;
    }

    public async Task<List<Message>> GetMessages(string chatId)
    {
       return await context.Messages.Where(message => message.ChatId == chatId).ToListAsync();
    }

    public async Task<Message> UpdateMessage(MessageUpdate message)
    {
        var messageToUpdate = await context.Messages.FindAsync(message.Id);
        if(messageToUpdate == null) throw new InvalidOperationException("Message not found");
        messageToUpdate.Text = message.Text;
        context.Update(messageToUpdate);
        await context.SaveChangesAsync();
        return messageToUpdate;
    }
}