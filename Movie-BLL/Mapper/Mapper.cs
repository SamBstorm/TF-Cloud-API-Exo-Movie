using System;
using System.Collections.Generic;
using System.Text;
using DAL = Movie_DAL.Entities;
using BLL = Movie_BLL.Entities;

namespace Movie_BLL.Mapper
{
    internal static class Mapper
    {
        #region Person
        public static DAL.Person ToDAL(this BLL.Person entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Person()
            {
                PersonId = entity.PersonId,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                BirthDate = entity.BirthDate
            };
        }

        public static BLL.Person ToBLL(this DAL.Person entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Person(entity);
        }
        #endregion


        #region Movie
        public static DAL.Movie ToDAL(this BLL.Movie entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new DAL.Movie()
            {
                MovieId = entity.MovieId,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                Synopsis = entity.Synopsis,
                ReleaseDate = entity.ReleaseDate,
                MainCategory = entity.MainCategory.ToString()
            };
        }

        public static BLL.Movie ToBLL(this DAL.Movie entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Movie(entity);
        }
        public static BLL.Movie ToBLL(this DAL.Movie entity, IEnumerable<BLL.Actor> actors)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            if (actors is null) throw new ArgumentNullException(nameof(actors));
            return new BLL.Movie(entity, actors);
        }
        #endregion
    }
}
