using RestApi.Models;

using RestApi.Services.Interfaces;
using RestApi.Repositories.Interfaces;

namespace RestApi.Services.Implementations {
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _recipeRepository.GetAllRecipesAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _recipeRepository.GetRecipeByIdAsync(id);
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            await _recipeRepository.AddRecipeAsync(recipe);
        }

        public async Task UpdateRecipeAsync(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                throw new ArgumentException("Recipe ID mismatch");
            }
            await _recipeRepository.UpdateRecipeAsync(recipe);
        }

        public async Task DeleteRecipeAsync(int id)
        {
            await _recipeRepository.DeleteRecipeAsync(id);
        }
    }
}

