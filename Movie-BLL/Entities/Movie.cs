using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_BLL.Entities
{
    public class Movie : IMovie
    {
        private string _title;
        private string? _subtitle;
        private string? _synopsis;
        public int MovieId {  get; set; }
        public string Title {
            get { return _title; }
            set {
                if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(Title));
                value = value.Trim();
                if(value.Length > 64) throw new ArgumentException(nameof(Title));
                _title = value;
            }
        }
        public string? SubTitle {
            get { return _subtitle; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _subtitle = null;
                    return;
                }
                value = value.Trim();
                if (value.Length > 64) throw new ArgumentException(nameof(SubTitle));
                _subtitle = value;
            }
        }
        public string? Synopsis
        {
            get { return _synopsis; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _synopsis = null;
                    return;
                }
                value = value.Trim();
                if (value.Length > 512) throw new ArgumentException(nameof(Synopsis));
                _synopsis = value;
            }
        }
        public DateTime ReleaseDate  { get; set; }
        public Category MainCategory { get; set; }

        public IEnumerable<Actor> Actors {  get; set; }

        public Movie(int movieId, string title, DateTime releaseDate, Category mainCategory, string? subTitle = null, string? synopsis = null) : this(title, releaseDate, mainCategory, subTitle, synopsis)
        {
            MovieId = movieId;
        }

        public Movie(string title, DateTime releaseDate, Category mainCategory, string? subTitle = null, string? synopsis = null)
        {
            Title = title;
            SubTitle = subTitle;
            Synopsis = synopsis;
            ReleaseDate = releaseDate;
            MainCategory = mainCategory;
        }

        public Movie(Movie_DAL.Entities.Movie movie)
        {
            MovieId = movie.MovieId;
            _title = movie.Title;
            _subtitle = movie.SubTitle;
            _synopsis = movie.Synopsis;
            ReleaseDate = movie.ReleaseDate;
            MainCategory = Enum.Parse<Category>(movie.MainCategory);
            Actors = null;
        }

        public Movie(Movie_DAL.Entities.Movie movie, IEnumerable<Actor> actors) : this(movie)
        {
            Actors = actors;
        }
    }
}
