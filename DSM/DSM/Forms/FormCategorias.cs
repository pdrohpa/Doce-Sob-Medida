using DSM.Exceptions;
using DSM.Models;
using DSM.Models.Queries;
using MySql.Data.MySqlClient;
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
    public partial class FrmCategorias : Form
    {
        private List<Categoria> categorias;
        private CategoriaQuery categoriaQuery;

        public FrmCategorias()
        {
            InitializeComponent();
            categorias = new List<Categoria>();
            categoriaQuery = new CategoriaQuery();

            dataGridCategorias.Columns.Add("Codigo", "Código");
            dataGridCategorias.Columns.Add("Descricao", "Descrição");

            dataGridCategorias.Columns["Codigo"].Width = 100;
            dataGridCategorias.Columns["Descricao"].Width = 150;

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "Editar";
            btnEdit.Text = "Editar";
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.UseColumnTextForButtonValue = true;
            dataGridCategorias.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "Excluir";
            btnDelete.Text = "Excluir";
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.DefaultCellStyle.BackColor = Color.Red;
            btnDelete.DefaultCellStyle.ForeColor = Color.White;
            dataGridCategorias.Columns.Add(btnDelete);

            BuscarCategorias();
        }

        public void BuscarCategorias(string descricao = "")
        {
            dataGridCategorias.Rows.Clear();
            categorias = categoriaQuery.findAll(descricao);

            foreach (Categoria categoria in categorias)
                dataGridCategorias.Rows.Add(categoria.getCodigo(), categoria.getDescricao());
        }

        private void btnFormCadastroProdutos_Click(object sender, EventArgs e)
        {
            FrmCadastroCategorias form = new FrmCadastroCategorias(this);
            form.Show();
            Hide();
        }

        private void dataGridCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Categoria categoria = categorias[e.RowIndex];
                string columnName = dataGridCategorias.Columns[e.ColumnIndex].Name;

                if (columnName == "Editar")
                {
                    FrmCadastroCategorias form = new FrmCadastroCategorias(this, categoria);
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
                            categoriaQuery.delete(categoria.getCodigo());

                            MessageBox.Show("Categoria excluída com sucesso!");
                            BuscarCategorias();
                        }
                        catch(AssociateRowException)
                        {
                            MessageBox.Show("Você não pode excluir uma categoria que possui receitas associadas");
                        }
                    }
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarCategorias(txtNomeCategoria.Text);
        }
    }
}
