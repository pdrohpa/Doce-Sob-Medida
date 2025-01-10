namespace DSM
{
    partial class FrmProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFormCadastroProdutos = new System.Windows.Forms.Button();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.dataGridIngredientes = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFormCadastroProdutos
            // 
            this.btnFormCadastroProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(134)))), ((int)(((byte)(153)))));
            this.btnFormCadastroProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFormCadastroProdutos.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormCadastroProdutos.ForeColor = System.Drawing.Color.White;
            this.btnFormCadastroProdutos.Location = new System.Drawing.Point(725, 25);
            this.btnFormCadastroProdutos.Name = "btnFormCadastroProdutos";
            this.btnFormCadastroProdutos.Size = new System.Drawing.Size(220, 71);
            this.btnFormCadastroProdutos.TabIndex = 1;
            this.btnFormCadastroProdutos.Text = "Adicionar";
            this.btnFormCadastroProdutos.UseVisualStyleBackColor = false;
            this.btnFormCadastroProdutos.Click += new System.EventHandler(this.btnFormCadastroProdutos_Click);
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProduto.Location = new System.Drawing.Point(12, 68);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(359, 30);
            this.txtNomeProduto.TabIndex = 0;
            // 
            // dataGridIngredientes
            // 
            this.dataGridIngredientes.AllowUserToAddRows = false;
            this.dataGridIngredientes.AllowUserToDeleteRows = false;
            this.dataGridIngredientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(214)))), ((int)(((byte)(202)))));
            this.dataGridIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIngredientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.dataGridIngredientes.Location = new System.Drawing.Point(10, 104);
            this.dataGridIngredientes.Name = "dataGridIngredientes";
            this.dataGridIngredientes.ReadOnly = true;
            this.dataGridIngredientes.RowHeadersWidth = 51;
            this.dataGridIngredientes.RowTemplate.Height = 24;
            this.dataGridIngredientes.Size = new System.Drawing.Size(935, 579);
            this.dataGridIngredientes.TabIndex = 4;
            this.dataGridIngredientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridIngredientes_CellClick);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(378, 68);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 30);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome";
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(957, 695);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dataGridIngredientes);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.btnFormCadastroProdutos);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngredientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFormCadastroProdutos;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.DataGridView dataGridIngredientes;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label2;
    }
}