using RestApi.Models;

namespace RestApi.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task AddRecipeAsync(Recipe recipe);
        Task UpdateRecipeAsync(Recipe recipe);
        Task DeleteRecipeAsync(int id);
        Task<bool> RecipeExistsAsync(int id);
    }

}
