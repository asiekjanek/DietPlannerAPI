using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public AppointmentsController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments
                .Include(a => a.Dietitian)
                .Include(a => a.UserProfile)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Dietitian)
                .Include(a => a.UserProfile)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await SetTimeSlotAvailability(appointment.DietitianId, appointment.AppointmentDate, false);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            var currentAppointment = await _context.Appointments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (currentAppointment == null)
            {
                return NotFound();
            }

            if (currentAppointment.DietitianId != appointment.DietitianId ||
                currentAppointment.AppointmentDate != appointment.AppointmentDate)
            {
                await SetTimeSlotAvailability(currentAppointment.DietitianId, currentAppointment.AppointmentDate, true);
            }

            await SetTimeSlotAvailability(appointment.DietitianId, appointment.AppointmentDate, false);
            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await SetTimeSlotAvailability(appointment.DietitianId, appointment.AppointmentDate, true);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task SetTimeSlotAvailability(int dietitianId, DateTime appointmentDate, bool isAvailable)
        {
            var timeSlot = await _context.TimeSlots
                .FirstOrDefaultAsync(ts => ts.DietitianId == dietitianId && ts.StartTime == appointmentDate);

            if (timeSlot != null)
            {
                timeSlot.IsAvailable = isAvailable;
            }
        }
    }
}
