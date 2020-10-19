using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatabaseInspector;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlDatabaseController sqlTest = new SqlDatabaseController();
            sqlTest.ScanForDatabases();
            var instances = sqlTest.GetAllInstances();
            Console.WriteLine("SQL Instance Count: " + instances.Count.ToString());
            var databases = sqlTest.GetAllDatabases();
            Console.WriteLine("SQL Database Count: " + databases.Count.ToString());

            MySqlDatabaseController mySqlTest = new MySqlDatabaseController();
            mySqlTest.ScanForDatabases();
            var mySqlInstances = mySqlTest.GetAllInstances();
            Console.WriteLine("MySQL Instance Count: " + mySqlInstances.Count.ToString());
            var mySqlDatabases = mySqlTest.GetAllDatabases();
            Console.WriteLine("MySQL Database Count: " + mySqlDatabases.Count.ToString());

            Console.ReadLine();
        }
    }
}
