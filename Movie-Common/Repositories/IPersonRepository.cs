using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Common.Repositories
{
    public interface IPersonRepository<TPerson> : ICRUDRepository<TPerson, int> where TPerson : IPerson
    {
        public IEnumerable<TPerson> GetByMovieId(int id);
        public IEnumerable<TPerson> GetByCharacterName(string characterName);
        public IEnumerable<string> GetAllRoles(int id);
        public IEnumerable<string> GetAllRolesOnMovieId(int personId, int movieId);
        public int SetRole(int personId, int movieId, string characterName);
    }
}
