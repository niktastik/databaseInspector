using System.Collections.Generic;

namespace DatabaseInspector
{
    public interface IDatabaseController
    {
        void ScanForDatabases();
        List<DatabaseInstance> GetAllInstances();
        List<Database> GetAllDatabases();
        bool GetDatabaseInfo(IDatabase targetDatabase);
        bool ConnectToDatabase(IDatabase targetDatabase);
        bool DisconnectFromDatabase(IDatabase targetDatabase);
    }
}
