using Microsoft.EntityFrameworkCore;
using Meddelandecentral.Models;

namespace Meddelandecentral.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){ this.Database.EnsureCreated();}
    
    public DbSet<Room> Rooms {get; set;}
    public DbSet<ChatMessage> Chats {get; set;}
    public DbSet<Todo> Todos {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

      //seed Rooms
        modelBuilder.Entity<Room>().HasData(new Room{Id = 1, RoomName="Room 1", isCleaned=false, });
        modelBuilder.Entity<Room>().HasData(new Room{Id = 2, RoomName="Room 2", isCleaned=false, });
        modelBuilder.Entity<Room>().HasData(new Room{Id = 3, RoomName="Room 3", isCleaned=true, });
        modelBuilder.Entity<Room>().HasData(new Room{Id = 4, RoomName="Room 4", isCleaned=true, });
        modelBuilder.Entity<Room>().HasData(new Room{Id = 5, RoomName="Room 5", isCleaned=true, });
        modelBuilder.Entity<Room>().HasData(new Room{Id = 6, RoomName="Conference Room", isCleaned=false, });

      //seed Todos  
        modelBuilder.Entity<Todo>().HasData(new Todo{Id = 1, RoomId=1, isDone=false, Notis="Wakeup call att 05:00 am"});

    }
}

