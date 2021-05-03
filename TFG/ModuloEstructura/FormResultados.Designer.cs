namespace TFG
{
    partial class FormResultados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResultados));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbBarras = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl3Min = new System.Windows.Forms.Label();
            this.txtMmin = new System.Windows.Forms.TextBox();
            this.lbl2Min = new System.Windows.Forms.Label();
            this.txtVmin = new System.Windows.Forms.TextBox();
            this.lbl1Min = new System.Windows.Forms.Label();
            this.txtNmin = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl3Max = new System.Windows.Forms.Label();
            this.txtMmax = new System.Windows.Forms.TextBox();
            this.lbl2Max = new System.Windows.Forms.Label();
            this.txtVmax = new System.Windows.Forms.TextBox();
            this.lbl1Max = new System.Windows.Forms.Label();
            this.txtNmax = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Esfuerzos = new System.Windows.Forms.TabPage();
            this.dgvEsfuerzos = new System.Windows.Forms.DataGridView();
            this.Deformaciones = new System.Windows.Forms.TabPage();
            this.dgvDeformaciones = new System.Windows.Forms.DataGridView();
            this.rBtnLocales = new System.Windows.Forms.RadioButton();
            this.rBtnGlobales = new System.Windows.Forms.RadioButton();
            this.DistNodoI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Axial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cortante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.Esfuerzos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsfuerzos)).BeginInit();
            this.Deformaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeformaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBarras
            // 
            this.cbBarras.FormattingEnabled = true;
            this.cbBarras.Location = new System.Drawing.Point(43, 10);
            this.cbBarras.Name = "cbBarras";
            this.cbBarras.Size = new System.Drawing.Size(103, 21);
            this.cbBarras.TabIndex = 1;
            this.cbBarras.SelectedIndexChanged += new System.EventHandler(this.CbBarras_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barra";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.lbl3Min);
            this.panel1.Controls.Add(this.txtMmin);
            this.panel1.Controls.Add(this.lbl2Min);
            this.panel1.Controls.Add(this.txtVmin);
            this.panel1.Controls.Add(this.lbl1Min);
            this.panel1.Controls.Add(this.txtNmin);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lbl3Max);
            this.panel1.Controls.Add(this.txtMmax);
            this.panel1.Controls.Add(this.lbl2Max);
            this.panel1.Controls.Add(this.txtVmax);
            this.panel1.Controls.Add(this.lbl1Max);
            this.panel1.Controls.Add(this.txtNmax);
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.cbBarras);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 480);
            this.panel1.TabIndex = 3;
            // 
            // lbl3Min
            // 
            this.lbl3Min.AutoSize = true;
            this.lbl3Min.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3Min.ForeColor = System.Drawing.Color.White;
            this.lbl3Min.Location = new System.Drawing.Point(269, 65);
            this.lbl3Min.Name = "lbl3Min";
            this.lbl3Min.Size = new System.Drawing.Size(38, 16);
            this.lbl3Min.TabIndex = 18;
            this.lbl3Min.Text = "Mmin";
            // 
            // txtMmin
            // 
            this.txtMmin.Location = new System.Drawing.Point(310, 63);
            this.txtMmin.Name = "txtMmin";
            this.txtMmin.Size = new System.Drawing.Size(60, 20);
            this.txtMmin.TabIndex = 17;
            // 
            // lbl2Min
            // 
            this.lbl2Min.AutoSize = true;
            this.lbl2Min.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2Min.ForeColor = System.Drawing.Color.White;
            this.lbl2Min.Location = new System.Drawing.Point(270, 39);
            this.lbl2Min.Name = "lbl2Min";
            this.lbl2Min.Size = new System.Drawing.Size(34, 16);
            this.lbl2Min.TabIndex = 16;
            this.lbl2Min.Text = "Vmin";
            // 
            // txtVmin
            // 
            this.txtVmin.Location = new System.Drawing.Point(310, 37);
            this.txtVmin.Name = "txtVmin";
            this.txtVmin.Size = new System.Drawing.Size(60, 20);
            this.txtVmin.TabIndex = 15;
            // 
            // lbl1Min
            // 
            this.lbl1Min.AutoSize = true;
            this.lbl1Min.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Min.ForeColor = System.Drawing.Color.White;
            this.lbl1Min.Location = new System.Drawing.Point(269, 13);
            this.lbl1Min.Name = "lbl1Min";
            this.lbl1Min.Size = new System.Drawing.Size(35, 16);
            this.lbl1Min.TabIndex = 14;
            this.lbl1Min.Text = "Nmin";
            // 
            // txtNmin
            // 
            this.txtNmin.Location = new System.Drawing.Point(310, 11);
            this.txtNmin.Name = "txtNmin";
            this.txtNmin.Size = new System.Drawing.Size(60, 20);
            this.txtNmin.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel4.Location = new System.Drawing.Point(81, 41);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 32);
            this.panel4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(43, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 32);
            this.panel3.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(5, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(32, 32);
            this.panel2.TabIndex = 10;
            // 
            // lbl3Max
            // 
            this.lbl3Max.AutoSize = true;
            this.lbl3Max.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3Max.ForeColor = System.Drawing.Color.White;
            this.lbl3Max.Location = new System.Drawing.Point(156, 65);
            this.lbl3Max.Name = "lbl3Max";
            this.lbl3Max.Size = new System.Drawing.Size(43, 16);
            this.lbl3Max.TabIndex = 9;
            this.lbl3Max.Text = "Mmax";
            // 
            // txtMmax
            // 
            this.txtMmax.Location = new System.Drawing.Point(202, 63);
            this.txtMmax.Name = "txtMmax";
            this.txtMmax.Size = new System.Drawing.Size(60, 20);
            this.txtMmax.TabIndex = 8;
            // 
            // lbl2Max
            // 
            this.lbl2Max.AutoSize = true;
            this.lbl2Max.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2Max.ForeColor = System.Drawing.Color.White;
            this.lbl2Max.Location = new System.Drawing.Point(156, 39);
            this.lbl2Max.Name = "lbl2Max";
            this.lbl2Max.Size = new System.Drawing.Size(39, 16);
            this.lbl2Max.TabIndex = 7;
            this.lbl2Max.Text = "Vmax";
            // 
            // txtVmax
            // 
            this.txtVmax.Location = new System.Drawing.Point(202, 37);
            this.txtVmax.Name = "txtVmax";
            this.txtVmax.Size = new System.Drawing.Size(60, 20);
            this.txtVmax.TabIndex = 6;
            // 
            // lbl1Max
            // 
            this.lbl1Max.AutoSize = true;
            this.lbl1Max.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1Max.ForeColor = System.Drawing.Color.White;
            this.lbl1Max.Location = new System.Drawing.Point(156, 13);
            this.lbl1Max.Name = "lbl1Max";
            this.lbl1Max.Size = new System.Drawing.Size(40, 16);
            this.lbl1Max.TabIndex = 5;
            this.lbl1Max.Text = "Nmax";
            // 
            // txtNmax
            // 
            this.txtNmax.Location = new System.Drawing.Point(202, 11);
            this.txtNmax.Name = "txtNmax";
            this.txtNmax.Size = new System.Drawing.Size(60, 20);
            this.txtNmax.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Esfuerzos);
            this.tabControl.Controls.Add(this.Deformaciones);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 96);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(395, 384);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // Esfuerzos
            // 
            this.Esfuerzos.Controls.Add(this.dgvEsfuerzos);
            this.Esfuerzos.Location = new System.Drawing.Point(4, 25);
            this.Esfuerzos.Name = "Esfuerzos";
            this.Esfuerzos.Padding = new System.Windows.Forms.Padding(3);
            this.Esfuerzos.Size = new System.Drawing.Size(387, 355);
            this.Esfuerzos.TabIndex = 0;
            this.Esfuerzos.Text = "Esfuerzos";
            this.Esfuerzos.UseVisualStyleBackColor = true;
            // 
            // dgvEsfuerzos
            // 
            this.dgvEsfuerzos.ColumnHeadersHeight = 29;
            this.dgvEsfuerzos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DistNodoI,
            this.Axial,
            this.Cortante,
            this.Flector});
            this.dgvEsfuerzos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEsfuerzos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEsfuerzos.Location = new System.Drawing.Point(3, 3);
            this.dgvEsfuerzos.Name = "dgvEsfuerzos";
            this.dgvEsfuerzos.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEsfuerzos.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEsfuerzos.RowHeadersVisible = false;
            this.dgvEsfuerzos.RowHeadersWidth = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvEsfuerzos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEsfuerzos.Size = new System.Drawing.Size(381, 349);
            this.dgvEsfuerzos.TabIndex = 0;
            // 
            // Deformaciones
            // 
            this.Deformaciones.Controls.Add(this.dgvDeformaciones);
            this.Deformaciones.Location = new System.Drawing.Point(4, 25);
            this.Deformaciones.Name = "Deformaciones";
            this.Deformaciones.Padding = new System.Windows.Forms.Padding(3);
            this.Deformaciones.Size = new System.Drawing.Size(387, 355);
            this.Deformaciones.TabIndex = 1;
            this.Deformaciones.Text = "Deformaciones";
            this.Deformaciones.UseVisualStyleBackColor = true;
            // 
            // dgvDeformaciones
            // 
            this.dgvDeformaciones.AllowUserToAddRows = false;
            this.dgvDeformaciones.AllowUserToDeleteRows = false;
            this.dgvDeformaciones.AllowUserToResizeColumns = false;
            this.dgvDeformaciones.AllowUserToResizeRows = false;
            this.dgvDeformaciones.ColumnHeadersHeight = 29;
            this.dgvDeformaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvDeformaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeformaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDeformaciones.Location = new System.Drawing.Point(3, 3);
            this.dgvDeformaciones.Name = "dgvDeformaciones";
            this.dgvDeformaciones.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeformaciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeformaciones.RowHeadersVisible = false;
            this.dgvDeformaciones.RowHeadersWidth = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDeformaciones.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDeformaciones.Size = new System.Drawing.Size(381, 349);
            this.dgvDeformaciones.TabIndex = 1;
            // 
            // rBtnLocales
            // 
            this.rBtnLocales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnLocales.AutoSize = true;
            this.rBtnLocales.Checked = true;
            this.rBtnLocales.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnLocales.ForeColor = System.Drawing.Color.White;
            this.rBtnLocales.Location = new System.Drawing.Point(12, 493);
            this.rBtnLocales.Name = "rBtnLocales";
            this.rBtnLocales.Size = new System.Drawing.Size(66, 20);
            this.rBtnLocales.TabIndex = 4;
            this.rBtnLocales.TabStop = true;
            this.rBtnLocales.Text = "Locales";
            this.rBtnLocales.UseVisualStyleBackColor = true;
            this.rBtnLocales.CheckedChanged += new System.EventHandler(this.rBtn_CheckedChanged);
            // 
            // rBtnGlobales
            // 
            this.rBtnGlobales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rBtnGlobales.AutoSize = true;
            this.rBtnGlobales.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rBtnGlobales.ForeColor = System.Drawing.Color.White;
            this.rBtnGlobales.Location = new System.Drawing.Point(84, 493);
            this.rBtnGlobales.Name = "rBtnGlobales";
            this.rBtnGlobales.Size = new System.Drawing.Size(74, 20);
            this.rBtnGlobales.TabIndex = 5;
            this.rBtnGlobales.Text = "Globales";
            this.rBtnGlobales.UseVisualStyleBackColor = true;
            this.rBtnGlobales.CheckedChanged += new System.EventHandler(this.rBtn_CheckedChanged);
            // 
            // DistNodoI
            // 
            this.DistNodoI.Frozen = true;
            this.DistNodoI.HeaderText = "Distancia nodo i";
            this.DistNodoI.MinimumWidth = 6;
            this.DistNodoI.Name = "DistNodoI";
            this.DistNodoI.ReadOnly = true;
            this.DistNodoI.Width = 110;
            // 
            // Axial
            // 
            this.Axial.Frozen = true;
            this.Axial.HeaderText = "N";
            this.Axial.MinimumWidth = 6;
            this.Axial.Name = "Axial";
            this.Axial.ReadOnly = true;
            this.Axial.Width = 85;
            // 
            // Cortante
            // 
            this.Cortante.Frozen = true;
            this.Cortante.HeaderText = "V";
            this.Cortante.MinimumWidth = 6;
            this.Cortante.Name = "Cortante";
            this.Cortante.ReadOnly = true;
            this.Cortante.Width = 85;
            // 
            // Flector
            // 
            this.Flector.Frozen = true;
            this.Flector.HeaderText = "M";
            this.Flector.MinimumWidth = 6;
            this.Flector.Name = "Flector";
            this.Flector.ReadOnly = true;
            this.Flector.Width = 85;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Distancia nodo i";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 110;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "𝜹x";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 85;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "𝜹y";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 85;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "θz";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 85;
            // 
            // FormResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(411, 516);
            this.Controls.Add(this.rBtnGlobales);
            this.Controls.Add(this.rBtnLocales);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(427, 555);
            this.MinimumSize = new System.Drawing.Size(427, 555);
            this.Name = "FormResultados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.Esfuerzos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEsfuerzos)).EndInit();
            this.Deformaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeformaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbBarras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl3Max;
        private System.Windows.Forms.TextBox txtMmax;
        private System.Windows.Forms.Label lbl2Max;
        private System.Windows.Forms.TextBox txtVmax;
        private System.Windows.Forms.Label lbl1Max;
        private System.Windows.Forms.TextBox txtNmax;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl3Min;
        private System.Windows.Forms.TextBox txtMmin;
        private System.Windows.Forms.Label lbl2Min;
        private System.Windows.Forms.TextBox txtVmin;
        private System.Windows.Forms.Label lbl1Min;
        private System.Windows.Forms.TextBox txtNmin;
        private System.Windows.Forms.RadioButton rBtnLocales;
        private System.Windows.Forms.RadioButton rBtnGlobales;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Esfuerzos;
        private System.Windows.Forms.DataGridView dgvEsfuerzos;
        private System.Windows.Forms.TabPage Deformaciones;
        private System.Windows.Forms.DataGridView dgvDeformaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistNodoI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Axial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cortante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flector;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}