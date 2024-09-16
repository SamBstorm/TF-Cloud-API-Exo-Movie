using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Common.Repositories
{
    public interface IMovieRepository<TMovie> : ICRUDRepository<TMovie, int> where TMovie : IMovie
    {
        public IEnumerable<TMovie> GetByPersonId(int id);
    }
}
