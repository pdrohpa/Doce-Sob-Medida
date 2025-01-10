namespace DSM
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFormCategorias = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnFormReceitas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFormProdutos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "produtos.png");
            this.imageList1.Images.SetKeyName(1, "receitas.png");
            this.imageList1.Images.SetKeyName(2, "estoque.png");
            this.imageList1.Images.SetKeyName(3, "relatorio.png");
            this.imageList1.Images.SetKeyName(4, "category.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(348, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seja bem-vindo";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(266, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 34);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selecione uma das opções abaixo para continuar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFormCategorias
            // 
            this.btnFormCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(134)))), ((int)(((byte)(153)))));
            this.btnFormCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormCategorias.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormCategorias.ForeColor = System.Drawing.Color.White;
            this.btnFormCategorias.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormCategorias.ImageKey = "category.png";
            this.btnFormCategorias.ImageList = this.imageList1;
            this.btnFormCategorias.Location = new System.Drawing.Point(595, 290);
            this.btnFormCategorias.Name = "btnFormCategorias";
            this.btnFormCategorias.Padding = new System.Windows.Forms.Padding(0, 30, 0, 20);
            this.btnFormCategorias.Size = new System.Drawing.Size(175, 175);
            this.btnFormCategorias.TabIndex = 10;
            this.btnFormCategorias.Text = "Categorias";
            this.btnFormCategorias.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFormCategorias.UseVisualStyleBackColor = false;
            this.btnFormCategorias.Click += new System.EventHandler(this.btnFormCategorias_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(134)))), ((int)(((byte)(153)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.ImageKey = "relatorio.png";
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(513, 491);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(0, 30, 0, 20);
            this.button4.Size = new System.Drawing.Size(175, 175);
            this.button4.TabIndex = 9;
            this.button4.Text = "Relatório";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(134)))), ((int)(((byte)(153)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.ImageKey = "estoque.png";
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(269, 491);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(0, 30, 0, 20);
            this.button3.Size = new System.Drawing.Size(175, 175);
            this.button3.TabIndex = 8;
            this.button3.Text = "Estoque";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnFormReceitas
            // 
            this.btnFormReceitas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(134)))), ((int)(((byte)(153)))));
            this.btnFormReceitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormReceitas.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormReceitas.ForeColor = System.Drawing.Color.White;
            this.btnFormReceitas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormReceitas.ImageKey = "receitas.png";
            this.btnFormReceitas.ImageList = this.imageList1;
            this.btnFormReceitas.Location = new System.Drawing.Point(391, 290);
            this.btnFormReceitas.Name = "btnFormReceitas";
            this.btnFormReceitas.Padding = new System.Windows.Forms.Padding(0, 30, 0, 20);
            this.btnFormReceitas.Size = new System.Drawing.Size(175, 175);
            this.btnFormReceitas.TabIndex = 7;
            this.btnFormReceitas.Text = "Receitas";
            this.btnFormReceitas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFormReceitas.UseVisualStyleBackColor = false;
            this.btnFormReceitas.Click += new System.EventHandler(this.btnFormReceitas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DSM.Properties.Resources.logodsm;
            this.pictureBox1.Location = new System.Drawing.Point(399, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnFormProdutos
            // 
            this.btnFormProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(134)))), ((int)(((byte)(153)))));
            this.btnFormProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormProdutos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormProdutos.ForeColor = System.Drawing.Color.White;
            this.btnFormProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFormProdutos.ImageKey = "produtos.png";
            this.btnFormProdutos.ImageList = this.imageList1;
            this.btnFormProdutos.Location = new System.Drawing.Point(186, 290);
            this.btnFormProdutos.Name = "btnFormProdutos";
            this.btnFormProdutos.Padding = new System.Windows.Forms.Padding(0, 30, 0, 20);
            this.btnFormProdutos.Size = new System.Drawing.Size(175, 175);
            this.btnFormProdutos.TabIndex = 0;
            this.btnFormProdutos.Text = "Produtos";
            this.btnFormProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFormProdutos.UseVisualStyleBackColor = false;
            this.btnFormProdutos.Click += new System.EventHandler(this.btnFormProdutos_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(957, 695);
            this.Controls.Add(this.btnFormCategorias);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnFormReceitas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFormProdutos);
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bem-vindo!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFormProdutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnFormReceitas;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnFormCategorias;
    }
}

