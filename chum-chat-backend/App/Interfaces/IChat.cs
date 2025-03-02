namespace chum_chat_backend.App.Interfaces;

public interface IChat
{
    string Id { get; }
    string Name { get;set; }
    string Description { get;set; }
    string Image { get;set; }
    List<IUser> UserList { get;set; }
    List<IMessage> MessageList { get;set; }
}