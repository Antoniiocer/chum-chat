using chum_chat_backend.App.Models;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Database;

public class ChumChatContext(DbContextOptions<ChumChatContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<FriendRequest> FriendRequests { get; set; }
    public DbSet<Call> Calls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //User Table
        
        modelBuilder.Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .HasMaxLength(16);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .HasMaxLength(100);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Password)
            .HasMaxLength(100);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Name)
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Chats)
            .WithMany(c => c.UserList);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.SentFriendRequests)
            .WithOne(fr => fr.User)
            .HasForeignKey(fr => fr.UserId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.ReceivedFriendRequests)
            .WithOne(fr => fr.Friend)
            .HasForeignKey(fr => fr.FriendId);
            
            
        

        // Chat Table

        modelBuilder.Entity<Chat>()
            .Property(c => c.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Chat>()
            .Property(c => c.Name)
            .HasMaxLength(20);

        modelBuilder.Entity<Chat>()
            .Property(c => c.Description)
            .HasMaxLength(50);

        modelBuilder.Entity<Chat>()
            .Property(c => c.Image)
            .HasMaxLength(100);

        modelBuilder.Entity<Chat>()
            .HasMany(c => c.UserList)
            .WithMany(u => u.Chats)
            .UsingEntity(j => j.ToTable("ChatUsers"));
        
        //Friend Request Table
        
        modelBuilder.Entity<FriendRequest>()
            .Property(fr => fr.Id)
            .HasMaxLength(36);
        modelBuilder.Entity<FriendRequest>()
            .Property(fr => fr.UserId)
            .HasMaxLength(36);
        modelBuilder.Entity<FriendRequest>()
            .Property(fr => fr.FriendId)
            .HasMaxLength(36);
        
        
        //Message Table
        modelBuilder.Entity<Message>()
            .Property(m => m.Text)
            .HasMaxLength(100);
        modelBuilder.Entity<Message>()
            .Property(m => m.Id)
            .HasMaxLength(36);
        modelBuilder.Entity<Message>()
            .Property(m => m.SenderId)
            .HasMaxLength(36);
        modelBuilder.Entity<Message>()
            .Property(m => m.ChatId)
            .HasMaxLength(36);
        
        
        //Call Table
        modelBuilder.Entity<Call>()
            .Property(m => m.Id)
            .HasMaxLength(36);
    }
}