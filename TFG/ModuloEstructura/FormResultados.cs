using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormResultados : Form
    {
        internal bool Locales = true;
        double Mmax = 0, Vmax = 0, Nmax = 0, Mmin = 0, Vmin = 0, Nmin = 0;
        double Dxmax = 0, Dymax = 0, Dzmax = 0, Dxmin = 0, Dymin = 0, Dzmin = 0;
        private readonly List<Barra> ListaBarras = new List<Barra>();
        public FormResultados(List<Barra> Lista)
        {
            InitializeComponent();
            dgvEsfuerzos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ListaBarras = Lista;
            RellenarCBBarras();
            rBtnLocales.Hide(); rBtnGlobales.Hide();
        }
        internal void RellenarCBBarras()
        {
            foreach (Barra bar in ListaBarras)
            {
                if (bar != null)
                {
                    cbBarras.Items.Add(bar.NumeroBarra.ToString(CultureInfo.InvariantCulture) + " " + "Nodos: " + bar.NodoInicial.NumeroNodo.ToString(CultureInfo.InvariantCulture) + "," + bar.NodoFinal.NumeroNodo.ToString(CultureInfo.InvariantCulture));
                }
            }
            if (cbBarras.Items.Count > 0) { cbBarras.SelectedIndex = 0; }
        }
        internal void MostrarResultados()
        {
            int num = cbBarras.SelectedIndex;
            int deci = 12;
            dgvEsfuerzos.RowCount = 1;
            dgvDeformaciones.RowCount = 1;
            Nmax = Vmax = Mmax = Nmin = Vmin = Mmin = 0; //Reseteamos los maximos y minimos
            foreach (Nodo nod in ListaBarras[num].ListaFaseFinal)
            {
                //Esfuerzos maximos
                if (nod.Nx > Nmax) { Nmax = Math.Round(nod.Nx, 4); }
                if (nod.Vy > Vmax) { Vmax = Math.Round(nod.Vy, 4); }
                if (nod.Mz > Mmax) { Mmax = Math.Round(nod.Mz, 4); }
                //Esfuerzos minimos
                if (nod.Nx < Nmin) { Nmin = Math.Round(nod.Nx, 4); }
                if (nod.Vy < Vmin) { Vmin = Math.Round(nod.Vy, 4); }
                if (nod.Mz < Mmin) { Mmin = Math.Round(nod.Mz, 4); }
                //Deformaciones maximas
                if (nod.Dx > Dxmax) { Dxmax = Math.Round(nod.Dx, 4); }
                if (nod.Dy > Dymax) { Dymax = Math.Round(nod.Dy, 4); }
                if (nod.Dz > Dzmax) { Dzmax = Math.Round(nod.Dz, 4); }
                //Deformaciones minimas
                if (nod.Dx < Dxmin) { Dxmin = Math.Round(nod.Dx, 4); }
                if (nod.Dy < Dymin) { Dymin = Math.Round(nod.Dy, 4); }
                if (nod.Dz < Dzmin) { Dzmin = Math.Round(nod.Dz, 4); }
            }


            if (tabControl.SelectedTab == Esfuerzos)
            {
                txtNmax.Text = Nmax.ToString(CultureInfo.InvariantCulture); txtNmin.Text = Nmin.ToString(CultureInfo.InvariantCulture);
                txtVmax.Text = Vmax.ToString(CultureInfo.InvariantCulture); txtVmin.Text = Vmin.ToString(CultureInfo.InvariantCulture);
                txtMmax.Text = Mmax.ToString(CultureInfo.InvariantCulture); txtMmin.Text = Mmin.ToString(CultureInfo.InvariantCulture);
            }
            else if (tabControl.SelectedTab == Deformaciones)
            {
                txtNmax.Text = Dxmax.ToString(CultureInfo.InvariantCulture); txtNmin.Text = Dxmin.ToString(CultureInfo.InvariantCulture);
                txtVmax.Text = Dymax.ToString(CultureInfo.InvariantCulture); txtVmin.Text = Dymin.ToString(CultureInfo.InvariantCulture);
                txtMmax.Text = Dzmax.ToString(CultureInfo.InvariantCulture); txtMmin.Text = Dzmin.ToString(CultureInfo.InvariantCulture);
            }


            for (int i = 0; i < ListaBarras[num].ListaFaseFinal.Count; i++)
            {
                dgvEsfuerzos.Rows.Add();
                dgvDeformaciones.Rows.Add();
                dgvEsfuerzos.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDeformaciones.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvEsfuerzos.Rows[i].Cells[0].Value = Math.Round((ListaBarras[num].Longitud * i) / (ListaBarras[num].NumeroPuntos - 1), 3);
                dgvEsfuerzos.Rows[i].Cells[1].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].Nx, 4);
                dgvEsfuerzos.Rows[i].Cells[2].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].Vy, 4);
                dgvEsfuerzos.Rows[i].Cells[3].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].Mz, 4);

                if (Locales)
                {
                    //Se muestran las deformaciones de la barra en ejes locales 
                    dgvDeformaciones.Rows[i].Cells[0].Value = Math.Round((ListaBarras[num].Longitud * i) / (ListaBarras[num].NumeroPuntos - 1), 3);
                    dgvDeformaciones.Rows[i].Cells[1].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].Dx, deci);
                    dgvDeformaciones.Rows[i].Cells[2].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].Dy, deci);
                    dgvDeformaciones.Rows[i].Cells[3].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].Dz, deci);
                }
                else
                {
                    //Se muestran las deformaciones de la barra en ejes globales 
                    dgvDeformaciones.Rows[i].Cells[0].Value = Math.Round((ListaBarras[num].Longitud * i) / (ListaBarras[num].NumeroPuntos - 1), 3);
                    dgvDeformaciones.Rows[i].Cells[1].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].DX, deci);
                    dgvDeformaciones.Rows[i].Cells[2].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].DY, deci);
                    dgvDeformaciones.Rows[i].Cells[3].Value = Math.Round(ListaBarras[num].ListaFaseFinal[i].DZ, deci);
                }

            }
        }

        private void CbBarras_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarResultados();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == Esfuerzos)
            {
                lbl1Max.Text = "Nmax"; lbl1Min.Text = "Nmin";
                lbl2Max.Text = "Vmax"; lbl2Min.Text = "Vmin";
                lbl3Max.Text = "Mmax"; lbl3Min.Text = "Mmin";
                rBtnLocales.Hide(); rBtnGlobales.Hide();
            }
            else if (tabControl.SelectedTab == Deformaciones)
            {
                lbl1Max.Text = "δxMax"; lbl1Min.Text = "δxMin";
                lbl2Max.Text = "δyMax"; lbl2Min.Text = "δyMin";
                lbl3Max.Text = "δzMax"; lbl3Min.Text = "δzMin";
                rBtnLocales.Show(); rBtnGlobales.Show();
            }
            if (tabControl.SelectedTab == Esfuerzos)
            {
                txtNmax.Text = Nmax.ToString(CultureInfo.InvariantCulture); txtNmin.Text = Nmin.ToString(CultureInfo.InvariantCulture);
                txtVmax.Text = Vmax.ToString(CultureInfo.InvariantCulture); txtVmin.Text = Vmin.ToString(CultureInfo.InvariantCulture);
                txtMmax.Text = Mmax.ToString(CultureInfo.InvariantCulture); txtMmin.Text = Mmin.ToString(CultureInfo.InvariantCulture);
            }
            else if (tabControl.SelectedTab == Deformaciones)
            {
                txtNmax.Text = Dxmax.ToString(CultureInfo.InvariantCulture); txtNmin.Text = Dxmin.ToString(CultureInfo.InvariantCulture);
                txtVmax.Text = Dymax.ToString(CultureInfo.InvariantCulture); txtVmin.Text = Dymin.ToString(CultureInfo.InvariantCulture);
                txtMmax.Text = Dzmax.ToString(CultureInfo.InvariantCulture); txtMmin.Text = Dzmin.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void rBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnLocales.Checked) { Locales = true; }
            if (rBtnGlobales.Checked) { Locales = false; }
            MostrarResultados();
        }

    }
}
