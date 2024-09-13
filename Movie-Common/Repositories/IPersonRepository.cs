using Movie_Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_Common.Repositories
{
    public interface IPersonRepository<TPerson> : ICRUDRepository<TPerson, int> where TPerson : IPerson
    {

    }
}
