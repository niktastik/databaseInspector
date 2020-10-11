namespace DatabaseInspector
{
    public interface IDatabase
    {
        bool connectToDatabase(string connectionString);
        bool disconnectFromDatabase();
        bool connectionIsActive();
        object queryDatabase(string query);
    }
}
