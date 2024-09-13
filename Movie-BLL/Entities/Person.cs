using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_BLL.Entities
{
    public class Person : IPerson
    {
        private string _lastName;
        private string _firstName;
        public int PersonId { get; set; }
        public string LastName {
            get { return _lastName; }
            set {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(LastName));
                value = value.Trim();
                if (value.Length > 32) throw new ArgumentException(nameof(LastName));
                _lastName = value;
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(FirstName));
                value = value.Trim();
                if (value.Length > 32) throw new ArgumentException(nameof(FirstName));
                _firstName = value;
            }
        }
        public DateTime BirthDate { get; set; }
        public Person(int personId, string lastName, string firstName, DateTime birthDate)
        {
            PersonId = personId;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
        }

        public Person(Movie_DAL.Entities.Person person)
        {
            PersonId = person.PersonId;
            _lastName = person.LastName;
            _firstName = person.FirstName;
            BirthDate = person.BirthDate;
        }

    }
}
