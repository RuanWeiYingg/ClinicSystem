using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Shared.Model
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public int RoleID { get; set; } 
        public DateTime? CreatedAt { get; set; }

        // Navigation Property: Để lấy thông tin từ bảng Roles
        [ForeignKey("RoleID")]
        public virtual Role? Role { get; set; }
    }
}