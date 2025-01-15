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
    public partial class FrmCalculadoraProporcao : Form
    {
        private FrmReceitas frmReceitas;
        private Receita receita;

        private IngredienteReceitaQuery ingredienteQuery;
        private EstoqueQuery estoqueQuery;

        private ConversorMedidas conversor;

        private List<IngredienteReceita> ingredientes;

        public FrmCalculadoraProporcao(FrmReceitas frmReceitas, Receita receita)
        {
            InitializeComponent();

            this.receita = receita;
            this.frmReceitas = frmReceitas;

            ingredienteQuery = new IngredienteReceitaQuery();
            estoqueQuery = new EstoqueQuery();

            conversor = new ConversorMedidas();

            txtProporcao.Text = "1";
            txtReceita.Text = receita.getNome();

            dataGridIngredientes.Columns.Clear();
            dataGridIngredientes.Columns.Add("Ingrediente", "Ingrediente");
            dataGridIngredientes.Columns.Add("Quantidade", "Quantidade");
            dataGridIngredientes.Columns.Add("QuantidadeNecessaria", "Quantidade Necessária");
            dataGridIngredientes.Columns.Add("Estoque", "Quantidade em Estoque");

            dataGridIngredientes.Columns["Ingrediente"].Width = 200;
            dataGridIngredientes.Columns["Quantidade"].Width = 200;
            dataGridIngredientes.Columns["QuantidadeNecessaria"].Width = 200;
            dataGridIngredientes.Columns["Estoque"].Width = 200;

            BuscarIngredientes();
        }

        private void BuscarIngredientes()
        {
            dataGridIngredientes.Rows.Clear();
            ingredientes = ingredienteQuery.findByReceitaId(receita.getCodigo());

            foreach (IngredienteReceita ingrediente in ingredientes)
            {
                ingrediente.setReceita(receita);

                Ingrediente i = ingrediente.getIngrediente();
                List<Estoque> estoques = estoqueQuery.findByIngredienteId(i.getCodigo());

                foreach (Estoque estoque in estoques)
                    i.AddEstoque(estoque);

                double quantidadeConvertida = conversor.converterParaUnidadeMedida(i.getQuantidade(), i.getUnidadeMedida());

                string textoQuantidade = String.Format("{0} {1}", ingrediente.getQuantidade(),
                    i.getUnidadeMedida().ToLowerInvariant());

                string textoEstoque = String.Format("{0} {1}", quantidadeConvertida.ToString("F2"), i.getUnidadeMedida());

                dataGridIngredientes.Rows.Add(
                    i.getNome(),
                    textoQuantidade,
                    textoQuantidade,
                    textoEstoque);
            }
        }

        private void FrmCalculadoraProporcao_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmReceitas.Show();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double proporcao = double.Parse(txtProporcao.Text);
                if (proporcao <= 0)
                    throw new ArgumentException("Você deve informar uma proporção superior a zero");

                for (int i = 0; i < ingredientes.Count; i++)
                {
                    double quantidadeOriginal = ingredientes[i].getQuantidade();
                    double quantidadeNecessaria = quantidadeOriginal * proporcao;

                    string textoQuantidade = String.Format("{0} {1}", 
                        quantidadeNecessaria,
                        ingredientes[i].getIngrediente()
                        .getUnidadeMedida().ToLowerInvariant());

                    dataGridIngredientes.Rows[i].Cells["QuantidadeNecessaria"].Value = textoQuantidade;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Você deve informar um valor numérico");
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnProduzir_Click(object sender, EventArgs e)
        {
            try
            {
                double proporcao = double.Parse(txtProporcao.Text);

                List<Estoque> estoques = new List<Estoque>();
                foreach (IngredienteReceita ingrediente in ingredientes)
                {
                    Ingrediente i = ingrediente.getIngrediente();
                    string unidadeMedida = i.getUnidadeMedida();
                    double quantidadeNecessaria = ingrediente.getQuantidade() * proporcao;

                    double estoqueIngrediente = i.getQuantidade();

                    double quantidadeEmQuilos = conversor.converterParaQuilos(quantidadeNecessaria, unidadeMedida);
                    double quantidadeEstoqueConvertida = conversor.converterParaUnidadeMedida(estoqueIngrediente, unidadeMedida);

                    Estoque estoque = new Estoque(DateTime.Now, "SAIDA", quantidadeEmQuilos, i);
                    bool permitirOperacao = estoque.permitirOperacao();

                    if (!permitirOperacao)
                    {
                        string error = String.Format("Você não possui quantidade suficiente de {0}.\n" +
                            "Quantidade necessária: {1} {2}\n" +
                            "Quantidade disponível: {3} {4}", 
                            i.getNome(), quantidadeNecessaria, unidadeMedida,
                            quantidadeEstoqueConvertida, unidadeMedida);

                        throw new ArgumentException(error);
                    }

                    estoques.Add(estoque);
                }

                FrmPedido form = new FrmPedido(this, estoques, new Pedido(proporcao, receita));
                form.Show();
                Hide();
            }
            catch (FormatException)
            {
                MessageBox.Show("Você deve digitar um valor numérico");
            }
            catch (ArgumentException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
