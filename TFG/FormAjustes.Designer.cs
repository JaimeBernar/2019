namespace TFG
{
    partial class FormAjustes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAjustes));
            this.Unidades = new System.Windows.Forms.TabPage();
            this.btnCancelarUnidades = new System.Windows.Forms.Button();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbBoxTension = new System.Windows.Forms.ComboBox();
            this.CmbBoxFuerza = new System.Windows.Forms.ComboBox();
            this.CmbBoxLongitud = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAplicarUnidades = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.General = new System.Windows.Forms.TabPage();
            this.btnCancelarGeneral = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ChcBoxM = new System.Windows.Forms.CheckBox();
            this.txtEscM = new System.Windows.Forms.TextBox();
            this.ChcBoxV = new System.Windows.Forms.CheckBox();
            this.ChcBoxN = new System.Windows.Forms.CheckBox();
            this.txtEscV = new System.Windows.Forms.TextBox();
            this.ChcBoxDef = new System.Windows.Forms.CheckBox();
            this.txtEscN = new System.Windows.Forms.TextBox();
            this.txtEscDef = new System.Windows.Forms.TextBox();
            this.txtMalla = new System.Windows.Forms.TextBox();
            this.txtDimEjes = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAplicarGeneral = new System.Windows.Forms.Button();
            this.Unidades.SuspendLayout();
            this.panelLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.General.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Unidades
            // 
            this.Unidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Unidades.Controls.Add(this.btnCancelarUnidades);
            this.Unidades.Controls.Add(this.panelLabels);
            this.Unidades.Controls.Add(this.btnAplicarUnidades);
            this.Unidades.Location = new System.Drawing.Point(4, 22);
            this.Unidades.Name = "Unidades";
            this.Unidades.Padding = new System.Windows.Forms.Padding(3);
            this.Unidades.Size = new System.Drawing.Size(435, 237);
            this.Unidades.TabIndex = 1;
            this.Unidades.Text = "Unidades";
            // 
            // btnCancelarUnidades
            // 
            this.btnCancelarUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarUnidades.Location = new System.Drawing.Point(258, 204);
            this.btnCancelarUnidades.Name = "btnCancelarUnidades";
            this.btnCancelarUnidades.Size = new System.Drawing.Size(65, 27);
            this.btnCancelarUnidades.TabIndex = 63;
            this.btnCancelarUnidades.Text = "Cancelar";
            this.btnCancelarUnidades.UseVisualStyleBackColor = true;
            this.btnCancelarUnidades.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panelLabels
            // 
            this.panelLabels.Controls.Add(this.splitContainer1);
            this.panelLabels.Controls.Add(this.label7);
            this.panelLabels.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLabels.Location = new System.Drawing.Point(3, 3);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(429, 112);
            this.panelLabels.TabIndex = 60;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 21);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CmbBoxTension);
            this.splitContainer1.Panel2.Controls.Add(this.CmbBoxFuerza);
            this.splitContainer1.Panel2.Controls.Add(this.CmbBoxLongitud);
            this.splitContainer1.Size = new System.Drawing.Size(429, 74);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(348, 21);
            this.label5.TabIndex = 61;
            this.label5.Text = "Unidades de tensión";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(348, 21);
            this.label10.TabIndex = 60;
            this.label10.Text = "Unidades de fuerza";
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(348, 21);
            this.label9.TabIndex = 59;
            this.label9.Text = "Unidades de longitud";
            // 
            // CmbBoxTension
            // 
            this.CmbBoxTension.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbBoxTension.FormattingEnabled = true;
            this.CmbBoxTension.Items.AddRange(new object[] {
            "GPa",
            "MPa",
            "Pa"});
            this.CmbBoxTension.Location = new System.Drawing.Point(0, 42);
            this.CmbBoxTension.Name = "CmbBoxTension";
            this.CmbBoxTension.Size = new System.Drawing.Size(77, 21);
            this.CmbBoxTension.TabIndex = 56;
            // 
            // CmbBoxFuerza
            // 
            this.CmbBoxFuerza.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbBoxFuerza.FormattingEnabled = true;
            this.CmbBoxFuerza.Items.AddRange(new object[] {
            "KN",
            "N",
            "Kg"});
            this.CmbBoxFuerza.Location = new System.Drawing.Point(0, 21);
            this.CmbBoxFuerza.Name = "CmbBoxFuerza";
            this.CmbBoxFuerza.Size = new System.Drawing.Size(77, 21);
            this.CmbBoxFuerza.TabIndex = 53;
            // 
            // CmbBoxLongitud
            // 
            this.CmbBoxLongitud.Dock = System.Windows.Forms.DockStyle.Top;
            this.CmbBoxLongitud.FormattingEnabled = true;
            this.CmbBoxLongitud.Items.AddRange(new object[] {
            "m",
            "cm",
            "mm"});
            this.CmbBoxLongitud.Location = new System.Drawing.Point(0, 0);
            this.CmbBoxLongitud.Name = "CmbBoxLongitud";
            this.CmbBoxLongitud.Size = new System.Drawing.Size(77, 21);
            this.CmbBoxLongitud.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(429, 21);
            this.label7.TabIndex = 56;
            this.label7.Text = "Módulo de sección y estructural";
            // 
            // btnAplicarUnidades
            // 
            this.btnAplicarUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicarUnidades.Location = new System.Drawing.Point(143, 204);
            this.btnAplicarUnidades.Name = "btnAplicarUnidades";
            this.btnAplicarUnidades.Size = new System.Drawing.Size(65, 27);
            this.btnAplicarUnidades.TabIndex = 56;
            this.btnAplicarUnidades.Text = "Aplicar";
            this.btnAplicarUnidades.UseVisualStyleBackColor = true;
            this.btnAplicarUnidades.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.General);
            this.tabControl1.Controls.Add(this.Unidades);
            this.tabControl1.Location = new System.Drawing.Point(9, 11);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(443, 263);
            this.tabControl1.TabIndex = 0;
            // 
            // General
            // 
            this.General.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.General.Controls.Add(this.btnCancelarGeneral);
            this.General.Controls.Add(this.panel3);
            this.General.Controls.Add(this.btnAplicarGeneral);
            this.General.Location = new System.Drawing.Point(4, 22);
            this.General.Name = "General";
            this.General.Padding = new System.Windows.Forms.Padding(3);
            this.General.Size = new System.Drawing.Size(435, 237);
            this.General.TabIndex = 2;
            this.General.Text = "General";
            // 
            // btnCancelarGeneral
            // 
            this.btnCancelarGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarGeneral.Location = new System.Drawing.Point(258, 204);
            this.btnCancelarGeneral.Name = "btnCancelarGeneral";
            this.btnCancelarGeneral.Size = new System.Drawing.Size(65, 27);
            this.btnCancelarGeneral.TabIndex = 62;
            this.btnCancelarGeneral.Text = "Cancelar";
            this.btnCancelarGeneral.UseVisualStyleBackColor = true;
            this.btnCancelarGeneral.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer4);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(429, 173);
            this.panel3.TabIndex = 60;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer4.Location = new System.Drawing.Point(0, 21);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            this.splitContainer4.Panel1.Controls.Add(this.label1);
            this.splitContainer4.Panel1.Controls.Add(this.label15);
            this.splitContainer4.Panel1.Controls.Add(this.label16);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.ChcBoxM);
            this.splitContainer4.Panel2.Controls.Add(this.txtEscM);
            this.splitContainer4.Panel2.Controls.Add(this.ChcBoxV);
            this.splitContainer4.Panel2.Controls.Add(this.ChcBoxN);
            this.splitContainer4.Panel2.Controls.Add(this.txtEscV);
            this.splitContainer4.Panel2.Controls.Add(this.ChcBoxDef);
            this.splitContainer4.Panel2.Controls.Add(this.txtEscN);
            this.splitContainer4.Panel2.Controls.Add(this.txtEscDef);
            this.splitContainer4.Panel2.Controls.Add(this.txtMalla);
            this.splitContainer4.Panel2.Controls.Add(this.txtDimEjes);
            this.splitContainer4.Size = new System.Drawing.Size(429, 152);
            this.splitContainer4.SplitterDistance = 294;
            this.splitContainer4.TabIndex = 57;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 21);
            this.label4.TabIndex = 64;
            this.label4.Text = "Escala de los esfuerzos flectores";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 21);
            this.label3.TabIndex = 63;
            this.label3.Text = "Escala de los esfuerzos cortantes";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 21);
            this.label2.TabIndex = 62;
            this.label2.Text = "Escala de los esfuerzos axiles";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 21);
            this.label1.TabIndex = 61;
            this.label1.Text = "Escala de la deformada";
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(0, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(294, 21);
            this.label15.TabIndex = 60;
            this.label15.Text = "Tamaño de la malla";
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(294, 21);
            this.label16.TabIndex = 59;
            this.label16.Text = "Dimensión de los ejes";
            // 
            // ChcBoxM
            // 
            this.ChcBoxM.AutoSize = true;
            this.ChcBoxM.Checked = true;
            this.ChcBoxM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChcBoxM.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChcBoxM.ForeColor = System.Drawing.Color.White;
            this.ChcBoxM.Location = new System.Drawing.Point(76, 106);
            this.ChcBoxM.Name = "ChcBoxM";
            this.ChcBoxM.Size = new System.Drawing.Size(52, 20);
            this.ChcBoxM.TabIndex = 66;
            this.ChcBoxM.Text = "Auto";
            this.ChcBoxM.UseVisualStyleBackColor = true;
            this.ChcBoxM.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // txtEscM
            // 
            this.txtEscM.Location = new System.Drawing.Point(0, 105);
            this.txtEscM.Multiline = true;
            this.txtEscM.Name = "txtEscM";
            this.txtEscM.Size = new System.Drawing.Size(75, 21);
            this.txtEscM.TabIndex = 5;
            // 
            // ChcBoxV
            // 
            this.ChcBoxV.AutoSize = true;
            this.ChcBoxV.Checked = true;
            this.ChcBoxV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChcBoxV.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChcBoxV.ForeColor = System.Drawing.Color.White;
            this.ChcBoxV.Location = new System.Drawing.Point(76, 85);
            this.ChcBoxV.Name = "ChcBoxV";
            this.ChcBoxV.Size = new System.Drawing.Size(52, 20);
            this.ChcBoxV.TabIndex = 65;
            this.ChcBoxV.Text = "Auto";
            this.ChcBoxV.UseVisualStyleBackColor = true;
            this.ChcBoxV.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ChcBoxN
            // 
            this.ChcBoxN.AutoSize = true;
            this.ChcBoxN.Checked = true;
            this.ChcBoxN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChcBoxN.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChcBoxN.ForeColor = System.Drawing.Color.White;
            this.ChcBoxN.Location = new System.Drawing.Point(76, 64);
            this.ChcBoxN.Name = "ChcBoxN";
            this.ChcBoxN.Size = new System.Drawing.Size(52, 20);
            this.ChcBoxN.TabIndex = 64;
            this.ChcBoxN.Text = "Auto";
            this.ChcBoxN.UseVisualStyleBackColor = true;
            this.ChcBoxN.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // txtEscV
            // 
            this.txtEscV.Location = new System.Drawing.Point(0, 84);
            this.txtEscV.Multiline = true;
            this.txtEscV.Name = "txtEscV";
            this.txtEscV.Size = new System.Drawing.Size(75, 21);
            this.txtEscV.TabIndex = 4;
            // 
            // ChcBoxDef
            // 
            this.ChcBoxDef.AutoSize = true;
            this.ChcBoxDef.Checked = true;
            this.ChcBoxDef.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChcBoxDef.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChcBoxDef.ForeColor = System.Drawing.Color.White;
            this.ChcBoxDef.Location = new System.Drawing.Point(76, 42);
            this.ChcBoxDef.Name = "ChcBoxDef";
            this.ChcBoxDef.Size = new System.Drawing.Size(52, 20);
            this.ChcBoxDef.TabIndex = 63;
            this.ChcBoxDef.Text = "Auto";
            this.ChcBoxDef.UseVisualStyleBackColor = true;
            this.ChcBoxDef.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // txtEscN
            // 
            this.txtEscN.Location = new System.Drawing.Point(0, 63);
            this.txtEscN.Multiline = true;
            this.txtEscN.Name = "txtEscN";
            this.txtEscN.Size = new System.Drawing.Size(75, 21);
            this.txtEscN.TabIndex = 3;
            // 
            // txtEscDef
            // 
            this.txtEscDef.Location = new System.Drawing.Point(0, 42);
            this.txtEscDef.Multiline = true;
            this.txtEscDef.Name = "txtEscDef";
            this.txtEscDef.Size = new System.Drawing.Size(75, 21);
            this.txtEscDef.TabIndex = 2;
            // 
            // txtMalla
            // 
            this.txtMalla.Location = new System.Drawing.Point(0, 21);
            this.txtMalla.Multiline = true;
            this.txtMalla.Name = "txtMalla";
            this.txtMalla.Size = new System.Drawing.Size(75, 21);
            this.txtMalla.TabIndex = 1;
            this.txtMalla.TextChanged += new System.EventHandler(this.TxtMalla_TextChanged);
            // 
            // txtDimEjes
            // 
            this.txtDimEjes.Location = new System.Drawing.Point(0, 0);
            this.txtDimEjes.Multiline = true;
            this.txtDimEjes.Name = "txtDimEjes";
            this.txtDimEjes.Size = new System.Drawing.Size(75, 21);
            this.txtDimEjes.TabIndex = 0;
            this.txtDimEjes.TextChanged += new System.EventHandler(this.TxtDimEjes_TextChanged);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(429, 21);
            this.label17.TabIndex = 56;
            this.label17.Text = "Espacio Dibujo";
            // 
            // btnAplicarGeneral
            // 
            this.btnAplicarGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicarGeneral.Location = new System.Drawing.Point(143, 204);
            this.btnAplicarGeneral.Name = "btnAplicarGeneral";
            this.btnAplicarGeneral.Size = new System.Drawing.Size(65, 27);
            this.btnAplicarGeneral.TabIndex = 56;
            this.btnAplicarGeneral.Text = "Aplicar";
            this.btnAplicarGeneral.UseVisualStyleBackColor = true;
            this.btnAplicarGeneral.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // Ajustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(464, 286);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(480, 325);
            this.MinimumSize = new System.Drawing.Size(480, 325);
            this.Name = "Ajustes";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustes";
            this.Unidades.ResumeLayout(false);
            this.panelLabels.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.General.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Unidades;
        private System.Windows.Forms.Button btnAplicarUnidades;
        private System.Windows.Forms.Panel panelLabels;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbBoxFuerza;
        private System.Windows.Forms.ComboBox CmbBoxLongitud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage General;
        private System.Windows.Forms.Button btnAplicarGeneral;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMalla;
        private System.Windows.Forms.TextBox txtDimEjes;
        private System.Windows.Forms.Button btnCancelarUnidades;
        private System.Windows.Forms.Button btnCancelarGeneral;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbBoxTension;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEscM;
        private System.Windows.Forms.TextBox txtEscV;
        private System.Windows.Forms.TextBox txtEscN;
        private System.Windows.Forms.TextBox txtEscDef;
        private System.Windows.Forms.CheckBox ChcBoxM;
        private System.Windows.Forms.CheckBox ChcBoxV;
        private System.Windows.Forms.CheckBox ChcBoxN;
        private System.Windows.Forms.CheckBox ChcBoxDef;
    }
}