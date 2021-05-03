using System;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormPretension : Form
    {
        public double Ni { get; set; }
        public double Vi { get; set; }
        public double Mi { get; set; }
        public double Nj { get; set; }
        public double Vj { get; set; }
        public double Mj { get; set; }
        public FormPretension()
        {
            InitializeComponent();
            btnAplicar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void txtNi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double aux = -Convert.ToDouble(txtNi.Text, CultureInfo.InvariantCulture);
                txtNj.Text = aux.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {

            }
        }

        private void txtVi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double aux = -Convert.ToDouble(txtVi.Text, CultureInfo.InvariantCulture);
                txtVj.Text = aux.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {

            }
        }

        private void txtMi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double aux = -Convert.ToDouble(txtMi.Text, CultureInfo.InvariantCulture);
                txtMj.Text = aux.ToString(CultureInfo.InvariantCulture);
            }
            catch
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Ni = Convert.ToDouble(txtNi.Text, CultureInfo.InvariantCulture);
                Vi = Convert.ToDouble(txtVi.Text, CultureInfo.InvariantCulture);
                Mi = Convert.ToDouble(txtMi.Text, CultureInfo.InvariantCulture);
                Nj = Convert.ToDouble(txtNj.Text, CultureInfo.InvariantCulture);
                Vj = Convert.ToDouble(txtVj.Text, CultureInfo.InvariantCulture);
                Mj = Convert.ToDouble(txtMj.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
