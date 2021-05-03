using System;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormPropiedadesBarra : Form
    {
        public Perfil PerfilEnUso { get; set; }
        public Material MaterialEnUso { get; set; }
        public bool EjeFuerte { get; set; }
        public FormPropiedadesBarra()
        {
            InitializeComponent();
            btnAplicar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;
            CBTipoCTEPers.SelectedIndex = 0;
            CBTipoCTENorm.SelectedIndex = 0;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TabSeccion.SelectedTab == SeccPersonal)
                {
                    string NombrePerf;
                    double A, Iz, Iy;
                    int TipoCte = CBTipoCTEPers.SelectedIndex;
                    if (txtNombrePerfil.TextLength > 0) { NombrePerf = txtNombrePerfil.Text; } else { NombrePerf = string.Empty; }
                    if (txtIy.TextLength > 0) { Iy = Convert.ToDouble(txtIy, CultureInfo.InvariantCulture); } else { Iy = 1; }
                    if (txtIz.TextLength > 0) { Iz = Convert.ToDouble(txtIz, CultureInfo.InvariantCulture); } else { Iz = 1; }
                    if (txtArea.TextLength > 0) { A = Convert.ToDouble(txtArea, CultureInfo.InvariantCulture); } else { A = 1; }
                    PerfilEnUso = new Perfil(NombrePerf, A, Iz, Iy, TipoCte);
                }
                else if (TabSeccion.SelectedTab == SeccNorm)
                {
                    int filaSecc = TablaPerfiles.CurrentCell.RowIndex;
                    string NombreSecc = TablaPerfiles.Rows[filaSecc].Cells[0].Value.ToString();
                    double A = Convert.ToDouble(TablaPerfiles.Rows[filaSecc].Cells[1].Value, CultureInfo.InvariantCulture);
                    double Iz = Convert.ToDouble(TablaPerfiles.Rows[filaSecc].Cells[2].Value, CultureInfo.InvariantCulture);
                    double Iy = Convert.ToDouble(TablaPerfiles.Rows[filaSecc].Cells[3].Value, CultureInfo.InvariantCulture);
                    int TipoCte = CBTipoCTENorm.SelectedIndex;
                    PerfilEnUso = new Perfil(NombreSecc, A, Iz, Iy, TipoCte);
                }

                if (TabMaterial.SelectedTab == MatPredet)
                {
                    int filaMat = TablaMaterial.CurrentCell.RowIndex;
                    string NombreMat = TablaMaterial.Rows[filaMat].Cells[0].Value.ToString();
                    double E = Convert.ToDouble(TablaMaterial.Rows[filaMat].Cells[1].Value, CultureInfo.InvariantCulture);
                    double Peso = Convert.ToDouble(TablaMaterial.Rows[filaMat].Cells[2].Value, CultureInfo.InvariantCulture);
                    double Alfa = Convert.ToDouble(TablaMaterial.Rows[filaMat].Cells[3].Value, CultureInfo.InvariantCulture);
                    MaterialEnUso = new Material(NombreMat, E, Peso, Alfa);
                }
                else if (TabMaterial.SelectedTab == MatPersonal)
                {
                    string NombreMat;
                    double E, Peso, Alfa;
                    if (txtNombreMat.TextLength > 0) { NombreMat = txtNombreMat.Text; } else { NombreMat = string.Empty; }
                    if (txtEYoung.TextLength > 0) { E = Convert.ToDouble(txtEYoung.Text, CultureInfo.InvariantCulture); } else { E = 1; }
                    if (txtPeso.TextLength > 0) { Peso = Convert.ToDouble(txtPeso.Text, CultureInfo.InvariantCulture); } else { Peso = 0; }
                    if (txtAlfa.TextLength > 0) { Alfa = Convert.ToDouble(txtAlfa.Text, CultureInfo.InvariantCulture); } else { Alfa = 1; }
                    MaterialEnUso = new Material(NombreMat, E, Peso, Alfa);
                }
                if (RBtnIy.Checked) { EjeFuerte = true; } else { EjeFuerte = false; }
            }
            catch
            {
            }
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CmbBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Perfil, Peso, Area, Iz, Iy
            if (CBTipoCTENorm.SelectedIndex == 0)
            {
                TablaPerfiles.Rows.Add(18);
                TablaPerfiles.Rows[0].Cells[0].Value = "IPE 80"; TablaPerfiles.Rows[0].Cells[1].Value = 764.38; TablaPerfiles.Rows[0].Cells[2].Value = 84900; TablaPerfiles.Rows[0].Cells[3].Value = 801400;
                TablaPerfiles.Rows[1].Cells[0].Value = "IPE 100"; TablaPerfiles.Rows[1].Cells[1].Value = 1032.40; TablaPerfiles.Rows[1].Cells[2].Value = 159200; TablaPerfiles.Rows[1].Cells[3].Value = 1710100;
                TablaPerfiles.Rows[2].Cells[0].Value = "IPE 120"; TablaPerfiles.Rows[2].Cells[1].Value = 1321.10; TablaPerfiles.Rows[2].Cells[2].Value = 276700; TablaPerfiles.Rows[2].Cells[3].Value = 3177500;
                TablaPerfiles.Rows[3].Cells[0].Value = "IPE 140"; TablaPerfiles.Rows[3].Cells[1].Value = 1642.68; TablaPerfiles.Rows[3].Cells[2].Value = 449200; TablaPerfiles.Rows[3].Cells[3].Value = 5412200;
                TablaPerfiles.Rows[4].Cells[0].Value = "IPE 160"; TablaPerfiles.Rows[4].Cells[1].Value = 2009.26; TablaPerfiles.Rows[4].Cells[2].Value = 683100; TablaPerfiles.Rows[4].Cells[3].Value = 8692900;
                TablaPerfiles.Rows[5].Cells[0].Value = "IPE 180"; TablaPerfiles.Rows[5].Cells[1].Value = 2394.86; TablaPerfiles.Rows[5].Cells[2].Value = 1008500; TablaPerfiles.Rows[5].Cells[3].Value = 13169600;
                TablaPerfiles.Rows[6].Cells[0].Value = "IPE 200"; TablaPerfiles.Rows[6].Cells[1].Value = 2848.64; TablaPerfiles.Rows[6].Cells[2].Value = 1423700; TablaPerfiles.Rows[6].Cells[3].Value = 19431700;
                TablaPerfiles.Rows[7].Cells[0].Value = "IPE 220"; TablaPerfiles.Rows[7].Cells[1].Value = 3337.28; TablaPerfiles.Rows[7].Cells[2].Value = 2048900; TablaPerfiles.Rows[7].Cells[3].Value = 27718400;
                TablaPerfiles.Rows[8].Cells[0].Value = "IPE 240"; TablaPerfiles.Rows[8].Cells[1].Value = 3911.98; TablaPerfiles.Rows[8].Cells[2].Value = 2836300; TablaPerfiles.Rows[8].Cells[3].Value = 38916200;
                TablaPerfiles.Rows[9].Cells[0].Value = "IPE 270"; TablaPerfiles.Rows[9].Cells[1].Value = 4594.86; TablaPerfiles.Rows[9].Cells[2].Value = 4198700; TablaPerfiles.Rows[9].Cells[3].Value = 57897800;
                TablaPerfiles.Rows[10].Cells[0].Value = "IPE 300"; TablaPerfiles.Rows[10].Cells[1].Value = 5381.56; TablaPerfiles.Rows[10].Cells[2].Value = 6037800; TablaPerfiles.Rows[10].Cells[3].Value = 83561000;
                TablaPerfiles.Rows[11].Cells[0].Value = "IPE 330"; TablaPerfiles.Rows[11].Cells[1].Value = 6261.14; TablaPerfiles.Rows[11].Cells[2].Value = 7881400; TablaPerfiles.Rows[11].Cells[3].Value = 117668900;
                TablaPerfiles.Rows[12].Cells[0].Value = "IPE 360"; TablaPerfiles.Rows[12].Cells[1].Value = 7273.44; TablaPerfiles.Rows[12].Cells[2].Value = 10434500; TablaPerfiles.Rows[12].Cells[3].Value = 162656200;
                TablaPerfiles.Rows[13].Cells[0].Value = "IPE 400"; TablaPerfiles.Rows[13].Cells[1].Value = 8447.06; TablaPerfiles.Rows[13].Cells[2].Value = 13178200; TablaPerfiles.Rows[13].Cells[3].Value = 231283500;
                TablaPerfiles.Rows[14].Cells[0].Value = "IPE 450"; TablaPerfiles.Rows[14].Cells[1].Value = 9882.78; TablaPerfiles.Rows[14].Cells[2].Value = 16758600; TablaPerfiles.Rows[14].Cells[3].Value = 337429100;
                TablaPerfiles.Rows[15].Cells[0].Value = "IPE 500"; TablaPerfiles.Rows[15].Cells[1].Value = 11552.86; TablaPerfiles.Rows[15].Cells[2].Value = 21416800; TablaPerfiles.Rows[15].Cells[3].Value = 481985000;
                TablaPerfiles.Rows[16].Cells[0].Value = "IPE 550"; TablaPerfiles.Rows[16].Cells[1].Value = 13442.52; TablaPerfiles.Rows[16].Cells[2].Value = 26675800; TablaPerfiles.Rows[16].Cells[3].Value = 671164600;
                TablaPerfiles.Rows[17].Cells[0].Value = "IPE 600"; TablaPerfiles.Rows[17].Cells[1].Value = 15599.36; TablaPerfiles.Rows[17].Cells[2].Value = 33873400; TablaPerfiles.Rows[17].Cells[3].Value = 920834000;

            }
            else if (CBTipoCTENorm.SelectedText == "HEB")
            {

            }
            else if (CBTipoCTENorm.SelectedText == "UPN")
            {

            }
            else if (CBTipoCTENorm.SelectedText == "UPE")
            {

            }
            else if (CBTipoCTENorm.SelectedText == "HUECA CIRCULAR")
            {

            }
            else if (CBTipoCTENorm.SelectedText == "HUECA CUADRADA")
            {

            }
            else if (CBTipoCTENorm.SelectedText == "HUECA RECTANGULAR")
            {

            }
        }

        private void TablaPerfiles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
