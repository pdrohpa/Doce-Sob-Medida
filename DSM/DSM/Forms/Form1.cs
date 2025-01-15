using DSM.Forms;
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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnFormProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos form = new FrmProdutos();
            form.Show();
 
        }

        private void btnFormReceitas_Click(object sender, EventArgs e)
        {
            FrmReceitas form = new FrmReceitas();
            form.Show();
        }

        private void btnFormCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias form = new FrmCategorias();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmEstoque form = new FrmEstoque();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmRelatorio form = new FrmRelatorio();
            form.Show();
        }
    }
}
