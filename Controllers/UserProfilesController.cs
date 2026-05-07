using DietPlannerAPI.Data;
using DietPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfilesController : ControllerBase
    {
        private readonly DietPlannerDbContext _context;

        public UserProfilesController(DietPlannerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
        {
            return await _context.UserProfiles
                .Include(u => u.BodyMeasurements)
                .Include(u => u.Goals)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfile>> GetUserProfile(int id)
        {
            var userProfile = await _context.UserProfiles
                .Include(u => u.BodyMeasurements)
                .Include(u => u.Goals)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return userProfile;
        }

        [HttpPost]
        public async Task<ActionResult<UserProfile>> AddUserProfile(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserProfile), new { id = userProfile.Id }, userProfile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProfile(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(userProfile).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var userProfile = await _context.UserProfiles.FindAsync(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
