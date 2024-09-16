using Movie_BLL.Entities;

namespace Movie_API.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Category MainCategory { get; set; }
    }
}
