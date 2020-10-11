using System.Collections.Generic;

namespace DatabaseInspector
{
    public interface IDatabaseController
    {
        bool GetAllInstances();
        bool GetAllDatabases();
        bool GetDatabaseInfo(IDatabase targetDatabase);
        bool ConnectToDatabase(IDatabase targetDatabase);
        bool DisconnectFromDatabase(IDatabase targetDatabase);
        void KillAllConnections();
    }
}
