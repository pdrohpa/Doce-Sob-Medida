using DSM.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class ReceitaQuery
    {
        public List<Receita> findAll(string nomeReceita = "")
        {
            List<Receita> receitas = new List<Receita>();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                StringBuilder commandText = new StringBuilder("SELECT r.codigo, r.nome, r.descricao, r.preco_custo, " +
                    "c.codigo as codigo_categoria, c.descricao as descricao_categoria " +
                    "FROM tb_receita as r, tb_categoria as c " +
                    "WHERE r.codigo_categoria = c.codigo");

                if (nomeReceita.Length > 0)
                {
                    commandText.Append(" AND r.nome LIKE @nome");
                    command.Parameters.AddWithValue("@nome", "%" + nomeReceita + "%");
                }

                command.CommandText = commandText.ToString();

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int codigo = reader.GetInt16(0);
                    string nome = reader.GetString(1);
                    string descricao = reader.GetString(2);
                    double precoCusto = reader.GetDouble(3);
                    int codigoCategoria = reader.GetInt16(4);
                    string descricaoCategoria = reader.GetString(5);

                    Categoria categoria = new Categoria(codigoCategoria, descricaoCategoria);
                    Receita receita = new Receita(codigo, nome, descricao, precoCusto, categoria);

                    receitas.Add(receita);
                }
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }

            return receitas;
        }

        public int insert(Receita receita)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "INSERT INTO tb_receita (nome, descricao, preco_custo, codigo_categoria) " +
                    "VALUES (@nome, @descricao, @precoCusto, @codigoCategoria); " +
                    "SELECT LAST_INSERT_ID();";

                command.Parameters.AddWithValue("nome", receita.getNome());
                command.Parameters.AddWithValue("descricao", receita.getDescricao());
                command.Parameters.AddWithValue("precoCusto", receita.getPrecoCusto());
                command.Parameters.AddWithValue("codigoCategoria", receita.getCategoria().getCodigo());

                int id = Convert.ToInt32(command.ExecuteScalar());

                return id;
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }

        public void delete(int id)
        {
            DBConnection dBConnection = new DBConnection();
            MySqlConnection connection = dBConnection.getConnection();
            MySqlCommand command = dBConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "DELETE FROM tb_receita_ingrediente WHERE " +
                    "codigo_receita = @id; " +
                    "DELETE FROM tb_receita WHERE codigo = @id;";

                command.Parameters.AddWithValue("id", id);

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

        public bool allowDelete(int codigoReceita)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "SELECT * FROM tb_pedido WHERE codigo_receita = @codigo";
                command.Parameters.AddWithValue("codigo", codigoReceita);

                MySqlDataReader reader = command.ExecuteReader();
                return !reader.HasRows;
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }
    }
}
