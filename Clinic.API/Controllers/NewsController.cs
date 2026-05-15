using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clinic.API.Data;
using Clinic.Shared.Model;

namespace Clinic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ClinicContext _context;

        public NewsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            try
            {
                return await _context.News
                    .OrderByDescending(n => n.PublishDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống Delta: {ex.Message}");
            }
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var newsItem = await _context.News.FindAsync(id);
            if (newsItem == null) return NotFound("Không tìm thấy bài viết.");
            return newsItem;
        }

        // POST: api/News (DÙNG ĐỂ THÊM MỚI)
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            try
            {
                news.PublishDate = DateTime.Now; // Tự động gán ngày đăng
                _context.News.Add(news);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetNews), new { id = news.NewsID }, news);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi thêm bài viết: {ex.Message}");
            }
        }

        // PUT: api/News/5 (DÙNG ĐỂ CẬP NHẬT - FIX LỖI 405)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNews(int id, News news)
        {
            if (id != news.NewsID)
            {
                return BadRequest("ID không khớp.");
            }

            _context.Entry(news).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.News.Any(e => e.NewsID == id)) return NotFound();
                else throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi cập nhật: {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/News/5 (DÙNG ĐỂ XÓA)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null) return NotFound();

            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}