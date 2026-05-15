using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.Shared.Model;
using System.Threading.Tasks;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ClinicContext _context;

        public AuthController(ClinicContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Xử lý đăng nhập cho hệ thống Phòng khám Delta
        /// Cho phép đăng nhập bằng Username hoặc Số điện thoại
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginInfo)
        {
            // 1. Kiểm tra tính hợp lệ của dữ liệu đầu vào
            if (loginInfo == null || string.IsNullOrEmpty(loginInfo.Username)
                                 || string.IsNullOrEmpty(loginInfo.PasswordHash))
            {
                return BadRequest("Vui lòng nhập đầy đủ tài khoản/số điện thoại và mật khẩu.");
            }

            try
            {
                // 2. Truy vấn Database thông minh: 
                // Tìm User khớp mật khẩu VÀ (Khớp Username HOẶC Khớp PhoneNumber)
                var user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => (u.Username == loginInfo.Username || u.PhoneNumber == loginInfo.Username)
                                           && u.PasswordHash == loginInfo.PasswordHash);

                // 3. Nếu không tìm thấy User phù hợp
                if (user == null)
                {
                    // Trả về Unauthorized để phía Web hiển thị thông báo lỗi đỏ
                    return Unauthorized("Thông tin đăng nhập không chính xác.");
                }

                // 4. Bảo mật: Xóa mật khẩu trước khi gửi dữ liệu về phía Web
                user.PasswordHash = null;

                // Trả về đối tượng User kèm thông tin Role (Admin/Bác sĩ/Bệnh nhân)
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu có vấn đề kết nối Database SQL Server
                return StatusCode(500, $"Lỗi hệ thống Delta: {ex.Message}");
            }
        }
    }
}