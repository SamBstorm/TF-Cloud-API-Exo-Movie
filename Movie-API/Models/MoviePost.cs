namespace Movie_API.Models
{
    public class MoviePost
    {
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MainCategory { get; set; }
    }
}
