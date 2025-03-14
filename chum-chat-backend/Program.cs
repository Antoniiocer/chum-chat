using System.Text.Json.Serialization;
using chum_chat_backend.App.Database;
using chum_chat_backend.App.Interfaces.Services;
using chum_chat_backend.App.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

// MVC services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cache and session setup
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// MySQL database connection setup
builder.Services.AddDbContext<ChumChatContext>(options =>
    options.UseMySql(Environment.GetEnvironmentVariable("DATABASE_URL"), 
        ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("DATABASE_URL"))));

// JSON configuration for controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Custom services setup
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IFriendRequestService, FriendRequestService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ChumChatSession>();

// JWT Authentication setup
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://dev-yk0swgmtlmtbajd8.us.auth0.com/";
        options.Audience = "https://chum-chat.es";
    });

// Build the application
var app = builder.Build();

// Authentication middleware
app.UseAuthentication();
app.UseAuthorization();

// Session middleware
app.UseSession();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ChumChatContext>();
    try
    {
        dbContext.Database.OpenConnection();
        dbContext.Database.CloseConnection();
        Console.WriteLine("Database connection successful.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection error: {ex.Message}");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS redirection and routing
app.UseHttpsRedirection();
app.MapControllers();

// Run the application
app.Run();
