namespace chum_chat_backend.App.Interfaces;

public interface IUser
{
    string Id { get; }
    string Username { get; set; }
    string Name { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    List<IChat> Chats { get; set; }
}