using Microsoft.AspNetCore.Mvc;
using Clinic.Shared.Model;
using System.Net.Http.Json;

namespace Clinic.PatientWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _http;

        public AccountController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ClinicAPI");
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserID") != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string phoneNumber, string password)
        {
            var loginRequest = new User { Username = phoneNumber, PasswordHash = password };

            try
            {
                var response = await _http.PostAsJsonAsync("api/Auth/login", loginRequest);
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<User>();
                    if (user != null)
                    {
                        // Lưu Session đồng nhất
                        HttpContext.Session.SetString("UserID", user.UserID.ToString());
                        HttpContext.Session.SetString("FullName", user.FullName ?? "");
                        HttpContext.Session.SetString("UserPhone", user.Username ?? "");
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch
            {
                ViewBag.Error = "Lỗi kết nối API Delta.";
            }

            ViewBag.Error = "Sai số điện thoại hoặc mật khẩu.";
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetString("UserID");
            if (string.IsNullOrEmpty(userId)) return RedirectToAction("Login");

            // Truyền dữ liệu ra View để hiển thị
            ViewBag.FullName = HttpContext.Session.GetString("FullName");
            ViewBag.Phone = HttpContext.Session.GetString("UserPhone");
            return View();
        }

        // GET: /Account/ChangePassword
        public IActionResult ChangePassword()
        {
            // Kiểm tra nếu chưa đăng nhập thì bắt quay về trang Login
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("FullName")))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        // POST: /Account/ChangePassword (Dùng để xử lý khi bấm lưu mật khẩu mới)
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            // Logic gọi API đổi mật khẩu sẽ viết ở đây
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}