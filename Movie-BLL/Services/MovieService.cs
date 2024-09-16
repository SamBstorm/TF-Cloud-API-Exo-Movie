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
        private IPersonRepository<Movie_DAL.Entities.Person> _personRepository;

        public MovieService(
            IMovieRepository<Movie_DAL.Entities.Movie> repository,
            IPersonRepository<Movie_DAL.Entities.Person> personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
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
            IEnumerable<Movie> result = _repository.Get().Select(e=>e.ToBLL());
            foreach (Movie movie in result)
            {
                IEnumerable<Actor> actors = _personRepository
                                                .GetByMovieId(movie.MovieId)
                                                .Select(e => e.ToBLL())
                                                .Select(e => new Actor(e, movie, _personRepository.GetAllRolesOnMovieId(e.PersonId, movie.MovieId)));
                movie.Actors = actors;
            }
            return result;
        }

        public Movie Get(int id)
        {
            Movie result = _repository.Get(id).ToBLL();
            IEnumerable<Actor> actors = _personRepository
                                                .GetByMovieId(id)
                                                .Select(e => e.ToBLL())
                                                .Select(e => new Actor(e,result,_personRepository.GetAllRolesOnMovieId(e.PersonId,id)));
            result.Actors = actors;
            return result;
        }

        public IEnumerable<Movie> GetByPersonId(int id)
        {
            return _repository.GetByPersonId(id).Select(e =>e.ToBLL());
        }

        public void Update(int id, Movie entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
