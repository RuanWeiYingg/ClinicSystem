namespace Clinic.Shared.Model
{
    public class Facility
    {
        public int FacilityID { get; set; }
        public string FacilityName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsOperating { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}