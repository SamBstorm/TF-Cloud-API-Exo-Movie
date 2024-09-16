using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie_BLL.Entities
{
    public class Actor
    {
        private IEnumerable<string> _charactersName;
        private Movie _movie;
        private Person _person;

        public Movie Movie {
            get {  return _movie; }
            set { 
                if(value is null) throw new ArgumentNullException(nameof(Movie));
                _movie = value;
            }
        }
        public Person Person
        {
            get { return _person; }
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(Person));
                _person = value;
            }
        }
        public IEnumerable<string> CharactersName { 
            get{ return _charactersName; }
            set{ 
                if(value is null || value.Count() == 0)  throw new ArgumentNullException(nameof(CharactersName));
                string[] names = value.ToArray();
                for (int i = 0; i < names.Length; i++)
                {
                    string name = names[i];
                    if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(CharactersName));
                    name = name.Trim();
                    if (name.Length > 64) throw new ArgumentException(nameof(CharactersName));
                }
                _charactersName = names;
            }
        }

        public Actor(Person person, Movie movie, IEnumerable<string> charactersName)
        {
            Person = person;
            Movie = movie;
            CharactersName = charactersName;
        }
    }
}
