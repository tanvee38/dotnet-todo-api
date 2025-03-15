using Microsoft.EntityFrameworkCore;
using RestApi.Models;

using RestApi.Repositories.Interfaces;


namespace RestApi.Repositories.Implementations {
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task AddTodoAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> TodoExistsAsync(int id)
        {
            return await _context.Todos.AnyAsync(e => e.Id == id);
        }
    }
}

