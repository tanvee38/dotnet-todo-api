using RestApi.Models;

namespace RestApi.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo> GetTodoByIdAsync(int id);
        Task AddTodoAsync(Todo todo);
        Task UpdateTodoAsync(Todo todo);
        Task DeleteTodoAsync(int id);
        Task<bool> TodoExistsAsync(int id);
    }

}
