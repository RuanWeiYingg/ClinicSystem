using Clinic.API.Data;
using Clinic.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordsController : ControllerBase
    {
        private readonly ClinicContext _context;
        public MedicalRecordsController(ClinicContext context) { _context = context; }

        // 1. Lấy tất cả hồ sơ kèm thông tin Lịch hẹn (để lấy thông tin Bệnh nhân/Bác sĩ)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetRecords()
        {
            return await _context.MedicalRecords
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        // 2. Lấy chi tiết một hồ sơ theo RecordId
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalRecord>> GetRecord(int id)
        {
            // Sử dụng RecordId theo Model của bạn
            var record = await _context.MedicalRecords
                .Include(r => r.Appointment)
                .FirstOrDefaultAsync(r => r.RecordID == id);

            if (record == null) return NotFound("Không tìm thấy hồ sơ bệnh án.");
            return record;
        }

        // 3. Lấy hồ sơ theo ID lịch hẹn (Dùng cho trang khám bệnh)
        [HttpGet("appointment/{appointmentId}")]
        public async Task<ActionResult<MedicalRecord>> GetByAppointment(int appointmentId)
        {
            var record = await _context.MedicalRecords
                .FirstOrDefaultAsync(r => r.AppointmentID == appointmentId);

            if (record == null) return NotFound();
            return record;
        }

        // 4. Tạo mới hồ sơ
        [HttpPost]
        public async Task<ActionResult<MedicalRecord>> PostRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();

            // Sử dụng RecordId
            return CreatedAtAction(nameof(GetRecord), new { id = record.RecordID }, record);
        }

        // 5. Cập nhật hồ sơ
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, MedicalRecord record)
        {
            // Sử dụng RecordId
            if (id != record.RecordID) return BadRequest("ID hồ sơ không khớp.");

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }


        // 6. Lấy danh sách hồ sơ theo DoctorId và tìm kiếm theo PatientId (Dùng cho giao diện Bác sĩ)
        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetRecordsByDoctor(int doctorId, [FromQuery] string? patientSearch = null)
        {
            var query = _context.MedicalRecords
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Patient)
                .Where(r => r.Appointment.DoctorID == doctorId); // Ánh xạ qua bảng Appointment

            // Nếu bác sĩ gõ ID hoặc tên bệnh nhân vào ô tìm kiếm
            if (!string.IsNullOrEmpty(patientSearch))
            {
                query = query.Where(r => r.Appointment.Patient.FullName.Contains(patientSearch)
                                      || r.Appointment.PatientID.ToString() == patientSearch);
            }

            return await query.OrderByDescending(r => r.Appointment.AppointmentDate).ToListAsync();
        }


        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetByPatient(int patientId)
        {
            var records = await _context.MedicalRecords
                .Include(r => r.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Where(r => r.PatientID == patientId)
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();

            return Ok(records); // ← Trả [] nếu rỗng, không 404
        }


        private bool RecordExists(int id)
        {
            // Sử dụng RecordId
            return _context.MedicalRecords.Any(e => e.RecordID == id);
        }
    }
}