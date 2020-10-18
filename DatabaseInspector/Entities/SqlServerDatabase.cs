using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInspector
{
    public class SqlServerDatabase : Database, IDatabase
    {
        public bool ConnectToDatabase(string connectionString)
        {
            throw new NotImplementedException();
        }

        public object QueryDatabase(string query)
        {
            throw new NotImplementedException();
        }
    }
}
