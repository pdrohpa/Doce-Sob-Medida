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
    public partial class FrmEstoque : Form
    {
        private List<Estoque> estoques;
        private EstoqueQuery estoqueQuery;

        public FrmEstoque()
        {
            InitializeComponent();

            estoques = new List<Estoque>();
            estoqueQuery = new EstoqueQuery();

            dataGridEstoque.Columns.Clear();
            dataGridEstoque.Columns.Add("Produto", "Produto");
            dataGridEstoque.Columns.Add("Acao", "Ação");
            dataGridEstoque.Columns.Add("Quantidade", "Quantidade");
            dataGridEstoque.Columns.Add("Data", "Data");

            dataGridEstoque.Columns["Produto"].Width = 200;
            dataGridEstoque.Columns["Acao"].Width = 100;
            dataGridEstoque.Columns["Quantidade"].Width = 120;
            dataGridEstoque.Columns["Data"].Width = 150;

            resetar();
        }

        private void BuscarEstoque(DateTime inicio, DateTime fim)
        {
            dataGridEstoque.Rows.Clear();
            estoques = estoqueQuery.findAll(inicio, fim);

            foreach (Estoque estoque in estoques)
            {
                int rowIndex = dataGridEstoque.Rows.Add(
                estoque.getIngrediente().getNome(),
                estoque.getTipoAcao(),
                estoque.getQuantidade().ToString("F2"),
                estoque.getData());

                string acao = estoque.getTipoAcao();
                if (acao == "ENTRADA")
                {
                    dataGridEstoque.Rows[rowIndex].Cells["Acao"].Style.BackColor = Color.Green;
                    dataGridEstoque.Rows[rowIndex].Cells["Acao"].Style.ForeColor = Color.White;
                }
                else if (acao == "SAIDA")
                {
                    dataGridEstoque.Rows[rowIndex].Cells["Acao"].Style.BackColor = Color.Red;
                    dataGridEstoque.Rows[rowIndex].Cells["Acao"].Style.ForeColor = Color.White;
                }
            }

        }

        private void btnCadastroEstoque_Click(object sender, EventArgs e)
        {
            FrmCadastroEstoque form = new FrmCadastroEstoque(this);
            form.Show();
            Hide();
        }

        public void resetar()
        {
            dtpInicio.Value = new DateTime(2025, 1, 1);
            dtpFim.Value = DateTime.Now;

            BuscarEstoque(dtpInicio.Value, dtpFim.Value);
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            resetar();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarEstoque(dtpInicio.Value, dtpFim.Value);
        }
    }
}
