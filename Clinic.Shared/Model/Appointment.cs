using Clinic.Shared.Model;

namespace Clinic.Shared.Model
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public int ServiceID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Navigation properties
        public virtual User? Patient { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public virtual Services? Service { get; set; }

        // ✅ THÊM 2 DÒNG NÀY
        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}