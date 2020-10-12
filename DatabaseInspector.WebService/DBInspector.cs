using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DatabaseInspector;

namespace DatabaseInspector.WebService
{
    public class DBInspector
    {
        protected SqlDatabaseController sqlDbService;
        private bool isRetrieved = false;

        public DBInspector()
        {
            sqlDbService = new SqlDatabaseController();
        }

        public void SearchForDBs()
        {
            if (!isRetrieved)
            {
                sqlDbService.ScanForDatabases();
                isRetrieved = true;
            }
        }

        public IEnumerable<Database> GetAllDBs()
        {
            return sqlDbService.GetAllDatabases();
        }
    }
}
