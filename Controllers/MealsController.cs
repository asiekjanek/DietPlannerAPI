using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealsController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public MealsController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
        {
            return await _context.Meals
                .Include(m => m.Category)
                .Include(m => m.MealIngredients)
                    .ThenInclude(mi => mi.Ingredient)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
            var meal = await _context.Meals
                .Include(m => m.Category)
                .Include(m => m.MealIngredients)
                    .ThenInclude(mi => mi.Ingredient)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        [HttpPost]
        public async Task<ActionResult<Meal>> AddMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMeal), new { id = meal.Id }, meal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeal(int id, Meal meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }

            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var meal = await _context.Meals.FindAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
