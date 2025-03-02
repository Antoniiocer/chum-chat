using chum_chat_backend.App.Models;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Database;

public class ChumChatContext(DbContextOptions<ChumChatContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Message> Message { get; set; }
    public DbSet<Chat> Chat { get; set; }
    public DbSet<FriendRequest> FriendRequest { get; set; }
    public DbSet<Call> Call { get; set; }
}