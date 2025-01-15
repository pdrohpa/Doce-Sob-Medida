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
    public partial class FrmCadastroEstoque : Form
    {
        private FrmEstoque frmEstoque;
        private EstoqueQuery estoqueQuery;

        private List<string> tiposAcao = new List<string> { "ENTRADA", "SAIDA" };
        private List<Ingrediente> ingredientes;

        public FrmCadastroEstoque(FrmEstoque frmEstoque)
        {
            InitializeComponent();
            this.frmEstoque = frmEstoque;
            estoqueQuery = new EstoqueQuery();

            ingredientes = new List<Ingrediente>();
            loadComboBox();
        }

        private void loadComboBox()
        {
            IngredienteQuery ingredienteQuery = new IngredienteQuery();

            cbAcao.Items.Clear();
            cbIngrediente.Items.Clear();

            foreach (string tipoAcao in tiposAcao)
                cbAcao.Items.Add(tipoAcao);

            ingredientes = ingredienteQuery.findAll();

            foreach (Ingrediente ingrediente in ingredientes)
                cbIngrediente.Items.Add(ingrediente.getNome());
        }

        private void FrmCadastroEstoque_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmEstoque.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAcao.SelectedItem == null)
                    throw new ArgumentException("Você deve informar uma ação");

                if (cbIngrediente.SelectedItem == null)
                    throw new ArgumentException("Você deve informar um produto");

                string tipoAcao = tiposAcao[cbAcao.SelectedIndex];
                Ingrediente ingrediente = ingredientes[cbIngrediente.SelectedIndex];
                DateTime data = dtpData.Value;
                int quantidade = int.Parse(txtQuantidade.Text);

                Estoque estoque = new Estoque(data, tipoAcao, quantidade, ingrediente);

                bool permitirOperacao = estoque.permitirOperacao();

                if (!permitirOperacao)
                {
                    var mensagem = String.Format("Você não possui quantidade suficiente " +
                        "para a operação.\nQuantidade = {0}", ingrediente.getQuantidade());

                    throw new ArgumentException(mensagem);
                }

                estoqueQuery.insert(estoque);

                MessageBox.Show("Estoque lançado com sucesso");
                frmEstoque.resetar();

                frmEstoque.Show();
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
    }
}
