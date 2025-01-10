using DSM.Exceptions;
using DSM.Forms;
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

namespace DSM
{
    public partial class FrmReceitas : Form
    {
        private List<Receita> receitas;
        private ReceitaQuery receitaQuery;

        public FrmReceitas()
        {
            InitializeComponent();
            receitas = new List<Receita>();
            receitaQuery = new ReceitaQuery();

            dataGridReceitas.Columns.Clear();
            dataGridReceitas.Columns.Add("Nome", "Nome");
            dataGridReceitas.Columns.Add("PrecoCusto", "Preço de Custo");
            dataGridReceitas.Columns.Add("Categoria", "Categoria");

            dataGridReceitas.Columns["Nome"].Width = 200;
            dataGridReceitas.Columns["PrecoCusto"].Width = 100;
            dataGridReceitas.Columns["Categoria"].Width = 120;

            DataGridViewButtonColumn btnProduzir = new DataGridViewButtonColumn();
            btnProduzir.Name = "Produzir";
            btnProduzir.Text = "Produzir";
            btnProduzir.FlatStyle = FlatStyle.Flat;
            btnProduzir.UseColumnTextForButtonValue = true;
            btnProduzir.DefaultCellStyle.BackColor = Color.DarkCyan;
            btnProduzir.DefaultCellStyle.ForeColor = Color.White;

            dataGridReceitas.Columns.Add(btnProduzir);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Excluir";
            btnDelete.Text = "Excluir";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.DefaultCellStyle.BackColor = Color.Red;
            btnDelete.DefaultCellStyle.ForeColor = Color.White;

            dataGridReceitas.Columns.Add(btnDelete);

            BuscarReceitas();
        }

        public void BuscarReceitas(string nome = "")
        {
            dataGridReceitas.Rows.Clear();
            receitas = receitaQuery.findAll(nome);

            foreach (Receita receita in receitas)
                dataGridReceitas.Rows.Add(
                    receita.getNome(), 
                    receita.getPrecoCusto().ToString("C2"), 
                    receita.getCategoria().getDescricao());
        }

        private void btnAdicionarReceita_Click(object sender, EventArgs e)
        {
            FrmCadastroReceitas form = new FrmCadastroReceitas(this);
            form.Show();
            Hide();
        }

        private void dataGridReceitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Receita receita = receitas[e.RowIndex];
                string columnName = dataGridReceitas.Columns[e.ColumnIndex].Name;

                if (columnName == "Produzir")
                {
                    FrmCalculadoraProporcao form = new FrmCalculadoraProporcao(this, receita);
                    form.Show();
                    Hide();
                }
                else if (columnName == "Excluir")
                {
                    DialogResult result = MessageBox.Show(
                        $"Tem certeza que deseja excluir a receita?",
                        "Confirmar Exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            bool permitirDeleção = receitaQuery.allowDelete(receita.getCodigo());

                            if (!permitirDeleção)
                                throw new AssociateRowException();

                            receitaQuery.delete(receita.getCodigo());

                            MessageBox.Show("Receita excluída com sucesso!");
                            BuscarReceitas();
                        }
                        catch (AssociateRowException)
                        {
                            MessageBox.Show("Você não pode excluir uma receita que possua pedidos associados");
                        }
                    }
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarReceitas(txtNomeReceita.Text);
        }
    }
}
