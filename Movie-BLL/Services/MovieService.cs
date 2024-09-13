using Movie_BLL.Entities;
using Movie_BLL.Mapper;
using Movie_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_BLL.Services
{
    public class MovieService : IMovieRepository<Movie>
    {
        private IMovieRepository<Movie_DAL.Entities.Movie> _repository;

        public MovieService(IMovieRepository<Movie_DAL.Entities.Movie> repository)
        {
            _repository = repository;
        }

        public int Create(Movie entity)
        {
            return _repository.Create(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Movie> Get()
        {
            return _repository.Get().Select(e=>e.ToBLL());
        }

        public Movie Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public void Update(int id, Movie entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
