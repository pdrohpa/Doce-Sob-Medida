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
    public partial class FormCadastroProdutos : Form
    {
        private FrmProdutos formProdutos;
        private Ingrediente ingrediente;
        private IngredienteQuery ingredienteQuery;
        private EstoqueQuery estoqueQuery;

        private List<string> unidadesDeMedida = new List<string>
        {
            "Mililitros",
            "Gramas",
            "Xícaras",
            "Colheres de Chá",
            "Colheres de Sopa",
            "Unidades"
        };

        public FormCadastroProdutos(FrmProdutos formProdutos, Ingrediente ingrediente)
        {
            InitializeComponent();
            this.formProdutos = formProdutos;
            this.ingrediente = ingrediente;
            ingredienteQuery = new IngredienteQuery();
            estoqueQuery = new EstoqueQuery();

            cbUnidadeMedida.Items.Clear();
            foreach (string item in unidadesDeMedida)
                cbUnidadeMedida.Items.Add(item);

            if (ingrediente != null)
            {
                txtNome.Text = ingrediente.getNome();
                cbUnidadeMedida.SelectedIndex = unidadesDeMedida.IndexOf(ingrediente.getUnidadeMedida());
            }
        }

        private void Editar()
        {
                        
            string nome = txtNome.Text;
            string unidadeMedida = cbUnidadeMedida.SelectedItem.ToString();

            ingrediente.setNome(nome);
            ingrediente.setUnidadeMedida(unidadeMedida);

            ingredienteQuery.update(ingrediente);

            MessageBox.Show("Ingrediente atualizado com sucesso!");
        }

        private void Cadastrar()
        {
            if (cbUnidadeMedida.SelectedItem == null)
                throw new ArgumentException("Você deve selecionar a unidade de medida");

            string nome = txtNome.Text;
            string unidadeMedida = unidadesDeMedida[cbUnidadeMedida.SelectedIndex];

            Ingrediente ingredienteNovo = new Ingrediente(nome, unidadeMedida);
            int id = ingredienteQuery.insert(ingredienteNovo);

            MessageBox.Show("Ingrediente cadastrado com sucesso!");

            ingredienteNovo.setCodigo(id);
            Estoque estoque = new Estoque(DateTime.Now, "ENTRADA", 0, ingredienteNovo);
            estoqueQuery.insert(estoque);

            txtNome.Text = "";
            cbUnidadeMedida.SelectedItem = null;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ingrediente != null) Editar();
                else Cadastrar();

                formProdutos.BuscarIngredientes();
                formProdutos.Show();
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
        }

        private void FormCadastroProdutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            formProdutos.Show();
        }
    }
}
