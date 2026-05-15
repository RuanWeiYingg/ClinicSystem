using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.Shared;
using Clinic.Shared.Model;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ClinicContext _context;

        public ServicesController(ClinicContext context)
        {
            _context = context;
        }

        // 1. LẤY DANH SÁCH
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> GetServices()
        {
            // Sắp xếp theo tên cho dễ nhìn trên DataGridView
            return await _context.Services.OrderBy(s => s.ServiceName).ToListAsync();
        }

        // 2. THÊM MỚI
        [HttpPost]
        public async Task<ActionResult<Services>> PostService(Services service)
        {
            if (service == null) return BadRequest("Dữ liệu không hợp lệ");

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            // nameof(GetServices) giúp định hướng sau khi tạo xong
            return CreatedAtAction(nameof(GetServices), new { id = service.ServiceID }, service);
        }

        // 3. CẬP NHẬT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Services service)
        {
            // Kiểm tra ID khớp nhau
            if (id != service.ServiceID) return BadRequest("ID không khớp");

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id)) return NotFound("Không tìm thấy dịch vụ");
                else throw;
            }

            return NoContent();
        }

        // 4. XÓA DỊCH VỤ
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound("Dịch vụ không tồn tại");

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Hàm phụ kiểm tra tồn tại
        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceID == id);
        }
    }
}