using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Models;

public interface IMessage
{
    string Id { get; set; }
    string Text { get; set; }
    DateTime CreatedAt { get; set; }
    string UserId { get; set; }
    string ChatId { get; set; }
}


public interface IMessageCreator
{
    string? Id { get; set; }
    string Text { get; set; }
    DateTime? CreatedAt { get; set; }
    string UserId { get; set; }
    string ChatId { get; set; }
}

public interface IMessageCreateDto
{
    string Text { get; set; }
    string UserId { get; set; }
    string ChatId { get; set; }
}

public interface IMessageUpdateDto
{
    string Id { get; set; }
    string Text { get; set; }
}

public interface IMessageDeleteDto
{
    string Id { get; set; }
}