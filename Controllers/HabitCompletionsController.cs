using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitCompletionsController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public HabitCompletionsController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitCompletion>>> GetHabitCompletions()
        {
            return await _context.HabitCompletions
                .Include(hc => hc.Goal)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<HabitCompletion>> AddHabitCompletion(HabitCompletion habitCompletion)
        {
            habitCompletion.CompletionDate = habitCompletion.CompletionDate.Date;

            var exists = await _context.HabitCompletions.AnyAsync(hc =>
                hc.GoalId == habitCompletion.GoalId &&
                hc.CompletionDate == habitCompletion.CompletionDate);

            if (exists)
            {
                return Conflict();
            }

            _context.HabitCompletions.Add(habitCompletion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHabitCompletions), new { id = habitCompletion.Id }, habitCompletion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitCompletion(int id)
        {
            var habitCompletion = await _context.HabitCompletions.FindAsync(id);

            if (habitCompletion == null)
            {
                return NotFound();
            }

            _context.HabitCompletions.Remove(habitCompletion);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
