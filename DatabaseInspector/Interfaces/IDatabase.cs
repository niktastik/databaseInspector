namespace DatabaseInspector
{
    public interface IDatabase
    {
        bool ConnectToDatabase(string connectionString);
        bool DisconnectFromDatabase();
        bool ConnectionIsActive();
        object QueryDatabase(string query);
    }
}
