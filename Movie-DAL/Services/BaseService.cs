using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_DAL.Services
{
    public abstract class BaseService
    {
        protected string _connectionString;
        protected BaseService(IConfiguration config, string dbName)
        {
            _connectionString = config.GetConnectionString(dbName);
        }
    }
}
