using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class PedidoQuery
    {
        public void insert(Pedido pedido)
        {
            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "INSERT INTO tb_pedido (proporcao, data, valor_venda, codigo_receita, codigo_cliente) " +
                    "VALUES (@proporcao, @data, @valorVenda, @codigoReceita, @codigoCliente)";

                command.Parameters.AddWithValue("proporcao", pedido.getProporcao());
                command.Parameters.AddWithValue("data", pedido.getData());
                command.Parameters.AddWithValue("valorVenda", pedido.getValorVenda());
                command.Parameters.AddWithValue("codigoReceita", pedido.getReceita().getCodigo());
                command.Parameters.AddWithValue("codigoCliente", pedido.getCliente().getCodigo());

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
