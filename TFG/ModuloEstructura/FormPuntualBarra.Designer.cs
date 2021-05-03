namespace TFG
{
    partial class FormFuerzaBarra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFuerzaBarra));
            this.checkBoxCentrada = new System.Windows.Forms.CheckBox();
            this.rbtnXlocal = new System.Windows.Forms.RadioButton();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtDnodoj = new System.Windows.Forms.TextBox();
            this.txtDnodoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnXglobal = new System.Windows.Forms.RadioButton();
            this.rbtnYglobal = new System.Windows.Forms.RadioButton();
            this.rbtnYlocal = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxCentrada
            // 
            this.checkBoxCentrada.AutoSize = true;
            this.checkBoxCentrada.Checked = true;
            this.checkBoxCentrada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCentrada.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.checkBoxCentrada.ForeColor = System.Drawing.Color.White;
            this.checkBoxCentrada.Location = new System.Drawing.Point(39, 123);
            this.checkBoxCentrada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCentrada.Name = "checkBoxCentrada";
            this.checkBoxCentrada.Size = new System.Drawing.Size(99, 23);
            this.checkBoxCentrada.TabIndex = 0;
            this.checkBoxCentrada.Text = "Centrada";
            this.checkBoxCentrada.UseVisualStyleBackColor = true;
            this.checkBoxCentrada.CheckStateChanged += new System.EventHandler(this.checkBoxCentrada_CheckStateChanged);
            // 
            // rbtnXlocal
            // 
            this.rbtnXlocal.AutoSize = true;
            this.rbtnXlocal.Checked = true;
            this.rbtnXlocal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnXlocal.ForeColor = System.Drawing.Color.White;
            this.rbtnXlocal.Location = new System.Drawing.Point(301, 20);
            this.rbtnXlocal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnXlocal.Name = "rbtnXlocal";
            this.rbtnXlocal.Size = new System.Drawing.Size(77, 23);
            this.rbtnXlocal.TabIndex = 2;
            this.rbtnXlocal.TabStop = true;
            this.rbtnXlocal.Text = "X local";
            this.rbtnXlocal.UseVisualStyleBackColor = true;
            // 
            // txtModulo
            // 
            this.txtModulo.Location = new System.Drawing.Point(181, 23);
            this.txtModulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(100, 22);
            this.txtModulo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Módulo";
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
            this.panel1.Controls.Add(this.rbtnXglobal);
            this.panel1.Controls.Add(this.rbtnYglobal);
            this.panel1.Controls.Add(this.rbtnYlocal);
            this.panel1.Controls.Add(this.rbtnXlocal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxCentrada);
            this.panel1.Controls.Add(this.txtModulo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 203);
            this.panel1.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(231, 165);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 31);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(87, 165);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(87, 31);
            this.btnAplicar.TabIndex = 14;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtDnodoj
            // 
            this.txtDnodoj.Location = new System.Drawing.Point(181, 82);
            this.txtDnodoj.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDnodoj.Name = "txtDnodoj";
            this.txtDnodoj.Size = new System.Drawing.Size(100, 22);
            this.txtDnodoj.TabIndex = 11;
            this.txtDnodoj.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDnodoj_KeyUp);
            // 
            // txtDnodoi
            // 
            this.txtDnodoi.Location = new System.Drawing.Point(181, 53);
            this.txtDnodoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDnodoi.Name = "txtDnodoi";
            this.txtDnodoi.Size = new System.Drawing.Size(100, 22);
            this.txtDnodoi.TabIndex = 10;
            this.txtDnodoi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDnodoi_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(35, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Distancia nodo i";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Distancia nodo j";
            // 
            // rbtnXglobal
            // 
            this.rbtnXglobal.AutoSize = true;
            this.rbtnXglobal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnXglobal.ForeColor = System.Drawing.Color.White;
            this.rbtnXglobal.Location = new System.Drawing.Point(301, 79);
            this.rbtnXglobal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnXglobal.Name = "rbtnXglobal";
            this.rbtnXglobal.Size = new System.Drawing.Size(87, 23);
            this.rbtnXglobal.TabIndex = 7;
            this.rbtnXglobal.Text = "X global";
            this.rbtnXglobal.UseVisualStyleBackColor = true;
            // 
            // rbtnYglobal
            // 
            this.rbtnYglobal.AutoSize = true;
            this.rbtnYglobal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnYglobal.ForeColor = System.Drawing.Color.White;
            this.rbtnYglobal.Location = new System.Drawing.Point(301, 108);
            this.rbtnYglobal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnYglobal.Name = "rbtnYglobal";
            this.rbtnYglobal.Size = new System.Drawing.Size(85, 23);
            this.rbtnYglobal.TabIndex = 6;
            this.rbtnYglobal.Text = "Y global";
            this.rbtnYglobal.UseVisualStyleBackColor = true;
            // 
            // rbtnYlocal
            // 
            this.rbtnYlocal.AutoSize = true;
            this.rbtnYlocal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnYlocal.ForeColor = System.Drawing.Color.White;
            this.rbtnYlocal.Location = new System.Drawing.Point(301, 49);
            this.rbtnYlocal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnYlocal.Name = "rbtnYlocal";
            this.rbtnYlocal.Size = new System.Drawing.Size(75, 23);
            this.rbtnYlocal.TabIndex = 5;
            this.rbtnYlocal.Text = "Y local";
            this.rbtnYlocal.UseVisualStyleBackColor = true;
            // 
            // FormPuntualBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(429, 219);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(447, 266);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(447, 266);
            this.Name = "FormPuntualBarra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carga puntual en barra";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCentrada;
        private System.Windows.Forms.RadioButton rbtnXlocal;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnYlocal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtDnodoj;
        private System.Windows.Forms.TextBox txtDnodoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnXglobal;
        private System.Windows.Forms.RadioButton rbtnYglobal;
    }
}