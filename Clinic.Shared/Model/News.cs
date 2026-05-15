namespace Clinic.Shared.Model
{
    public class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public string? Author { get; set; }
    }
}