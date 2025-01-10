using DSM.Models;
using DSM.Models.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSM.Forms
{
    public partial class FrmPedido : Form
    {
        private FrmCalculadoraProporcao frmCalculadoraProporcao;
        private List<Estoque> estoques;
        private Pedido pedido;
        private EstoqueQuery estoqueQuery;

        public FrmPedido(FrmCalculadoraProporcao frmCalculadoraProporcao, List<Estoque> estoques, Pedido pedido)
        {
            InitializeComponent();
            estoqueQuery = new EstoqueQuery();
            this.frmCalculadoraProporcao = frmCalculadoraProporcao;
            this.estoques = estoques;
            this.pedido = pedido;

            Receita receita = pedido.getReceita();

            txtProporcao.Text = pedido.getProporcao().ToString("F2");
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            double valorVenda = (receita.getPrecoCusto() * pedido.getProporcao()) * 1.3;
            txtValorVenda.Text = valorVenda.ToString("F2");
        }

        private void FrmPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCalculadoraProporcao.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente(txtCliente.Text, txtTelefone.Text);
                double valorVenda = double.Parse(txtValorVenda.Text);

                pedido.setData(DateTime.Now);
                pedido.setCliente(cliente);
                pedido.setValorVenda(valorVenda);

                PedidoQuery pedidoQuery = new PedidoQuery();
                ClienteQuery clienteQuery = new ClienteQuery();

                int idCliente = clienteQuery.insert(cliente);
                cliente.setCodigo(idCliente);

                pedidoQuery.insert(pedido);

                Receita receita = pedido.getReceita();
                
                foreach (Estoque estoque in estoques)
                    estoqueQuery.insert(estoque);

                MessageBox.Show("Pedido cadastrado com sucesso!");
                frmCalculadoraProporcao.Show();
                Close();
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("Você deve digitar um valor numérico");
            }
        }
    }
}
