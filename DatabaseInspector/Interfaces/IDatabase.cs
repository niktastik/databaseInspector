namespace DatabaseInspector
{
    public interface IDatabase
    {
        bool ConnectToDatabase(string connectionString);
        void DisconnectFromDatabase();
        bool ConnectionIsActive();
        object QueryDatabase(string query);
    }
}
