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
            sqlTest.GetAllDatabases();

        }
    }
}
