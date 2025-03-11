using chum_chat_backend.App.Interfaces.Models;

namespace chum_chat_backend.App.Models;

public class Call: ICall
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public TimeSpan Duration { get; set; }
    public List<UserCall> UserCalls { get; set; } = [];
    
    public Call() { }
    
    public Call(ICallCreator call)
    {
        Id = call.Id ?? Guid.NewGuid().ToString();
        Duration = call.Duration;
    }

}

public class CallCreate: ICallCreateDto
{
    public required TimeSpan Duration { get; set; }
    public required List<string> UserIds { get; set; }
    
}

public class CallUpdate : ICallUpdateDto
{
    public required string Id { get; set; }
    public TimeSpan? Duration { get; set; }
    public List<string>? UserIds { get; set; }
}

public class CallDelete : ICallDeleteDto
{
    public required string Id { get; set; }
}

