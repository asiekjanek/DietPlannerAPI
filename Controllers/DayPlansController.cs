using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayPlansController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public DayPlansController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayPlan>>> GetDayPlans()
        {
            return await _context.DayPlans
                .Include(dp => dp.DietPlan)
                .Include(dp => dp.UserProfile)
                .Include(dp => dp.Meal)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DayPlan>> GetDayPlan(int id)
        {
            var dayPlan = await _context.DayPlans
                .Include(dp => dp.DietPlan)
                .Include(dp => dp.UserProfile)
                .Include(dp => dp.Meal)
                .FirstOrDefaultAsync(dp => dp.Id == id);

            if (dayPlan == null)
            {
                return NotFound();
            }

            return dayPlan;
        }

        [HttpPost]
        public async Task<ActionResult<DayPlan>> AddDayPlan(DayPlan dayPlan)
        {
            _context.DayPlans.Add(dayPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDayPlan), new { id = dayPlan.Id }, dayPlan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDayPlan(int id, DayPlan dayPlan)
        {
            if (id != dayPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(dayPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDayPlan(int id)
        {
            var dayPlan = await _context.DayPlans.FindAsync(id);

            if (dayPlan == null)
            {
                return NotFound();
            }

            _context.DayPlans.Remove(dayPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
