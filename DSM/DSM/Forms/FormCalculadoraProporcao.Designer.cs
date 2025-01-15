namespace DSM.Forms
{
    partial class FrmCalculadoraProporcao
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
            this.dataGridIngredientes = new System.Windows.Forms.DataGridView();
            this.txtReceita = new System.Windows.Forms.TextBox();
            this.txtProporcao = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProduzir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridIngredientes
            // 
            this.dataGridIngredientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(214)))), ((int)(((byte)(202)))));
            this.dataGridIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridIngredientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.dataGridIngredientes.Location = new System.Drawing.Point(14, 132);
            this.dataGridIngredientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridIngredientes.Name = "dataGridIngredientes";
            this.dataGridIngredientes.RowHeadersWidth = 51;
            this.dataGridIngredientes.RowTemplate.Height = 24;
            this.dataGridIngredientes.Size = new System.Drawing.Size(873, 497);
            this.dataGridIngredientes.TabIndex = 0;
            // 
            // txtReceita
            // 
            this.txtReceita.Enabled = false;
            this.txtReceita.Location = new System.Drawing.Point(15, 92);
            this.txtReceita.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReceita.Name = "txtReceita";
            this.txtReceita.Size = new System.Drawing.Size(316, 30);
            this.txtReceita.TabIndex = 1;
            // 
            // txtProporcao
            // 
            this.txtProporcao.Location = new System.Drawing.Point(560, 81);
            this.txtProporcao.Name = "txtProporcao";
            this.txtProporcao.Size = new System.Drawing.Size(163, 30);
            this.txtProporcao.TabIndex = 2;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(740, 55);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(147, 56);
            this.btnCalcular.TabIndex = 3;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(556, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quantidade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Receita";
            // 
            // btnProduzir
            // 
            this.btnProduzir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(134)))), ((int)(((byte)(153)))));
            this.btnProduzir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduzir.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduzir.ForeColor = System.Drawing.Color.White;
            this.btnProduzir.Location = new System.Drawing.Point(363, 636);
            this.btnProduzir.Name = "btnProduzir";
            this.btnProduzir.Size = new System.Drawing.Size(174, 50);
            this.btnProduzir.TabIndex = 6;
            this.btnProduzir.Text = "Produzir";
            this.btnProduzir.UseVisualStyleBackColor = false;
            this.btnProduzir.Click += new System.EventHandler(this.btnProduzir_Click);
            // 
            // FrmCalculadoraProporcao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(176)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(900, 697);
            this.Controls.Add(this.btnProduzir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.txtProporcao);
            this.Controls.Add(this.txtReceita);
            this.Controls.Add(this.dataGridIngredientes);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCalculadoraProporcao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Proporção";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCalculadoraProporcao_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIngredientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridIngredientes;
        private System.Windows.Forms.TextBox txtReceita;
        private System.Windows.Forms.TextBox txtProporcao;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProduzir;
    }
}