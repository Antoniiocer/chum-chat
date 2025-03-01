namespace chum_chat_backend.App.Interfaces;

public interface IMessage
{
    string Id {get;set;}
    string ChatId {get;set;}
    string SenderId {get;set;}
    string Message {get;set;}
    DateTime Date {get;set;}
    IUser Sender {get;set;}
    IChat Chat {get;set;}
}