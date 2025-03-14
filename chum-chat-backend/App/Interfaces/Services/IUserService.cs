using chum_chat_backend.App.Interfaces.Models;
using chum_chat_backend.App.Models;

namespace chum_chat_backend.App.Interfaces.Services;

public interface IUserService
{
    Task<User> Register(UserCreate user);
    Task<User?> GetUser(string id);
    Task<List<User>> GetUsers();
    Task<User> UpdateUser(UserUpdate user);
    Task<User> DeleteUser(UserDelete id);
}