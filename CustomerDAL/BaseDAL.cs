using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerEntities.Entities;
using System.Configuration;

namespace CustomerDAL
{
    class BaseDal
    {
        public CustomerServiceEntities _entities;
        static string _connectionstring;
        public static string ConnectionString
        {
            get
            {
                if(string.IsNullOrEmpty(_connectionstring))
                {
                    _connectionstring = System.Configuration.ConfigurationManager.ConnectionStrings["CustomerServiceEntities"].ConnectionString;
                }
                return _connectionstring;
            }
        }

        public BaseDal()
        {
            _entities = new CustomerServiceEntities(ConnectionString);
        }
    }
}
