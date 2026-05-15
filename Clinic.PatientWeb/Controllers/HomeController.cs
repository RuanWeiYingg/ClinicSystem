using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Clinic.PatientWeb.Models;
using Clinic.Shared.Model;
using System.Net.Http.Json;

namespace Clinic.PatientWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _http;

    // Inject IHttpClientFactory để tạo client kết nối tới API
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
    {
        _logger = logger;
        // "ClinicAPI" là tên đã cấu hình trong Program.cs
        _http = factory.CreateClient("ClinicAPI");
    }

    public IActionResult Index()
    {
        // Truyền thông tin session xuống View
        ViewBag.IsLoggedIn = !string.IsNullOrEmpty(HttpContext.Session.GetString("FullName"));
        ViewBag.FullName = HttpContext.Session.GetString("FullName");
        ViewBag.UserPhone = HttpContext.Session.GetString("UserPhone");
        return View();
    }

    public IActionResult About()
    {
        ViewData["Title"] = "Về chúng tôi";
        return View();
    }

    public async Task<IActionResult> Services()
    {
        List<Services> services = new List<Services>();
        try
        {
            var response = await _http.GetFromJsonAsync<List<Services>>("api/Services");
            if (response != null) services = response;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Lỗi trang Services: {ex.Message}");
        }
        return View(services);
    }

    public async Task<IActionResult> Facilities()
    {
        ViewData["Title"] = "Trang thiết bị - Phòng khám Delta";
        List<Facility> list = new List<Facility>();
        try
        {
            var response = await _http.GetFromJsonAsync<List<Facility>>("api/Facilities");
            if (response != null) list = response;
        }
        catch
        {
            ViewBag.Message = "Hệ thống đang cập nhật danh sách trang thiết bị.";
        }
        return View(list);
    }

    public async Task<IActionResult> Doctors()
    {
        ViewData["Title"] = "Đội ngũ Bác sĩ - Delta";
        try
        {
            var doctors = await _http.GetFromJsonAsync<List<Doctor>>("api/Doctors");
            return View(doctors ?? new List<Doctor>());
        }
        catch
        {
            ViewBag.Error = "Hiện tại không thể kết nối với danh sách bác sĩ.";
            return View(new List<Doctor>());
        }
    }

    public async Task<IActionResult> News()
    {
        ViewData["Title"] = "Tin tức & Sự kiện - Delta";
        try
        {
            var data = await _http.GetFromJsonAsync<List<News>>("api/News");
            return View(data ?? new List<News>());
        }
        catch
        {
            return View(new List<News>());
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            // Gọi API lấy chi tiết 1 bài viết theo ID
            var news = await _http.GetFromJsonAsync<News>($"api/News/{id}");

            if (news == null)
            {
                return NotFound("Không tìm thấy nội dung bài viết.");
            }

            return View(news);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Lỗi khi lấy chi tiết tin tức ID {id}: {ex.Message}");
            return RedirectToAction("News");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}