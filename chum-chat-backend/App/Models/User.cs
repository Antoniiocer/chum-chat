using System.Text.Json.Serialization;
using chum_chat_backend.App.Interfaces.Models;
using static chum_chat_backend.App.Utils.Validators;

namespace chum_chat_backend.App.Models;

public class User: IUser
{
    public string Name
    {
        get => _name;
        set => _name = NameValidator(value);
    }

    public string Password
    {
        get => _password;
        set => _password = HashPassword(PasswordValidator(value));
    }

    public string Email
    {
        get => _email;
        set => _email = EmailValidator(value);
    }

    public string Username
    {
        get => _username;
        set => _username = UsernameValidator(value);
    }
    public string Id { get; set; } = Guid.NewGuid().ToString();
    private string _username;
    private string _name;
    private string _email;
    private string _password;
    public DateTime CreatedAt { get; set; }
    public bool Disabled { get; set; }
    
    
    //Navigation properties
    [JsonIgnore]
    public List<UserChat>? UserChat { get; set; } = [];
    [JsonIgnore]
    public List<UserCall>? UserCalls { get; set; } = [];
    public List<Chat>? Chats { get; set; } = [];
    public List<Message>? Messages { get; set; } = [];
    public List<FriendRequest>? FriendRequestSent { get; set; } = [];
    public List<FriendRequest>? FriendRequestReceived { get; set; } = [];
    
    public User() {}

    public User(IUserCreator user)
    {
        Id = user.Id ?? Guid.NewGuid().ToString();
        _username = user.Username;
        _name = user.Name;
        _email = user.Email;
        _password = user.Password;
        CreatedAt = DateTime.UtcNow;
        Disabled = false;
    }
    
    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}

public class UserCreate: IUserCreateDto
{
    public required string Username { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class UserUpdate : IUserUpdateDto
{
    public required string Id { get; set; }
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class UserDelete : IUserDeleteDto
{
    public required string Id { get; set; }
}

public class UserChatDto : IUserChatDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required bool Disabled { get; set; }
}
