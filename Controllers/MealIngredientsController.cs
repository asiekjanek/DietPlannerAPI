using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealIngredientsController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public MealIngredientsController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealIngredient>>> GetMealIngredients()
        {
            return await _context.MealIngredients
                .Include(mi => mi.Meal)
                .Include(mi => mi.Ingredient)
                .ToListAsync();
        }

        [HttpGet("{mealId}/{ingredientId}")]
        public async Task<ActionResult<MealIngredient>> GetMealIngredient(int mealId, int ingredientId)
        {
            var mealIngredient = await _context.MealIngredients
                .Include(mi => mi.Meal)
                .Include(mi => mi.Ingredient)
                .FirstOrDefaultAsync(mi => mi.MealId == mealId && mi.IngredientId == ingredientId);

            if (mealIngredient == null)
            {
                return NotFound();
            }

            return mealIngredient;
        }

        [HttpPost]
        public async Task<ActionResult<MealIngredient>> AddMealIngredient(MealIngredient mealIngredient)
        {
            var exists = await _context.MealIngredients
                .AnyAsync(mi => mi.MealId == mealIngredient.MealId && mi.IngredientId == mealIngredient.IngredientId);

            if (exists)
            {
                return BadRequest("Ten składnik jest już przypisany do tego posiłku.");
            }

            _context.MealIngredients.Add(mealIngredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMealIngredient),
                new { mealId = mealIngredient.MealId, ingredientId = mealIngredient.IngredientId },
                mealIngredient
            );
        }

        [HttpPut("{mealId}/{ingredientId}")]
        public async Task<IActionResult> UpdateMealIngredient(int mealId, int ingredientId, MealIngredient mealIngredient)
        {
            if (mealId != mealIngredient.MealId || ingredientId != mealIngredient.IngredientId)
            {
                return BadRequest();
            }

            _context.Entry(mealIngredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{mealId}/{ingredientId}")]
        public async Task<IActionResult> DeleteMealIngredient(int mealId, int ingredientId)
        {
            var mealIngredient = await _context.MealIngredients
                .FirstOrDefaultAsync(mi => mi.MealId == mealId && mi.IngredientId == ingredientId);

            if (mealIngredient == null)
            {
                return NotFound();
            }

            _context.MealIngredients.Remove(mealIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
