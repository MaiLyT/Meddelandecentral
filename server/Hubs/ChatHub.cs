using Microsoft.AspNetCore.SignalR;
using Meddelandecentral.Models;
namespace Meddelandecentral.Hubs;


public interface IHubClient
    {
        Task ReceiveMessage(ChatMessage msg);
        Task ReceiveRoomCleaning(RoomCleaning cleaning);
        Task ReceiveUpdatedTodo(UpdateTodo todo);
        Task ReceiveNewTodo(Todo todo);
    }
public class ChatHub: Hub<IHubClient>
{
    public async Task SendMessage(ChatMessage msg)
    {

        await Clients.All.ReceiveMessage(msg);
    }

    public async Task SendRoomCleaning(RoomCleaning cleaning)
    {

        await Clients.All.ReceiveRoomCleaning(cleaning);
    }

    public async Task SendNewTodo(Todo todo)
    {
        await Clients.All.ReceiveNewTodo(todo);
    }

    public async Task SendUpdateTodo(UpdateTodo todo)
    {
        await Clients.All.ReceiveUpdatedTodo(todo);
    }
}