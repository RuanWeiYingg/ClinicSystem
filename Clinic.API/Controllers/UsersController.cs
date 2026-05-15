using Clinic.API.Data;
using Clinic.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ClinicContext _context;
        public UsersController(ClinicContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>?> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
        }

        // PUT: api/Users/5 - ĐÃ FIX LOGIC CẬP NHẬT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User userDto)
        {
            if (id != userDto.UserID) return BadRequest();

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null) return NotFound();

            // 1. Cập nhật các thông tin cơ bản
            existingUser.FullName = userDto.FullName;
            existingUser.RoleID = userDto.RoleID;
            existingUser.PhoneNumber = userDto.PhoneNumber;  
            existingUser.Email = userDto.Email;         
            // 2. Logic xử lý mật khẩu quan trọng
            if (!string.IsNullOrWhiteSpace(userDto.PasswordHash))
            {
                
                existingUser.PasswordHash = userDto.PasswordHash;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id)) return NotFound();
                else throw;
            }

            return Ok(existingUser); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("role/{roleId}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersByRole(int roleId)
        {
            return await _context.Users.Where(u => u.RoleID == roleId).ToListAsync();
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<User>>> GetPatientsByDoctor(int doctorId, [FromQuery] string? search)
        {
            var query = _context.Appointments
                .Where(a => a.DoctorID == doctorId)
                .Include(a => a.Patient)
                .Select(a => a.Patient!)
                .Distinct();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(u => u.FullName.Contains(search) || (u.PhoneNumber != null && u.PhoneNumber.Contains(search)));
            }
            return Ok(await query.ToListAsync());
        }

        private bool UserExists(int id) => _context.Users.Any(e => e.UserID == id);
    }
}