using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public class User : IUser
{
    public string Id { get; }
    public string Username { get; set; }
    public string Name { get; set; }
    private string email
    private string password;
    private List<IChat> chats;

    public User(string username, string name, string email, string password)
    {
        Id = Guid.NewGuid().ToString();
        this.username = username;
        this.name = name;
        this.email = email;
        this.password = password;
        chats = new List<IChat>();
    }

}
