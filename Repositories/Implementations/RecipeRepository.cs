using Microsoft.EntityFrameworkCore;
using RestApi.Models;

using RestApi.Repositories.Interfaces;


namespace RestApi.Repositories.Implementations {
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipe.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipe.FindAsync(id);
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            _context.Recipe.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipe.Remove(recipe);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> RecipeExistsAsync(int id)
        {
            return await _context.Recipe.AnyAsync(e => e.Id == id);
        }
    }
}

