using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.IO;
using Microsoft.Win32;

namespace DatabaseInspector
{
    public class SqlDatabaseController : BaseDatabaseController, IDatabaseController
    {
        public void ScanForDatabases()
        {
            RetrieveInstanceInfo();
            RetrieveDatabasesForInstances();
        }

        public bool GetDatabaseInfo(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public bool ConnectToDatabase(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectFromDatabase(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        private void GetSQLBrowserInstances()
        {
            try
            {
                SqlDataSourceEnumerator sqlInstances = SqlDataSourceEnumerator.Instance;
                DataTable instanceInfoTable = sqlInstances.GetDataSources();

                for (int i = 0; i < instanceInfoTable.Rows.Count; i++)
                {
                    if (IsDuplicateInstance(instanceInfoTable.Rows[i].Field<string>("InstanceName"))) break;

                    var temp = new DatabaseInstance();
                    temp.ServerName = instanceInfoTable.Rows[i].Field<string>("ServerName");
                    temp.InstanceName = instanceInfoTable.Rows[i].Field<string>("InstanceName");
                    temp.IsClustered = instanceInfoTable.Rows[i].Field<string>("IsClustered");
                    temp.Version = instanceInfoTable.Rows[i].Field<string>("Version");
                    instanceList.Add(temp);
                }
            }
            catch
            {
                //throw new InvalidOperationException();
            }
        }

        private void FindSqlInstancesInRegistry()
        {
            Dictionary<string, string> instanceRegMap = new Dictionary<string, string>();
            string ServerName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        instanceRegMap.Add(instanceName.ToString(), instanceKey.GetValue(instanceName.ToString()).ToString());
                    }
                }
            }

            foreach (var instance in instanceRegMap)
            {
                if (IsDuplicateInstance(instance.Key)) break;

                var newInstance = new DatabaseInstance();
                newInstance.InstanceName = instance.Key;
                newInstance.ServerName = ServerName;

                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
                {
                    RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\" + instance.Value + @"\Setup");
                    if (instanceKey != null)
                    {
                        newInstance.Version = instanceKey.GetValue("Version").ToString();
                        newInstance.DataDirectory = instanceKey.GetValue("SQLDataRoot").ToString() + @"\Data";
                    }
                }
                instanceList.Add(newInstance);
            }
        }

        private void RetrieveInstanceInfo()
        {
            FindSqlInstancesInRegistry();
            //GetSQLBrowserInstances();
        }

        private void RetrieveDatabasesForInstances()
        {
            foreach (DatabaseInstance currentInstance in instanceList)
            {
                DirectoryInfo instanceDataDir = new DirectoryInfo(currentInstance.DataDirectory);
                foreach(FileInfo instanceDataFile in instanceDataDir.EnumerateFiles("*.mdf"))
                {
                    var temp = new SqlServerDatabase();
                    temp.HostInstance = currentInstance;
                    temp.DatabaseName = instanceDataFile.Name.Substring(0, instanceDataFile.Name.LastIndexOf('.'));
                    databaseList.Add(temp);
                }
            }
        }
    }
}
