using chum_chat_backend.App.Models;
using Microsoft.EntityFrameworkCore;

namespace chum_chat_backend.App.Database;

public class ChumChatContext(DbContextOptions<ChumChatContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserChat> UserChat { get; set; }
    public DbSet<UserCall> UserCalls { get; set; }
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
            .Property(x => x.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<User>()
            .Property(x => x.Name)
            .HasMaxLength(50);
        
        modelBuilder.Entity<User>()
            .Property(x => x.Email)
            .HasMaxLength(100);
        
        modelBuilder.Entity<User>()
            .Property(x => x.Password)
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(x => x.Username)
            .HasMaxLength(24);
        
        modelBuilder.Entity<User>()
            .Property(x => x.Id)
            .HasMaxLength(36);
        modelBuilder.Entity<User>()
            .HasMany(c => c.Chats)
            .WithMany(u => u.Users)
            .UsingEntity<UserChat>();
        
        
        //UserChat Table
        
        modelBuilder.Entity<UserChat>()
            .HasKey(uc => new { uc.UserId, uc.ChatId });
        
        modelBuilder.Entity<UserChat>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserChat)
            .HasForeignKey(uc => uc.UserId);
        
        modelBuilder.Entity<UserChat>()
            .HasOne(uc => uc.Chat)
            .WithMany(c => c.UserChat)
            .HasForeignKey(uc => uc.ChatId);
        
        modelBuilder.Entity<UserChat>()
            .Property(x => x.ChatId)
            .HasMaxLength(36);
        
        modelBuilder.Entity<UserChat>()
            .Property(x => x.UserId)
            .HasMaxLength(36);
        
        
        //Chat Table
        
        modelBuilder.Entity<Chat>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Chat>()
            .Property(x => x.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Chat>()
            .Property(x => x.Name)
            .HasMaxLength(50);
        
        modelBuilder.Entity<Chat>()
            .Property(x => x.Description)
            .HasMaxLength(100);
        
        modelBuilder.Entity<Chat>()
            .Property(x => x.Image)
            .HasMaxLength(100);

        modelBuilder.Entity<Chat>()
            .HasMany(c => c.Users)
            .WithMany(u => u.Chats)
            .UsingEntity<UserChat>();
        
        modelBuilder.Entity<Chat>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Message Table
        
        modelBuilder.Entity<Message>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Message>()
            .Property(x => x.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Message>()
            .Property(x => x.Text)
            .HasMaxLength(100);
        
        modelBuilder.Entity<Message>()
            .Property(x => x.UserId)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Message>()
            .Property(x => x.ChatId)
            .HasMaxLength(36);
        
        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany(u => u.Messages)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
        
        
        //Friend Request Table
        
        modelBuilder.Entity<FriendRequest>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<FriendRequest>()
            .Property(x => x.Id)
            .HasMaxLength(36);
        
        modelBuilder.Entity<FriendRequest>()
            .Property(x => x.SenderId)
            .HasMaxLength(36);
        
        modelBuilder.Entity<FriendRequest>()
            .Property(x => x.ReceiverId)
            .HasMaxLength(36);
        
        modelBuilder.Entity<FriendRequest>()
            .HasOne(uc => uc.Sender)
            .WithMany(u => u.FriendRequestSent)
            .HasForeignKey(uc => uc.SenderId);
        
        modelBuilder.Entity<FriendRequest>()
            .HasOne(uc => uc.Receiver)
            .WithMany(u => u.FriendRequestReceived)
            .HasForeignKey(uc => uc.ReceiverId);
            
        //UserCall Table

        modelBuilder.Entity<UserCall>()
            .HasKey(uc => new { uc.UserId, uc.CallId });

        modelBuilder.Entity<UserCall>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCalls)
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<UserCall>()
            .HasOne(uc => uc.Call)
            .WithMany(c => c.UserCalls)
            .HasForeignKey(uc => uc.CallId);
        
        modelBuilder.Entity<UserCall>()
            .Property(x => x.CallId)
            .HasMaxLength(36);
        
        modelBuilder.Entity<UserCall>()
            .Property(x => x.UserId)
            .HasMaxLength(36);
        
        
        //Call Table
        
        modelBuilder.Entity<Call>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<Call>()
            .Property(x => x.Id)
            .HasMaxLength(36);
    }
}