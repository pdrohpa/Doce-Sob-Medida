using DSM.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class IngredienteQuery
    {
        public List<Ingrediente> findAll(string nomeProduto = "")
        {
            List<Ingrediente> ingredientes = new List<Ingrediente>();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                string commandText = "SELECT i.codigo, i.nome, i.unidade_medida, " +
                    "e.codigo AS codigo_estoque, e.data, e.tipo_acao, e.quantidade " +
                    "FROM tb_ingrediente as i, tb_estoque as e " +
                    "WHERE e.codigo_ingrediente = i.codigo";

                if (nomeProduto.Length > 0)
                {
                    commandText += " AND i.nome LIKE @nome";
                    command.Parameters.AddWithValue("@nome", "%" + nomeProduto + "%");
                }

                command.CommandText = commandText;

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int codigo = reader.GetInt16(0);
                    string nome = reader.GetString(1);
                    string unidadeMedida = reader.GetString(2);
                    int codigoEstoque = reader.GetInt16(3);
                    DateTime data = reader.GetDateTime(4);
                    string tipoAcao = reader.GetString(5);
                    double quantidade = reader.GetDouble(6);

                    Ingrediente ingrediente = null;
                    
                    foreach (Ingrediente i in ingredientes)
                        if (i.getCodigo() == codigo) ingrediente = i;


                    if (ingrediente == null)
                    {
                        ingrediente = new Ingrediente(codigo, nome, unidadeMedida);
                        Estoque estoque = new Estoque(codigoEstoque, data, tipoAcao, quantidade, ingrediente);
                        ingrediente.AddEstoque(estoque);
                        ingredientes.Add(ingrediente);
                    }
                    else
                    {
                        Estoque estoque = new Estoque(codigoEstoque, data, tipoAcao, quantidade, ingrediente);
                        ingrediente.AddEstoque(estoque);
                    }
                    
                }

                reader.Close();
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }

            return ingredientes;
        }

        public int insert(Ingrediente ingrediente)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();
                command.CommandText = "INSERT INTO tb_ingrediente (nome, unidade_medida)" +
                    " VALUES (@nome, @unidadeMedida); " +
                    "SELECT LAST_INSERT_ID();";

                command.Parameters.AddWithValue("nome", ingrediente.getNome());
                command.Parameters.AddWithValue("unidadeMedida", ingrediente.getUnidadeMedida());

                int id = Convert.ToInt32(command.ExecuteScalar());
                return id;
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }

        public void update(Ingrediente ingrediente)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();
                command.CommandText = "UPDATE tb_ingrediente SET nome = @nome, " +
                    "unidade_medida = @unidadeMedida " +
                    "WHERE codigo = @codigo";

                command.Parameters.AddWithValue("nome", ingrediente.getNome());
                command.Parameters.AddWithValue("unidadeMedida", ingrediente.getUnidadeMedida());
                command.Parameters.AddWithValue("codigo", ingrediente.getCodigo());

                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }

        public void delete(int codigo)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();
                command.CommandText = "DELETE FROM tb_estoque " +
                    "WHERE codigo_ingrediente = @codigo; " +
                    "DELETE FROM tb_ingrediente " +
                    "WHERE codigo = @codigo;";

                command.Parameters.AddWithValue("codigo", codigo);

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

        public bool canDelete(int codigo)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM tb_receita_ingrediente WHERE codigo_ingrediente = @codigo";

                command.Parameters.AddWithValue("codigo", codigo);

                MySqlDataReader reader = command.ExecuteReader();

                return !reader.HasRows;
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
