using System.Text.RegularExpressions;
using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public partial class User(string username, string name, string email, string password) : IUser
{
    public string Id { get; } = Guid.NewGuid().ToString();
    private string _username = UsernameValidator(username);
    public string Name { get; set; } = name;
    private string _email = EmailValidator(email);
    private string _password = PasswordValidator(password);
    public DateTime CreatedAt { get; } = DateTime.UtcNow;

    public List<IChat> Chats { get; set; } = [];
    public List<IFriendRequest> FriendRequests { get; set; } = [];

    public string Password
    {
        get => _password;
        set => _password = PasswordValidator(value);
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

    [GeneratedRegex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()\-_+=<>?])[A-Za-z\d!@#$%^&*()\-_+=<>?]{8,}$")]
    private static partial Regex PasswordRegex();
    
    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
    
    [GeneratedRegex(@"^(?!_)[a-zA-Z0-9_]{3,16}(?<!_)$")]
    private static partial Regex UsernameRegex();

    private static string PasswordValidator(string password)
    {
        var formattedPassword = password.Trim();
        if (PasswordRegex().IsMatch(formattedPassword)) return HashPassword(formattedPassword);
        throw new ArgumentException("Invalid password", nameof(password));
    }

    private static string EmailValidator(string email)
    {
        var formattedEmail = email.Trim().ToLower();
        if (EmailRegex().IsMatch(formattedEmail)) return formattedEmail;
        throw new ArgumentException("Invalid email", nameof(email));
    }

    private static string UsernameValidator(string username)
    {
        var formattedUsername = username.Trim();
        if (UsernameRegex().IsMatch(formattedUsername)) return formattedUsername;
        throw new ArgumentException("Invalid username", nameof(username));
    }

    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}
