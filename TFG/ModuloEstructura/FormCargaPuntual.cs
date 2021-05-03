using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormCargaPuntual : Form
    {
        public double Modulo { get; set; }
        public double Angulo { get; set; }
        public bool Momento { get; set; }
        public FormCargaPuntual(Nodo nodo, bool Momento)
        {
            InitializeComponent();
            if (Momento) { txtAngulo.ReadOnly = true; txtAngulo.BackColor = Color.LightGray; }
            if (nodo != null)
            {
                txtNodo.Text = nodo.NumeroNodo.ToString(CultureInfo.InvariantCulture);
            }

            btnAplicar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Modulo = Convert.ToDouble(txtModulo.Text, CultureInfo.InvariantCulture);
                Angulo = Convert.ToDouble(txtAngulo.Text, CultureInfo.InvariantCulture);
            }
            catch
            {

            }
            Close();
        }
    }
}
