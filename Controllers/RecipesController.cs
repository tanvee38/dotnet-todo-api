using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Services.Interfaces;

namespace RestApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            await _recipeService.AddRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            try
            {
                await _recipeService.UpdateRecipeAsync(id, recipe);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            await _recipeService.DeleteRecipeAsync(id);
            return NoContent();
        }
    }

}
