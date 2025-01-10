using DSM.Exceptions;
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
using System.Windows.Forms.VisualStyles;

namespace DSM
{
    public partial class FrmProdutos : Form
    {
        private List<Ingrediente> ingredientes;
        public FrmProdutos()
        {
            InitializeComponent();
            ingredientes = new List<Ingrediente>();

            dataGridIngredientes.Columns.Clear();
            dataGridIngredientes.Columns.Add("Nome", "Nome");
            dataGridIngredientes.Columns.Add("UnidadeMedida", "Unidade de Medida");
            dataGridIngredientes.Columns.Add("Quantidade", "Quantidade");

            dataGridIngredientes.Columns["Nome"].Width = 200;
            dataGridIngredientes.Columns["UnidadeMedida"].Width = 150;
            dataGridIngredientes.Columns["Quantidade"].Width = 100;

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "Editar";
            btnEdit.Text = "Editar";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            dataGridIngredientes.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Excluir";
            btnDelete.Text = "Excluir";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.DefaultCellStyle.BackColor = Color.Red;
            btnDelete.DefaultCellStyle.ForeColor = Color.White;
            dataGridIngredientes.Columns.Add(btnDelete);

            BuscarIngredientes();
        }

        public void BuscarIngredientes(string nome = "")
        {
            dataGridIngredientes.Rows.Clear();

            IngredienteQuery query = new IngredienteQuery();

            ingredientes = query.findAll(nome);

            foreach (Ingrediente ingrediente in ingredientes)
            {
                dataGridIngredientes.Rows.Add(ingrediente.getNome(), ingrediente.getUnidadeMedida(), ingrediente.getTextoEstoque());
            }
        }

        private void btnFormCadastroProdutos_Click(object sender, EventArgs e)
        {
            FormCadastroProdutos form = new FormCadastroProdutos(this, null);
            form.Show();
            Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nomeProduto = txtNomeProduto.Text;
            BuscarIngredientes(nomeProduto);
        }

        private void dataGridIngredientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Ingrediente ingrediente = ingredientes[e.RowIndex];
                string columnName = dataGridIngredientes.Columns[e.ColumnIndex].Name;

                if (columnName == "Editar")
                {
                    FormCadastroProdutos form = new FormCadastroProdutos(this, ingrediente);
                    form.Show();
                }
                else if (columnName == "Excluir")
                {
                    DialogResult result = MessageBox.Show(
                        $"Tem certeza que deseja excluir o ingrediente?",
                        "Confirmar Exclusão",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            IngredienteQuery query = new IngredienteQuery();

                            bool podeExcluir = query.canDelete(ingrediente.getCodigo());

                            if (!podeExcluir)
                                throw new AssociateRowException();

                            query.delete(ingrediente.getCodigo());

                            MessageBox.Show("Ingrediente excluído com sucesso!");
                            BuscarIngredientes();
                        }
                        catch (AssociateRowException)
                        {
                            MessageBox.Show("Você não pode excluir um ingrediente que possui receitas associadas");
                        }
                    }
                }
            }
        }
    }
}
