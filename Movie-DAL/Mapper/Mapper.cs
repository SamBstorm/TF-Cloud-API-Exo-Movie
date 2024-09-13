using Movie_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Movie_DAL.Mapper
{
    internal static class Mapper
    {
        public static Person ToPerson(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Person()
            {
                PersonId = (int)record[nameof(Person.PersonId)],
                LastName = (string)record[nameof(Person.LastName)],
                FirstName = (string)record[nameof(Person.FirstName)],
                BirthDate = (DateTime)record[nameof(Person.BirthDate)]
            };
        }
        public static Movie ToMovie(this IDataRecord record)
        {
            if (record is null) throw new ArgumentNullException(nameof(record));
            return new Movie()
            {
                MovieId = (int)record[nameof(Movie.MovieId)],
                Title = (string)record[nameof(Movie.Title)],
                SubTitle = (record[nameof(Movie.SubTitle)] is DBNull) ? null : (string)record[nameof(Movie.SubTitle)],
                Synopsis = (record[nameof(Movie.Synopsis)] is DBNull) ? null : (string)record[nameof(Movie.Synopsis)],
                ReleaseDate = (DateTime)record[nameof(Movie.ReleaseDate)],
                MainCategory = (string)record[nameof(Movie.MainCategory)]
            };
        }
    }
}
