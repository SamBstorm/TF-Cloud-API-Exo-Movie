using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Movie_Common.Repositories;
using Movie_DAL.Entities;
using Movie_DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_DAL.Services
{
    public class MovieService : BaseService, IMovieRepository<Movie>
    {
        public MovieService(IConfiguration config) : base(config, "Movie-DB")
        {
        }

        public int Create(Movie entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Movie_Insert";
                    command.Parameters.AddWithValue("title", entity.Title);
                    command.Parameters.AddWithValue("subtitle", (object?)entity.SubTitle ?? DBNull.Value);
                    command.Parameters.AddWithValue("synopsis", (object?)entity.Synopsis ?? DBNull.Value);
                    command.Parameters.AddWithValue("releaseDate", entity.ReleaseDate);
                    command.Parameters.AddWithValue("category", entity.MainCategory);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Movie_Delete";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Movie> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Movie_GetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToMovie();
                        }
                    }
                }
            }
        }

        public Movie Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Movie_GetById";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToMovie();
                        }
                        throw new ArgumentOutOfRangeException(nameof(id));
                    }
                }
            }
        }

        public void Update(int id, Movie entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Movie_Update";
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("title", entity.Title);
                    command.Parameters.AddWithValue("subtitle", (object?)entity.SubTitle ?? DBNull.Value);
                    command.Parameters.AddWithValue("synopsis", (object?)entity.Synopsis ?? DBNull.Value);
                    command.Parameters.AddWithValue("releaseDate", entity.ReleaseDate);
                    command.Parameters.AddWithValue("category", entity.MainCategory);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
