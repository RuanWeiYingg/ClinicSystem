using Clinic.API.Data;
using Clinic.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ClinicContext _context;

        public DoctorsController(ClinicContext context)
        {
            _context = context;
        }

        // 1. Lấy danh sách tất cả bác sĩ kèm thông tin User và Chuyên khoa
        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Specialty)
                .ToListAsync();
        }

        // 2. Lấy thông tin chi tiết bác sĩ theo DoctorID
        // GET: api/Doctors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Specialty)
                .FirstOrDefaultAsync(d => d.DoctorID == id);

            if (doctor == null)
            {
                return NotFound("Không tìm thấy bác sĩ có ID này.");
            }

            return doctor;
        }

        // 3. QUAN TRỌNG: Lấy thông tin bác sĩ theo UserID (Dùng cho logic Login Desktop)
        // GET: api/Doctors/user/2
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Doctor>> GetDoctorByUserId(int userId)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Specialty)
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.UserID == userId);

            if (doctor == null)
            {
                return NotFound("Tài khoản này chưa có thông tin chuyên môn trong danh sách bác sĩ.");
            }

            return doctor;
        }

        // 4. Thêm bác sĩ mới
        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDoctor), new { id = doctor.DoctorID }, doctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi thêm bác sĩ: {ex.Message}");
            }
        }

        // 5. Cập nhật thông tin bác sĩ
        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.DoctorID)
            {
                return BadRequest("ID bác sĩ không khớp giữa URL và dữ liệu.");
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // 6. Xóa bác sĩ
        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpPost("{id}/avatar")]
        //public async Task<IActionResult> UploadAvatar(int id, IFormFile avatar)
        //{
        //    var doctor = await _context.Doctors.FindAsync(id);
        //    if (doctor == null) return NotFound();

        //    using var ms = new MemoryStream();
        //    await avatar.CopyToAsync(ms);
        //    doctor.AvatarData = ms.ToArray(); // Thêm field này vào model + DB

        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorID == id);
        }
    }
}