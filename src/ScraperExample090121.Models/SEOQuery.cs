namespace ScraperExample090121.Models
{
    public class SEOQuery
    {
        public int Id { get; set; }
        public string SearchEngine { get; set; }
        public string Terms { get; set; }
        public string Url { get; set; }
        public int SEOPosition { get; set; }
    }
}