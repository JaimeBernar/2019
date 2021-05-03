namespace TFG
{
    partial class FormAsentamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAsentamiento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.rbtnYpos = new System.Windows.Forms.RadioButton();
            this.rbtnXpos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAsentamiento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiro = new System.Windows.Forms.TextBox();
            this.rbtnYneg = new System.Windows.Forms.RadioButton();
            this.rbtnXneg = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.rbtnXneg);
            this.panel1.Controls.Add(this.rbtnYneg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtGiro);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.rbtnYpos);
            this.panel1.Controls.Add(this.rbtnXpos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAsentamiento);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 157);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(131, 124);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 19);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(23, 124);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(56, 19);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // rbtnYpos
            // 
            this.rbtnYpos.AutoSize = true;
            this.rbtnYpos.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnYpos.ForeColor = System.Drawing.Color.White;
            this.rbtnYpos.Location = new System.Drawing.Point(217, 48);
            this.rbtnYpos.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnYpos.Name = "rbtnYpos";
            this.rbtnYpos.Size = new System.Drawing.Size(39, 20);
            this.rbtnYpos.TabIndex = 3;
            this.rbtnYpos.Text = "+Y";
            this.rbtnYpos.UseVisualStyleBackColor = true;
            // 
            // rbtnXpos
            // 
            this.rbtnXpos.AutoSize = true;
            this.rbtnXpos.Checked = true;
            this.rbtnXpos.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnXpos.ForeColor = System.Drawing.Color.White;
            this.rbtnXpos.Location = new System.Drawing.Point(217, 18);
            this.rbtnXpos.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnXpos.Name = "rbtnXpos";
            this.rbtnXpos.Size = new System.Drawing.Size(39, 20);
            this.rbtnXpos.TabIndex = 2;
            this.rbtnXpos.TabStop = true;
            this.rbtnXpos.Text = "+X";
            this.rbtnXpos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Asentamiento";
            // 
            // txtAsentamiento
            // 
            this.txtAsentamiento.Location = new System.Drawing.Point(115, 27);
            this.txtAsentamiento.Margin = new System.Windows.Forms.Padding(2);
            this.txtAsentamiento.Name = "txtAsentamiento";
            this.txtAsentamiento.Size = new System.Drawing.Size(76, 20);
            this.txtAsentamiento.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Giro";
            // 
            // txtGiro
            // 
            this.txtGiro.Location = new System.Drawing.Point(115, 71);
            this.txtGiro.Margin = new System.Windows.Forms.Padding(2);
            this.txtGiro.Name = "txtGiro";
            this.txtGiro.Size = new System.Drawing.Size(76, 20);
            this.txtGiro.TabIndex = 1;
            // 
            // rbtnYneg
            // 
            this.rbtnYneg.AutoSize = true;
            this.rbtnYneg.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnYneg.ForeColor = System.Drawing.Color.White;
            this.rbtnYneg.Location = new System.Drawing.Point(217, 110);
            this.rbtnYneg.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnYneg.Name = "rbtnYneg";
            this.rbtnYneg.Size = new System.Drawing.Size(37, 20);
            this.rbtnYneg.TabIndex = 35;
            this.rbtnYneg.Text = "-Y";
            this.rbtnYneg.UseVisualStyleBackColor = true;
            // 
            // rbtnXneg
            // 
            this.rbtnXneg.AutoSize = true;
            this.rbtnXneg.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.rbtnXneg.ForeColor = System.Drawing.Color.White;
            this.rbtnXneg.Location = new System.Drawing.Point(217, 80);
            this.rbtnXneg.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnXneg.Name = "rbtnXneg";
            this.rbtnXneg.Size = new System.Drawing.Size(37, 20);
            this.rbtnXneg.TabIndex = 36;
            this.rbtnXneg.Text = "-X";
            this.rbtnXneg.UseVisualStyleBackColor = true;
            // 
            // FormAsentamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(294, 181);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(310, 220);
            this.MinimumSize = new System.Drawing.Size(260, 200);
            this.Name = "FormAsentamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asentamiento";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.RadioButton rbtnYpos;
        private System.Windows.Forms.RadioButton rbtnXpos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAsentamiento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiro;
        private System.Windows.Forms.RadioButton rbtnXneg;
        private System.Windows.Forms.RadioButton rbtnYneg;
    }
}