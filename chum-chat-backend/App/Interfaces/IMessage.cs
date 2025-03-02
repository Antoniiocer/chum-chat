namespace chum_chat_backend.App.Interfaces;

public interface IMessage
{
    string Id { get; }
    string Text { get;set; }
    DateTime Date { get; }
    IUser Sender { get; }
    IChat Chat { get; }
}