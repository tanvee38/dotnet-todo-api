using RestApi.Models;

using RestApi.Services.Interfaces;
using RestApi.Repositories.Interfaces;

namespace RestApi.Services.Implementations {
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            return await _todoRepository.GetAllTodosAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _todoRepository.GetTodoByIdAsync(id);
        }

        public async Task AddTodoAsync(Todo todo)
        {
            await _todoRepository.AddTodoAsync(todo);
        }

        public async Task UpdateTodoAsync(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                throw new ArgumentException("Todo ID mismatch");
            }
            await _todoRepository.UpdateTodoAsync(todo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            await _todoRepository.DeleteTodoAsync(id);
        }
    }
}

