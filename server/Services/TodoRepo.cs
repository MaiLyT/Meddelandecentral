using Meddelandecentral.Models;

namespace Meddelandecentral.Services
{
    public interface ITodoRepo
    {
        IEnumerable<Todo>GetALl(); 

    }

    public class TodoRepo
    {
        private readonly List<Todo> todos = new List<Todo>();

        public IEnumerable<Todo> GetAll()
        {
            return todos;
        }  
    }
}