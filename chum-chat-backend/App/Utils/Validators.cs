using System.Text.RegularExpressions;

namespace chum_chat_backend.App.Utils;

public static partial class Validators
{
    [GeneratedRegex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()\-_+=<>?])[A-Za-z\d!@#$%^&*()\-_+=<>?]{8,100}$")]
    private static partial Regex PasswordRegex();
    
    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,100}$")]
    private static partial Regex EmailRegex();
    
    [GeneratedRegex(@"^(?!_)[a-zA-Z0-9_]{3,24}(?<!_)$")]
    private static partial Regex UsernameRegex();
    
    [GeneratedRegex(@"^/storage/images/[a-fA-F0-9\-]+\.(jpg|jpeg|png|gif|bmp|tiff|webp)$")]
    private static partial Regex ImagePathRegex();

    public static string NameValidator(string name)
    {
        var formattedName = name.Trim();
        if (formattedName != string.Empty) return formattedName;
        throw new ArgumentException("The name cannot be empty or consist only of spaces.", nameof(name));
    }

    public static string PasswordValidator(string password)
    {
        var formattedPassword = password.Trim();
        if (PasswordRegex().IsMatch(formattedPassword)) return formattedPassword;
        throw new ArgumentException("The password must be between 8 and 100 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character (!@#$%^&*()-_+=<>?).", nameof(password));
    }

    public static string EmailValidator(string email)
    {
        var formattedEmail = email.Trim().ToLower();
        if (EmailRegex().IsMatch(formattedEmail)) return formattedEmail;
        throw new ArgumentException("The email address is invalid. Make sure it follows the correct format (e.g., user@domain.com).", nameof(email));
    }

    public static string UsernameValidator(string username)
    {
        var formattedUsername = username.Trim();
        if (UsernameRegex().IsMatch(formattedUsername)) return formattedUsername;
        throw new ArgumentException("The username must be between 3 and 24 characters long, can only contain letters, numbers, and underscores, and cannot start or end with an underscore.", nameof(username));
    }
    
    public static string ImageRouteValidator(string imageRoute)
    {
        if (!ImagePathRegex().IsMatch(imageRoute))
        {
            throw new ArgumentException("Invalid image route format");
        }
        return imageRoute;
    }

    public static string ChatNameValidator(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 20)
            throw new ArgumentException("Chat Name must be between 1 and 20 characters");

        return name;
    }

    public static string DescriptionValidator(string description)
    {
        if (description.Length > 100)
            throw new ArgumentException("Chat Description must be less than 100 characters");

        return description;
    }
    
    public static string TextValidator(string text)
    {
        if (text.Length <= 100) return text;
        throw new ArgumentException("Text must be between 100 characters.");
    }
}
