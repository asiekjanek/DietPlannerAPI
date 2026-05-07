using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterIntakesController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public WaterIntakesController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WaterIntake>>> GetWaterIntakes()
        {
            return await _context.WaterIntakes
                .Include(w => w.UserProfile)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WaterIntake>> GetWaterIntake(int id)
        {
            var waterIntake = await _context.WaterIntakes
                .Include(w => w.UserProfile)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (waterIntake == null)
            {
                return NotFound();
            }

            return waterIntake;
        }

        [HttpPost]
        public async Task<ActionResult<WaterIntake>> AddWaterIntake(WaterIntake waterIntake)
        {
            _context.WaterIntakes.Add(waterIntake);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWaterIntake), new { id = waterIntake.Id }, waterIntake);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWaterIntake(int id, WaterIntake waterIntake)
        {
            if (id != waterIntake.Id)
            {
                return BadRequest();
            }

            _context.Entry(waterIntake).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWaterIntake(int id)
        {
            var waterIntake = await _context.WaterIntakes.FindAsync(id);

            if (waterIntake == null)
            {
                return NotFound();
            }

            _context.WaterIntakes.Remove(waterIntake);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
