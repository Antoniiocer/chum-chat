using System.Text.RegularExpressions;
using chum_chat_backend.App.Interfaces;

namespace chum_chat_backend.App.Models;

public partial class Chat(string name, string description, string image, List<IUser> userList): IChat
{
    public string Id { get; } = Guid.NewGuid().ToString();
    private string _name = NameValidator(name);
    private string _description = DescriptionValidator(description);
    private string _image = ImageRouteValidator(image);
    public List<IUser> UserList { get; set; } = userList;
    public List<IMessage> MessageList { get; set; } = [];
    
    public string Name { get => _name; set => _name = NameValidator(value); }
    public string Description { get => _description; set => _description = DescriptionValidator(value); }
    public string Image { get => _image; set => _image = ImageRouteValidator(value); }
    
    
    [GeneratedRegex(@"^/storage/images/([a-fA-F0-9\-]+)\.(jpg|jpeg|png|gif|bmp|tiff|webp)$")]
    private static partial Regex ImagePathRegex();
    
    private static string ImageRouteValidator(string imageRoute)
    {
        if (ImagePathRegex().IsMatch(imageRoute)) {
            return imageRoute;
        }
        throw new ArgumentException("Invalid image route");
    }
    
    private static string NameValidator(string name)
    {
        if(name.Length <= 20) return name;
        throw new ArgumentException("Chat Name must be less than 20 characters");
    }

    private static string DescriptionValidator(string description)
    {
        if(description.Length <= 50) return description;
        throw new ArgumentException("Chat Description must be less than 50 characters");
    }
}