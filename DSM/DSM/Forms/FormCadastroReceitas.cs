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

namespace DSM
{
    public partial class FrmCadastroReceitas : Form
    {
        private FrmReceitas frmReceitas;

        private List<IngredienteReceita> ingredienteReceitas;
        private List<Categoria> categorias;
        private List<Ingrediente> ingredientes;

        private ReceitaQuery receitaQuery;
        private IngredienteReceitaQuery ingredienteQuery;

        public FrmCadastroReceitas(FrmReceitas frmReceitas)
        {
            InitializeComponent();
            this.frmReceitas = frmReceitas;
            ingredienteReceitas = new List<IngredienteReceita>();
            categorias = new List<Categoria>();
            ingredientes = new List<Ingrediente>();
            receitaQuery = new ReceitaQuery();
            ingredienteQuery = new IngredienteReceitaQuery();

            loadComboBox();

            dataGridIngredientes.Columns.Add("Nome", "Nome");
            dataGridIngredientes.Columns.Add("UnidadeMedida", "Unidade de Medida");
            dataGridIngredientes.Columns.Add("Quantidade", "Quantidade");
        }

        private void loadComboBox()
        {
            IngredienteQuery ingredienteQuery = new IngredienteQuery();
            ingredientes = ingredienteQuery.findAll();

            CategoriaQuery categoriaQuery = new CategoriaQuery();
            categorias = categoriaQuery.findAll();

            cbIngredientes.Items.Clear();
            cbCategorias.Items.Clear();

            foreach (Ingrediente ingrediente in ingredientes)
                cbIngredientes.Items.Add(ingrediente.getNome());
            

            foreach (Categoria categoria in categorias)
                cbCategorias.Items.Add(categoria.getDescricao());
        }

        private void btnAdicionarIngrediente_Click(object sender, EventArgs e)
        {
            try
            {
                int quantidade = int.Parse(txtQuantidade.Text);

                Ingrediente ingrediente = ingredientes[cbIngredientes.SelectedIndex];
                IngredienteReceita ingredienteReceita = new IngredienteReceita();

                ingredienteReceita.setIngrediente(ingrediente);
                ingredienteReceita.setQuantidade(quantidade);

                ingredienteReceitas.Add(ingredienteReceita);

                cbIngredientes.SelectedItem = null;
                txtQuantidade.Text = "";

                dataGridIngredientes.Rows.Add(ingrediente.getNome(), ingrediente.getUnidadeMedida(), quantidade);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Por favor, selecione um ingrediente");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, digite um número");
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void dataGridIngredientes_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int removedRowIndex = e.RowIndex;
            int rowsRemovedCount = e.RowCount;

            for (int i = removedRowIndex; i < removedRowIndex + rowsRemovedCount; i++)
            {
                if (i < ingredienteReceitas.Count)
                {
                    ingredienteReceitas.RemoveAt(i); 
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCategorias.SelectedItem == null)
                    throw new ArgumentException("Você deve selecionar uma categoria");

                string nome = txtNome.Text;
                double precoCusto = double.Parse(txtPrecoCusto.Text);
                Categoria categoria = categorias[cbCategorias.SelectedIndex];
                string descricao = txtDescricao.Text;

                Receita receita = new Receita(nome, descricao, precoCusto, categoria);

                if (ingredienteReceitas.Count == 0)
                    throw new EmptyListException();

                foreach (IngredienteReceita ingrediente in ingredienteReceitas)
                {
                    ingrediente.setReceita(receita);
                    receita.AddIngrediente(ingrediente);
                }

                int id = receitaQuery.insert(receita);
                receita.setCodigo(id);

                ingredienteQuery.insertMany(receita.getIngredientes());

                MessageBox.Show("Receita cadastrada com sucesso!");
                frmReceitas.BuscarReceitas();
                frmReceitas.Show();
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Digite um valor numérico");
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message);
            }
            catch (EmptyListException)
            {
                MessageBox.Show("Você precisa adicionar pelo menos um ingrediente");
            }
        }

        private void FrmCadastroReceitas_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmReceitas.Show();
        }
    }
}
