using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class ClienteQuery
    {
        public int insert(Cliente cliente)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "INSERT INTO tb_cliente (nome, telefone) " +
                    "VALUES (@nome, @telefone); SELECT LAST_INSERT_ID();";

                command.Parameters.AddWithValue("nome", cliente.getNome());
                command.Parameters.AddWithValue("telefone", cliente.getTelefone());

                int id = Convert.ToInt32(command.ExecuteScalar());
                return id;
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }
    }
}
