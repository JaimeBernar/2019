using System;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormNuevoDoc : Form
    {

        internal FormNuevoDoc()
        {
            InitializeComponent();
            btnAceptar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        public void BtnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
