using System.Threading.Tasks;
using Meddelandecentral.Hubs;
using Meddelandecentral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Meddelandecentral.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController: ControllerBase
    {
        private readonly IHubContext<ChatHub, IHubClient>_chatHub;
        public RoomController(IHubContext<ChatHub, IHubClient> chatHub) 
        {
            _chatHub = chatHub;
        }

        [HttpPost("cleaning")]
        public async Task Post(RoomCleaning cleaning)
        {
            
            await _chatHub.Clients.All.UpdateRoomCleaning(cleaning);
        }
    }
}