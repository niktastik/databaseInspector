using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;

namespace DatabaseInspector
{
    public class SqlDatabaseController : IDatabaseController
    {
        List<DatabaseInstance> sqlInstanceList = new List<DatabaseInstance> {};
        List<SqlServerDatabase> sqlDatabaseList = new List<SqlServerDatabase> {};

        public bool ConnectToDatabase(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectFromDatabase(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public bool GetAllInstances()
        {
            // Try SQL Browser service to get instance list
            SqlDataSourceEnumerator sqlInstances = SqlDataSourceEnumerator.Instance;
            DataTable instanceInfoTable = sqlInstances.GetDataSources();

            for (int i = 0; i < instanceInfoTable.Rows.Count; i++)
            {
                var temp = new DatabaseInstance();
                temp.ServerName = instanceInfoTable.Rows[i].Field<string>("ServerName");
                temp.InstanceName = instanceInfoTable.Rows[i].Field<string>("InstanceName");
                temp.IsClustered = instanceInfoTable.Rows[i].Field<string>("IsClustered");
                temp.Version = instanceInfoTable.Rows[i].Field<string>("Version");
                sqlInstanceList.Add(temp);
            }

            // TODO: Implement searching for SQL instances in registry

            return (sqlInstanceList.Count > 0) ? true : false;
        }

        public bool GetAllDatabases()
        {
            if (GetAllInstances())
            {
                foreach (DatabaseInstance currentInstance in sqlInstanceList)
                {

                }
            }
            return (sqlDatabaseList.Count > 0) ? true : false;
        }

        public bool GetDatabaseInfo(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public void KillAllConnections()
        {
            throw new NotImplementedException();
        }
    }
}
