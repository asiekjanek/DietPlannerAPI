using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSlotsController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public TimeSlotsController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeSlot>>> GetTimeSlots()
        {
            return await _context.TimeSlots
                .Include(ts => ts.Dietitian)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlot>> GetTimeSlot(int id)
        {
            var timeSlot = await _context.TimeSlots
                .Include(ts => ts.Dietitian)
                .FirstOrDefaultAsync(ts => ts.Id == id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            return timeSlot;
        }

        [HttpPost]
        public async Task<ActionResult<TimeSlot>> AddTimeSlot(TimeSlot timeSlot)
        {
            _context.TimeSlots.Add(timeSlot);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTimeSlot), new { id = timeSlot.Id }, timeSlot);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeSlot(int id, TimeSlot timeSlot)
        {
            if (id != timeSlot.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeSlot).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeSlot(int id)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(id);

            if (timeSlot == null)
            {
                return NotFound();
            }

            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
