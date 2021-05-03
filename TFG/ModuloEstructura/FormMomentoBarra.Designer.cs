namespace TFG
{
    partial class FormMomentoBarra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMomentoBarra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtDnodoj = new System.Windows.Forms.TextBox();
            this.txtDnodoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxCentrada = new System.Windows.Forms.CheckBox();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.txtDnodoj);
            this.panel1.Controls.Add(this.txtDnodoi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxCentrada);
            this.panel1.Controls.Add(this.txtModulo);
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 169);
            this.panel1.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(162, 134);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(65, 25);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(45, 134);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(65, 25);
            this.btnAplicar.TabIndex = 14;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtDnodoj
            // 
            this.txtDnodoj.Location = new System.Drawing.Point(162, 67);
            this.txtDnodoj.Margin = new System.Windows.Forms.Padding(2);
            this.txtDnodoj.Name = "txtDnodoj";
            this.txtDnodoj.Size = new System.Drawing.Size(76, 20);
            this.txtDnodoj.TabIndex = 11;
            this.txtDnodoj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDnodoj_KeyUp);
            // 
            // txtDnodoi
            // 
            this.txtDnodoi.Location = new System.Drawing.Point(162, 43);
            this.txtDnodoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDnodoi.Name = "txtDnodoi";
            this.txtDnodoi.Size = new System.Drawing.Size(76, 20);
            this.txtDnodoi.TabIndex = 10;
            this.txtDnodoi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDnodoi_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Distancia nodo i";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Distancia nodo j";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Módulo";
            // 
            // checkBoxCentrada
            // 
            this.checkBoxCentrada.AutoSize = true;
            this.checkBoxCentrada.Checked = true;
            this.checkBoxCentrada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCentrada.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.checkBoxCentrada.ForeColor = System.Drawing.Color.White;
            this.checkBoxCentrada.Location = new System.Drawing.Point(29, 100);
            this.checkBoxCentrada.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCentrada.Name = "checkBoxCentrada";
            this.checkBoxCentrada.Size = new System.Drawing.Size(81, 20);
            this.checkBoxCentrada.TabIndex = 0;
            this.checkBoxCentrada.Text = "Centrada";
            this.checkBoxCentrada.UseVisualStyleBackColor = true;
            this.checkBoxCentrada.CheckedChanged += new System.EventHandler(this.checkBoxCentrada_CheckedChanged);
            // 
            // txtModulo
            // 
            this.txtModulo.Location = new System.Drawing.Point(162, 19);
            this.txtModulo.Margin = new System.Windows.Forms.Padding(2);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(76, 20);
            this.txtModulo.TabIndex = 3;
            // 
            // FormMomentoBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 230);
            this.MinimumSize = new System.Drawing.Size(300, 230);
            this.Name = "FormMomentoBarra";
            this.Text = "Momento en barra";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtDnodoj;
        private System.Windows.Forms.TextBox txtDnodoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxCentrada;
        private System.Windows.Forms.TextBox txtModulo;
    }
}