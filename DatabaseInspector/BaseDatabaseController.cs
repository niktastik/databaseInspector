using System.Collections.Generic;
using System.Linq;

namespace DatabaseInspector
{
    public class BaseDatabaseController
    {
        protected List<DatabaseInstance> instanceList = new List<DatabaseInstance> {};
        protected List<Database> databaseList = new List<Database> {};

        public List<DatabaseInstance> GetAllInstances()
        {
            return instanceList;
        }

        public List<Database> GetAllDatabases()
        {
            return databaseList;
        }

        public void DisconnectFromAllDatabases()
        {
            foreach (var database in databaseList)
            {
                if (database.ConnectionIsActive())
                {
                    database.DisconnectFromDatabase();
                }
            }
        }

        protected bool IsDuplicateInstance(string instanceName)
        {
            return (instanceList.Where(x => x.InstanceName == instanceName).Count() > 0) ? true : false;
        }
    }
}
