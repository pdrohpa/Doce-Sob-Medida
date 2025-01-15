using DSM.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class CategoriaQuery
    {
        public List<Categoria> findAll(string descricaoCategoria = "")
        {
            List<Categoria> categorias = new List<Categoria>();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                StringBuilder commandText = new StringBuilder("SELECT * FROM tb_categoria");
                
                if (descricaoCategoria.Length > 0)
                {
                    commandText.Append(" WHERE descricao LIKE @descricao");
                    command.Parameters.AddWithValue("descricao", "%" + descricaoCategoria + "%");
                }

                command.CommandText = commandText.ToString();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int codigo = reader.GetInt16(0);
                    string descricao = reader.GetString(1);

                    Categoria categoria = new Categoria(codigo, descricao);
                    categorias.Add(categoria);
                }

                reader.Close();
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }

            return categorias;
        }

        public void insert(Categoria categoria)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "INSERT INTO tb_categoria (descricao) " +
                    "VALUES (@descricao);";

                command.Parameters.AddWithValue("descricao", categoria.getDescricao());

                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }

        public void update(Categoria categoria)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "UPDATE tb_categoria SET descricao = @descricao " +
                    "WHERE codigo = @codigo";

                command.Parameters.AddWithValue("descricao", categoria.getDescricao());
                command.Parameters.AddWithValue("codigo", categoria.getCodigo());

                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }

        public void delete(int id)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "DELETE FROM tb_categoria WHERE codigo = @codigo";
                command.Parameters.AddWithValue("codigo", id);

                command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                if (err.Message.IndexOf("cannot delete or update a parent row", StringComparison.OrdinalIgnoreCase) >= 0)
                    throw new AssociateRowException();

                throw;
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }
    }
}
