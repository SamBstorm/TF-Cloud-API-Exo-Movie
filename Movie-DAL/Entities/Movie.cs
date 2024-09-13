using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_DAL.Entities
{
    public class Movie : IMovie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string MainCategory { get; set; }
    }
}
