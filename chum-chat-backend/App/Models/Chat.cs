using System.Text.Json.Serialization;
using chum_chat_backend.App.Interfaces.Models;
using static chum_chat_backend.App.Utils.Validators;

namespace chum_chat_backend.App.Models;

public class Chat: IChat
{
    public string Id { get;  set; } = Guid.NewGuid().ToString();
    public string Image { get; set; } = string.Empty;
    private string _name = string.Empty;
    private string _description = string.Empty;
    public string Name
    {
        get => _name;
        set => _name = ChatNameValidator(value);
    }

    public string Description
    {
        get => _description;
        set => _description = DescriptionValidator(value);
    }
    
    //Navigation properties
    [JsonIgnore]
    public List<UserChat>? UserChat { get; set; } = [];
    public List<User>? Users { get; set; } = [];
    public List<Message>? Messages { get; set; } = [];

    public Chat() { }
    
    public Chat(IChatCreator chat)
    {
        Id = chat.Id ?? Guid.NewGuid().ToString();
        _name = NameValidator(chat.Name);
        _description = DescriptionValidator(chat.Description);
        Image = chat.Image;
    }
    
}

public class ChatCreate: IChatCreateDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public string Image { get; set; } = string.Empty;
    public required List<string> UserIds { get; set; }
    
}

public class ChatUpdate : IChatUpdateDto
{
    public required string Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public List<string>? UserIds { get; set; }
}

public class ChatDelete : IChatDeleteDto
{
    public required string Id { get; set; }
}

public class ChatUserDto : IChatUserDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Image { get; set; }
    public required List<UserChatDto> Users { get; set; }
    public List<Message>? Messages { get; set; }
}