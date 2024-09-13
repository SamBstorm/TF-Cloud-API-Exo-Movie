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
