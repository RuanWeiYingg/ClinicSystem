using Clinic.API.Data;
using Clinic.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ClinicContext _context;
        public InvoicesController(ClinicContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await _context.Invoices
                .Include(i => i.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(i => i.Appointment)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d.User) // ✅ Include thêm Doctor nếu cần hiển thị
                .ToListAsync();
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<ActionResult<Invoice>> GetInvoiceByAppointment(int appointmentId)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Appointment)
                    .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(i => i.AppointmentID == appointmentId);

            if (invoice == null) return NotFound("Không tìm thấy hóa đơn cho lịch hẹn này.");
            return invoice;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.Appointment)
                    .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(i => i.InvoiceID == id);

            if (invoice == null) return NotFound("Không tìm thấy hóa đơn.");
            return invoice;
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInvoice), new { id = invoice.InvoiceID }, invoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceID) return BadRequest("ID hóa đơn không khớp.");

            // ✅ Chỉ cập nhật các field cần thiết, tránh overwrite navigation property
            var existing = await _context.Invoices.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Status = invoice.Status;
            existing.PaymentDate = invoice.PaymentDate;
            existing.TotalAmount = invoice.TotalAmount;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null) return NotFound();
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceID == id);
        }
    }
}