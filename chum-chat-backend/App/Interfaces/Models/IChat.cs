using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Models;

public interface IChat
{
    string Id { get; set; }
    string Name { get;set; }
    string Description { get;set; }
    string Image { get;set; }
}

public interface IChatCreator
{
    string? Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Image { get; set; }
}

public interface IChatCreateDto
{
    string Name { get; set; }
    string Description { get; set; }
    string Image { get; set; }
    List<string> UserIds { get; set; }
}

public interface IChatUpdateDto
{
    string Id { get; set; }
    string? Name { get; set; }
    string? Description { get; set; }
    string? Image { get; set; }
    List<string>? UserIds { get; set; }
}

public interface IChatDeleteDto
{
    string Id { get; set; }
}

public interface IChatUserDto
{
    string Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Image { get; set; }
    List<Message>? Messages { get; set; }
}
