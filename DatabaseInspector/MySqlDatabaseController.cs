using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseInspector.Utilities;
using Microsoft.Win32;

namespace DatabaseInspector
{
    class MySqlDatabaseController : BaseDatabaseController, IDatabaseController
    {
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
            var versionsInstalled = GetAllMySqlVersionsInstalled();
        }

        private List<string> GetAllMySqlVersionsInstalled()
        {
            string ServerName = WindowsSystemHelper.GetMachineName();
            var registryView = WindowsSystemHelper.GetRegistryView();

            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\WOW6432Node\MySQL AB", false);
                if (instanceKey != null)
                {
                    
                }
            }

            return new List<string> { };
        }
    }
}
