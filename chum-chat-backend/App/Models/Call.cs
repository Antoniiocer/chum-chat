using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public class Call : ICall
{
    public string Id { get; private set; } = Guid.NewGuid().ToString(); 
    public TimeSpan Duration { get;  private set; }
    public List<User> UserList { get;  private set; } = [];
    
    public Call() { }
    
    public Call(TimeSpan duration, List<User> userList)
    {
        Duration = duration;
        UserList = [];
    }

}