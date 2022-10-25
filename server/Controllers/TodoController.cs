using Meddelandecentral.Hubs;
using Meddelandecentral.Models;
using Meddelandecentral.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Meddelandecentral.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController: ControllerBase
    {
        private readonly IHubContext<ChatHub, IHubClient> _chatHub;
        private readonly ITodoRepo _todoRepo;

        public TodoController(IHubContext<ChatHub, IHubClient> chatHub, ITodoRepo todoRepo)
        {
            _chatHub = chatHub;
            _todoRepo = todoRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoRepo.GetAll();
            if(todos != null)
            { 
                return Ok(todos); 
            }

            return StatusCode(404, "Notis not found");
        }

        [HttpPost("update")]
        public async void Update(UpdateTodo todo)
        {
            _todoRepo.Update(todo);
            await _chatHub.Clients.All.ReceiveUpdatedTodo(todo); 
        }

        [HttpPost("create")]
        public async void Create(CreateTodo todo)
        {
            var newTodo = await _todoRepo.Create(todo);
            await _chatHub.Clients.All.ReceiveNewTodo(newTodo);
        }
    }
}