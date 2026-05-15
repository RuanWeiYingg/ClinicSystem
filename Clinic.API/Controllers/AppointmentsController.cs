using Clinic.API.Data;
using Clinic.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly ClinicContext _context;

    // ✅ Danh sách trạng thái hợp lệ — đồng bộ với UI
    private static readonly string[] ValidStatuses = new[]
    {
        "Pending",
        "Confirmed",
        "Examining",
        "WaitingForPayment",
        "Completed",
        "Cancelled"
    };

    public AppointmentsController(ClinicContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
    {
        return await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Service)
            .Include(a => a.Doctor).ThenInclude(d => d.User)
            .OrderBy(a => a.AppointmentID) // ✅ Tăng dần theo ID
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointment(int id)
    {
        var appointment = await _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Service)
            .Include(a => a.Doctor).ThenInclude(d => d.User)
            .FirstOrDefaultAsync(a => a.AppointmentID == id);

        if (appointment == null) return NotFound();
        return appointment;
    }

    [HttpPost]
    public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
    {
        // ✅ Đảm bảo lịch mới luôn bắt đầu từ Pending
        appointment.Status = "Pending";

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAppointment),
            new { id = appointment.AppointmentID }, appointment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
    {
        if (id != appointment.AppointmentID) return BadRequest("ID không khớp.");

        var existing = await _context.Appointments.FindAsync(id);
        if (existing == null) return NotFound();

        existing.PatientID = appointment.PatientID;
        existing.DoctorID = appointment.DoctorID;
        existing.ServiceID = appointment.ServiceID;
        existing.AppointmentDate = appointment.AppointmentDate;
        existing.Notes = appointment.Notes;

        // ✅ Chỉ update Status nếu hợp lệ — đồng bộ ValidStatuses
        if (!string.IsNullOrWhiteSpace(appointment.Status) &&
            ValidStatuses.Contains(appointment.Status))
        {
            existing.Status = appointment.Status;
        }

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null) return NotFound();

        // ✅ Không cho xóa nếu đã qua giai đoạn khám
        if (appointment.Status == "Examining" ||
            appointment.Status == "WaitingForPayment" ||
            appointment.Status == "Completed")
        {
            return BadRequest("Không thể xóa lịch hẹn đang/đã khám.");
        }

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetByDoctor(
        int doctorId, [FromQuery] string? date)
    {
        var query = _context.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Service)
            .Include(a => a.Doctor).ThenInclude(d => d.User)
            .Where(a => a.DoctorID == doctorId);

        if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out var parsedDate))
            query = query.Where(a => a.AppointmentDate.Date == parsedDate.Date);

        return await query.OrderBy(a => a.AppointmentID).ToListAsync();
    }

    [HttpGet("patient/{patientId}")]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetByPatient(int patientId)
    {
        return await _context.Appointments
            .Include(a => a.Service)
            .Include(a => a.Doctor).ThenInclude(d => d.User)
            .Where(a => a.PatientID == patientId)
            .OrderBy(a => a.AppointmentID)
            .ToListAsync();
    }

    [HttpPut("status/{id}")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusUpdateDto body)
    {
        if (string.IsNullOrWhiteSpace(body.Status))
            return BadRequest("Status không được để trống.");

        // ✅ Validate status hợp lệ
        if (!ValidStatuses.Contains(body.Status))
            return BadRequest($"Status '{body.Status}' không hợp lệ.");

        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null) return NotFound();

        appointment.Status = body.Status;
        await _context.SaveChangesAsync();
        return NoContent();
    }
}

public class StatusUpdateDto
{
    public string Status { get; set; }
}