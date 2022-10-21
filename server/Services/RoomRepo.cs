using Meddelandecentral.Models;

namespace Meddelandecentral.Services
{
    public interface IRoomRepo
    {
        IEnumerable<Room>GetAll();
    }

    public class RoomRepo : IRoomRepo
    {
        private readonly List<Room> rooms = new List<Room>();
    
        public RoomRepo()
        {
            rooms.Add(new Room {Id = 1, RoomName="Room 1", isCleaned=false });
            rooms.Add(new Room {Id = 2, RoomName="Room 2", isCleaned=false });
            rooms.Add(new Room {Id = 3, RoomName="Room 3", isCleaned=false });
            rooms.Add(new Room {Id = 4, RoomName="Room 4", isCleaned=false });
            rooms.Add(new Room {Id = 5, RoomName="Conference 5", isCleaned=true });
            rooms.Add(new Room {Id = 6, RoomName="Conference 6", isCleaned=true });            
        }

        public IEnumerable<Room> GetAll()
        {
            return rooms;
        }
    }
    

}