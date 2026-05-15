using System.ComponentModel.DataAnnotations;

namespace Clinic.Shared.Model
{
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }

        public string? ServiceName { get; set; }

        public decimal Price { get; set; }

        public int DurationMinutes { get; set; }

        // --- THÊM DÒNG NÀY ĐỂ CHỨA ẢNH ---
        public string? ImageUrl { get; set; }
    }
}