using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Movie_Common.Entities;
using Movie_Common.Repositories;
using Movie_DAL.Entities;
using Movie_DAL.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_DAL.Services
{
    public class PersonService : BaseService, IPersonRepository<Person>
    {
        public PersonService(IConfiguration config) : base(config, "Movie-DB")
        {
        }

        public int Create(Person entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Person_Insert";
                    command.Parameters.AddWithValue("lastname", entity.LastName);
                    command.Parameters.AddWithValue("firstname", entity.FirstName);
                    command.Parameters.AddWithValue("birthdate", entity.BirthDate);
                    connection.Open();
                    return (int) command.ExecuteScalar();
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
                    command.CommandText = "SP_Person_Delete";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Person> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Person_GetAll";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToPerson();
                        }
                    }
                }
            }
        }

        public Person Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Person_GetById";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToPerson();
                        }
                        throw new ArgumentOutOfRangeException(nameof(id));
                    }
                }
            }
        }

        public IEnumerable<string> GetAllRoles(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Role].[CharacterName] FROM [Role] WHERE [Role].[PersonId] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader[0].ToString();
                        }
                    }
                }
            }
        }

        public IEnumerable<string> GetAllRolesOnMovieId(int personId, int movieId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Role].[CharacterName] FROM [Role] WHERE [Role].[PersonId] = @personid AND [Role].[MovieId] = @movieid";
                    command.Parameters.AddWithValue("personid", personId);
                    command.Parameters.AddWithValue("movieid", movieId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader[0].ToString();
                        }
                    }
                }
            }
        }

        public IEnumerable<Person> GetByCharacterName(string characterName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Person].* FROM [Person] JOIN [Role] ON [Person].[PersonId] = [Role].[PersonId] WHERE [Role].[CharacterName] = @char_name";
                    command.Parameters.AddWithValue("char_name", characterName);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToPerson();
                        }
                    }
                }
            }
        }

        public IEnumerable<Person> GetByMovieId(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT DISTINCT [Person].* FROM [Person] JOIN [Role] ON [Person].[PersonId] = [Role].[PersonId] WHERE [Role].[MovieId] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToPerson();
                        }
                    }
                }
            }
        }

        public int SetRole(int personId, int movieId, string characterName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "INSERT INTO [Role] ([PersonId], [MovieId], [CharacterName]) OUTPUT [inserted].[RoleId] VALUES (@person_id, @movie_id, @character_name)";
                    command.Parameters.AddWithValue("person_id", personId);
                    command.Parameters.AddWithValue("movie_id", movieId);
                    command.Parameters.AddWithValue("character_name", characterName);
                    connection.Open();
                    return (int) command.ExecuteScalar();
                }
            }
        }

        public void Update(int id, Person entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_Person_Update";
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("lastname", entity.LastName);
                    command.Parameters.AddWithValue("firstname", entity.FirstName);
                    command.Parameters.AddWithValue("birthdate", entity.BirthDate);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
