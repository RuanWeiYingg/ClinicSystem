using Microsoft.AspNetCore.Mvc;
using Clinic.Shared.Model;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.PatientWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly HttpClient _http;

        // Cấu hình giờ làm việc — chỉnh ở đây nếu phòng khám thay đổi lịch
        private const int WorkHourStart = 8;
        private const int WorkHourEnd = 17;
        private const int MaxBookAhead = 60; // ngày

        public BookingController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ClinicAPI");
        }

        // ── HELPER ──────────────────────────────────────────────────
        private string? GetUserId() => HttpContext.Session.GetString("UserID");

        // ── INDEX ────────────────────────────────────────────────────
        public IActionResult Index() => View();

        // ── GET: CreateBooking ───────────────────────────────────────
        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Account");

            await LoadViewDataForBooking();
            return View();
        }

        // ── POST: CreateBooking ──────────────────────────────────────
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBooking(Appointment appointment)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Account");

  

            // 1. Ngày không được để trống
            if (appointment.AppointmentDate == default)
            {
                ModelState.AddModelError("AppointmentDate", "Vui lòng chọn ngày và giờ hẹn.");
            }
            else
            {
                // 2. Không đặt lịch trong quá khứ
                if (appointment.AppointmentDate < DateTime.Now)
                    ModelState.AddModelError("AppointmentDate",
                        "Ngày hẹn không được ở trong quá khứ.");

                // 3. Không đặt quá xa
                if (appointment.AppointmentDate.Date > DateTime.Today.AddDays(MaxBookAhead))
                    ModelState.AddModelError("AppointmentDate",
                        $"Chỉ được đặt lịch trong vòng {MaxBookAhead} ngày tới.");

                // 4. Không đặt ngày Chủ nhật
                if (appointment.AppointmentDate.DayOfWeek == DayOfWeek.Sunday)
                    ModelState.AddModelError("AppointmentDate",
                        "Phòng khám không làm việc vào Chủ nhật.");

                // 5. Kiểm tra giờ làm việc
                int hour = appointment.AppointmentDate.Hour;
                if (hour < WorkHourStart || hour >= WorkHourEnd)
                    ModelState.AddModelError("AppointmentDate",
                        $"Chỉ đặt lịch trong giờ làm việc ({WorkHourStart}:00 – {WorkHourEnd}:00).");
            }

            // 6. Bác sĩ bắt buộc
            if (appointment.DoctorID <= 0)
                ModelState.AddModelError("DoctorID", "Vui lòng chọn bác sĩ.");

            // 7. Dịch vụ bắt buộc
            if (appointment.ServiceID <= 0)
                ModelState.AddModelError("ServiceID", "Vui lòng chọn dịch vụ.");

            // 8. Ghi chú không quá dài
            if (!string.IsNullOrEmpty(appointment.Notes) && appointment.Notes.Length > 500)
                ModelState.AddModelError("Notes",
                    "Ghi chú không được vượt quá 500 ký tự.");

            // Nếu có lỗi UX → trả lại view ngay, không gọi API
            if (!ModelState.IsValid)
            {
                await LoadViewDataForBooking();
                return View(appointment);
            }

            // ── Gán giá trị mặc định trước khi gửi API ──────────────
            appointment.PatientID = int.Parse(userId);
            appointment.Status = "Pending";
            appointment.CreatedAt = DateTime.Now;

            try
            {
                var response = await _http.PostAsJsonAsync("api/Appointments", appointment);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("BookingSuccess");

                // Đọc message lỗi từ API (trùng lịch, bác sĩ không rảnh, v.v.)
                var apiError = await response.Content.ReadAsStringAsync();
                ViewBag.Error = string.IsNullOrWhiteSpace(apiError)
                    ? "Đặt lịch không thành công. Vui lòng thử lại."
                    : apiError;
            }
            catch (HttpRequestException)
            {
                ViewBag.Error = "Không thể kết nối tới máy chủ Delta. Vui lòng thử lại sau.";
            }

            await LoadViewDataForBooking();
            return View(appointment);
        }

        // ── LoadViewData (dùng chung GET & POST lỗi) ────────────────
        private async Task LoadViewDataForBooking()
        {
            try
            {
                var doctors = await _http.GetFromJsonAsync<List<Doctor>>("api/Doctors");
                var services = await _http.GetFromJsonAsync<List<Services>>("api/Services");
                var specialties = await _http.GetFromJsonAsync<List<Specialty>>("api/Specialties");

                ViewBag.Doctors = doctors ?? new List<Doctor>();
                ViewBag.Services = services ?? new List<Services>();
                ViewBag.Specialties = specialties ?? new List<Specialty>();
            }
            catch
            {
                ViewBag.Doctors = new List<Doctor>();
                ViewBag.Services = new List<Services>();
                ViewBag.Specialties = new List<Specialty>();
                ViewBag.Error = "Hệ thống đang bảo trì dữ liệu danh mục.";
            }

            // Truyền giới hạn ngày cho input[type=datetime-local] trong View
            ViewBag.MinDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm");
            ViewBag.MaxDate = DateTime.Today.AddDays(MaxBookAhead)
                                            .ToString($"yyyy-MM-ddT{WorkHourEnd}:00");
        }

        // ── TrackProgress ────────────────────────────────────────────
        public async Task<IActionResult> TrackProgress(int? id)
        {
            if (id == null)
                return View(new Appointment { Status = "None" });

            try
            {
                var appointment = await _http.GetFromJsonAsync<Appointment>(
                    $"api/Appointments/{id}");
                return View(appointment ?? new Appointment { Status = "Pending" });
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // ── MyHistory ────────────────────────────────────────────────
        [HttpGet]
        public async Task<IActionResult> MyHistory()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Login", "Account");

            try
            {
                var history = await _http.GetFromJsonAsync<List<Appointment>>(
                    $"api/Appointments/Patient/{userId}");
                return View(history ?? new List<Appointment>());
            }
            catch
            {
                ViewBag.Error = "Không thể tải lịch sử khám.";
                return View(new List<Appointment>());
            }
        }

        // ── BookingSuccess ───────────────────────────────────────────
        public IActionResult BookingSuccess() => View();
    }

}