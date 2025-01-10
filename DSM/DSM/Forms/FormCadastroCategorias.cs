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
    public partial class FrmCadastroCategorias : Form
    {
        private FrmCategorias frmCategorias;
        private Categoria categoria;

        public FrmCadastroCategorias(FrmCategorias frmCategorias, Categoria categoria = null)
        {
            InitializeComponent();
            this.frmCategorias = frmCategorias;
            this.categoria = categoria;

            if (categoria != null)
            {
                txtDescricao.Text = categoria.getDescricao();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CategoriaQuery query = new CategoriaQuery();

            try
            {
                if (categoria == null)
                {
                    Categoria categoriaNova = new Categoria(txtDescricao.Text);
                    query.insert(categoriaNova);
                    MessageBox.Show("Categoria cadastrada com sucesso");
                }
                else
                {
                    categoria.setDescricao(txtDescricao.Text);
                    query.update(categoria);
                    MessageBox.Show("Categoria atualizada com sucesso");
                }

                frmCategorias.BuscarCategorias();

                frmCategorias.Show();
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmCadastroCategorias_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCategorias.Show();
        }
    }
}
