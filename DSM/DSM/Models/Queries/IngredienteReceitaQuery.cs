using DSM.Exceptions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class IngredienteReceitaQuery
    {
        public void insertMany(List<IngredienteReceita> ingredientes)
        {
            if (ingredientes.Count == 0)
                throw new EmptyListException();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();
                var commandText = new StringBuilder("INSERT INTO tb_receita_ingrediente (codigo_ingrediente, codigo_receita, quantidade) VALUES ");
                for (int i = 0; i < ingredientes.Count; i++)
                {
                    commandText.Append($"(@codigoIngrediente{i}, @codigoReceita{i}, @quantidade{i}), ");

                    command.Parameters.AddWithValue($"@codigoIngrediente{i}", ingredientes[i].getIngrediente().getCodigo());
                    command.Parameters.AddWithValue($"@codigoReceita{i}", ingredientes[i].getReceita().getCodigo());
                    command.Parameters.AddWithValue($"@quantidade{i}", ingredientes[i].getQuantidade());
                }

                commandText.Length -= 2;

                command.CommandText = commandText.ToString();
                command.ExecuteNonQuery();
            } 
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }
        }

        public List<IngredienteReceita> findByReceitaId(int id)
        {
            List<IngredienteReceita> ingredientes = new List<IngredienteReceita>();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "SELECT r.quantidade, i.codigo as codigo_ingrediente, i.nome, i.unidade_medida " +
                    "FROM tb_receita_ingrediente as r, tb_ingrediente as i " +
                    "WHERE r.codigo_ingrediente = i.codigo " +
                    "AND r.codigo_receita = @codigo";

                command.Parameters.AddWithValue("codigo", id);

                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    int quantidade = reader.GetInt16(0);
                    int codigoIngrediente = reader.GetInt16(1);
                    string nome = reader.GetString(2);
                    string unidadeMedida = reader.GetString(3);

                    IngredienteReceita ingrediente = new IngredienteReceita();

                    ingrediente.setIngrediente(
                        new Ingrediente(codigoIngrediente, nome, unidadeMedida));
                    ingrediente.setQuantidade(quantidade);

                    ingredientes.Add(ingrediente);
                }
            }
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }

            return ingredientes;
        }
    }
}
