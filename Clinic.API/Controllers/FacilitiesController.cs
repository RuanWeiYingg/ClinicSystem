using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.Shared.Model;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly ClinicContext _context;

        public FacilitiesController(ClinicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
        {
            // Lấy danh sách từ bảng Facilities vừa tạo trong SQL
            return await _context.Facilities.ToListAsync();
        }
    }
}