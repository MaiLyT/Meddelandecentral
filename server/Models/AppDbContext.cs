using Microsoft.EntityFrameworkCore;

namespace Meddelandecentral.Models;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){ this.Database.EnsureCreated();}
    
    public DbSet<Room> Rooms {get; set;}
    public DbSet<ChatMessage> Messages {get; set;}
    public DbSet<Todo> Todos {get; set;}

}