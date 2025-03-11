namespace chum_chat_backend.App.Interfaces.Models;

public interface ICall
{
    string Id { get; set; }
    TimeSpan Duration { get; set; }
}

public interface ICallCreator
{
    string? Id { get; set; }
    TimeSpan Duration { get; set; }
}

public interface ICallCreateDto
{
    TimeSpan Duration { get; set; }
    List<string> UserIds { get; set; }
}

public interface ICallUpdateDto
{
    string Id { get; set; }
    TimeSpan? Duration { get; set; }
    List<string>? UserIds { get; set; }
}

public interface ICallDeleteDto
{
    string Id { get; set; }
}