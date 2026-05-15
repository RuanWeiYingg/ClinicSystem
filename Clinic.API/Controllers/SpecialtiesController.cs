using Clinic.API.Data;
using Clinic.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ClinicContext _context;
        public SpecialtiesController(ClinicContext context) { _context = context; }

        // 1. Lấy danh sách tất cả chuyên khoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialty>>> GetSpecialties()
            => await _context.Specialty.ToListAsync();

        // 2. Lấy chi tiết một chuyên khoa theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialty>> GetSpecialty(int id)
        {
            // Lưu ý: Hãy đảm bảo tên thuộc tính trong model Specialty là SpecialtyId hoặc Id
            var specialty = await _context.Specialty.FindAsync(id);

            if (specialty == null)
            {
                return NotFound("Không tìm thấy chuyên khoa.");
            }

            return specialty;
        }

        // 3. Thêm chuyên khoa mới
        [HttpPost]
        public async Task<ActionResult<Specialty>> PostSpecialty(Specialty specialty)
        {
            _context.Specialty.Add(specialty);
            await _context.SaveChangesAsync();

            // Giả định model dùng SpecialtyId làm khóa chính
            return CreatedAtAction(nameof(GetSpecialty), new { id = specialty.SpecialtyID }, specialty);
        }

        // 4. Cập nhật thông tin chuyên khoa
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialty(int id, Specialty specialty)
        {
            if (id != specialty.SpecialtyID)
            {
                return BadRequest("ID chuyên khoa không khớp.");
            }

            _context.Entry(specialty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialtyExists(id)) return NotFound();
                else throw;
            }

            // THAY THẾ return NoContent(); BẰNG DÒNG DƯỚI ĐÂY:
            return Ok(specialty);
        }

        // 5. Xóa chuyên khoa
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            var specialty = await _context.Specialty.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }

            _context.Specialty.Remove(specialty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialtyExists(int id)
        {
            return _context.Specialty.Any(e => e.SpecialtyID == id);
        }
    }
}