namespace chum_chat_backend.App.Interfaces.Models;

public interface IUser
{
    string Id { get; set; }
    string Auth0Id { get; set; }
    string Email { get; set; }
    string Name { get; set; }
    string Username { get; set; }
    string Password { get; set; }
    DateTime CreatedAt { get; set; }
    bool Disabled { get; set; }


}

public interface IUserCreator
{
    string? Id { get; set; }
    string Auth0Id { get; set; }
    string Email { get; set; }
    string Name { get; set; }
    string Username { get; set; }
    string Password { get; set; }
    DateTime? CreatedAt { get; set; }
    bool? Disabled { get; set; }
}

public interface IUserCreateDto
{
    string Auth0Id { get; set; }
    string Username { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    string Password { get; set; }
}

public interface IUserUpdateDto
{
    string Id { get; set; }
    string Auth0Id { get; set; }
    string? Username { get; set; }
    string? Name { get; set; }
    string? Email { get; set; }
    string? Password { get; set; }
}

public interface IUserDeleteDto
{
    string Id { get; set; }
    string Auth0Id { get; set; }
}

public interface IUserChatDto
{
    string Id { get; set; }
    string Auth0Id { get; set; }
    string Name { get; set; }
    string Username { get; set; }
    bool Disabled { get; set; }
}