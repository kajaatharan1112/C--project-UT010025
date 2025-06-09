using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__project_unicom_tic.data
{
    internal class DB_connection
    {
        private static string connectionString = "Data Source=unicom_tic_DB.db;Version=3;";

        public static SQLiteConnection Get_Connection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
