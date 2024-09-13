using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_DAL.Entities
{
    public class Person : IPerson
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
