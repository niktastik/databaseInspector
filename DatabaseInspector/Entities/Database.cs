using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInspector
{
    public class Database
    {
        public string DatabaseName = string.Empty;
        public DatabaseInstance HostInstance = new DatabaseInstance();

        public bool ConnectionIsActive()
        {
            return false;
        }

        public void DisconnectFromDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
