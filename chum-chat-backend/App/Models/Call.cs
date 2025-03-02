using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public class Call(TimeSpan duration, List<IUser> userList): ICall
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public TimeSpan Duration { get; } = duration;
    public List<IUser> UserList { get; } = userList;
}