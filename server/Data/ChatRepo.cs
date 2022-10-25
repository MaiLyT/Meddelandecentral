using Meddelandecentral.Models;
using Meddelandecentral.Data;
using Microsoft.EntityFrameworkCore;

namespace Meddelandecentral.Data
{
    public interface IChatRepo
    {
        public IEnumerable<ChatMessage> GetAll();
        public void Create (CreateNewMsg msg);
    }

    public class ChatRepo : IChatRepo
    {
        private readonly AppDbContext _context;

        public ChatRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ChatMessage> GetAll()
        {
                return _context.Chats;
        }

        public async void Create(CreateNewMsg msg)
        {
            var newMsg = new ChatMessage();
            newMsg.Id = Guid.NewGuid();
            newMsg.User = msg.User;
            newMsg.Message = msg.Message;
            await _context.Chats.AddAsync(newMsg);
            await _context.SaveChangesAsync();
        }

    }
}