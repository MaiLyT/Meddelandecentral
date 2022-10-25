using System.Threading.Tasks;
using Meddelandecentral.Hubs;
using Meddelandecentral.Models;
using Meddelandecentral.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Meddelandecentral.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController: ControllerBase
    {
        private readonly IHubContext<ChatHub, IHubClient>_chatHub;
        private readonly IRoomRepo _roomRepo;
        public RoomController(IHubContext<ChatHub, IHubClient> chatHub, IRoomRepo roomRepo) 
        {
            _chatHub = chatHub;
            _roomRepo = roomRepo;
        }

        [HttpPost("cleaning")]
        public async Task Post(RoomCleaning cleaning)
        {
            _roomRepo.UpdateRoomCleaning(cleaning);
            await _chatHub.Clients.All.ReceiveRoomCleaning(cleaning);
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _roomRepo.GetAll();
            if(rooms != null)
            { 
                return Ok(rooms); 
            }

            return StatusCode(404, "Rooms not found");
        }
    }
}