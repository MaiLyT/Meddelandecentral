using Microsoft.AspNetCore.SignalR;
using Meddelandecentral.Models;
namespace Meddelandecentral.Hubs;


public interface IHubClient
    {
        Task ReceiveMessage(ChatMessage msg);
        Task UpdateRoomCleaning(RoomCleaning cleaning);
    }
public class ChatHub: Hub<IHubClient>
{
    
    public async Task SendMessage(ChatMessage msg)
    {
        await Clients.All.ReceiveMessage(msg);
    }

    public async Task SendRoomCleaning(RoomCleaning cleaning)
    {
        await Clients.All.UpdateRoomCleaning(cleaning);
    }
}