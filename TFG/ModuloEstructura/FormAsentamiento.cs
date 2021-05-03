using System;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormAsentamiento : Form
    {
        public double ValorAsentamiento { get; set; } = 0;
        public double ValorGiro { get; set; } = 0;
        public bool DireccionXpos { get; set; }
        public bool DireccionXneg { get; set; }
        public bool DireccionYpos { get; set; }
        public bool DireccionYneg { get; set; }

        public FormAsentamiento()
        {
            InitializeComponent();
            btnAplicar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                ValorAsentamiento = Convert.ToDouble(txtAsentamiento.Text, CultureInfo.InvariantCulture);
                ValorGiro = Convert.ToDouble(txtGiro.Text, CultureInfo.InvariantCulture);
                DireccionXpos = rbtnXpos.Checked;
                DireccionXneg = rbtnXneg.Checked;
                DireccionYpos = rbtnYpos.Checked;
                DireccionYneg = rbtnYneg.Checked;
            }
            catch
            {
                //MessageBox.Show(TeiestStrings.Error, TeiestStrings.Espacio, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
