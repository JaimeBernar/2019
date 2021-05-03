namespace TFG
{
    partial class FormCargaTermica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargaTermica));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chcBoxGradiente = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtGradiente = new System.Windows.Forms.TextBox();
            this.txtTmedia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.chcBoxGradiente);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.txtGradiente);
            this.panel1.Controls.Add(this.txtTmedia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 166);
            this.panel1.TabIndex = 0;
            // 
            // chcBoxGradiente
            // 
            this.chcBoxGradiente.AutoSize = true;
            this.chcBoxGradiente.Checked = true;
            this.chcBoxGradiente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcBoxGradiente.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcBoxGradiente.ForeColor = System.Drawing.Color.White;
            this.chcBoxGradiente.Location = new System.Drawing.Point(18, 81);
            this.chcBoxGradiente.Name = "chcBoxGradiente";
            this.chcBoxGradiente.Size = new System.Drawing.Size(83, 20);
            this.chcBoxGradiente.TabIndex = 43;
            this.chcBoxGradiente.Text = "Gradiente";
            this.chcBoxGradiente.UseVisualStyleBackColor = true;
            this.chcBoxGradiente.CheckedChanged += new System.EventHandler(this.chcBoxGradiente_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(146, 119);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(65, 25);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(37, 119);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(65, 25);
            this.btnAplicar.TabIndex = 41;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtGradiente
            // 
            this.txtGradiente.BackColor = System.Drawing.Color.White;
            this.txtGradiente.Location = new System.Drawing.Point(135, 42);
            this.txtGradiente.Margin = new System.Windows.Forms.Padding(2);
            this.txtGradiente.Name = "txtGradiente";
            this.txtGradiente.Size = new System.Drawing.Size(76, 20);
            this.txtGradiente.TabIndex = 40;
            // 
            // txtTmedia
            // 
            this.txtTmedia.Location = new System.Drawing.Point(135, 19);
            this.txtTmedia.Margin = new System.Windows.Forms.Padding(2);
            this.txtTmedia.Name = "txtTmedia";
            this.txtTmedia.Size = new System.Drawing.Size(76, 20);
            this.txtTmedia.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Temperatura media";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Gradiente de Tª";
            // 
            // FormCargaTermica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(259, 191);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(275, 230);
            this.MinimumSize = new System.Drawing.Size(275, 230);
            this.Name = "FormCargaTermica";
            this.Text = "Carga Térmica";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chcBoxGradiente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtGradiente;
        private System.Windows.Forms.TextBox txtTmedia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}