using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodyMeasurementsController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public BodyMeasurementsController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyMeasurement>>> GetBodyMeasurements()
        {
            return await _context.BodyMeasurements
                .Include(b => b.UserProfile)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BodyMeasurement>> GetBodyMeasurement(int id)
        {
            var bodyMeasurement = await _context.BodyMeasurements
                .Include(b => b.UserProfile)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bodyMeasurement == null)
            {
                return NotFound();
            }

            return bodyMeasurement;
        }

        [HttpPost]
        public async Task<ActionResult<BodyMeasurement>> AddBodyMeasurement(BodyMeasurement bodyMeasurement)
        {
            _context.BodyMeasurements.Add(bodyMeasurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBodyMeasurement), new { id = bodyMeasurement.Id }, bodyMeasurement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBodyMeasurement(int id, BodyMeasurement bodyMeasurement)
        {
            if (id != bodyMeasurement.Id)
            {
                return BadRequest();
            }

            _context.Entry(bodyMeasurement).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyMeasurement(int id)
        {
            var bodyMeasurement = await _context.BodyMeasurements.FindAsync(id);

            if (bodyMeasurement == null)
            {
                return NotFound();
            }

            _context.BodyMeasurements.Remove(bodyMeasurement);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
