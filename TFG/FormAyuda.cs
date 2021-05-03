using System;
using System.Windows.Forms;



namespace TFG
{
    public partial class FormAyuda : Form
    {
        public FormAyuda()
        {
            InitializeComponent();
            //labelInfo.Hide();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            //msg.To.Add("teiest2020@gmail.com");
            //msg.Subject = txtAsunto.Text;
            //msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //msg.Body = txtMensaje.Text;
            //msg.IsBodyHtml = false;
            //msg.BodyEncoding = System.Text.Encoding.UTF8;

            //msg.From = new System.Net.Mail.MailAddress("teiest2020@gmail.com");

            //System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient
            //{
            //    Credentials = new System.Net.NetworkCredential("teiest2020@gmail.com", "Teiest123."),

            //    Port = 587,
            //    EnableSsl = true,
            //    Host = "smtp.gmail.com"
            //};

            //try
            //{
            //    if (string.IsNullOrEmpty(txtMensaje.Text))
            //    {
            //        cliente.Send(msg);
            //        MessageBox.Show("Enviado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        cliente.Dispose();
            //        this.Close();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Error al enviar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtMailOrigen_Click(object sender, EventArgs e)
        {
            //    txtMailOrigen.Clear();
            //    txtMailOrigen.ForeColor = Color.Black;
        }

        private void txtAsunto_Click(object sender, EventArgs e)
        {
            //    txtAsunto.Clear();
            //    txtAsunto.ForeColor = Color.Black;
        }

        private void txtMensaje_Click(object sender, EventArgs e)
        {
            //    txtMensaje.Clear();
            //    txtMensaje.ForeColor = Color.Black;
        }

        private void txtMailOrigen_Leave(object sender, EventArgs e)
        {
            //    if (txtMailOrigen.Text == "")
            //    {
            //        txtMailOrigen.ForeColor = Color.Gray;
            //        txtMailOrigen.Text = "Tu direccion de correo electrónico";
            //    }
        }

        private void txtAsunto_Leave(object sender, EventArgs e)
        {
            //    if (txtAsunto.Text == "")
            //    {
            //        txtAsunto.ForeColor = Color.Gray;
            //        txtAsunto.Text = "Asunto del mensaje";
            //    }
        }

        private void txtMensaje_Leave(object sender, EventArgs e)
        {
            //    if (txtMensaje.Text == "")
            //    {
            //        txtMensaje.ForeColor = Color.Gray;
            //        txtMensaje.Text = "Escribe lo mas detalladamente posible la situación";
            //    }
        }

        private void btnInfo_MouseEnter(object sender, EventArgs e)
        {
            //    labelInfo.Show();
        }

        private void btnInfo_MouseLeave(object sender, EventArgs e)
        {
            //    labelInfo.Hide();
        }
    }
}
