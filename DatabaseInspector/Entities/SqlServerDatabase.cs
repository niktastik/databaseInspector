using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInspector
{
    public class SqlServerDatabase : IDatabase
    {
        public string DatabaseName { get; private set; } = string.Empty;

        public bool connectionIsActive()
        {
            throw new NotImplementedException();
        }

        public bool connectToDatabase(string connectionString)
        {
            throw new NotImplementedException();
        }

        public bool disconnectFromDatabase()
        {
            throw new NotImplementedException();
        }

        public object queryDatabase(string query)
        {
            throw new NotImplementedException();
        }
    }
}
