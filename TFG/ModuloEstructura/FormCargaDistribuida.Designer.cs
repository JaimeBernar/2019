namespace TFG
{
    partial class FormCargaDistribuida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCargaDistribuida));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chcBoxConst = new System.Windows.Forms.CheckBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtQj = new System.Windows.Forms.TextBox();
            this.txtQi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnXglobal = new System.Windows.Forms.RadioButton();
            this.rbtnYglobal = new System.Windows.Forms.RadioButton();
            this.rbtnYlocal = new System.Windows.Forms.RadioButton();
            this.rbtnXlocal = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.chcBoxConst);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.txtQj);
            this.panel1.Controls.Add(this.txtQi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rbtnXglobal);
            this.panel1.Controls.Add(this.rbtnYglobal);
            this.panel1.Controls.Add(this.rbtnYlocal);
            this.panel1.Controls.Add(this.rbtnXlocal);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 170);
            this.panel1.TabIndex = 0;
            // 
            // chcBoxConst
            // 
            this.chcBoxConst.AutoSize = true;
            this.chcBoxConst.Checked = true;
            this.chcBoxConst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chcBoxConst.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chcBoxConst.ForeColor = System.Drawing.Color.White;
            this.chcBoxConst.Location = new System.Drawing.Point(15, 86);
            this.chcBoxConst.Name = "chcBoxConst";
            this.chcBoxConst.Size = new System.Drawing.Size(84, 20);
            this.chcBoxConst.TabIndex = 32;
            this.chcBoxConst.Text = "Constante";
            this.chcBoxConst.UseVisualStyleBackColor = true;
            this.chcBoxConst.CheckedChanged += new System.EventHandler(this.chcBoxConst_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(156, 138);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(65, 25);
            this.btnCancelar.TabIndex = 31;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(49, 138);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(65, 25);
            this.btnAplicar.TabIndex = 30;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtQj
            // 
            this.txtQj.BackColor = System.Drawing.Color.White;
            this.txtQj.Location = new System.Drawing.Point(108, 43);
            this.txtQj.Margin = new System.Windows.Forms.Padding(2);
            this.txtQj.Name = "txtQj";
            this.txtQj.Size = new System.Drawing.Size(76, 20);
            this.txtQj.TabIndex = 27;
            // 
            // txtQi
            // 
            this.txtQi.Location = new System.Drawing.Point(108, 19);
            this.txtQi.Margin = new System.Windows.Forms.Padding(2);
            this.txtQi.Name = "txtQi";
            this.txtQi.Size = new System.Drawing.Size(76, 20);
            this.txtQi.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Fuerza nodo i";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Fuerza nodo j";
            // 
            // rbtnXglobal
            // 
            this.rbtnXglobal.AutoSize = true;
            this.rbtnXglobal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnXglobal.ForeColor = System.Drawing.Color.White;
            this.rbtnXglobal.Location = new System.Drawing.Point(201, 62);
            this.rbtnXglobal.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnXglobal.Name = "rbtnXglobal";
            this.rbtnXglobal.Size = new System.Drawing.Size(70, 20);
            this.rbtnXglobal.TabIndex = 23;
            this.rbtnXglobal.Text = "X global";
            this.rbtnXglobal.UseVisualStyleBackColor = true;
            // 
            // rbtnYglobal
            // 
            this.rbtnYglobal.AutoSize = true;
            this.rbtnYglobal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnYglobal.ForeColor = System.Drawing.Color.White;
            this.rbtnYglobal.Location = new System.Drawing.Point(201, 86);
            this.rbtnYglobal.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnYglobal.Name = "rbtnYglobal";
            this.rbtnYglobal.Size = new System.Drawing.Size(70, 20);
            this.rbtnYglobal.TabIndex = 22;
            this.rbtnYglobal.Text = "Y global";
            this.rbtnYglobal.UseVisualStyleBackColor = true;
            // 
            // rbtnYlocal
            // 
            this.rbtnYlocal.AutoSize = true;
            this.rbtnYlocal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnYlocal.ForeColor = System.Drawing.Color.White;
            this.rbtnYlocal.Location = new System.Drawing.Point(201, 38);
            this.rbtnYlocal.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnYlocal.Name = "rbtnYlocal";
            this.rbtnYlocal.Size = new System.Drawing.Size(62, 20);
            this.rbtnYlocal.TabIndex = 21;
            this.rbtnYlocal.Text = "Y local";
            this.rbtnYlocal.UseVisualStyleBackColor = true;
            // 
            // rbtnXlocal
            // 
            this.rbtnXlocal.AutoSize = true;
            this.rbtnXlocal.Checked = true;
            this.rbtnXlocal.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnXlocal.ForeColor = System.Drawing.Color.White;
            this.rbtnXlocal.Location = new System.Drawing.Point(201, 14);
            this.rbtnXlocal.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnXlocal.Name = "rbtnXlocal";
            this.rbtnXlocal.Size = new System.Drawing.Size(62, 20);
            this.rbtnXlocal.TabIndex = 18;
            this.rbtnXlocal.TabStop = true;
            this.rbtnXlocal.Text = "X local";
            this.rbtnXlocal.UseVisualStyleBackColor = true;
            // 
            // FormCargaDistribuida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(303, 196);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(319, 251);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(319, 235);
            this.Name = "FormCargaDistribuida";
            this.Text = "Carga distribuida";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtQj;
        private System.Windows.Forms.TextBox txtQi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnXglobal;
        private System.Windows.Forms.RadioButton rbtnYglobal;
        private System.Windows.Forms.RadioButton rbtnYlocal;
        private System.Windows.Forms.RadioButton rbtnXlocal;
        private System.Windows.Forms.CheckBox chcBoxConst;
    }
}