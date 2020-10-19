using System.Collections.Generic;

namespace DatabaseInspector.WebService
{
    public class DBInspector
    {
        protected SqlDatabaseController sqlDbService;
        protected MySqlDatabaseController mySqlDbService;
        private bool isRetrieved = false;

        public DBInspector()
        {
            sqlDbService = new SqlDatabaseController();
            mySqlDbService = new MySqlDatabaseController();
        }

        public void SearchForDBs()
        {
            if (!isRetrieved)
            {
                sqlDbService.ScanForDatabases();
                mySqlDbService.ScanForDatabases();
                isRetrieved = true;
            }
        }

        public IEnumerable<Database> GetAllDBs()
        {
            var allDbs = new List<Database>();
            allDbs.AddRange(sqlDbService.GetAllDatabases());
            allDbs.AddRange(mySqlDbService.GetAllDatabases());
            return allDbs;
        }
    }
}
