using System;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormSplashScreen : Form
    {
        public FormSplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarSplash.Increment(20);
            if (progressBarSplash.Value == 5000)
            {
                timer1.Stop();
                Close();
            }
        }
    }
}
