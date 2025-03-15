using RestApi.Models;

namespace RestApi.Services.Interfaces {
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task AddTodoAsync(Todo toto);
        Task UpdateTodoAsync(int id, Todo todo);
        Task DeleteTodoAsync(int id);
    }
}

