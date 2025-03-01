namespace chum_chat_backend.App.Interfaces;

public interface IChat
{
    string Id {get;}
    string Name {get;set;}
    string Description {get;set;}
    string Image {get;set;}
    string Background {get;set;}
    List<IUser> Users {get;set;}
    List<IMessage> Messages {get;set;}
}