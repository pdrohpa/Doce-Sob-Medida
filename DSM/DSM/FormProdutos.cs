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
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();

            listViewProdutos.View = View.Details;
            listViewProdutos.FullRowSelect = true; // Seleção da linha inteira

            // Adicionando as colunas ao ListView
            listViewProdutos.Columns.Add("Nome", 300, HorizontalAlignment.Left);
            listViewProdutos.Columns.Add("Preço", 100, HorizontalAlignment.Right);
            listViewProdutos.Columns.Add("Estoque", 150, HorizontalAlignment.Center);

            ListViewItem item1 = new ListViewItem("Produto 1");
            item1.SubItems.Add("R$ 15,00"); // Preço formatado como moeda
            item1.SubItems.Add("100"); // Quantidade
            listViewProdutos.Items.Add(item1);

            ListViewItem item2 = new ListViewItem("Produto 2");
            item2.SubItems.Add("R$ 25,00");
            item2.SubItems.Add("200");
            listViewProdutos.Items.Add(item2);

            ListViewItem item3 = new ListViewItem("Produto 3");
            item3.SubItems.Add("R$ 10,00");
            item3.SubItems.Add("50");
            listViewProdutos.Items.Add(item3);

            ListViewItem item4 = new ListViewItem("Produto 4");
            item4.SubItems.Add("R$ 50,00");
            item4.SubItems.Add("30");
            listViewProdutos.Items.Add(item4);
        }
    }
}
