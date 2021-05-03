using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormCargaTermica : Form
    {
        public double Tmedia { get; set; }
        public double Tgrad { get; set; }
        public FormCargaTermica()
        {
            InitializeComponent();
            btnAplicar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            chcBoxGradiente.Checked = false;
            txtGradiente.ReadOnly = true;
            txtGradiente.BackColor = Color.LightGray;
        }

        private void chcBoxGradiente_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chcBoxGradiente.Checked)
            {
                txtGradiente.ReadOnly = false;
                txtGradiente.BackColor = Color.White;
            }
            else
            {
                txtGradiente.ReadOnly = true;
                txtGradiente.BackColor = Color.LightGray;
            }
        }

        private void btnAplicar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Tmedia = Convert.ToDouble(txtTmedia.Text, CultureInfo.InvariantCulture);
                if (chcBoxGradiente.Checked) { Tgrad = Convert.ToDouble(txtGradiente.Text, CultureInfo.InvariantCulture); } else { Tgrad = 0; }
            }
            catch
            {
                throw;
            }
            Close();
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
