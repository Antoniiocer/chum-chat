using System.Text.RegularExpressions;
using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public partial class Chat : IChat
{
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    
    private string _name = string.Empty;
    private string _description = string.Empty;
    private string _image = string.Empty;

    public List<User> UserList { get; set; } = [];
    public List<Message> MessageList { get; set; } = [];

    public string Name
    {
        get => _name;
        set => _name = NameValidator(value);
    }

    public string Description
    {
        get => _description;
        set => _description = DescriptionValidator(value);
    }

    public string Image
    {
        get => _image;
        set => _image = ImageRouteValidator(value);
    }
    
    public Chat() { }
    
    public Chat(string name, string description, string image, List<User> userList)
    {
        _name = NameValidator(name);
        _description = DescriptionValidator(description);
        _image = ImageRouteValidator(image);
        UserList = userList;
    }

    [GeneratedRegex(@"^/storage/images/[a-fA-F0-9\-]+\.(jpg|jpeg|png|gif|bmp|tiff|webp)$")]
    private static partial Regex ImagePathRegex();

    private static string ImageRouteValidator(string imageRoute)
    {
        if (!ImagePathRegex().IsMatch(imageRoute))
        {
            throw new ArgumentException("Invalid image route format");
        }
        return imageRoute;
    }

    private static string NameValidator(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Chat Name must be between 1 and 20 characters");

        return name;
    }

    private static string DescriptionValidator(string description)
    {
        if (description.Length > 50)
            throw new ArgumentException("Chat Description must be less than 50 characters");

        return description;
    }
}
