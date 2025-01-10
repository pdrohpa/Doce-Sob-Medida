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
    public partial class FrmRelatorio : Form
    {
        private List<Pedido> pedidos;

        private RelatorioQuery relatorioQuery;

        public FrmRelatorio()
        {
            InitializeComponent();
            pedidos = new List<Pedido>();
            relatorioQuery = new RelatorioQuery();

            dataGridRelatorio.Columns.Clear();
            dataGridRelatorio.Columns.Add("Cliente", "Cliente");
            dataGridRelatorio.Columns.Add("Receita", "Receita");
            dataGridRelatorio.Columns.Add("Proporcao", "Proporcao");
            dataGridRelatorio.Columns.Add("Data", "Data");
            dataGridRelatorio.Columns.Add("ValorVenda", "Valor");

            dataGridRelatorio.Columns["Cliente"].Width = 200;
            dataGridRelatorio.Columns["Receita"].Width = 150;
            dataGridRelatorio.Columns["Proporcao"].Width = 100;
            dataGridRelatorio.Columns["Data"].Width = 100;
            dataGridRelatorio.Columns["ValorVenda"].Width = 120;

            resetar();
        }

        private void BuscarRelatorio(DateTime inicio, DateTime fim)
        {
            dataGridRelatorio.Rows.Clear();

            pedidos = relatorioQuery.findAll(inicio, fim);

            double valorTotal = 0.0;
            foreach (Pedido pedido in pedidos)
            {
                valorTotal += pedido.getValorVenda();
                dataGridRelatorio.Rows.Add(
                    pedido.getCliente().getNome(),
                    pedido.getReceita().getNome(),
                    pedido.getProporcao(),
                    pedido.getData().ToString("dd/MM/yyyy"),
                    pedido.getValorVenda().ToString("C2"));
            }

            lbValorTotal.Text = String.Format("Valor Total: {0}", valorTotal.ToString("C2"));
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarRelatorio(dtpInicio.Value, dtpFim.Value);
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            resetar();
        }

        private void resetar()
        {
            dtpInicio.Value = new DateTime(2025, 1, 1);
            dtpFim.Value = DateTime.Now;

            BuscarRelatorio(dtpInicio.Value, dtpFim.Value);
        }
    }
}
