using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models
{
    public class DBConnection
    {
        private readonly string connectionString = @"server=127.0.0.1;uid=student;pwd=student;database=doce_sob_medida_bd;ConnectionTimeout=1";
        private MySqlConnection dbConnection;

        public DBConnection()
        {
            dbConnection = new MySqlConnection(connectionString);
        }

        public MySqlConnection getConnection()
        {
            return dbConnection;
        }

        public MySqlCommand getCommand()
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = dbConnection;

            return command;
        }
    }
}
