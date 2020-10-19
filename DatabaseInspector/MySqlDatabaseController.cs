using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseInspector.Utilities;
using Microsoft.Win32;

namespace DatabaseInspector
{
    public class MySqlDatabaseController : BaseDatabaseController, IDatabaseController
    {
        private const string instanceType = "MySQL";

        public bool ConnectToDatabase(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public bool DisconnectFromDatabase(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public bool GetDatabaseInfo(IDatabase targetDatabase)
        {
            throw new NotImplementedException();
        }

        public void ScanForDatabases()
        {
            GetAllMySqlVersionsInstalled();
            RetrieveAllDatabases();
        }

        private void GetAllMySqlVersionsInstalled()
        {
            var serverName = WindowsSystemHelper.GetMachineName();
            var registryView = WindowsSystemHelper.GetRegistryView();

            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey mySqlKey = hklm.OpenSubKey(@"SOFTWARE\WOW6432Node\MySQL AB", false);
                if (mySqlKey != null)
                {
                    foreach (var keyName in mySqlKey.GetSubKeyNames())
                    {
                        if (keyName.StartsWith("MySQL Server"))
                        {
                            var newInstance = new DatabaseInstance();
                            newInstance.InstanceName = keyName;
                            newInstance.InstanceType = instanceType;
                            newInstance.ServerName = serverName;

                            RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\WOW6432Node\MySQL AB\" + keyName);
                            if (instanceKey != null)
                            {
                                newInstance.DataDirectory = instanceKey.GetValue("DataLocation").ToString() + @"\Data";
                                newInstance.Version = instanceKey.GetValue("Version").ToString();
                            }

                            instanceList.Add(newInstance);
                        }

                    }
                }
            }
        }

        private void RetrieveAllDatabases()
        {
            foreach (var version in instanceList)
            {
                DirectoryInfo instanceDataDir = new DirectoryInfo(version.DataDirectory);
                var subfoldersToCheck = instanceDataDir.GetDirectories();
                foreach (var folder in subfoldersToCheck)
                {
                    if (folder.EnumerateFiles("*.ibd") != null ||
                        folder.EnumerateFiles("*.ibt") != null ||
                        folder.EnumerateFiles("*.sdi") != null)
                        {
                        var temp = new MySqlDatabase();
                        temp.DatabaseName = folder.Name;
                        temp.HostInstance = version;
                        databaseList.Add(temp);
                    }
                }
            }
        }
    }
}
