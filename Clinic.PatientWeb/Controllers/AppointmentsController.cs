using Microsoft.AspNetCore.Mvc;

namespace Clinic.PatientWeb.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HttpClient _http;

        // Inject IHttpClientFactory từ DI (đăng ký trong Program.cs)
        public AppointmentsController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("ClinicAPI");
        }

        // -------------------------------------------------------
        // GET /Appointments/TrackProgress/5
        // Trả về View trang tiến trình khám
        // -------------------------------------------------------
        [HttpGet]
        public IActionResult TrackProgress(int id)
        {
            return View(id);
        }

        // -------------------------------------------------------
        // GET /api/appointments/upcoming
        // Được gọi bởi fetch() trong Index.cshtml
        // Relay sang Clinic.API rồi trả JSON về browser
        // -------------------------------------------------------
        [HttpGet("/api/appointments/upcoming")]
        public async Task<IActionResult> GetUpcoming()
        {
            // Lấy patientId từ Session
            var patientId = HttpContext.Session.GetString("PatientId");
            if (string.IsNullOrEmpty(patientId))
                return Unauthorized();

            // Gọi sang Clinic.API
            var response = await _http.GetAsync(
                $"api/Appointments/upcoming?patientId={patientId}");

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode);

            // Trả thẳng JSON từ API về cho browser
            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json");
        }
    }
}