using Movie_API.Models;
using BLL = Movie_BLL.Entities;

namespace Movie_API.Mapper
{
    public static class Mapper
    {
        #region Person
        public static BLL.Person ToBLL(this PersonPost entity)
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Person(
                entity.LastName,
                entity.FirstName,
                entity.BirthDate
                );
        }

        public static Person ToModel(this BLL.Person entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Person() {
                PersonId = entity.PersonId,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                BirthDate = entity.BirthDate
                };
        }

        #endregion
        #region Movie
        public static BLL.Movie ToBLL(this MoviePost entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new BLL.Movie(
                entity.Title,
                entity.ReleaseDate,
                Enum.Parse<BLL.Category>(entity.MainCategory),
                entity.SubTitle,
                entity.Synopsis
                );
        }

        public static Movie ToModel(this BLL.Movie entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Movie()
            {
                MovieId = entity.MovieId,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                Synopsis = entity.Synopsis,
                ReleaseDate = entity.ReleaseDate,
                MainCategory = entity.MainCategory,
                Actors = null
            };
        }

        public static Movie ToDetailedModel(this BLL.Movie entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new Movie()
            {
                MovieId = entity.MovieId,
                Title = entity.Title,
                SubTitle = entity.SubTitle,
                Synopsis = entity.Synopsis,
                ReleaseDate = entity.ReleaseDate,
                MainCategory = entity.MainCategory,
                Actors = entity.Actors.Select(e => e.ToModel())
            };
        }

        #endregion

        #region Actor

        public static ActorInMovie ToModel(this BLL.Actor entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            return new ActorInMovie()
            {
                Person = entity.Person.ToModel(),
                CharactersName = entity.CharactersName
            };
        }
        #endregion
    }
}
