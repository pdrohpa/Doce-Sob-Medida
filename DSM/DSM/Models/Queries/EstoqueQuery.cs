using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class EstoqueQuery
    {
        public List<Estoque> findAll(DateTime inicio, DateTime fim)
        {
            List <Estoque> estoques = new List<Estoque>();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "SELECT e.codigo, e.tipo_acao, e.quantidade, e.data, " +
                    "i.codigo as codigo_produto, i.nome as produto, i.unidade_medida " +
                    "FROM tb_estoque as e, tb_ingrediente as i " +
                    "WHERE e.codigo_ingrediente = i.codigo " +
                    "AND data BETWEEN @inicio AND @fim " +
                    "ORDER BY e.data DESC";

                command.Parameters.AddWithValue("inicio", inicio);
                command.Parameters.AddWithValue("fim", fim);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int codigo = reader.GetInt16(0);
                    string tipoAcao = reader.GetString(1);
                    double quantidade = reader.GetDouble(2);
                    DateTime data = reader.GetDateTime(3);
                    int codigoProduto = reader.GetInt16(4);
                    string produto = reader.GetString(5);
                    string unidadeMedida = reader.GetString(6);

                    Ingrediente ingrediente = new Ingrediente(codigoProduto, produto, unidadeMedida);
                    Estoque estoque = new Estoque(codigo, data, tipoAcao, quantidade, ingrediente);

                    estoques.Add(estoque);
                }

            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }

            return estoques;
        }

        public List<Estoque> findByIngredienteId(int id)
        {
            List<Estoque> estoques = new List<Estoque>();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "SELECT e.codigo, e.data, e.tipo_acao, e.quantidade, " +
                    "i.codigo as codigo_ingrediente, i.nome, i.unidade_medida " +
                    "FROM doce_sob_medida_bd.tb_estoque as e, tb_ingrediente as i " +
                    "WHERE e.codigo_ingrediente = i.codigo " +
                    "AND i.codigo = @codigo";

                command.Parameters.AddWithValue("codigo", id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int codigo = reader.GetInt16(0);
                    DateTime data = reader.GetDateTime(1);
                    string tipoAcao = reader.GetString(2);
                    double quantidade = reader.GetDouble(3);
                    int codigoIngrediente = reader.GetInt16(4);
                    string produto = reader.GetString(5);
                    string unidadeMedida = reader.GetString(6);

                    Ingrediente ingrediente = new Ingrediente(codigoIngrediente, produto, unidadeMedida);
                    Estoque estoque = new Estoque(codigo, data, tipoAcao, quantidade, ingrediente);

                    estoques.Add(estoque);
                }
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }

            return estoques;
        }

        public void insert(Estoque estoque)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();
                command.CommandText = "INSERT INTO tb_estoque (data, tipo_acao, codigo_ingrediente, quantidade) " +
                    "VALUES (@data, @tipoAcao, @codigoIngrediente, @quantidade)";

                command.Parameters.AddWithValue("data", estoque.getData());
                command.Parameters.AddWithValue("tipoAcao", estoque.getTipoAcao());
                command.Parameters.AddWithValue("codigoIngrediente", estoque.getIngrediente().getCodigo());
                command.Parameters.AddWithValue("quantidade", estoque.getQuantidade());

                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }
    }
}
