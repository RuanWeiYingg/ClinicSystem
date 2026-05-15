using System;
using System.Collections.Generic;

namespace Clinic.Shared.Model 
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public int SpecialtyID { get; set; }
        public int? ExperienceYears { get; set; }
        public string? Bio { get; set; }
        public bool? IsActive { get; set; }

        public virtual User? User { get; set; }
        public virtual Specialty? Specialty { get; set; }
    }
}