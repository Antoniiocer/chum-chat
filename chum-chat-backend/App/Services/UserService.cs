using chum_chat_backend.App.Database;
using chum_chat_backend.App.Interfaces.Models;
using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Models;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Services;

public class UserService(ChumChatContext context) : IUserService
{
    public async Task<User> CreateUser(UserCreate user)
    {
        var userToCreate = new User
            { Name = user.Name, Email = user.Email, Password = user.Password, Username = user.Username };
        var userExists = await CheckIfUserExists(userToCreate);
        if (userExists != null) throw new InvalidOperationException(userExists);
        
        var createdUser = context.Users.Add(userToCreate);
        await context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task<User> DeleteUser(UserDelete user)
    {
        var userToDelete = await context.Users.FindAsync(user.Id);
        if(userToDelete == null) throw new InvalidOperationException("User not found");
        userToDelete.Disabled = true;
        await context.SaveChangesAsync();
        return userToDelete;
    }

    public async Task<User?> GetUser(string id)
    {
        return await context.Users.Include(u => u.Chats).FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<User>> GetUsers()
    {
        return await context.Users.Include(u => u.Chats).ToListAsync();
    }

    public async Task<User> UpdateUser(UserUpdate user)
    {
        var existingUser = await context.Users.FindAsync(user.Id);
        if (existingUser == null) throw new ArgumentException($"User not found {user.Id}");

        existingUser.Name = user.Name ?? existingUser.Name;
        existingUser.Email = user.Email ?? existingUser.Email;
        existingUser.Username = user.Username ?? existingUser.Username;

        await context.SaveChangesAsync();
        return existingUser;
    }


    private async Task<string?> CheckIfUserExists(User user)
    {
        var foundUser = await context.Users
            .FirstOrDefaultAsync(u => u.Email == user.Email || u.Username == user.Username);
    
        if (foundUser == null) return null;
        return user.Email == foundUser.Email 
            ? "A user with that email already exists." 
            : "A user with that username already exists.";
    }

}