using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Clinic.Desktop.Helpers
{
    /// <summary>
    /// Validator tập trung — tất cả các trang quản lý gọi vào đây.
    /// Mỗi method trả về List<string> lỗi (rỗng = hợp lệ).
    /// Gọi ShowErrors() để hiện 1 MessageBox tổng hợp.
    /// </summary>
    public static class ClinicValidator
    {
        // ══════════════════════════════════════════════════════════
        //  HIỂN THỊ LỖI
        // ══════════════════════════════════════════════════════════

        public static bool ShowErrors(List<string> errors, string title = "Dữ liệu chưa hợp lệ")
        {
            if (errors == null || errors.Count == 0) return false;

            MessageBox.Show(
                "Vui lòng kiểm tra lại:\n\n" + string.Join("\n", errors),
                title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }

        // ══════════════════════════════════════════════════════════
        //  RULES DÙNG CHUNG
        // ══════════════════════════════════════════════════════════

        /// Họ tên: bắt buộc, 2–100 ký tự, không chứa số/ký tự đặc biệt
        public static void ValidateFullName(string value, List<string> errors,
            string fieldLabel = "Họ và tên")
        {
            if (string.IsNullOrWhiteSpace(value))
            { errors.Add($"• {fieldLabel} không được để trống."); return; }

            if (value.Trim().Length < 2)
                errors.Add($"• {fieldLabel} phải có ít nhất 2 ký tự.");

            if (value.Trim().Length > 100)
                errors.Add($"• {fieldLabel} không được vượt quá 100 ký tự.");

            if (Regex.IsMatch(value, @"[0-9!@#$%^&*()_+=\[\]{};':""\\|,.<>/?]"))
                errors.Add($"• {fieldLabel} không được chứa số hoặc ký tự đặc biệt.");
        }

        /// Số điện thoại VN: bắt buộc, 10 số, bắt đầu 0
        public static void ValidatePhone(string value, List<string> errors,
            string fieldLabel = "Số điện thoại")
        {
            if (string.IsNullOrWhiteSpace(value))
            { errors.Add($"• {fieldLabel} không được để trống."); return; }

            if (!Regex.IsMatch(value.Trim(), @"^0[0-9]{9}$"))
                errors.Add($"• {fieldLabel} phải gồm 10 chữ số và bắt đầu bằng 0.");
        }

        /// Email: không bắt buộc, nhưng nếu nhập phải đúng định dạng
        public static void ValidateEmail(string value, List<string> errors,
            string fieldLabel = "Email", bool required = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (required) errors.Add($"• {fieldLabel} không được để trống.");
                return;
            }

            if (!Regex.IsMatch(value.Trim(),
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errors.Add($"• {fieldLabel} không đúng định dạng (vd: ten@email.com).");

            if (value.Trim().Length > 150)
                errors.Add($"• {fieldLabel} không được vượt quá 150 ký tự.");
        }

        /// Username: bắt buộc, 4–50 ký tự, chỉ chữ/số/gạch dưới/chấm
        public static void ValidateUsername(string value, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(value))
            { errors.Add("• Tên đăng nhập không được để trống."); return; }

            if (value.Trim().Length < 4)
                errors.Add("• Tên đăng nhập phải có ít nhất 4 ký tự.");

            if (value.Trim().Length > 50)
                errors.Add("• Tên đăng nhập không được vượt quá 50 ký tự.");

            if (!Regex.IsMatch(value.Trim(), @"^[a-zA-Z0-9_.]+$"))
                errors.Add("• Tên đăng nhập chỉ được dùng chữ cái, số, dấu chấm và gạch dưới.");
        }

        /// Mật khẩu: bắt buộc khi tạo mới, tối thiểu 6 ký tự
        public static void ValidatePassword(string value, List<string> errors,
            bool required = true)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (required) errors.Add("• Mật khẩu không được để trống.");
                return;
            }

            if (value.Length < 6)
                errors.Add("• Mật khẩu phải có ít nhất 6 ký tự.");

            if (value.Length > 100)
                errors.Add("• Mật khẩu không được vượt quá 100 ký tự.");
        }

        /// Tên thực thể chung (chuyên khoa, dịch vụ, cơ sở...): bắt buộc, 2–200 ký tự
        public static void ValidateName(string value, List<string> errors,
            string fieldLabel = "Tên", int maxLength = 200)
        {
            if (string.IsNullOrWhiteSpace(value))
            { errors.Add($"• {fieldLabel} không được để trống."); return; }

            if (value.Trim().Length < 2)
                errors.Add($"• {fieldLabel} phải có ít nhất 2 ký tự.");

            if (value.Trim().Length > maxLength)
                errors.Add($"• {fieldLabel} không được vượt quá {maxLength} ký tự.");
        }

        /// Mô tả / Bio: không bắt buộc, giới hạn độ dài
        public static void ValidateDescription(string value, List<string> errors,
            string fieldLabel = "Mô tả", int maxLength = 1000)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
                errors.Add($"• {fieldLabel} không được vượt quá {maxLength} ký tự " +
                           $"(hiện tại: {value.Length}).");
        }

        /// Giá tiền: bắt buộc, > 0, không quá 1 tỷ
        public static void ValidatePrice(string value, List<string> errors,
            string fieldLabel = "Giá tiền")
        {
            if (string.IsNullOrWhiteSpace(value))
            { errors.Add($"• {fieldLabel} không được để trống."); return; }

            if (!decimal.TryParse(value.Trim().Replace(",", ""), out decimal price))
            { errors.Add($"• {fieldLabel} phải là số hợp lệ."); return; }

            if (price <= 0)
                errors.Add($"• {fieldLabel} phải lớn hơn 0.");

            if (price > 1_000_000_000)
                errors.Add($"• {fieldLabel} không được vượt quá 1.000.000.000 VNĐ.");
        }

        /// Số nguyên dương (thời gian, kinh nghiệm...): bắt buộc, min–max
        public static void ValidatePositiveInt(string value, List<string> errors,
            string fieldLabel, int min = 0, int max = int.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(value))
            { errors.Add($"• {fieldLabel} không được để trống."); return; }

            if (!int.TryParse(value.Trim(), out int num))
            { errors.Add($"• {fieldLabel} phải là số nguyên."); return; }

            if (num < min)
                errors.Add($"• {fieldLabel} phải lớn hơn hoặc bằng {min}.");

            if (num > max)
                errors.Add($"• {fieldLabel} không được vượt quá {max}.");
        }

        /// URL ảnh: không bắt buộc, kiểm tra định dạng nếu có nhập
        public static void ValidateImageUrl(string value, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(value)) return;

            string v = value.Trim();

            // Chấp nhận URL http/https
            bool isWebUrl = v.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                          || v.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

            // Chấp nhận đường dẫn web tương đối /images/...
            bool isRelativeWebPath = v.StartsWith("/images/", StringComparison.OrdinalIgnoreCase);

            // Chấp nhận file local tồn tại trên disk
            bool isFilePath = System.IO.File.Exists(v);

            if (!isWebUrl && !isRelativeWebPath && !isFilePath)
                errors.Add("• Đường dẫn ảnh không hợp lệ (phải là URL http/https, đường dẫn /images/... hoặc đường dẫn file tồn tại).");
        }
    }
}