using Movie_BLL.Entities;
using Movie_BLL.Mapper;
using Movie_Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_BLL.Services
{
    public class PersonService : IPersonRepository<Person>
    {
        private IPersonRepository<Movie_DAL.Entities.Person> _repository;

        public PersonService(IPersonRepository<Movie_DAL.Entities.Person> repository)
        {
            _repository = repository;
        }

        public int Create(Person entity)
        {
            return _repository.Create(entity.ToDAL());
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Person> Get()
        {
            return _repository.Get().Select(e=>e.ToBLL());
        }

        public Person Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public void Update(int id, Person entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
