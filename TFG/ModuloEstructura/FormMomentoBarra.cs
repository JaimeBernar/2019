using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormMomentoBarra : Form
    {
        internal double Lbarra, dnodoj, dnodoi;
        public double Modulo { get; set; }
        public string Eje { get; set; }
        public bool Centrada { get; set; }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Modulo = Convert.ToDouble(txtModulo.Text, CultureInfo.InvariantCulture);
                if (checkBoxCentrada.Checked) { Centrada = true; } else { Centrada = false; }
                Dnodoi = Convert.ToDouble(txtDnodoi.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw;
            }
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxCentrada_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCentrada.Checked)
            {
                txtDnodoi.ReadOnly = true;
                txtDnodoj.ReadOnly = true;
                txtDnodoi.BackColor = Color.LightGray;
                txtDnodoj.BackColor = Color.LightGray;
                txtDnodoi.Text = (Lbarra / 2).ToString(CultureInfo.InvariantCulture);
                txtDnodoj.Text = (Lbarra / 2).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtDnodoi.ReadOnly = false;
                txtDnodoj.ReadOnly = false;
                txtDnodoi.BackColor = Color.White;
                txtDnodoj.BackColor = Color.White;
            }
        }

        private void txtDnodoi_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dnodoi = Convert.ToDouble(txtDnodoi.Text, CultureInfo.InvariantCulture);
                dnodoj = Lbarra - dnodoi;
                if (dnodoj > Lbarra) { dnodoj = Lbarra; dnodoi = 0; }
                txtDnodoj.Text = dnodoj.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {
                throw;
            }
        }

        private void txtDnodoj_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dnodoj = Convert.ToDouble(txtDnodoj.Text, CultureInfo.InvariantCulture);
                dnodoi = Lbarra - dnodoj;
                if (dnodoi > Lbarra) { dnodoi = Lbarra; dnodoj = 0; }
                txtDnodoi.Text = dnodoi.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {
                throw;
            }
        }

        public double Dnodoi { get; set; }
        public FormMomentoBarra(Barra Barra)
        {
            InitializeComponent();
            btnAplicar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            if (Barra != null)
            {
                Lbarra = Barra.Longitud;
            }

            txtDnodoi.ReadOnly = true;
            txtDnodoj.ReadOnly = true;
            txtDnodoi.BackColor = Color.LightGray;
            txtDnodoj.BackColor = Color.LightGray;
            txtDnodoi.Text = (Lbarra / 2.0).ToString(CultureInfo.InvariantCulture);
            txtDnodoj.Text = (Lbarra / 2.0).ToString(CultureInfo.InvariantCulture);
        }
    }
}
