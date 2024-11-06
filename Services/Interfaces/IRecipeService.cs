using RestApi.Models;

namespace RestApi.Services.Interfaces {
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task AddRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(int id, Recipe recipe);
        Task DeleteRecipeAsync(int id);
    }
}

