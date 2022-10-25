using Meddelandecentral.Models;
using Microsoft.EntityFrameworkCore;

namespace Meddelandecentral.Data
{
    public interface ITodoRepo
    {
        IEnumerable<Todo>GetAll(); 
        void Update(UpdateTodo input );
        Task<Todo> Create(CreateTodo input);
    }

    public class TodoRepo: ITodoRepo
    {
        private readonly AppDbContext _context;

        public TodoRepo(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos;
        }

        public async void Update(UpdateTodo input)
        {
            var updatedTodo = await getTodoById(input.Id);
            updatedTodo.isDone = input.isDone;

            _context.Todos.Update(updatedTodo);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> Create(CreateTodo input){
            Random rd = new Random();
            var newtodo = new Todo();
            newtodo.Id = rd.Next();
            newtodo.isDone = false;
            newtodo.Notis = input.Notis;
            newtodo.RoomId = input.RoomId;

            await _context.Todos.AddAsync(newtodo);
            await _context.SaveChangesAsync();

            return newtodo;
        }

        private async Task<Todo> getTodoById(int id)
        {
            var todo =  await _context.Todos
                .Where(y => y.Id == id)
                .FirstOrDefaultAsync();
            if(todo == null){throw new FileNotFoundException("Notis not found");}
            return todo;
        }
    }
}