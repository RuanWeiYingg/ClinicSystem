using Clinic.Shared.Model;
using System.ComponentModel.DataAnnotations;

public class MedicalRecord
{
    [Key]
    public int RecordID { get; set; }
    public int AppointmentID { get; set; }

    // Thêm 2 dòng này để khớp với logic khám bệnh
    public int PatientID { get; set; }
    public string? Symptoms { get; set; }

    public string Diagnosis { get; set; } = string.Empty;
    public string? TreatmentPlan { get; set; }
    public string? Prescription { get; set; }

    // Bạn đang dùng DateCreated, hãy giữ nguyên nó
    public DateTime DateCreated { get; set; } = DateTime.Now;

    public virtual Appointment? Appointment { get; set; }
}