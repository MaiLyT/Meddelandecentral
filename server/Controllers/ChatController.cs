using System.Threading.Tasks;
using Meddelandecentral.Hubs;
using Meddelandecentral.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Meddelandecentral.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController: ControllerBase
    {
        private readonly IHubContext<ChatHub, IHubClient>_chatHub;
        public ChatController(IHubContext<ChatHub, IHubClient> chatHub) 
        {
            _chatHub = chatHub;
        }

        [HttpPost("messages")]
        public async Task Post(ChatMessage message)
        {

            await _chatHub.Clients.All.ReceiveMessage(message);
        }
    }
}
