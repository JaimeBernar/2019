namespace TFG
{
    partial class FormPropiedadesBarra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPropiedadesBarra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TabMenu = new System.Windows.Forms.TabControl();
            this.Seccion = new System.Windows.Forms.TabPage();
            this.TabSeccion = new System.Windows.Forms.TabControl();
            this.SeccNorm = new System.Windows.Forms.TabPage();
            this.TablaPerfiles = new System.Windows.Forms.DataGridView();
            this.ColumPerfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumInerciaZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumInerciaY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.RBtnIz = new System.Windows.Forms.RadioButton();
            this.RBtnIy = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.CBTipoCTENorm = new System.Windows.Forms.ComboBox();
            this.SeccPersonal = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CBTipoCTEPers = new System.Windows.Forms.ComboBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIy = new System.Windows.Forms.TextBox();
            this.txtNombrePerfil = new System.Windows.Forms.TextBox();
            this.Material = new System.Windows.Forms.TabPage();
            this.TabMaterial = new System.Windows.Forms.TabControl();
            this.MatPredet = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.TablaMaterial = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatPersonal = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.ChcBPeso = new System.Windows.Forms.CheckBox();
            this.txtNombreMat = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAlfa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEYoung = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.TabMenu.SuspendLayout();
            this.Seccion.SuspendLayout();
            this.TabSeccion.SuspendLayout();
            this.SeccNorm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaPerfiles)).BeginInit();
            this.SeccPersonal.SuspendLayout();
            this.Material.SuspendLayout();
            this.TabMaterial.SuspendLayout();
            this.MatPredet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaMaterial)).BeginInit();
            this.MatPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.TabMenu);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 386);
            this.panel1.TabIndex = 0;
            // 
            // TabMenu
            // 
            this.TabMenu.Controls.Add(this.Seccion);
            this.TabMenu.Controls.Add(this.Material);
            this.TabMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabMenu.Location = new System.Drawing.Point(0, 0);
            this.TabMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.SelectedIndex = 0;
            this.TabMenu.Size = new System.Drawing.Size(383, 345);
            this.TabMenu.TabIndex = 83;
            // 
            // Seccion
            // 
            this.Seccion.Controls.Add(this.TabSeccion);
            this.Seccion.Location = new System.Drawing.Point(4, 25);
            this.Seccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Seccion.Name = "Seccion";
            this.Seccion.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Seccion.Size = new System.Drawing.Size(375, 316);
            this.Seccion.TabIndex = 0;
            this.Seccion.Text = "Sección";
            this.Seccion.UseVisualStyleBackColor = true;
            // 
            // TabSeccion
            // 
            this.TabSeccion.Controls.Add(this.SeccNorm);
            this.TabSeccion.Controls.Add(this.SeccPersonal);
            this.TabSeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabSeccion.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabSeccion.Location = new System.Drawing.Point(3, 4);
            this.TabSeccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabSeccion.Name = "TabSeccion";
            this.TabSeccion.SelectedIndex = 0;
            this.TabSeccion.Size = new System.Drawing.Size(369, 308);
            this.TabSeccion.TabIndex = 82;
            // 
            // SeccNorm
            // 
            this.SeccNorm.BackColor = System.Drawing.Color.White;
            this.SeccNorm.Controls.Add(this.TablaPerfiles);
            this.SeccNorm.Controls.Add(this.label11);
            this.SeccNorm.Controls.Add(this.RBtnIz);
            this.SeccNorm.Controls.Add(this.RBtnIy);
            this.SeccNorm.Controls.Add(this.label8);
            this.SeccNorm.Controls.Add(this.CBTipoCTENorm);
            this.SeccNorm.Location = new System.Drawing.Point(4, 25);
            this.SeccNorm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SeccNorm.Name = "SeccNorm";
            this.SeccNorm.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SeccNorm.Size = new System.Drawing.Size(361, 279);
            this.SeccNorm.TabIndex = 1;
            this.SeccNorm.Text = "Normalizados";
            // 
            // TablaPerfiles
            // 
            this.TablaPerfiles.AllowUserToAddRows = false;
            this.TablaPerfiles.AllowUserToDeleteRows = false;
            this.TablaPerfiles.AllowUserToResizeColumns = false;
            this.TablaPerfiles.AllowUserToResizeRows = false;
            this.TablaPerfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablaPerfiles.ColumnHeadersHeight = 29;
            this.TablaPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TablaPerfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumPerfil,
            this.ColumArea,
            this.ColumInerciaZ,
            this.ColumInerciaY});
            this.TablaPerfiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.TablaPerfiles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TablaPerfiles.Location = new System.Drawing.Point(0, 72);
            this.TablaPerfiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaPerfiles.MultiSelect = false;
            this.TablaPerfiles.Name = "TablaPerfiles";
            this.TablaPerfiles.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaPerfiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.TablaPerfiles.RowHeadersVisible = false;
            this.TablaPerfiles.RowHeadersWidth = 40;
            this.TablaPerfiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TablaPerfiles.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TablaPerfiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TablaPerfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaPerfiles.Size = new System.Drawing.Size(361, 171);
            this.TablaPerfiles.TabIndex = 89;
            this.TablaPerfiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TablaPerfiles_CellContentClick);
            // 
            // ColumPerfil
            // 
            this.ColumPerfil.FillWeight = 85F;
            this.ColumPerfil.Frozen = true;
            this.ColumPerfil.HeaderText = "Perfil";
            this.ColumPerfil.Name = "ColumPerfil";
            this.ColumPerfil.ReadOnly = true;
            this.ColumPerfil.Width = 85;
            // 
            // ColumArea
            // 
            this.ColumArea.Frozen = true;
            this.ColumArea.HeaderText = "Área";
            this.ColumArea.MinimumWidth = 6;
            this.ColumArea.Name = "ColumArea";
            this.ColumArea.ReadOnly = true;
            this.ColumArea.Width = 85;
            // 
            // ColumInerciaZ
            // 
            this.ColumInerciaZ.Frozen = true;
            this.ColumInerciaZ.HeaderText = "Iz";
            this.ColumInerciaZ.MinimumWidth = 6;
            this.ColumInerciaZ.Name = "ColumInerciaZ";
            this.ColumInerciaZ.ReadOnly = true;
            this.ColumInerciaZ.Width = 85;
            // 
            // ColumInerciaY
            // 
            this.ColumInerciaY.Frozen = true;
            this.ColumInerciaY.HeaderText = "Iy";
            this.ColumInerciaY.MinimumWidth = 6;
            this.ColumInerciaY.Name = "ColumInerciaY";
            this.ColumInerciaY.ReadOnly = true;
            this.ColumInerciaY.Width = 85;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(10, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 16);
            this.label11.TabIndex = 88;
            this.label11.Text = "Unidades: N-mm";
            // 
            // RBtnIz
            // 
            this.RBtnIz.AutoSize = true;
            this.RBtnIz.Location = new System.Drawing.Point(187, 251);
            this.RBtnIz.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RBtnIz.Name = "RBtnIz";
            this.RBtnIz.Size = new System.Drawing.Size(147, 20);
            this.RBtnIz.TabIndex = 86;
            this.RBtnIz.Text = "Inercia eje Z (Eje débil)";
            this.RBtnIz.UseVisualStyleBackColor = true;
            // 
            // RBtnIy
            // 
            this.RBtnIy.AutoSize = true;
            this.RBtnIy.Checked = true;
            this.RBtnIy.Location = new System.Drawing.Point(15, 251);
            this.RBtnIy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RBtnIy.Name = "RBtnIy";
            this.RBtnIy.Size = new System.Drawing.Size(152, 20);
            this.RBtnIy.TabIndex = 85;
            this.RBtnIy.TabStop = true;
            this.RBtnIy.Text = "Inercia eje Y (Eje fuerte)";
            this.RBtnIy.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 16);
            this.label8.TabIndex = 82;
            this.label8.Text = "Tipo de perfil: ";
            // 
            // CBTipoCTENorm
            // 
            this.CBTipoCTENorm.FormattingEnabled = true;
            this.CBTipoCTENorm.Items.AddRange(new object[] {
            "IPE",
            "HEB",
            "UPN",
            "UPE",
            "HUECA CIRCULAR",
            "HUECA CUADRADA",
            "HUECA RECTANGULAR "});
            this.CBTipoCTENorm.Location = new System.Drawing.Point(147, 36);
            this.CBTipoCTENorm.Margin = new System.Windows.Forms.Padding(2);
            this.CBTipoCTENorm.Name = "CBTipoCTENorm";
            this.CBTipoCTENorm.Size = new System.Drawing.Size(150, 24);
            this.CBTipoCTENorm.TabIndex = 81;
            this.CBTipoCTENorm.SelectedIndexChanged += new System.EventHandler(this.CmbBoxTipo_SelectedIndexChanged);
            // 
            // SeccPersonal
            // 
            this.SeccPersonal.Controls.Add(this.label9);
            this.SeccPersonal.Controls.Add(this.label1);
            this.SeccPersonal.Controls.Add(this.label5);
            this.SeccPersonal.Controls.Add(this.label7);
            this.SeccPersonal.Controls.Add(this.CBTipoCTEPers);
            this.SeccPersonal.Controls.Add(this.txtArea);
            this.SeccPersonal.Controls.Add(this.label2);
            this.SeccPersonal.Controls.Add(this.txtIz);
            this.SeccPersonal.Controls.Add(this.label4);
            this.SeccPersonal.Controls.Add(this.txtIy);
            this.SeccPersonal.Controls.Add(this.txtNombrePerfil);
            this.SeccPersonal.Location = new System.Drawing.Point(4, 25);
            this.SeccPersonal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SeccPersonal.Name = "SeccPersonal";
            this.SeccPersonal.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SeccPersonal.Size = new System.Drawing.Size(361, 279);
            this.SeccPersonal.TabIndex = 0;
            this.SeccPersonal.Text = "Personalizar";
            this.SeccPersonal.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(10, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 16);
            this.label9.TabIndex = 83;
            this.label9.Text = "Area";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "Inercia a flexion en Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(10, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 77;
            this.label5.Text = "Unidades: N-mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(10, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 16);
            this.label7.TabIndex = 81;
            this.label7.Text = "Tipo de sección según CTE";
            // 
            // CBTipoCTEPers
            // 
            this.CBTipoCTEPers.FormattingEnabled = true;
            this.CBTipoCTEPers.Items.AddRange(new object[] {
            "Laminado en I",
            "Armado en I",
            "Perfiles laminados soldados",
            "Tubo de chapa simples o agrupados",
            "Perfil armado en cajón",
            "Perfil simple U,T, Chapa, Redondo macizo",
            "Perfil en L"});
            this.CBTipoCTEPers.Location = new System.Drawing.Point(200, 157);
            this.CBTipoCTEPers.Margin = new System.Windows.Forms.Padding(2);
            this.CBTipoCTEPers.Name = "CBTipoCTEPers";
            this.CBTipoCTEPers.Size = new System.Drawing.Size(140, 24);
            this.CBTipoCTEPers.TabIndex = 80;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(200, 67);
            this.txtArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(140, 21);
            this.txtArea.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 69;
            this.label2.Text = "Inercia a flexion en Y";
            // 
            // txtIz
            // 
            this.txtIz.Location = new System.Drawing.Point(200, 127);
            this.txtIz.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIz.Name = "txtIz";
            this.txtIz.Size = new System.Drawing.Size(140, 21);
            this.txtIz.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 73;
            this.label4.Text = "Nombre del perfil";
            // 
            // txtIy
            // 
            this.txtIy.Location = new System.Drawing.Point(200, 97);
            this.txtIy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIy.Name = "txtIy";
            this.txtIy.Size = new System.Drawing.Size(140, 21);
            this.txtIy.TabIndex = 76;
            // 
            // txtNombrePerfil
            // 
            this.txtNombrePerfil.Location = new System.Drawing.Point(200, 37);
            this.txtNombrePerfil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombrePerfil.Name = "txtNombrePerfil";
            this.txtNombrePerfil.Size = new System.Drawing.Size(140, 21);
            this.txtNombrePerfil.TabIndex = 74;
            // 
            // Material
            // 
            this.Material.Controls.Add(this.TabMaterial);
            this.Material.Location = new System.Drawing.Point(4, 25);
            this.Material.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Material.Name = "Material";
            this.Material.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Material.Size = new System.Drawing.Size(375, 316);
            this.Material.TabIndex = 1;
            this.Material.Text = "Material";
            this.Material.UseVisualStyleBackColor = true;
            // 
            // TabMaterial
            // 
            this.TabMaterial.Controls.Add(this.MatPredet);
            this.TabMaterial.Controls.Add(this.MatPersonal);
            this.TabMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMaterial.Location = new System.Drawing.Point(3, 4);
            this.TabMaterial.Name = "TabMaterial";
            this.TabMaterial.SelectedIndex = 0;
            this.TabMaterial.Size = new System.Drawing.Size(369, 308);
            this.TabMaterial.TabIndex = 88;
            // 
            // MatPredet
            // 
            this.MatPredet.Controls.Add(this.label3);
            this.MatPredet.Controls.Add(this.TablaMaterial);
            this.MatPredet.Location = new System.Drawing.Point(4, 25);
            this.MatPredet.Name = "MatPredet";
            this.MatPredet.Padding = new System.Windows.Forms.Padding(3);
            this.MatPredet.Size = new System.Drawing.Size(361, 279);
            this.MatPredet.TabIndex = 1;
            this.MatPredet.Text = "Predeterminados";
            this.MatPredet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 91;
            this.label3.Text = "Unidades: N-mm";
            // 
            // TablaMaterial
            // 
            this.TablaMaterial.AllowUserToAddRows = false;
            this.TablaMaterial.AllowUserToDeleteRows = false;
            this.TablaMaterial.AllowUserToResizeColumns = false;
            this.TablaMaterial.AllowUserToResizeRows = false;
            this.TablaMaterial.ColumnHeadersHeight = 29;
            this.TablaMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TablaMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3});
            this.TablaMaterial.Cursor = System.Windows.Forms.Cursors.Default;
            this.TablaMaterial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TablaMaterial.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TablaMaterial.Location = new System.Drawing.Point(3, 30);
            this.TablaMaterial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TablaMaterial.MultiSelect = false;
            this.TablaMaterial.Name = "TablaMaterial";
            this.TablaMaterial.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TablaMaterial.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.TablaMaterial.RowHeadersVisible = false;
            this.TablaMaterial.RowHeadersWidth = 40;
            this.TablaMaterial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TablaMaterial.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.TablaMaterial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TablaMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaMaterial.Size = new System.Drawing.Size(355, 246);
            this.TablaMaterial.TabIndex = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 85F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Material";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Módulo Young";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 95;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Peso ";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Coef. dilatación";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // MatPersonal
            // 
            this.MatPersonal.Controls.Add(this.label6);
            this.MatPersonal.Controls.Add(this.ChcBPeso);
            this.MatPersonal.Controls.Add(this.txtNombreMat);
            this.MatPersonal.Controls.Add(this.txtPeso);
            this.MatPersonal.Controls.Add(this.label10);
            this.MatPersonal.Controls.Add(this.txtAlfa);
            this.MatPersonal.Controls.Add(this.label12);
            this.MatPersonal.Controls.Add(this.txtEYoung);
            this.MatPersonal.Controls.Add(this.label13);
            this.MatPersonal.Controls.Add(this.label14);
            this.MatPersonal.Location = new System.Drawing.Point(4, 25);
            this.MatPersonal.Name = "MatPersonal";
            this.MatPersonal.Padding = new System.Windows.Forms.Padding(3);
            this.MatPersonal.Size = new System.Drawing.Size(361, 279);
            this.MatPersonal.TabIndex = 0;
            this.MatPersonal.Text = "Personalizar";
            this.MatPersonal.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(10, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 16);
            this.label6.TabIndex = 78;
            this.label6.Text = "Unidades: N-mm";
            // 
            // ChcBPeso
            // 
            this.ChcBPeso.AutoSize = true;
            this.ChcBPeso.Location = new System.Drawing.Point(13, 161);
            this.ChcBPeso.Name = "ChcBPeso";
            this.ChcBPeso.Size = new System.Drawing.Size(87, 20);
            this.ChcBPeso.TabIndex = 87;
            this.ChcBPeso.Text = "Incluir peso";
            this.ChcBPeso.UseVisualStyleBackColor = true;
            // 
            // txtNombreMat
            // 
            this.txtNombreMat.Location = new System.Drawing.Point(200, 37);
            this.txtNombreMat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreMat.Name = "txtNombreMat";
            this.txtNombreMat.Size = new System.Drawing.Size(140, 21);
            this.txtNombreMat.TabIndex = 79;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(200, 127);
            this.txtPeso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(140, 21);
            this.txtPeso.TabIndex = 86;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(10, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 80;
            this.label10.Text = "Módulo de Young";
            // 
            // txtAlfa
            // 
            this.txtAlfa.Location = new System.Drawing.Point(200, 97);
            this.txtAlfa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAlfa.Name = "txtAlfa";
            this.txtAlfa.Size = new System.Drawing.Size(140, 21);
            this.txtAlfa.TabIndex = 85;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 16);
            this.label12.TabIndex = 81;
            this.label12.Text = "Nombre";
            // 
            // txtEYoung
            // 
            this.txtEYoung.Location = new System.Drawing.Point(200, 67);
            this.txtEYoung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEYoung.Name = "txtEYoung";
            this.txtEYoung.Size = new System.Drawing.Size(140, 21);
            this.txtEYoung.TabIndex = 84;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(10, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 16);
            this.label13.TabIndex = 82;
            this.label13.Text = "Peso (Kg/m)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(10, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 16);
            this.label14.TabIndex = 83;
            this.label14.Text = "Coef. dilatación lineal";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(241, 353);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.TabIndex = 72;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Location = new System.Drawing.Point(59, 353);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 25);
            this.btnAplicar.TabIndex = 71;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // FormPropiedadesBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(404, 411);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(420, 450);
            this.MinimumSize = new System.Drawing.Size(420, 450);
            this.Name = "FormPropiedadesBarra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Perfil";
            this.panel1.ResumeLayout(false);
            this.TabMenu.ResumeLayout(false);
            this.Seccion.ResumeLayout(false);
            this.TabSeccion.ResumeLayout(false);
            this.SeccNorm.ResumeLayout(false);
            this.SeccNorm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaPerfiles)).EndInit();
            this.SeccPersonal.ResumeLayout(false);
            this.SeccPersonal.PerformLayout();
            this.Material.ResumeLayout(false);
            this.TabMaterial.ResumeLayout(false);
            this.MatPredet.ResumeLayout(false);
            this.MatPredet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaMaterial)).EndInit();
            this.MatPersonal.ResumeLayout(false);
            this.MatPersonal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CBTipoCTEPers;
        private System.Windows.Forms.TextBox txtIz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIy;
        private System.Windows.Forms.TextBox txtNombrePerfil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TabControl TabSeccion;
        private System.Windows.Forms.TabPage SeccPersonal;
        private System.Windows.Forms.TabPage SeccNorm;
        private System.Windows.Forms.RadioButton RBtnIz;
        private System.Windows.Forms.RadioButton RBtnIy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CBTipoCTENorm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView TablaPerfiles;
        private System.Windows.Forms.TabControl TabMenu;
        private System.Windows.Forms.TabPage Seccion;
        private System.Windows.Forms.TabPage Material;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNombreMat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumInerciaZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumInerciaY;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtAlfa;
        private System.Windows.Forms.TextBox txtEYoung;
        private System.Windows.Forms.CheckBox ChcBPeso;
        private System.Windows.Forms.TabControl TabMaterial;
        private System.Windows.Forms.TabPage MatPersonal;
        private System.Windows.Forms.TabPage MatPredet;
        private System.Windows.Forms.DataGridView TablaMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}