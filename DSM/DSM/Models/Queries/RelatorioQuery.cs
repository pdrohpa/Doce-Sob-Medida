using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Models.Queries
{
    public class RelatorioQuery
    {
        public List<Pedido> findAll(DateTime inicio, DateTime fim)
        {
            List<Pedido> pedidos = new List<Pedido>();

            DBConnection dbConnection = new DBConnection();
            MySqlConnection connection = dbConnection.getConnection();
            MySqlCommand command = dbConnection.getCommand();

            try
            {
                connection.Open();

                command.CommandText = "SELECT c.nome, r.nome, " +
                    "p.proporcao, p.data, p.valor_venda " +
                    "FROM tb_pedido as p, tb_receita as r, tb_cliente as c " +
                    "WHERE p.codigo_cliente = c.codigo AND p.codigo_receita = r.codigo " +
                    "AND p.data BETWEEN @inicio AND @fim";

                command.Parameters.AddWithValue("inicio", inicio);
                command.Parameters.AddWithValue("fim", fim);

                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    string clienteNome = reader.GetString(0);
                    string receitaNome = reader.GetString(1);
                    double proporcao = reader.GetDouble(2);
                    DateTime data = reader.GetDateTime(3);
                    double valorVenda = reader.GetDouble(4);

                    Cliente cliente = new Cliente();
                    cliente.setNome(clienteNome);

                    Receita receita = new Receita();
                    receita.setNome(receitaNome);

                    Pedido pedido = new Pedido(proporcao, receita);
                    pedido.setCliente(cliente);
                    pedido.setData(data);
                    pedido.setValorVenda(valorVenda);

                    pedidos.Add(pedido);
                }
            } 
            finally
            {
                if (connection != null) connection.Close();
                if (command != null) command.Dispose();
            }

            return pedidos;
        }
    }
}
