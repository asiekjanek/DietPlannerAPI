using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietPlansController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public DietPlansController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietPlan>>> GetDietPlans()
        {
            return await _context.DietPlans
                .Include(dp => dp.DayPlans)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DietPlan>> GetDietPlan(int id)
        {
            var dietPlan = await _context.DietPlans
                .Include(dp => dp.DayPlans)
                .FirstOrDefaultAsync(dp => dp.Id == id);

            if (dietPlan == null)
            {
                return NotFound();
            }

            return dietPlan;
        }

        [HttpPost]
        public async Task<ActionResult<DietPlan>> AddDietPlan(DietPlan dietPlan)
        {
            _context.DietPlans.Add(dietPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDietPlan), new { id = dietPlan.Id }, dietPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDietPlan(int id, DietPlan dietPlan)
        {
            if (id != dietPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(dietPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietPlan(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);

            if (dietPlan == null)
            {
                return NotFound();
            }

            _context.DietPlans.Remove(dietPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
