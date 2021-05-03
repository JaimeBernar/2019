using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormCargaDistribuida : Form
    {
        public string Eje { get; set; }
        public double Qi { get; set; }
        public double Qj { get; set; }
        public FormCargaDistribuida()
        {
            InitializeComponent();
            txtQj.ReadOnly = true;
            txtQj.BackColor = Color.LightGray;
            btnAplicar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chcBoxConst.Checked)
                {
                    Qi = Qj = Convert.ToDouble(txtQi.Text, CultureInfo.InvariantCulture);
                }
                else
                {
                    Qi = Convert.ToDouble(txtQi.Text, CultureInfo.InvariantCulture);
                    Qj = Convert.ToDouble(txtQj.Text, CultureInfo.InvariantCulture);
                }
                if (rbtnXglobal.Checked) { Eje = "XG"; } else if (rbtnYglobal.Checked) { Eje = "YG"; } else if (rbtnXlocal.Checked) { Eje = "XL"; } else if (rbtnYlocal.Checked) { Eje = "YL"; }
            }
            catch (Exception)
            {
                //MessageBox.Show(TeiestStrings.Error, TeiestStrings.Espacio, MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chcBoxConst_CheckedChanged(object sender, EventArgs e)
        {
            if (chcBoxConst.Checked)
            {
                txtQj.ReadOnly = true;
                txtQj.BackColor = Color.LightGray;
            }
            else
            {
                txtQj.ReadOnly = false;
                txtQj.BackColor = Color.White;
            }
        }
    }
}
