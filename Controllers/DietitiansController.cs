using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietitiansController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public DietitiansController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dietitian>>> GetDietitians()
        {
            return await _context.Dietitians
                .Include(d => d.TimeSlots)
                .Include(d => d.Appointments)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dietitian>> GetDietitian(int id)
        {
            var dietitian = await _context.Dietitians
                .Include(d => d.TimeSlots)
                .Include(d => d.Appointments)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dietitian == null)
            {
                return NotFound();
            }

            return dietitian;
        }

        [HttpPost]
        public async Task<ActionResult<Dietitian>> AddDietitian(Dietitian dietitian)
        {
            _context.Dietitians.Add(dietitian);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDietitian), new { id = dietitian.Id }, dietitian);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDietitian(int id, Dietitian dietitian)
        {
            if (id != dietitian.Id)
            {
                return BadRequest();
            }

            _context.Entry(dietitian).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietitian(int id)
        {
            var dietitian = await _context.Dietitians.FindAsync(id);

            if (dietitian == null)
            {
                return NotFound();
            }

            _context.Dietitians.Remove(dietitian);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
