using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormAjustes : Form
    {
        private readonly int dimEjesDefault = 32, undsMallaDefault = 1;

        public FormAjustes(string UdLongitud, string UdFuerza, string UdTension, double DimEjes, double Malla, double Def, double Axial, double Cort, double Flect, bool AutoDef, bool AutoN, bool AutoV, bool AutoM)
        {
            InitializeComponent();

            btnAplicarGeneral.DialogResult = DialogResult.OK;
            btnCancelarGeneral.DialogResult = DialogResult.Cancel;

            CmbBoxLongitud.Text = UdLongitud;
            CmbBoxFuerza.Text = UdFuerza;
            CmbBoxTension.Text = UdTension;
            EscDef = Def;
            EscAxial = Axial;
            EscCortante = Cort;
            EscFlector = Flect;

            if (AutoDef) { txtEscDef.ReadOnly = true; txtEscDef.ForeColor = Color.LightGray; ChcBoxDef.Checked = true; } else { txtEscDef.ReadOnly = false; txtEscDef.ForeColor = Color.Black; ChcBoxDef.Checked = false; }
            if (AutoN) { txtEscN.ReadOnly = true; txtEscN.ForeColor = Color.LightGray; ChcBoxN.Checked = true; } else { txtEscDef.ReadOnly = false; txtEscDef.ForeColor = Color.Black; ChcBoxDef.Checked = false; }
            if (AutoV) { txtEscV.ReadOnly = true; txtEscV.ForeColor = Color.LightGray; ChcBoxV.Checked = true; } else { txtEscDef.ReadOnly = false; txtEscDef.ForeColor = Color.Black; ChcBoxDef.Checked = false; }
            if (AutoM) { txtEscM.ReadOnly = true; txtEscM.ForeColor = Color.LightGray; ChcBoxM.Checked = true; } else { txtEscDef.ReadOnly = false; txtEscDef.ForeColor = Color.Black; ChcBoxDef.Checked = false; }

            txtDimEjes.Text = DimEjes.ToString(CultureInfo.InvariantCulture);
            txtMalla.Text = Malla.ToString(CultureInfo.InvariantCulture);
            txtEscDef.Text = Def.ToString(CultureInfo.InvariantCulture);
            txtEscN.Text = Axial.ToString(CultureInfo.InvariantCulture);
            txtEscV.Text = Cort.ToString(CultureInfo.InvariantCulture);
            txtEscM.Text = Flect.ToString(CultureInfo.InvariantCulture);
        }


        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Malla = Convert.ToDouble(txtMalla.Text, CultureInfo.InvariantCulture);
                DimEjes = Convert.ToDouble(txtDimEjes.Text, CultureInfo.InvariantCulture);
                EscDef = Convert.ToDouble(txtEscDef.Text, CultureInfo.InvariantCulture);
                EscAxial = Convert.ToDouble(txtEscN.Text, CultureInfo.InvariantCulture);
                EscCortante = Convert.ToDouble(txtEscV.Text, CultureInfo.InvariantCulture);
                EscFlector = Convert.ToDouble(txtEscM.Text, CultureInfo.InvariantCulture);

            }
            catch (Exception ex)
            {
            }
            Close();
        }

        private void TxtDimEjes_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDimEjes.Text))
            {
                try
                {
                    if (Convert.ToDouble(txtDimEjes.Text, CultureInfo.InvariantCulture) < 0)
                    {
                        txtDimEjes.Text = dimEjesDefault.ToString(CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception)
                {
                }
            }

        }

        private void TxtMalla_TextChanged(object sender, EventArgs e)
        {
            if (txtMalla.TextLength > 0)
            {
                try
                {
                    if (Convert.ToDouble(txtMalla.Text, CultureInfo.InvariantCulture) < 0)
                    {
                        txtMalla.Text = undsMallaDefault.ToString(CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception)
                {
                }
            }
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public double DimEjes { get; set; }
        public double Malla { get; set; }
        public double EscDef { get; set; }
        public double EscAxial { get; set; }
        public double EscCortante { get; set; }
        public double EscFlector { get; set; }
        public string UndsLongi { get; set; } = "mm";
        public string UndsFuerz { get; set; } = "N";

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (sender == ChcBoxDef)
            {
                if (ChcBoxDef.Checked)
                {
                    AutoDef = true;
                    txtEscDef.ReadOnly = true;
                    txtEscDef.ForeColor = Color.LightGray;
                }
                else
                {
                    AutoDef = false;
                    txtEscDef.ReadOnly = false;
                    txtEscDef.ForeColor = Color.Black;
                    txtEscDef.Text = Convert.ToString(EscDef, CultureInfo.InvariantCulture);

                }
            }
            if (sender == ChcBoxN)
            {
                if (ChcBoxN.Checked)
                {
                    AutoN = true;
                    txtEscN.ReadOnly = true;
                    txtEscN.ForeColor = Color.LightGray;
                }
                else
                {
                    AutoN = false;
                    txtEscN.ReadOnly = false;
                    txtEscN.ForeColor = Color.Black;
                    txtEscN.Text = Convert.ToString(EscDef, CultureInfo.InvariantCulture);

                }
            }
            if (sender == ChcBoxV)
            {
                if (ChcBoxV.Checked)
                {
                    AutoV = true;
                    txtEscV.ReadOnly = true;
                    txtEscV.ForeColor = Color.LightGray;
                }
                else
                {
                    AutoV = false;
                    txtEscV.ReadOnly = false;
                    txtEscV.ForeColor = Color.Black;
                    txtEscV.Text = Convert.ToString(EscDef, CultureInfo.InvariantCulture);

                }
            }
            if (sender == ChcBoxM)
            {
                if (ChcBoxM.Checked)
                {
                    AutoM = true;
                    txtEscM.ReadOnly = true;
                    txtEscM.ForeColor = Color.LightGray;
                }
                else
                {
                    AutoM = false;
                    txtEscM.ReadOnly = false;
                    txtEscM.ForeColor = Color.Black;
                    txtEscM.Text = Convert.ToString(EscDef, CultureInfo.InvariantCulture);

                }
            }
        }

        public string UndsTension { get; set; } = "MPa";
        public bool AutoDef { get; set; }
        public bool AutoN { get; set; }
        public bool AutoV { get; set; }
        public bool AutoM { get; set; }

    }
}
