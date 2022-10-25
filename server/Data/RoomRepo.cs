using Meddelandecentral.Models;
using Microsoft.EntityFrameworkCore;

namespace Meddelandecentral.Data
{
    public interface IRoomRepo
    {
        IEnumerable<Room>GetAll();
        void UpdateRoomCleaning(RoomCleaning roomCleaning);
    }

    public class RoomRepo : IRoomRepo
    {
        private readonly AppDbContext _context;

        public  RoomRepo(AppDbContext context)
        {   
            _context = context;
        }
        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.Include(room => room.Todo);
        }

        public async void UpdateRoomCleaning(RoomCleaning input)
        {
            var updatedRoom = await getRoomById(input.Id);
            updatedRoom.isCleaned = input.isCleaned;

            _context.Rooms.Update(updatedRoom);
            await _context.SaveChangesAsync();
        }

        private async Task<Room> getRoomById(int id)
        {
            var room =  await _context.Rooms
                .Where(y => y.Id == id)
                .FirstOrDefaultAsync();
            if(room == null){throw new FileNotFoundException("Room not found");}
            return room;
        }
    }
    

}