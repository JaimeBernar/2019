using MathNet.Numerics.LinearAlgebra;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TFG
{
    public partial class FormPpal : Form
    {
        //Declaramos los atributos
        private double zoom = 1f, ObjectPosX0, ObjectPosY0, Pixel, R2, RR = 1, GG = 0.5, BB = 0.25;
        private double Xi, Yi, xf, yf, xinicio, yinicio, cx1, cy1, cx3, cy3, zx, zy;
        private int ContClicks = 0, IdNodo, IdCarga, IdCargaSeleccionada, IdPuntoCT, IdPuntoCTSeleccionado, IdBarra, IdApoyo, IdNodoSeleccionado, IdBarraSeleccionada, IdApoyoSeleccionado, IdFiguras, IdFiguraCopiada, hitsGlcontrol1 = 0, hitsGlcontrol3 = 0, IdArrastrar, IdMoviendoNodo, IdMoviendoBarra, IdMoviendoPunto, IdPuntos, IdFiguraSeleccionada, IdNegativa, IdPuntoSeleccionado, Decimales = 3;
        private double xmin1 = 100, xmax1 = 100, ymin1 = 100, ymax1 = 100, xmin3 = 100, xmax3 = 100, ymin3 = 100, ymax3 = 100, yr, xr, ex, ey, multLong = 1, multFuerz = 1, multPres = 1;
        private List<Figura> ListaFiguras = new List<Figura>();
        private List<Figura> ListaUndo = new List<Figura>();
        private List<Figura> ListaRedo = new List<Figura>();
        private MouseEventArgs mouse1, mouseanterior1, mousegirar1, mouseanteriorgirar1, mouse3, mouseanterior3, mousegirar3, mouseanteriorgirar3, mouseanteriorzoom, mousezoom;
        private List<Punto> ListaPuntos = new List<Punto>();
        private List<Punto> ListaPuntosCT = new List<Punto>(); //Lista de puntos para cambiar el tamaño
        private Figura FiguraAux;
        private Punto PuntoAux, CdgT;
        private Nodo NodoAux, NodoInicial, NodoFinal;
        private bool Dibujando, esfuerzosXYZ = true, agarrar = false, drag;
        private bool NodoSeleccionado, CargaSeleccionada, BarraSeleccionada, ApoyoSeleccionado, MoviendoNodo, MoviendoBarra, FiguraDebajo, PuntoDebajo, MouseIzdaDown, MouseDchaDown, MoviendoPunto, FiguraSeleccionada, PuntoSeleccionado, CambiandoTamaño, BtnClic, RuedaPress1, RuedaPress3;
        private Arco CirculoMohr;
        private Linea LineaNeutra;
        private double AngRotX1, AngRotY1, AngRotX3, AngRotY3;
        private bool isCopied, toPaste, RectanguloSeleccion, CreandoBarra;
        private Figura figCopy;
        private double AreaTotal, Ix, Iy, Ixy, Ixg, Iyg, Ixgyg, Ixp, Iyp, Ip, Ipg, Ixpers, Iypers, Ixypers, cdgx, cdgy, Phi, Sigma, SigmaN, SigmaMx, SigmaMy, SigmaMax = 0, SigmaMin = 0, Pcr, ix, iy, ixG, iyG, Wx, Wy, Wxg, Wyg, txy, txz, Qx, Qy;
        private List<Barra> ListaBarras = new List<Barra>();
        private List<Nodo> ListaNodos = new List<Nodo>();
        private List<Apoyo> ListaApoyos = new List<Apoyo>();
        private Barra BarraAux;
        private double Mmax, Vmax, Nmax, Dmax, Lmax, Vy, Vx;
        private List<Carga> ListaFuerzas = new List<Carga>();
        private List<Nodo> VectorDesplaz = new List<Nodo>();
        private List<Nodo> VectorFuerzas = new List<Nodo>();
        private double[,] Kglobal;
        private double[,] Kred;
        private double[,] Ktriang;
        private Flecha EjeX, EjeY, EjeZ;
        private int FontTextureID;
        private int TextureWidth;
        private int TextureHeight;
        private double Const1, Const3;
        private double Dplanos = 0.02;
        private Vector3d FinalBarra;
        private float[] BuffGlobalesX = new float[3];
        private float[] BuffGlobalesY = new float[3];
        private float[] BuffGlobalesZ = new float[3];
        private float[] BuffLocalesX = new float[3];
        private float[] BuffLocalesY = new float[3];
        private Perfil PerfilEnUso;
        private Material MaterialEnUso;
        private bool FlechaPropAbajo = true;
        private bool FlechaEsfAbajo = true;
        private bool FlechaEjesCDGAbajo = true;
        private bool FlechaContornoAbajo = true;
        private bool FlechaNodoAbajo = true;
        private bool FlechaBarraAbajo = true;

        private void BarraSupArchivo_MouseEnter(object sender, EventArgs e)
        {
            BarraSupArchivo.BackColor = Color.FromArgb(170, 170, 170);
        }

        private void Propiedades_Click(object sender, EventArgs e)
        {
            if (FlechaPropAbajo)
            {
                FlechaPropAbajo = false;

            }
            else
            {
                FlechaPropAbajo = true;
            }
        }

        private void Esfuerzos_Click(object sender, EventArgs e)
        {
            if (FlechaEsfAbajo)
            {
                FlechaEsfAbajo = false;
                CuadroEsfuerzos.Height = 22;
                panelEsfuerzosDcho.Hide();
                panelEsfuerzosIzdo.Hide();
            }
            else
            {
                FlechaEsfAbajo = true;
                CuadroEsfuerzos.Height = 169;
                panelEsfuerzosDcho.Show();
                panelEsfuerzosIzdo.Show();
            }
        }

        private void EjesCDG_Click(object sender, EventArgs e)
        {
            if (FlechaEjesCDGAbajo)
            {
                FlechaEjesCDGAbajo = false;
                CuadroEjesCDG.Height = 22;
                panelEjesDcho.Hide();
                panelEjesIzdo.Hide();
            }
            else
            {
                FlechaEjesCDGAbajo = true;
                CuadroEjesCDG.Height = 43;
                panelEjesDcho.Show();
                panelEjesIzdo.Show();
            }
        }

        private void Contorno_Click(object sender, EventArgs e)
        {
            if (FlechaContornoAbajo)
            {
                FlechaContornoAbajo = false;
                CuadroContorno.Height = 22;
                cmbboxContorno.Hide();
                panelContornoDcho.Hide();
                panelContornoIzdo.Hide();
            }
            else
            {
                FlechaContornoAbajo = true;
                CuadroContorno.Height = 64;
                cmbboxContorno.Show();
                panelContornoDcho.Show();
                panelContornoIzdo.Show();
            }
        }

        private void Nodo_Click(object sender, EventArgs e)
        {
            if (FlechaNodoAbajo)
            {
                CuadroNodo.Height = 22;
                panelNodoDch.Hide();
                panelNodoIzd.Hide();
                FlechaNodoAbajo = false;
            }
            else
            {
                CuadroNodo.Height = 85;
                panelNodoDch.Show();
                panelNodoIzd.Show();
                FlechaNodoAbajo = true;
            }
        }

        private void Barra_Click(object sender, EventArgs e)
        {
            if (FlechaBarraAbajo)
            {
                FlechaBarraAbajo = false;
                CuadroBarra.Height = 22;
                panelBarraDcho.Hide();
                panelBarraIzdo.Hide();
            }
            else
            {
                FlechaBarraAbajo = true;
                CuadroBarra.Height = 232;
                panelBarraDcho.Show();
                panelBarraIzdo.Show();
            }
        }

        private void Seccion_Click(object sender, EventArgs e)
        {

        }

        private void txtAlto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAncho_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDx_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDy_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAngulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnguloEjes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLongitudReal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLongitudPandeo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumNodo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNodoCx_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNodoCy_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLongitudBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAreaBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInerciaBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtYoungBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNx_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVyi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVyf_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMzi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMzf_TextChanged(object sender, EventArgs e)
        {

        }

        private void BarraSupArchivo_MouseLeave(object sender, EventArgs e)
        {
            BarraSupArchivo.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            glControl1.Dispose();
            glControl2.Dispose();
            glControl3.Dispose();
        }


        internal float[] BuffLocalesZ = new float[3];
        internal string undsLong = "mm", undsFuerza = "N", undsTension = "MPa", undsYoung = "MPa", undsAreaBarra = "mm2", undsIBarra = "mm4";
        internal bool EnergiaElasticaPositiva;
        internal double EsfuerzoAxial, EsfuerzoMx, EsfuerzoMy;
        internal double XWx, YWy, XgWx, YgWy;
        internal GLControl glControl1, glControl2, glControl3;
        internal double dimEjes = 32, Malla = 1, SigmaYP, ModuloYoung = 210000, EscDeformada = 1, EscAxiales = 1, EscCortante = 1, EscFlector = 1;
        internal int conti = 0;
        internal bool AutoSclDef = true, AutoSclN = true, AutoSclV = true, AutoSclM = true;
        internal double AutoDef, AutoN, AutoV, AutoM, ManDef, ManN, ManV, ManM;
        private void CmbboxContorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            LongitudPandeo();
        }

        private void BtnDecimales_Click(object sender, EventArgs e)
        {
            if (sender == btnMasDecimales && Decimales < 9)
            {
                Decimales++;
            }
            else if (sender == btnMenosDecimales && Decimales > 1)
            {
                Decimales--;
            }
            glControl1.Refresh();
        }

        private void BtnCiclos_Click(object sender, EventArgs e)
        {

        }

        private void BtnEnlazar_Click(object sender, EventArgs e)
        {
            if (btnEnlazar.Checked)
            {
                foreach (Barra bar in ListaBarras)
                {
                    bar.Area = AreaTotal;
                    bar.Inercia = Ixg;
                    bar.EYoung = 2100000;
                }
            }
        }

        private void Esfuerzos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtVx.TextLength > 0) { Vx = Convert.ToDouble(txtVx.Text, CultureInfo.InvariantCulture); } else { Vx = 0; }
                if (txtVy.TextLength > 0) { Vy = Convert.ToDouble(txtVy.Text, CultureInfo.InvariantCulture); } else { Vy = 0; }
                if (txtAxial.TextLength > 0) { EsfuerzoAxial = Convert.ToDouble(txtAxial.Text, CultureInfo.InvariantCulture); } else { EsfuerzoAxial = 0; }
                if (txtFlectorX.TextLength > 0) { EsfuerzoMx = Convert.ToDouble(txtFlectorX.Text, CultureInfo.InvariantCulture); } else { EsfuerzoMx = 0; }
                if (txtFlectorY.TextLength > 0) { EsfuerzoMy = Convert.ToDouble(txtFlectorY.Text, CultureInfo.InvariantCulture); } else { EsfuerzoMy = 0; }
            }
            catch
            {
                throw;
            }
            glControl1.Refresh();
        }

        private void BtnMapaColor_Click(object sender, EventArgs e)
        {
            foreach (Figura fig in ListaFiguras)
            {
                if (btnMapaColor.Checked) { fig.MapaColor = true; } else { fig.MapaColor = false; }
            }
        }

        internal void AbrirDoc()
        {
            FiguraSeleccionada = false;
            string rutaabrir;
            if (MenuOpen.ShowDialog() == DialogResult.OK)
            {
                rutaabrir = MenuOpen.FileName;
                BinaryFormatter formateador = new BinaryFormatter();
                try
                {
                    Stream miStream = new FileStream(rutaabrir, FileMode.Open, FileAccess.Read, FileShare.None);
                    ClaseSerializable guardar = new ClaseSerializable();
                    guardar = (ClaseSerializable)formateador.Deserialize(miStream);
                    ListaFiguras = guardar.ListaFiguras;
                    ListaNodos = guardar.ListaNodos;
                    ListaBarras = guardar.ListaBarras;
                    ListaApoyos = guardar.ListaApoyos;
                    ListaFuerzas = guardar.ListaFuerzas;
                    miStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        internal void GuardarDoc()
        {
            string rutaguardar;
            if (MenuSave.ShowDialog() == DialogResult.OK)
            {
                rutaguardar = MenuSave.FileName;
                BinaryFormatter formateador = new BinaryFormatter();

                try
                {
                    Stream miStream = new FileStream(rutaguardar, FileMode.Create, FileAccess.Write, FileShare.None);
                    ClaseSerializable guardar = new ClaseSerializable
                    {
                        ListaFiguras = ListaFiguras,
                        ListaNodos = ListaNodos,
                        ListaBarras = ListaBarras,
                        ListaApoyos = ListaApoyos,
                        ListaFuerzas = ListaFuerzas
                    };
                    formateador.Serialize(miStream, guardar);
                    miStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        internal void LongitudPandeo()
        {
            if (txtLongitudReal.TextLength > 0)
            {
                try
                {
                    double L = Convert.ToDouble(txtLongitudReal.Text, CultureInfo.InvariantCulture), Lk;
                    if (cmbboxContorno.SelectedIndex == 0)
                    {
                        Lk = Math.Round(L, 3);
                    }
                    else if (cmbboxContorno.SelectedIndex == 1)
                    {
                        Lk = Math.Round(L * 0.7, 3);
                    }
                    else if (cmbboxContorno.SelectedIndex == 2)
                    {
                        Lk = Math.Round(L * 0.5, 3);
                    }
                    else if (cmbboxContorno.SelectedIndex == 3)
                    {
                        Lk = Math.Round(2 * L, 3);
                    }
                    else if (cmbboxContorno.SelectedIndex == 4)
                    {
                        Lk = Math.Round(L, 3);
                    }
                    else
                    {
                        Lk = Math.Round(2 * L, 3);
                    }
                    txtLongitudPandeo.Text = Convert.ToString(Lk, CultureInfo.InvariantCulture);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

            }
            txtLongitudPandeo.Refresh();
            CalculoPandeo();
        }
        private void TxtLongitudReal_KeyUp(object sender, KeyEventArgs e)
        {
            LongitudPandeo();
        }

        private void TxtAlto_KeyUp(object sender, KeyEventArgs e)
        {
            if (FiguraSeleccionada && txtAlto.TextLength > 0)
            {
                try
                {
                    ListaFiguras[IdFiguraSeleccionada - 1].Alto = Convert.ToDouble(txtAlto.Text, CultureInfo.InvariantCulture);
                    glControl1.Refresh();
                }
                catch (Exception ex)
                {
                    txtAlto.Clear();
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void BtnEliminarEstructura_Click(object sender, EventArgs e)
        {
            IdNodoSeleccionado = 0; NodoSeleccionado = false;
            IdBarraSeleccionada = 0; BarraSeleccionada = false;
            IdApoyoSeleccionado = 0; ApoyoSeleccionado = false;
            IdCargaSeleccionada = 0; CargaSeleccionada = false;

            if (IdNodo > 0)
            {
                //Quitamos las barras asociadas al nodo
                for (int i = ListaBarras.Count - 1; i >= 0; i--)
                {
                    if (ListaBarras[i].NodoInicial == ListaNodos[IdNodo - 1]) { ListaBarras.RemoveAt(i); }
                    if (ListaBarras[i].NodoFinal == ListaNodos[IdNodo - 1]) { ListaBarras.RemoveAt(i); }
                }
                //Quitamos los apoyos asociados al nodo
                for (int i = ListaApoyos.Count - 1; i >= 0; i--)
                {
                    if (ListaApoyos[i].NodoAdjunto == ListaNodos[IdNodo - 1]) { ListaApoyos.RemoveAt(i); }
                }
                //Quitamos las cargas asociadas al nodo
                for (int i = ListaFuerzas.Count - 1; i >= 0; i--)
                {
                    if (ListaFuerzas[i].NodAdjunto == ListaNodos[IdNodo - 1]) { ListaFuerzas.RemoveAt(i); }
                }
                Renumerar();
                ListaNodos.RemoveAt(IdNodo - 1);
            }
            if (IdBarra > 0 && ListaBarras.Count > 0)
            {
                for (int i = ListaNodos.Count - 1; i >= 0; i--)
                {
                    for (int j = ListaNodos[i].ListaBarrasAsociadas.Count - 1; j >= 0; j--)
                    {
                        if (ListaNodos[i].ListaBarrasAsociadas[j] == ListaBarras[IdBarra - 1]) { ListaNodos[i].ListaBarrasAsociadas.RemoveAt(j); }
                    }
                }
                for (int j = ListaFuerzas.Count - 1; j >= 0; j--)
                {
                    if (ListaFuerzas[j].BarraAsociada != null) { if (IdBarra == ListaFuerzas[j].BarraAsociada.NumeroBarra) { ListaFuerzas.RemoveAt(j); } }
                }

                ListaBarras.RemoveAt(IdBarra - 1);
                Renumerar();
            }
            if (IdApoyo > 0)
            {
                ListaNodos[ListaApoyos[IdApoyo - 1].NodoAdjunto.NumeroNodo - 1].ApoyoAsociado = null;
                ListaApoyos.RemoveAt(IdApoyo - 1);
            }
            if (IdCarga > 0)
            {
                if (!ListaFuerzas[IdCarga - 1].CargaNodal) //Cargas sobre nodos
                {
                    ListaBarras[ListaFuerzas[IdCarga - 1].BarraAsociada.NumeroBarra - 1].Carga = null;
                }
                ListaFuerzas.RemoveAt(IdCarga - 1);
            }
        }

        private void TxtAncho_KeyUp(object sender, KeyEventArgs e)
        {
            if (FiguraSeleccionada && txtAncho.TextLength > 0)
            {
                try
                {
                    ListaFiguras[IdFiguraSeleccionada - 1].Ancho = Convert.ToDouble(txtAncho.Text, CultureInfo.InvariantCulture);
                    glControl1.Refresh();
                }
                catch (Exception ex)
                {
                    txtAncho.Clear();
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void TxtRadio_KeyUp(object sender, KeyEventArgs e)
        {
            if (FiguraSeleccionada && txtRadio.TextLength > 0)
            {
                try
                {
                    ListaFiguras[IdFiguraSeleccionada - 1].R = Convert.ToDouble(txtRadio.Text, CultureInfo.InvariantCulture);
                    glControl1.Refresh();
                }
                catch (Exception ex)
                {
                    txtRadio.Clear();
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void TxtNodoCx_KeyUp(object sender, KeyEventArgs e)
        {
            if (NodoSeleccionado && txtNodoCx.TextLength > 0)
            {
                try
                {
                    foreach (Barra barr in ListaBarras)
                    {
                        if (barr.X0 == ListaNodos[IdNodoSeleccionado - 1].X && barr.Y0 == ListaNodos[IdNodoSeleccionado - 1].Y)
                        {
                            ListaNodos[IdNodoSeleccionado - 1].X = Convert.ToDouble(txtNodoCx.Text, CultureInfo.InvariantCulture);
                            barr.X0 = ListaNodos[IdNodoSeleccionado - 1].X;
                            barr.Y0 = ListaNodos[IdNodoSeleccionado - 1].Y;
                        }
                        if (barr.X1 == ListaNodos[IdNodoSeleccionado - 1].X && barr.Y1 == ListaNodos[IdNodoSeleccionado - 1].Y)
                        {
                            ListaNodos[IdNodoSeleccionado - 1].X = Convert.ToDouble(txtNodoCx.Text, CultureInfo.InvariantCulture);
                            barr.X1 = ListaNodos[IdNodoSeleccionado - 1].X;
                            barr.Y1 = ListaNodos[IdNodoSeleccionado - 1].Y;
                        }
                    }
                    foreach (Apoyo ap in ListaApoyos)
                    {
                        if (ap.X == ListaNodos[IdNodoSeleccionado - 1].X && ap.Y == ListaNodos[IdNodoSeleccionado - 1].Y)
                        {
                            ListaNodos[IdNodoSeleccionado - 1].X = Convert.ToDouble(txtNodoCx.Text, CultureInfo.InvariantCulture);
                            ap.X = ListaNodos[IdNodoSeleccionado - 1].X;
                            ap.Y = ListaNodos[IdNodoSeleccionado - 1].Y;
                        }
                    }

                    glControl3.Refresh();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void TxtNodoCy_KeyUp(object sender, KeyEventArgs e)
        {
            if (NodoSeleccionado && txtNodoCy.TextLength > 0)
            {
                try
                {
                    foreach (Barra barr in ListaBarras)
                    {
                        if (barr.X0 == ListaNodos[IdNodoSeleccionado - 1].X && barr.Y0 == ListaNodos[IdNodoSeleccionado - 1].Y)
                        {
                            ListaNodos[IdNodoSeleccionado - 1].Y = Convert.ToDouble(txtNodoCy.Text, CultureInfo.InvariantCulture);
                            barr.X0 = ListaNodos[IdNodoSeleccionado - 1].X;
                            barr.Y0 = ListaNodos[IdNodoSeleccionado - 1].Y;
                        }
                        if (barr.X1 == ListaNodos[IdNodoSeleccionado - 1].X && barr.Y1 == ListaNodos[IdNodoSeleccionado - 1].Y)
                        {
                            ListaNodos[IdNodoSeleccionado - 1].Y = Convert.ToDouble(txtNodoCy.Text, CultureInfo.InvariantCulture);
                            barr.X1 = ListaNodos[IdNodoSeleccionado - 1].X;
                            barr.Y1 = ListaNodos[IdNodoSeleccionado - 1].Y;
                        }
                    }
                    foreach (Apoyo ap in ListaApoyos)
                    {
                        if (ap.X == ListaNodos[IdNodoSeleccionado - 1].X && ap.Y == ListaNodos[IdNodoSeleccionado - 1].Y)
                        {
                            ListaNodos[IdNodoSeleccionado - 1].Y = Convert.ToDouble(txtNodoCy.Text, CultureInfo.InvariantCulture);
                            ap.X = ListaNodos[IdNodoSeleccionado - 1].X;
                            ap.Y = ListaNodos[IdNodoSeleccionado - 1].Y;
                        }
                    }
                    glControl3.Refresh();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        private void BtnVistaAxonometrica_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == Seccion)
            {
                AngRotX1 = -25; AngRotY1 = -45;
                glControl1.Refresh();
            }
            if (tabControl.SelectedTab == Estructura)
            {
                AngRotX3 = -30; AngRotY3 = 45;
                glControl3.Refresh();
            }
        }

        private void BtnVistaFrontal_Click(object sender, EventArgs e)
        {
            AngRotX1 = AngRotY1 = AngRotX3 = AngRotY3 = 0;
            glControl1.Refresh();
            glControl3.Refresh();
        }

        private void BtnCambiarColor_Click(object sender, EventArgs e)
        {
            if (EditarColor.ShowDialog() == DialogResult.OK)
            {
                RR = EditarColor.Color.R * 1.0 / 255;
                GG = EditarColor.Color.G * 1.0 / 255;
                BB = EditarColor.Color.B * 1.0 / 255;
            }
            btnCambiarColor.BackColor = Color.FromArgb(255, Convert.ToInt32(RR * 255), Convert.ToInt32(GG * 255), Convert.ToInt32(BB * 255));

        }

        private void BtnCentrar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == Seccion)
            {
                cx1 = 0; cy1 = 0; zx = 0; zy = 0;
                zoom = 1f;
                GL.LoadIdentity();
                glControl1.Refresh();
            }
            else if (tabControl.SelectedTab == Estructura)
            {
                cx3 = 0; cy3 = 0;
                zoom = 1f;
                GL.LoadIdentity();
                glControl3.Refresh();
            }

        }


        private void TxtDx_KeyUp(object sender, KeyEventArgs e)
        {
            if (FiguraSeleccionada && string.IsNullOrEmpty(txtDx.Text))
            {
                try
                {
                    ListaFiguras[IdFiguraSeleccionada - 1].X = Convert.ToDouble(txtDx.Text, CultureInfo.InvariantCulture);
                    glControl1.Refresh();
                }
                catch (Exception ex)
                {
                    txtDx.Clear();
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

            if (PuntoSeleccionado && string.IsNullOrEmpty(txtDx.Text))
            {
                try
                {
                    ListaPuntos[IdPuntoSeleccionado - 1].X = Convert.ToDouble(txtDx.Text, CultureInfo.InvariantCulture);
                    glControl1.Refresh();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void TxtDy_KeyUp(object sender, KeyEventArgs e)
        {
            if (FiguraSeleccionada && string.IsNullOrEmpty(txtDy.Text))
            {
                try
                {
                    ListaFiguras[IdFiguraSeleccionada - 1].Y = Convert.ToDouble(txtDy.Text, CultureInfo.InvariantCulture);
                    glControl1.Refresh();
                }
                catch (Exception)
                {
                    throw;
                }
            }


            if (PuntoSeleccionado && string.IsNullOrEmpty(txtDy.Text))
            {
                try
                {
                    ListaPuntos[IdPuntoSeleccionado - 1].Y = Convert.ToDouble(txtDy.Text, CultureInfo.InvariantCulture);
                    glControl1.Refresh();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void TxtYoungBarra_KeyUp(object sender, KeyEventArgs e)
        {
            if (BarraSeleccionada && txtYoungBarra.TextLength > 0)
            {
                try
                {
                    ListaBarras[IdBarraSeleccionada - 1].EYoung = Convert.ToDouble(txtYoungBarra.Text, CultureInfo.InvariantCulture);
                    glControl3.Refresh();
                }
                catch (Exception ex)
                {
                    txtYoungBarra.Clear();
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }



        private void TxtInerciaBarra_KeyUp(object sender, KeyEventArgs e)
        {
            if (BarraSeleccionada && txtInerciaBarra.TextLength > 0)
            {
                try
                {
                    ListaBarras[IdBarraSeleccionada - 1].Inercia = Convert.ToDouble(txtInerciaBarra.Text, CultureInfo.InvariantCulture);
                    glControl3.Refresh();
                }
                catch (Exception ex)
                {
                    txtInerciaBarra.Clear();
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void TxtAreaBarra_KeyUp(object sender, KeyEventArgs e)
        {
            if (BarraSeleccionada && txtAreaBarra.TextLength > 0)
            {
                try
                {
                    ListaBarras[IdBarraSeleccionada - 1].Area = Convert.ToDouble(txtAreaBarra.Text, CultureInfo.InvariantCulture);
                    glControl3.Refresh();
                }
                catch (Exception ex)
                {
                    txtAreaBarra.Clear();
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        private void TxtAngulo_KeyUp(object sender, KeyEventArgs e)
        {
            if (FiguraSeleccionada && txtAngulo.TextLength > 0)
            {
                try
                {
                    double ang = Convert.ToDouble(txtAngulo.Text, CultureInfo.InvariantCulture);
                    ListaFiguras[IdFiguraSeleccionada - 1].Theta = ang;
                    glControl1.Refresh();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        internal void DibujarEstructura()
        {
            double resultx, resulty;

            if (btnForzarCursor.Checked) //Solo cuando la rejilla está activada y no estamos dentro de la figura
            {
                resultx = xr / Malla;
                resulty = yr / Malla;
                if (btnNodo.Checked) { NodoAux = new Nodo(Math.Round(resultx, 0, MidpointRounding.ToEven) * Malla, Math.Round(resulty, 0, MidpointRounding.ToEven) * Malla, 0); }
                if (CreandoBarra == false)
                {
                    double xt = Math.Round(resultx, 0, MidpointRounding.ToEven) * Malla;
                    double yt = Math.Round(resulty, 0, MidpointRounding.ToEven) * Malla;

                    if (MoviendoNodo)
                    {
                        ListaNodos[IdNodoSeleccionado - 1].X = xt;
                        ListaNodos[IdNodoSeleccionado - 1].Y = yt;

                        foreach (Barra barr in ListaBarras)
                        {
                            barr.X0 = barr.NodoInicial.X;
                            barr.Y0 = barr.NodoInicial.Y;
                            barr.X1 = barr.NodoFinal.X;
                            barr.Y1 = barr.NodoFinal.Y;
                        }
                        foreach (Apoyo ap in ListaApoyos)
                        {
                            ap.X = ap.NodoAdjunto.X;
                            ap.Y = ap.NodoAdjunto.Y;
                        }
                        foreach (Carga carga in ListaFuerzas)
                        {
                            if (carga.CargaNodal)
                            {
                                carga.X = ListaNodos[carga.NodAdjunto.NumeroNodo - 1].X;
                                carga.Y = ListaNodos[carga.NodAdjunto.NumeroNodo - 1].Y;
                            }
                        }
                    }
                }
            }
            else
            {
                if (btnNodo.Checked) { NodoAux = new Nodo(xr, yr, 0); }
                if (MoviendoNodo && CreandoBarra == false)
                {
                    ListaNodos[IdNodoSeleccionado - 1].X = xr;
                    ListaNodos[IdNodoSeleccionado - 1].Y = yr;
                    foreach (Barra barr in ListaBarras)
                    {
                        barr.X0 = barr.NodoInicial.X;
                        barr.Y0 = barr.NodoInicial.Y;
                        barr.X1 = barr.NodoFinal.X;
                        barr.Y1 = barr.NodoFinal.Y;
                    }
                    foreach (Apoyo ap in ListaApoyos)
                    {
                        ap.X = ap.NodoAdjunto.X;
                        ap.Y = ap.NodoAdjunto.Y;
                    }
                    foreach (Carga carga in ListaFuerzas)
                    {
                        if (carga.CargaNodal)
                        {
                            carga.X = ListaNodos[carga.NodAdjunto.NumeroNodo - 1].X;
                            carga.Y = ListaNodos[carga.NodAdjunto.NumeroNodo - 1].Y;
                        }
                    }
                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
            }

            if (e.Control && e.KeyCode == Keys.Y)
            {
                Redo();
            }
        }

        internal void Undo()
        {
            if (tabControl.SelectedTab == Seccion)
            {
                int pos = ListaUndo.Count - 1;
                if (pos >= 0)
                {
                    Figura fig = CopyAnObject<Figura>.Copiar(ListaUndo[pos]);
                    ListaRedo.Add(fig);
                    try
                    {
                        if (ListaUndo[pos].NumeroFigura - 1 < ListaFiguras.Count)
                        {
                            ListaFiguras[ListaUndo[pos].NumeroFigura - 1] = ListaUndo[pos];
                        }
                        else
                        {
                            ListaFiguras.Insert(ListaUndo[pos].NumeroFigura - 1, ListaUndo[pos]);
                        }
                        ListaUndo.RemoveAt(pos);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            glControl1.Refresh();
        }
        internal void Redo()
        {
            if (tabControl.SelectedTab == Seccion)
            {
                int pos = ListaRedo.Count - 1;
                if (pos >= 0)
                {
                    try
                    {
                        Figura fig = CopyAnObject<Figura>.Copiar(ListaRedo[pos]);
                        ListaUndo.Add(fig);
                        if (ListaRedo[pos].NumeroFigura - 1 < ListaFiguras.Count)
                        {
                            ListaFiguras[ListaRedo[pos].NumeroFigura - 1] = ListaRedo[pos];
                        }
                        else
                        {
                            ListaFiguras.Insert(ListaRedo[pos].NumeroFigura - 1, ListaRedo[pos]);
                        }
                        ListaRedo.RemoveAt(pos);
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            glControl1.Refresh();
        }

        private void BtnAyuda_Click(object sender, EventArgs e)
        {
            FormAyuda form = new FormAyuda
            {
                StartPosition = FormStartPosition.CenterParent
            };
            form.ShowDialog();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == Seccion)
            {
                CuadroBarra.Hide();
                CuadroNodo.Hide();
                CuadroPropiedades.Show();
                CuadroEsfuerzos.Show();
                CuadroEjesCDG.Show();
                CuadroContorno.Show();
                cmbboxContorno.Show();

                //Barra superior
                glControl1.Context.MakeCurrent(glControl1.WindowInfo);
                btnNodo.Visible = false;
                btnDeslizaderaArticX.Visible = false;
                btnDeslizaderaArticY.Visible = false;
                btnApoyoFijo.Visible = false;
                btnEmpotramiento.Visible = false;
                btnFuerzaBarra.Visible = false;
                btnFuerzaNodo.Visible = false;
                btnCargaDistribuida.Visible = false;
                btnMomentoNodo.Visible = false;
                btnMomentoBarra.Visible = false;
                btnBarraBiarticulada.Visible = false;
                btnBarraEmpotrada.Visible = false;
                btnBarraEmpArt.Visible = false;
                btnPropiedadesBarra.Visible = false;
                btnIncrementoTa.Visible = false;
                btnErrorForma.Visible = false;
                btnAsentamiento.Visible = false;
                btnCalcular.Visible = false;
                btnResultados.Visible = false;
                btnCirculo.Visible = true;
                btnRectangulo.Visible = true;
                btnCuartoCirculo.Visible = true;
                btnSemiCirculo.Visible = true;
                btnTrianguloRectangulo.Visible = true;
                btnDeslizaderaRigX.Visible = false;
                btnDeslizaderaRigY.Visible = false;
                btnUndo.Visible = true;
                btnRedo.Visible = true;
                //Barra inferior
                btnEjesCDG.Visible = true;
                btnEjesPpales.Visible = true;
                btnLineaNeutra.Visible = true;
                btnDistribucionTensiones.Visible = true;
                btnMapaColor.Visible = true;
                btnDistribucionAxiales.Visible = false;
                btnDistribucionCortantes.Visible = false;
                btnDistribucionFlectores.Visible = false;
                btnDeformada.Visible = false;
                btnCambiarColor.Visible = true;
                btnEjesLocales.Visible = false;

                glControl2.Visible = true;
            }
            else
            {
                CuadroBarra.Show();
                CuadroNodo.Show();
                CuadroPropiedades.Hide();
                CuadroEsfuerzos.Hide();
                CuadroEjesCDG.Hide();
                CuadroContorno.Hide();
                cmbboxContorno.Hide();

                glControl3.Context.MakeCurrent(glControl3.WindowInfo);
                btnNodo.Visible = true;
                btnDeslizaderaArticX.Visible = true;
                btnDeslizaderaArticY.Visible = true;
                btnApoyoFijo.Visible = true;
                btnEmpotramiento.Visible = true;
                btnFuerzaBarra.Visible = true;
                btnFuerzaNodo.Visible = true;
                btnCargaDistribuida.Visible = true;
                btnMomentoNodo.Visible = true;
                btnMomentoBarra.Visible = true;
                btnBarraBiarticulada.Visible = true;
                btnBarraEmpotrada.Visible = true;
                btnBarraEmpArt.Visible = true;
                btnPropiedadesBarra.Visible = true;
                btnIncrementoTa.Visible = true;
                btnErrorForma.Visible = true;
                btnAsentamiento.Visible = true;
                btnCalcular.Visible = true;
                btnResultados.Visible = true;
                btnCirculo.Visible = false;
                btnRectangulo.Visible = false;
                btnCuartoCirculo.Visible = false;
                btnSemiCirculo.Visible = false;
                btnTrianguloRectangulo.Visible = false;
                btnDeslizaderaRigX.Visible = true;
                btnDeslizaderaRigY.Visible = true;
                btnUndo.Visible = false;
                btnRedo.Visible = false;
                //Barra inferior
                btnEjesCDG.Visible = false;
                btnEjesPpales.Visible = false;
                btnLineaNeutra.Visible = false;
                btnDistribucionTensiones.Visible = false;
                btnMapaColor.Visible = false;
                btnDistribucionAxiales.Visible = true;
                btnDistribucionCortantes.Visible = true;
                btnDistribucionFlectores.Visible = true;
                btnDeformada.Visible = true;
                btnCambiarColor.Visible = false;
                btnEjesLocales.Visible = true;
                glControl2.Visible = false;
            }
        }


        internal void NuevoDoc()
        {
            FormNuevoDoc form = new FormNuevoDoc
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                IdFiguraSeleccionada = 0;
                IdNodoSeleccionado = 0;
                IdBarraSeleccionada = 0;
                IdPuntoSeleccionado = 0;
                IdApoyoSeleccionado = 0;
                IdCargaSeleccionada = 0;
                ListaFiguras.Clear();
                ListaPuntos.Clear();
                ListaNodos.Clear();
                ListaBarras.Clear();
                ListaPuntosCT.Clear();
                ListaApoyos.Clear();
                ListaFuerzas.Clear();
            }
        }

        internal void CopiarFigura()
        {
            if (FiguraSeleccionada)
            {
                figCopy = CopyAnObject<Figura>.Copiar(ListaFiguras[IdFiguraSeleccionada - 1]);
                isCopied = true;
                toPaste = true;
            }
        }

        internal void PegarFigura()
        {
            toPaste = false;
            if (isCopied == true)
            {
                figCopy.X = 0;
                figCopy.Y = 0;
                ListaFiguras.Add(figCopy);
                figCopy = null;
                glControl1.Refresh();
            }
        }


        private void CmnuInercias_Click(object sender, EventArgs e)
        {
            if (CmnuInercias.Checked)
            {
                labelIx.Show(); txtIx.Show(); txtUndsIx.Show();
                labelIy.Show(); txtIy.Show(); txtUndsIy.Show();
                labelIxy.Show(); txtIxy.Show(); txtUndsIxy.Show();
                labelIxg.Show(); txtIxg.Show(); txtUndsIxg.Show();
                labelIyg.Show(); txtIyg.Show(); txtUndsIyg.Show();
                labelIxgyg.Show(); txtIxgyg.Show(); txtUndsIxgyg.Show();
                labelPhi.Show(); txtPhi.Show(); txtUndsPhip.Show();
                labelIxp.Show(); txtIxp.Show(); txtUndsIxp.Show();
                labelIyp.Show(); txtIyp.Show(); txtUndsIyp.Show();
            }
            else
            {
                labelIx.Hide(); txtIx.Hide(); txtUndsIx.Hide();
                labelIy.Hide(); txtIy.Hide(); txtUndsIy.Hide();
                labelIxy.Hide(); txtIxy.Hide(); txtUndsIxy.Hide();
                labelIxg.Hide(); txtIxg.Hide(); txtUndsIxg.Hide();
                labelIyg.Hide(); txtIyg.Hide(); txtUndsIyg.Hide();
                labelIxgyg.Hide(); txtIxgyg.Hide(); txtUndsIxgyg.Hide();
                labelPhi.Hide(); txtPhi.Hide(); txtUndsPhip.Hide();
                labelIxp.Hide(); txtIxp.Hide(); txtUndsIxp.Hide();
                labelIyp.Hide(); txtIyp.Hide(); txtUndsIyp.Hide();
            }
        }

        private void TxtAxial_KeyUp(object sender, KeyEventArgs e)
        {
            glControl1.Refresh();
        }


        private void CmnuCDG_Click(object sender, EventArgs e)
        {
            if (CmnuCDG.Checked)
            {
                labelCdgx.Show(); txtCdgX.Show(); txtUndsCdgX.Show();
                labelCdgy.Show(); txtCdgY.Show(); txtUndsCdgY.Show();
            }
            else
            {
                labelCdgx.Hide(); txtCdgX.Hide(); txtUndsCdgX.Hide();
                labelCdgy.Hide(); txtCdgY.Hide(); txtUndsCdgY.Hide();
            }
        }

        private void CmnuCargacritica_Click(object sender, EventArgs e)
        {
            if (CmnuCargacritica.Checked)
            {
                labelPcr.Show(); txtCargaCritica.Show(); txtUndsPcr.Show();
            }
            else
            {
                labelPcr.Hide(); txtCargaCritica.Hide(); txtUndsPcr.Hide();
            }
        }

        private void CmnuInerciasXY_Click(object sender, EventArgs e)
        {
            if (CmnuInerciasXY.Checked)
            {
                labelIx.Show(); txtIx.Show(); txtUndsIx.Show();
                labelIy.Show(); txtIy.Show(); txtUndsIy.Show();
                labelIxy.Show(); txtIxy.Show(); txtUndsIxy.Show();
            }
            else
            {
                labelIx.Hide(); txtIx.Hide(); txtUndsIx.Hide();
                labelIy.Hide(); txtIy.Hide(); txtUndsIy.Hide();
                labelIxy.Hide(); txtIxy.Hide(); txtUndsIxy.Hide();

            }
        }

        private void CmnuInerciasCDG_Click(object sender, EventArgs e)
        {
            if (CmnuInerciasCDG.Checked)
            {
                labelIxg.Show(); txtIxg.Show(); txtUndsIxg.Show();
                labelIyg.Show(); txtIyg.Show(); txtUndsIyg.Show();
                labelIxgyg.Show(); txtIxgyg.Show(); txtUndsIxgyg.Show();
            }
            else
            {
                labelIxg.Hide(); txtIxg.Hide(); txtUndsIxg.Hide();
                labelIyg.Hide(); txtIyg.Hide(); txtUndsIyg.Hide();
                labelIxgyg.Hide(); txtIxgyg.Hide(); txtUndsIxgyg.Hide();
            }
        }

        private void CmnuTension_Click(object sender, EventArgs e)
        {
            if (CmnuTension.Checked)
            {
                labelSigma.Show(); txtSigma.Show(); txtUndsSigma.Show();
                labelSigmaMax.Show(); txtSigmaMax.Show(); txtUndsSigmaMax.Show();
                labelSigmaMin.Show(); txtSigmaMin.Show(); txtUndsSigmaMin.Show();
                labelSigmaMx.Show(); txtSigmaMx.Show(); txtUndsSigmaMx.Show();
                labelSigmaMy.Show(); txtSigmaMy.Show(); txtUndsSigmaMy.Show();
                labelSigmaN.Show(); txtSigmaN.Show(); txtUndsSigmaN.Show();
            }
            else
            {
                labelSigma.Hide(); txtSigma.Hide(); txtUndsSigma.Hide();
                labelSigmaMax.Hide(); txtSigmaMax.Hide(); txtUndsSigmaMax.Hide();
                labelSigmaMin.Hide(); txtSigmaMin.Hide(); txtUndsSigmaMin.Hide();
                labelSigmaMx.Hide(); txtSigmaMx.Hide(); txtUndsSigmaMx.Hide();
                labelSigmaMy.Hide(); txtSigmaMy.Hide(); txtUndsSigmaMy.Hide();
                labelSigmaN.Hide(); txtSigmaN.Hide(); txtUndsSigmaN.Hide();
            }
        }




        public FormPpal()//CONSTRUCTOR
        {
            //Thread t = new Thread(new ThreadStart(SplashStart));
            //t.Start();
            ////Codigo para cargar el form1   

            //Thread.Sleep(5000);
            //---------------------------                 

            InitializeComponent();

            //------------------------------------------------
            glControl1 = new GLControl(new GraphicsMode(32, 24, 0, 8))
            {
                Dock = DockStyle.Fill
            };
            Seccion.Controls.Add(glControl1);
            glControl1.Load += GlControl1_Load;
            glControl1.Paint += GlControl1_Paint;
            glControl1.KeyDown += GlControl1_KeyDown;
            glControl1.KeyUp += GlControl1_KeyUp;
            glControl1.MouseMove += GlControl1_MouseMove;
            glControl1.MouseDoubleClick += GlControl1_MouseDoubleClick;
            glControl1.MouseDown += GlControl1_MouseDown1;
            glControl1.MouseUp += GlControl1_MouseUp;
            glControl1.MouseWheel += GlControl1_MouseWheel;
            //-------------------------------------------------
            glControl2 = new GLControl(new GraphicsMode(32, 24, 0, 8))
            {
                Dock = DockStyle.Fill
            };
            panelGlControl2.Controls.Add(glControl2);
            glControl2.Load += GlControl2_Load;
            glControl2.Paint += GlControl2_Paint;
            //-------------------------------------------------
            glControl3 = new GLControl(new GraphicsMode(32, 24, 0, 8))
            {
                Dock = DockStyle.Fill
            };
            Estructura.Controls.Add(glControl3);
            glControl3.Load += GlControl3_Load;
            glControl3.Paint += GlControl3_Paint;
            glControl3.KeyDown += GlControl3_KeyDown;
            glControl3.KeyUp += GlControl3_KeyUp;
            glControl3.MouseMove += GlControl3_MouseMove;
            glControl3.MouseDoubleClick += GlControl3_MouseDoubleClick;
            glControl3.MouseDown += GlControl3_MouseDown;
            glControl3.MouseUp += GlControl3_MouseUp;
            glControl3.MouseWheel += GlControl3_MouseWheel;
            //-------------------------------------------------
            BarraHerramientas.Renderer = new ToolStripOverride();
            barraPropiedadesInferior.Renderer = new ToolStripOverride();
            barraOpcionesResultados.Renderer = new ToolStripOverride();
            barraMenuSuperior.Renderer = new ToolStripOverride();
            IdFiguras = 0;
            zoom = 1f;
            //t.Abort();
        }

        private void GlControl3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                RuedaPress3 = false;
                Cursor.Current = Cursors.Default;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (btnMover.Checked)
                {
                    agarrar = false;
                }
                MoviendoNodo = false;
                IdMoviendoNodo = 0;
            }
            glControl3.Refresh();
        }

        private void GlControl3_MouseDown(object sender, MouseEventArgs e)
        {
            double resultx, resulty;
            if (e.Button == MouseButtons.Middle)
            {
                RuedaPress3 = true;
                Cursor.Current = Cursors.Hand;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (IdCarga == 0) { CargaSeleccionada = false; IdCargaSeleccionada = 0; }
                if (IdApoyo == 0) { ApoyoSeleccionado = false; IdApoyoSeleccionado = 0; }
                if (IdBarra == 0) { BarraSeleccionada = false; IdBarraSeleccionada = 0; }
                if (IdNodo == 0) { NodoSeleccionado = false; IdNodoSeleccionado = 0; }
                if (btnMover.Checked)
                {
                    agarrar = true;
                }
                if (IdBarra > 0)
                {
                    if (btnFuerzaBarra.Checked)
                    {
                        FormFuerzaBarra form = new FormFuerzaBarra(ListaBarras[IdBarra - 1]) { StartPosition = FormStartPosition.CenterParent };
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            double Prop = form.Dnodoi / ListaBarras[IdBarra - 1].Longitud;

                            FuerzaBarra carg = new FuerzaBarra(ListaBarras[IdBarra - 1], form.Modulo, form.Eje, Prop)
                            {
                                NodAdjuntoi = ListaBarras[IdBarra - 1].NodoInicial,
                                NodAdjuntoj = ListaBarras[IdBarra - 1].NodoFinal
                            };
                            ListaBarras[IdBarra - 1].Carga = carg;
                            carg.NumeroCarga = ListaFuerzas.Count + 1;
                            carg.CargaNodal = false;
                            ListaFuerzas.Add(carg);
                        }
                        form.Dispose();
                        btnFuerzaBarra.Checked = false;
                    }
                    if (btnMomentoBarra.Checked)
                    {
                        FormMomentoBarra form = new FormMomentoBarra(ListaBarras[IdBarra - 1]) { StartPosition = FormStartPosition.CenterParent };
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            double Prop = form.Dnodoi / ListaBarras[IdBarra - 1].Longitud;

                            MomentoBarra carg = new MomentoBarra(ListaBarras[IdBarra - 1], form.Modulo, Prop)
                            {
                                NodAdjuntoi = ListaBarras[IdBarra - 1].NodoInicial,
                                NodAdjuntoj = ListaBarras[IdBarra - 1].NodoFinal
                            };
                            ListaBarras[IdBarra - 1].Carga = carg;
                            carg.NumeroCarga = ListaFuerzas.Count + 1;
                            carg.CargaNodal = false;
                            ListaFuerzas.Add(carg);
                        }
                        btnMomentoBarra.Checked = false;
                        form.Dispose();
                    }
                    if (btnCargaDistribuida.Checked)
                    {
                        FormCargaDistribuida form = new FormCargaDistribuida { StartPosition = FormStartPosition.CenterParent };
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            CargaDistribuida distribuida = new CargaDistribuida(ListaBarras[IdBarra - 1], form.Qi, form.Qj, form.Eje)
                            {
                                NodAdjuntoi = ListaBarras[IdBarra - 1].NodoInicial,
                                NodAdjuntoj = ListaBarras[IdBarra - 1].NodoFinal
                            };
                            ListaBarras[IdBarra - 1].Carga = distribuida;
                            distribuida.NumeroCarga = ListaFuerzas.Count + 1;
                            distribuida.CargaNodal = false;
                            ListaFuerzas.Add(distribuida);
                        }
                        btnCargaDistribuida.Checked = false;
                        form.Dispose();
                    }
                    if (btnIncrementoTa.Checked)
                    {
                        FormCargaTermica form = new FormCargaTermica
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            CargaTermica carg = new CargaTermica(ListaBarras[IdBarra - 1], form.Tmedia, form.Tgrad);
                            ListaBarras[IdBarra - 1].Carga = carg;
                            ListaBarras[IdBarra - 1].CargaTermica = true;
                            carg.NodAdjuntoi = ListaBarras[IdBarra - 1].NodoInicial;
                            carg.NodAdjuntoj = ListaBarras[IdBarra - 1].NodoFinal;
                            carg.NumeroCarga = ListaFuerzas.Count + 1;
                            carg.CargaNodal = false;
                            ListaFuerzas.Add(carg);
                        }
                        btnIncrementoTa.Checked = false;
                        form.Dispose();
                    }
                }
                if (IdNodo > 0)
                {
                    if (NodoInicial != null)
                    {
                        NodoFinal = ListaNodos[IdNodo - 1];
                        Vector3d Inicio = new Vector3d(NodoInicial.X, NodoInicial.Y, NodoInicial.Z);
                        Vector3d Final = new Vector3d(NodoFinal.X, NodoFinal.Y, NodoFinal.Z);

                        if (NodoInicial != NodoFinal)
                        {
                            if (btnBarraBiarticulada.Checked)
                            {
                                BarraArticulada barra = new BarraArticulada(Inicio, Final)
                                {
                                    NodoInicial = NodoInicial,
                                    NodoFinal = NodoFinal,
                                    NumeroBarra = ListaBarras.Count + 1
                                };
                                NodoInicial.Articulado = true;
                                NodoFinal.Articulado = true;
                                NodoInicial.ListaBarrasAsociadas.Add(barra);
                                NodoFinal.ListaBarrasAsociadas.Add(barra);
                                ListaBarras.Add(barra);
                            }
                            else if (btnBarraEmpArt.Checked)
                            {
                                BarraRigidaArticulada barra = new BarraRigidaArticulada(Inicio, Final)
                                {
                                    NodoInicial = NodoInicial,
                                    NodoFinal = NodoFinal,
                                    NumeroBarra = ListaBarras.Count + 1
                                };
                                NodoInicial.Rigido = true;
                                NodoFinal.Articulado = true;
                                NodoInicial.ListaBarrasAsociadas.Add(barra);
                                NodoFinal.ListaBarrasAsociadas.Add(barra);
                                ListaBarras.Add(barra);
                            }
                            else if (btnBarraEmpotrada.Checked)
                            {
                                BarraRigida barra = new BarraRigida(Inicio, Final)
                                {
                                    NodoInicial = NodoInicial,
                                    NodoFinal = NodoFinal,
                                    NumeroBarra = ListaBarras.Count + 1
                                };
                                NodoInicial.Rigido = true;
                                NodoFinal.Rigido = true;
                                NodoInicial.ListaBarrasAsociadas.Add(barra);
                                NodoFinal.ListaBarrasAsociadas.Add(barra);
                                ListaBarras.Add(barra);
                            }

                        }
                        BarraAux = null;
                        NodoInicial = null; NodoFinal = null;
                    }

                    if (btnBarraBiarticulada.Checked || btnBarraEmpArt.Checked || btnBarraEmpotrada.Checked)
                    {
                        if (NodoInicial == null)
                        {
                            NodoInicial = ListaNodos[IdNodo - 1];
                        }
                    }

                    if (btnAsentamiento.Checked)
                    {
                        FormAsentamiento form = new FormAsentamiento
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        if (DialogResult.OK == form.ShowDialog())
                        {

                        }
                        form.Dispose();
                        btnAsentamiento.Checked = false;
                        IdNodoSeleccionado = 0;
                        NodoSeleccionado = false;
                    }

                    if (CreandoBarra == false && btnFuerzaNodo.Checked == false && btnCargaDistribuida.Checked == false && btnMomentoNodo.Checked == false && !btnAsentamiento.Checked)
                    {
                        NodoSeleccionado = true;
                        IdNodoSeleccionado = IdNodo;
                        MoviendoNodo = true;
                        IdMoviendoNodo = IdNodo;
                    }
                    if (btnFuerzaNodo.Checked)
                    {
                        NodoSeleccionado = false;
                        IdNodoSeleccionado = 0;
                        FormCargaPuntual form = new FormCargaPuntual(ListaNodos[IdNodo - 1], false) { StartPosition = FormStartPosition.CenterParent };
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            FuerzaNodal puntual = new FuerzaNodal(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y, 0, 0)
                            {
                                Modulo = form.Modulo,
                                Theta = form.Angulo,
                                NodAdjunto = ListaNodos[IdNodo - 1],
                                NumeroCarga = ListaFuerzas.Count + 1,
                                CargaNodal = true
                            };
                            ListaFuerzas.Add(puntual);
                        }
                        form.Dispose();
                        btnFuerzaNodo.Checked = false;
                    }
                    if (btnMomentoNodo.Checked)
                    {
                        NodoSeleccionado = false;
                        IdNodoSeleccionado = 0;
                        FormCargaPuntual form = new FormCargaPuntual(ListaNodos[IdNodo - 1], true) { StartPosition = FormStartPosition.CenterParent };
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            MomentoNodal mom = new MomentoNodal(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y, 0, 0)
                            {
                                Modulo = form.Modulo,
                                NodAdjunto = ListaNodos[IdNodo - 1],
                                NumeroCarga = ListaFuerzas.Count + 1,
                                CargaNodal = true
                            };
                            ListaFuerzas.Add(mom);
                        }
                        form.Dispose();
                        btnMomentoNodo.Checked = false;
                    }
                }

                if (btnNodo.Checked)
                {
                    if (btnForzarCursor.Checked) //Solo cuando la rejilla está activada
                    {
                        resultx = xr / Malla;
                        resulty = yr / Malla;
                        Nodo nodo = new Nodo(Math.Round(resultx, 0, MidpointRounding.ToEven) * Malla, Math.Round(resulty, 0, MidpointRounding.ToEven) * Malla, 0)
                        {
                            ApoyoAsociado = null,
                            NumeroNodo = ListaNodos.Count + 1
                        };
                        ListaNodos.Add(nodo);
                    }
                    else
                    {
                        Nodo nodo = new Nodo(xr, yr, 0)
                        {
                            ApoyoAsociado = null,
                            NumeroNodo = ListaNodos.Count + 1
                        };
                        ListaNodos.Add(nodo);
                    }
                }

                if (btnDeslizaderaArticX.Checked && IdNodo > 0)
                {
                    ApoyoDeslizaderaArticX ap = new ApoyoDeslizaderaArticX(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y)
                    {
                        NodoAdjunto = ListaNodos[IdNodo - 1],
                        NumeroApoyo = ListaApoyos.Count + 1,
                    };
                    if (ListaNodos[IdNodo - 1].ApoyoAsociado == null) { ListaApoyos.Add(ap); }
                    ListaNodos[IdNodo - 1].ApoyoAsociado = ap;
                    //btnDeslizaderaArticX.Checked = false;
                }
                if (btnDeslizaderaArticY.Checked && IdNodo > 0)
                {
                    ApoyoDeslizaderaArticY ap = new ApoyoDeslizaderaArticY(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y)
                    {
                        NodoAdjunto = ListaNodos[IdNodo - 1],
                        NumeroApoyo = ListaApoyos.Count + 1,
                    };
                    if (ListaNodos[IdNodo - 1].ApoyoAsociado == null) { ListaApoyos.Add(ap); }
                    ListaNodos[IdNodo - 1].ApoyoAsociado = ap;
                    //btnDeslizaderaArticY.Checked = false;
                }

                if (btnDeslizaderaRigX.Checked && IdNodo > 0)
                {
                    ApoyoDeslizaderaRigX ap = new ApoyoDeslizaderaRigX(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y)
                    {
                        NodoAdjunto = ListaNodos[IdNodo - 1],
                        NumeroApoyo = ListaApoyos.Count + 1,
                    };
                    if (ListaNodos[IdNodo - 1].ApoyoAsociado == null) { ListaApoyos.Add(ap); }
                    ListaNodos[IdNodo - 1].ApoyoAsociado = ap;
                    //btnDeslizaderaRigX.Checked = false;
                }

                if (btnDeslizaderaRigY.Checked && IdNodo > 0)
                {
                    ApoyoDeslizaderaRigY ap = new ApoyoDeslizaderaRigY(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y)
                    {
                        NodoAdjunto = ListaNodos[IdNodo - 1],
                        NumeroApoyo = ListaApoyos.Count + 1,
                    };
                    if (ListaNodos[IdNodo - 1].ApoyoAsociado == null) { ListaApoyos.Add(ap); }
                    ListaNodos[IdNodo - 1].ApoyoAsociado = ap;
                    //btnDeslizaderaRigY.Checked = false;
                }

                if (btnApoyoFijo.Checked && IdNodo > 0)
                {
                    ApoyoArticulado ap = new ApoyoArticulado(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y)
                    {
                        NodoAdjunto = ListaNodos[IdNodo - 1],
                        NumeroApoyo = ListaApoyos.Count + 1,
                    };
                    if (ListaNodos[IdNodo - 1].ApoyoAsociado == null) { ListaApoyos.Add(ap); }
                    ListaNodos[IdNodo - 1].ApoyoAsociado = ap;
                    //btnApoyoFijo.Checked = false;
                }
                if (btnEmpotramiento.Checked && IdNodo > 0)
                {
                    ApoyoEmpotramiento ap = new ApoyoEmpotramiento(ListaNodos[IdNodo - 1].X, ListaNodos[IdNodo - 1].Y)
                    {
                        NodoAdjunto = ListaNodos[IdNodo - 1],
                        NumeroApoyo = ListaApoyos.Count + 1,
                    };
                    if (ListaNodos[IdNodo - 1].ApoyoAsociado == null) { ListaApoyos.Add(ap); }
                    ListaNodos[IdNodo - 1].ApoyoAsociado = ap;
                    //btnEmpotramiento.Checked = false;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (IdCarga > 0 || IdNodo > 0 || IdBarra > 0 || IdApoyo > 0)
                {
                    MenuEditarEstructura.Show(Cursor.Position);
                }
            }

            glControl3.Refresh();
        }

        private void GlControl3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (IdApoyo > 0)
            {
                ApoyoSeleccionado = true;
                IdApoyoSeleccionado = IdApoyo;
            }
            if (IdBarra > 0)
            {
                BarraSeleccionada = true;
                IdBarraSeleccionada = IdBarra;
                MoviendoBarra = true;
                IdMoviendoBarra = IdBarra;
            }
            if (IdNodo > 0 && !btnAsentamiento.Checked)
            {
                if (CreandoBarra == false)
                {
                    NodoSeleccionado = true;
                    IdNodoSeleccionado = IdNodo;
                    MoviendoNodo = true;
                    IdMoviendoNodo = IdNodo;
                }
            }

            if (IdCarga > 0)
            {
                CargaSeleccionada = true;
                IdCargaSeleccionada = IdCarga;
                if (ListaFuerzas[IdCarga - 1].GetType() == typeof(CargaDistribuida))
                {
                    FormCargaDistribuida form = new FormCargaDistribuida
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        ListaFuerzas[IdCarga - 1].Qi = form.Qi;
                        ListaFuerzas[IdCarga - 1].Qj = form.Qj;
                        ListaFuerzas[IdCarga - 1].SegunEje = form.Eje;
                    }
                    form.Dispose();
                }
                if (ListaFuerzas[IdCarga - 1].GetType() == typeof(FuerzaNodal))
                {
                    FormCargaPuntual form = new FormCargaPuntual(ListaFuerzas[IdCarga - 1].NodAdjunto, false)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        ListaFuerzas[IdCarga - 1].Modulo = form.Modulo;
                        ListaFuerzas[IdCarga - 1].Theta = form.Angulo;
                    }
                    form.Dispose();
                }
                if (ListaFuerzas[IdCarga - 1].GetType() == typeof(MomentoNodal))
                {
                    FormCargaPuntual form = new FormCargaPuntual(ListaFuerzas[IdCarga - 1].NodAdjunto, true)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        ListaFuerzas[IdCarga - 1].Modulo = form.Modulo;
                    }
                    form.Dispose();
                }
                if (ListaFuerzas[IdCarga - 1].GetType() == typeof(FuerzaBarra))
                {
                    FormFuerzaBarra form = new FormFuerzaBarra(ListaFuerzas[IdCarga - 1].BarraAsociada)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        ListaFuerzas[IdCarga - 1].Modulo = form.Modulo;
                        ListaFuerzas[IdCarga - 1].SegunEje = form.Eje;
                    }
                    form.Dispose();
                }
            }
        }

        private void GlControl3_MouseMove(object sender, MouseEventArgs e)
        {
            mouseanterior3 = mouse3; mouseanteriorgirar3 = mousegirar3;
            mouse3 = e; mousegirar3 = e;
            //---------------------------------------------------------------------------------
            if (RuedaPress3)
            {
                AngRotX3 += 180.0 * (mouseanteriorgirar3.Y - mousegirar3.Y) / glControl3.Width;
                AngRotY3 += 180.0 * (mouseanteriorgirar3.X - mousegirar3.X) / glControl3.Height;
                Cursor.Current = Cursors.Hand;
                glControl3.Refresh();
            }
            if (btnMover.Checked && agarrar == true)
            {
                cx3 -= (mouseanterior3.X - mouse3.X) * (xmax3 - xmin3) / glControl3.Width;
                cy3 += (mouseanterior3.Y - mouse3.Y) * (ymax3 - ymin3) / glControl3.Height;
            }
            //---------------------------------------------------------------------------------
            DibujarEstructura();

            xr = xmin3 + (1.0 / glControl3.Width) * e.X * (xmax3 - xmin3);
            yr = ymax3 - (1.0 / glControl3.Height) * e.Y * (ymax3 - ymin3);
            txtCoordReales.Text = new Vector2d(Math.Round(xr, 2), Math.Round(yr, 2)).ToString();
            txtCoordReales.Refresh();
            FinalBarra = new Vector3d(xr, yr, 0);
            if (NodoInicial != null) { BarraAux = new Barra(new Vector3d(NodoInicial.X, NodoInicial.Y, NodoInicial.Z), FinalBarra); }
            ShowProperties();

            if (btnBarraEmpArt.Checked == false || btnBarraBiarticulada.Checked == false || btnBarraEmpotrada.Checked == false) { FiguraAux = null; }
            if (btnNodo.Checked == false) { NodoAux = null; }

            //--------------------------------------------------------------------------------------------------------------------------
            int cont1 = ListaNodos.Count;
            int cont2 = ListaBarras.Count + ListaNodos.Count;
            int cont3 = ListaApoyos.Count + ListaNodos.Count + ListaBarras.Count;
            int[] Buff = new int[512];
            GL.SelectBuffer(Buff.Length, Buff);
            GL.RenderMode(RenderingMode.Select);
            GL.InitNames();
            GL.PushName(int.MaxValue);
            GL.Viewport(0, 0, glControl3.Width, glControl3.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Translate(glControl3.Width - 2 * e.X, glControl3.Height - 2 * (glControl3.Height - e.Y), 0);
            GL.Scale(glControl3.Width, glControl3.Height, 1);
            //Lo mismo que donde se pinta GLcontrol3           
            GL.Ortho(xmin3, xmax3, ymin3, ymax3, 3 * xmin3, 3 * xmax3);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //Aqui dibujamos desde cero con los LoadName

            GL.Clear(ClearBufferMask.ColorBufferBit);
            //GL.Rotate(-AngRotX3, 1, 0, 0);
            //GL.Rotate(-AngRotY3, 0, 1, 0);

            for (int i = 0; i < ListaNodos.Count; i++)
            {
                GL.LoadName(i + 1);
                ListaNodos[i].Dibujar2D(Malla / 6.0, 1.5, 0.0, 0.3);
            }

            for (int i = 0; i < ListaBarras.Count; i++)
            {
                GL.LoadName(cont1 + i + 1);
                ListaBarras[i].Dibujar2D(Malla / 4.0, 0.65, 0.65, 0.65);
            }

            for (int i = 0; i < ListaApoyos.Count; i++)
            {
                GL.LoadName(cont2 + i + 1);
                ListaApoyos[i].Dibujar2D(Malla, 2.0 / 255, 160.0 / 255, 112.0 / 255);
            }

            for (int i = 0; i < ListaFuerzas.Count; i++)
            {
                GL.LoadName(cont3 + i + 1);
                ListaFuerzas[i].Dibujar2D(Malla / 6.0, 0.7, 0.7, 0, ListaFuerzas[i].Theta);
            }


            //Aqui terminamos de dibujar
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            hitsGlcontrol3 = GL.RenderMode(RenderingMode.Render);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();

            //Si hits >0 raton tiene algo debajo y hay que procesarlo
            //En buff[3] nos sale el identificador de la figura seleccionada 
            //Hay que devolver este identificador y procesarlo 
            if (hitsGlcontrol3 > 0)
            {
                if (Buff[3] > cont3)
                {
                    IdCarga = Buff[3] - cont3;
                }
                else if (Buff[3] <= cont1)
                {
                    IdNodo = Buff[3];
                }
                else if (Buff[3] <= cont2)
                {
                    IdBarra = Buff[3] - cont1;
                }
                else if (Buff[3] <= cont3)
                {
                    IdApoyo = Buff[3] - cont2;
                }
            }
            //Si no hay nada debajo del mouse el identificador es cero
            if (hitsGlcontrol3 == 0)
            {
                IdNodo = 0;
                IdBarra = 0;
                IdApoyo = 0;
                IdCarga = 0;
            }

            txtNodoCx.Refresh();
            txtNodoCy.Refresh();
            glControl3.Refresh();
        }

        private void GlControl3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                RuedaPress3 = false;
            }
        }

        private void GlControl3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                RuedaPress3 = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                BarraAux = null;
                foreach (ToolStripButton btn in BarraHerramientas.Items)
                {
                    btn.Checked = false;
                }
                NodoAux = null; NodoInicial = null; NodoFinal = null;
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (IdNodoSeleccionado > 0)
                {
                    //Quitamos las barras asociadas al nodo
                    for (int i = ListaBarras.Count - 1; i >= 0; i--)
                    {
                        if (ListaBarras[i].NodoInicial == ListaNodos[IdNodoSeleccionado - 1]) { ListaBarras.RemoveAt(i); }
                        if (ListaBarras[i].NodoFinal == ListaNodos[IdNodoSeleccionado - 1]) { ListaBarras.RemoveAt(i); }
                    }
                    //Quitamos los apoyos asociados al nodo
                    for (int i = ListaApoyos.Count - 1; i >= 0; i--)
                    {
                        if (ListaApoyos[i].NodoAdjunto == ListaNodos[IdNodoSeleccionado - 1]) { ListaApoyos.RemoveAt(i); }
                    }
                    //Quitamos las cargas asociadas al nodo
                    for (int i = ListaFuerzas.Count - 1; i >= 0; i--)
                    {
                        if (ListaFuerzas[i].NodAdjunto == ListaNodos[IdNodoSeleccionado - 1]) { ListaFuerzas.RemoveAt(i); }
                    }
                    Renumerar();
                    ListaNodos.RemoveAt(IdNodoSeleccionado - 1);
                }
                if (IdBarraSeleccionada > 0)
                {
                    for (int i = ListaNodos.Count - 1; i >= 0; i--)
                    {
                        for (int j = ListaNodos[i].ListaBarrasAsociadas.Count - 1; j >= 0; j--)
                        {
                            if (ListaNodos[i].ListaBarrasAsociadas[j] == ListaBarras[IdBarraSeleccionada - 1]) { ListaNodos[i].ListaBarrasAsociadas.RemoveAt(j); }
                        }
                    }
                    for (int j = ListaFuerzas.Count - 1; j >= 0; j--)
                    {
                        if (IdBarra == ListaFuerzas[j].BarraAsociada.NumeroBarra) { ListaFuerzas.RemoveAt(j); }
                    }
                    ListaBarras.RemoveAt(IdBarraSeleccionada - 1);
                    Renumerar();
                }
                if (IdApoyoSeleccionado > 0)
                {
                    ListaNodos[ListaApoyos[IdApoyoSeleccionado - 1].NodoAdjunto.NumeroNodo - 1].ApoyoAsociado = null;
                    ListaApoyos.RemoveAt(IdApoyoSeleccionado - 1);
                    Renumerar();
                }
                if (IdCargaSeleccionada > 0)
                {
                    ListaBarras[ListaFuerzas[IdCargaSeleccionada - 1].BarraAsociada.NumeroBarra - 1].Carga = null;
                    ListaFuerzas.RemoveAt(IdCargaSeleccionada - 1);
                }
                NodoSeleccionado = false;
                IdNodoSeleccionado = 0;
                BarraSeleccionada = false;
                IdBarraSeleccionada = 0;
                ApoyoSeleccionado = false;
                IdApoyoSeleccionado = 0;
                IdCargaSeleccionada = 0;
                CargaSeleccionada = false;

            }
            glControl3.Refresh();
        }

        private void GlControl3_Paint(object sender, PaintEventArgs e)
        {
            GL.Viewport(0, 0, glControl3.Width, glControl3.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Calcular_dimensiones_iniciales3();
            //Dimensiones();
            GL.Ortho(xmin3, xmax3, ymin3, ymax3, -100, 300);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.DepthFunc(DepthFunction.Less);
            GL.Enable(EnableCap.DepthTest);

            //GL.Rotate(-AngRotX3, 1, 0, 0);
            //GL.Rotate(-AngRotY3, 0, 1, 0);
            //Renumerar();                      

            //-----------------------------------------------------------------------------------------------------------
            //LUZ ACTIVADA-LUZ ACTIVADA-LUZ ACTIVADA-LUZ ACTIVADA-LUZ ACTIVADA-LUZ ACTIVADA-LUZ ACTIVADA-LUZ ACTIVADA-
            GL.Enable(EnableCap.Lighting);
            {
                Ejes(0, 0, 0, 0.9 * Const3);
            }

            if (btnEjesLocales.Checked)
            {
                foreach (Barra barr in ListaBarras)
                {
                    double x = barr.X0 + (barr.X1 - barr.X0) / 2;
                    double y = barr.Y0 + (barr.Y1 - barr.Y0) / 2;
                    double AngX = Math.Atan2(barr.Y1 - barr.Y0, barr.X1 - barr.X0) * 180 / Math.PI;
                    double AngY = AngX + 90;
                    Flecha EjeX = new Flecha(x, y, 10, 7);
                    EjeX.FlechaSimple(0.6, 0, 0, Const3, 0, AngX);
                    Flecha EjeY = new Flecha(x, y, 10, 7);
                    EjeY.FlechaSimple(0, 0.6, 0, Const3, 0, AngY);
                }
            }
            if (NodoAux != null)
            {
                NodoAux.Dibujar2D(Malla / 6.0, 0.0, 0.3, 0.7);
            }
            for (int i = 0; i < ListaNodos.Count; i++)
            {
                if (IdNodo - 1 == i || IdNodoSeleccionado - 1 == i)
                {
                    ListaNodos[i].Dibujar2D(Malla / 6.0, 1.0, 1.0 / 3, 0);
                }
                else
                {
                    ListaNodos[i].Dibujar2D(Malla / 6.0, 0.0, 0.3, 0.7);
                }

            }

            if (BarraAux != null)
            {
                BarraAux.Dibujar2D(Malla / 4.0, 0.65, 0.65, 0.65);
            }

            for (int i = 0; i < ListaBarras.Count; i++)
            {
                if ((IdBarra - 1 == i || IdBarraSeleccionada - 1 == i) && IdNodo == 0 && IdCarga == 0)
                {
                    ListaBarras[i].Dibujar2D(Malla / 4.0, 1.0, 1.0 / 3, 0);
                }
                else
                {
                    if (ListaBarras[i].CargaTermica && ListaBarras[i].Carga.Tmedia != 0)
                    {
                        ListaBarras[i].Dibujar2D(Malla / 4.0, 1.0, 0.25, 0.25);
                    }
                    else
                    {
                        ListaBarras[i].Dibujar2D(Malla / 4.0, 0.65, 0.65, 0.65);
                    }
                }
            }


            for (int i = 0; i < ListaApoyos.Count; i++)
            {
                if (IdApoyo - 1 == i || IdApoyoSeleccionado - 1 == i)//Color con mouse encima
                {
                    ListaApoyos[i].Dibujar2D(Malla, 1.0, 1.0 / 3, 0);
                }
                else
                {
                    ListaApoyos[i].Dibujar2D(Malla, 2.0 / 255, 160.0 / 255, 112.0 / 255);
                }
            }

            for (int i = 0; i < ListaFuerzas.Count; i++)
            {
                if (IdCarga - 1 == i || IdCargaSeleccionada - 1 == i)//Color con mouse encima
                {
                    ListaFuerzas[i].Dibujar2D(Malla / 6.0, 1.0, 1.0 / 3, 0, ListaFuerzas[i].Theta);
                }
                else
                {
                    ListaFuerzas[i].Dibujar2D(Malla / 6.0, 0.7, 0.0, 0, ListaFuerzas[i].Theta);
                }
            }

            //LUZ DESACTIVADA-LUZ DESACTIVADA-LUZDESACTIVADA-LUZ DESACTIVADA-LUZ DESACTIVADA-LUZDESACTIVADA
            GL.Disable(EnableCap.Lighting);
            Cuadricula3();

            //CopyAnObject<List<Barra>> Cop = new CopyAnObject<List<Barra>>();
            //ListaBarrasAnterior = Cop.Copiar(ListaBarras);

            //if(ListaBarras != ListaBarrasAnterior && EnergiaElasticaPositiva)
            //{
            //    MetodoMatricial();
            //}

            foreach (Barra bar in ListaBarras)
            {
                if (btnDistribucionFlectores.Checked) { bar.DibujarFlector(EscFlector); }
                if (btnDistribucionCortantes.Checked) { bar.DibujarCortante(EscCortante); }
                if (btnDistribucionAxiales.Checked) { bar.DibujarAxial(EscAxiales); }
                if (btnDeformada.Checked) { bar.Deformada(EscDeformada); }
            }


            if (!MoviendoNodo)
            {
                if (cmnuNumBarras.Checked)
                {
                    foreach (Barra bar in ListaBarras)
                    {
                        GL.PushMatrix();
                        double x = bar.X0 + (bar.X1 - bar.X0) / 2.0;
                        double y = bar.Y0 + (bar.Y1 - bar.Y0) / 2.0;
                        GL.Translate(x, y, 0);
                        GL.Scale(0.2 * Const3, 0.2 * Const3, 0.2 * Const3);
                        DrawText(0, 0, bar.NumeroBarra.ToString(CultureInfo.InvariantCulture), 0.0, 0.0, 0.0, 0, 0, 1);
                        GL.PopMatrix();
                    }
                }

                if (cmnuNumNodos.Checked)
                {
                    foreach (Nodo nod in ListaNodos)
                    {
                        GL.PushMatrix();
                        GL.Translate(nod.X + 3 * Const3, nod.Y, 0);
                        GL.Scale(0.2 * Const3, 0.2 * Const3, 0.2 * Const3);
                        DrawText(0, 0, nod.NumeroNodo.ToString(CultureInfo.InvariantCulture), 0.0, 0.0, 0.0, 0, 0, 1);
                        GL.PopMatrix();
                    }
                }
            }

            Vector2d txtEjeX = PantallaAReales(BuffGlobalesX[1], BuffGlobalesX[2], 3);
            Vector2d txtEjeY = PantallaAReales(BuffGlobalesY[1], BuffGlobalesY[2], 3);
            //Vector2d txtEjeZ = PantallaAReales(BuffGlobalesZ[1], BuffGlobalesZ[2], 3);
            double h = glControl3.Height;
            double w = glControl3.Width;

            if (BuffGlobalesX[1] > 0 && BuffGlobalesX[1] < w && BuffGlobalesX[2] > 0 && BuffGlobalesX[2] < h)
            {
                DrawText(txtEjeX.X, -txtEjeX.Y - 2 * cy3, "X", 0.7, 0.0, 0.0, 0, 0, 0.25 * Const3);
            }

            if (BuffGlobalesY[1] > 0 && BuffGlobalesY[1] < w && BuffGlobalesY[2] > 0 && BuffGlobalesY[2] < h)
            {
                DrawText(txtEjeY.X, -txtEjeY.Y - 2 * cy3, "Y", 0.0, 0.7, 0.0, 0, 0, 0.25 * Const3);
            }
            //if (BuffGlobalesZ[1] > 0 && BuffGlobalesZ[1] < w && BuffGlobalesZ[2] > 0 && BuffGlobalesZ[2] < h) DrawText(txtEjeZ.X, -txtEjeZ.Y - 2 * cy3, "Z", 0.0, 0.0, 0.7, AngRotX3, AngRotY3, 0.25 * Const3);

            glControl3.SwapBuffers();
        }

        private void GlControl3_Load(object sender, EventArgs e)
        {
            //Textures
            GL.Enable(EnableCap.LineSmooth);
            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.PolygonSmooth);

            FontTextureID = LoadTexture(Settings.FontBitmapFilename);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            Luces(new Vector3(0.6f, 0.6f, 0.6f), new Vector3(0.4f, 0.4f, 0.4f), new Vector3(0.0f, 0.0f, 0.0f), 50.0f);
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.LoadIdentity();
        }

        private void GlControl2_Paint(object sender, PaintEventArgs e)
        {
            glControl2.Context.MakeCurrent(glControl2.WindowInfo);

            //Parametros circulo de Mohr
            double C, R;
            C = (Ixg + Iyg) / 2;
            R = Math.Sqrt(Math.Pow((Ixg - Iyg) / 2, 2) + Math.Pow(Ixgyg, 2));

            GL.Viewport(0, 0, glControl2.Width, glControl2.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2 * R + C, 2 * R + C, -2 * R * glControl2.Height / glControl2.Width, 2 * R * glControl2.Height / glControl2.Width, -100, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.DepthFunc(DepthFunction.Less);
            GL.Enable(EnableCap.DepthTest);

            //EJES
            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.5, 0.5, 0.5);
            GL.Vertex2(-2 * R + C, 0);
            GL.Vertex2(2 * R + C, 0);
            GL.End();

            CirculoMohr = new Arco(C, 0, R, 0, 360, 1.25f);
            CirculoMohr.Dibujar(1.0, 0.0, 0.0);

            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(0.0, 0.0, 0.5);
            GL.Vertex2(Ixg, Ixgyg);
            GL.Vertex2(Iyg, -Ixgyg);
            GL.Vertex2(Ixg, Ixgyg);
            GL.Vertex2(Ixg, 0);
            GL.Vertex2(Iyg, -Ixgyg);
            GL.Vertex2(Iyg, 0);
            GL.End();

            GL.PointSize(5f);
            GL.Color3(0, 0, 0.7);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(Ixg, Ixgyg, 1);
            GL.End();

            GL.PointSize(5f);
            GL.Color3(0, 0.7, 0);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(Iyg, -Ixgyg, 1);
            GL.End();

            DrawText(Ixg + 0.2 * R, Ixgyg,"Z", 0.0, 0.0, 0.7, 0, 0, R / 50);
            DrawText(Iyg + 0.2 * R, -Ixgyg, "Y", 0.0, 0.7, 0.0, 0, 0, R / 50);


            glControl2.SwapBuffers();
            glControl1.Context.MakeCurrent(glControl1.WindowInfo);

        }

        private void GlControl2_Load(object sender, EventArgs e)
        {
            //Textures
            GL.Enable(EnableCap.LineSmooth);
            GL.Enable(EnableCap.PointSmooth);
            GL.Enable(EnableCap.PointSmooth);
            FontTextureID = LoadTexture(Settings.FontBitmapFilename);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
        }

        private void GlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            double resultx, resulty;
            mouseanterior1 = mouse1; mouseanteriorgirar1 = mousegirar1;
            mouse1 = e; mousegirar1 = e;
            //---------------------------------------------------------------------------------------------------
            xr = xmin1 + (1.0 / glControl1.Width) * e.X * (xmax1 - xmin1);
            yr = ymax1 - (1.0 / glControl1.Height) * e.Y * (ymax1 - ymin1);
            ex = (xr - xmin1) * (glControl1.Width) / (xmax1 - xmin1);
            ey = -(yr - ymax1) * (glControl1.Height) / (ymax1 - ymin1);

            txtCoordReales.Text = new Vector2d(Math.Round(xr, 2), Math.Round(yr, 2)).ToString();
            txtCoordReales.Refresh();
            if (IdFiguras > 0)
            {
                Cursor.Current = Cursors.Cross;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }
            if (btnRectangulo.Checked || btnCirculo.Checked || btnCuartoCirculo.Checked || btnSemiCirculo.Checked || btnTrianguloRectangulo.Checked)
            {
                Dibujando = true;
            }
            else
            {
                Dibujando = false;
            }
            //---------------------------------------------------------------------------------------------------
            if (RuedaPress1)
            {
                AngRotX1 += 180.0 * (mouseanteriorgirar1.Y - mousegirar1.Y) / glControl1.Width;
                AngRotY1 += 180.0 * (mouseanteriorgirar1.X - mousegirar1.X) / glControl1.Height;
            }

            if (IdArrastrar > 0)
            {
                txtDx.Text = Convert.ToString(ListaFiguras[IdArrastrar - 1].X, CultureInfo.InvariantCulture);
                txtDy.Text = Convert.ToString(ListaFiguras[IdArrastrar - 1].Y, CultureInfo.InvariantCulture);
                txtDx.Refresh();
                txtDy.Refresh();
            }
            //---------------------------------------------------------------------------------------------------
            if (btnMover.Checked && agarrar == true)
            {
                cx1 -= (mouseanterior1.X - mouse1.X) * (xmax1 - xmin1) / glControl1.Width;
                cy1 += (mouseanterior1.Y - mouse1.Y) * (ymax1 - ymin1) / glControl1.Height;
            }

            if (IdFiguras > 0) { FiguraDebajo = true; } else { FiguraDebajo = false; }
            if (IdPuntos > 0) { PuntoDebajo = true; } else { PuntoDebajo = false; }


            if (btnForzarCursor.Checked && IdFiguras == 0) //Solo cuando la rejilla está activada y no estamos dentro de la figura
            {
                resultx = xr / Malla;
                resulty = yr / Malla;
                PuntoAux = new Punto(Math.Round(resultx, 0, MidpointRounding.ToEven) * Malla, Math.Round(resulty, 0, MidpointRounding.ToEven) * Malla);
            }
            else
            {
                PuntoAux = new Punto(xr, yr);
            }


            if (btnForzarCursor.Checked)
            {
                xf = PuntoAux.X;
                yf = PuntoAux.Y;
            }
            else
            {
                xf = xr;
                yf = yr;
            }


            if (FiguraDebajo == false && PuntoDebajo == false && MouseIzdaDown && BtnClic || FiguraSeleccionada || MoviendoPunto || PuntoSeleccionado)
            {
                ShowProperties();
            }

            if (FiguraDebajo == false && PuntoDebajo == false && MouseIzdaDown == true)
            {

                if (FiguraDebajo == false && MouseIzdaDown == true)
                {

                    if (btnRectangulo.Checked)
                    {
                        FiguraAux = new Rectangulo(xf - xinicio, yf - yinicio, xinicio + (xf - xinicio) / 2, yinicio + (yf - yinicio) / 2, 0);
                    }
                    if (btnCirculo.Checked)
                    {
                        double x = xf - xinicio, y = yf - yinicio;
                        FiguraAux = new Circulo(xinicio, yinicio, Math.Sqrt(x * x + y * y));
                    }

                    if (btnCuartoCirculo.Checked)
                    {
                        double x = xf - xinicio, y = yf - yinicio, theta = Math.Atan2(y, x) * 180.0 / Math.PI;
                        FiguraAux = new CuartoCirculo(xinicio, yinicio, Math.Sqrt(x * x + y * y), theta);
                    }

                    if (btnSemiCirculo.Checked)
                    {
                        double x = xf - xinicio, y = yf - yinicio, theta = Math.Atan2(y, x) * 180.0 / Math.PI;
                        FiguraAux = new Semicirculo(xinicio, yinicio, Math.Sqrt(x * x + y * y), theta);
                    }

                    if (btnTrianguloRectangulo.Checked)
                    {
                        double theta = 0;
                        FiguraAux = new TrianguloRectangulo(xf - xinicio, yinicio - yf, xinicio, yf, theta);

                    }
                    if (FiguraAux != null)
                    {
                        txtAlto.Text = Convert.ToString(FiguraAux.Alto, CultureInfo.InvariantCulture);
                        txtAncho.Text = Convert.ToString(FiguraAux.Ancho, CultureInfo.InvariantCulture);
                        txtDx.Text = Convert.ToString(FiguraAux.X, CultureInfo.InvariantCulture);
                        txtDy.Text = Convert.ToString(FiguraAux.Y, CultureInfo.InvariantCulture);
                        txtRadio.Text = Convert.ToString(FiguraAux.R, CultureInfo.InvariantCulture);
                        txtAngulo.Text = Convert.ToString(FiguraAux.Theta, CultureInfo.InvariantCulture);
                        txtAlto.Refresh();
                        txtAncho.Refresh();
                        txtDx.Refresh();
                        txtDy.Refresh();
                        txtRadio.Refresh();
                        txtAngulo.Refresh();
                    }
                }
            }


            if (MouseIzdaDown == true && e.Button == MouseButtons.Left && btnForzarCursor.Checked)
            {
                double dx, dy, xinicial, yinicial;

                if (FiguraDebajo && IdArrastrar > 0 && btnVistaAxonometrica.Checked == false)
                {
                    dx = (xr) / (Malla / 2); //punto mas cercano de la malla respecto al cursor
                    dy = (yr) / (Malla / 2);
                    xinicial = Xi / (Malla / 2);
                    yinicial = Yi / (Malla / 2);
                    ListaFiguras[IdArrastrar - 1].X = Math.Round(dx, 0, MidpointRounding.ToEven) * (Malla / 2) + ObjectPosX0 - Math.Round(xinicial, 0, MidpointRounding.ToEven) * (Malla / 2);
                    ListaFiguras[IdArrastrar - 1].Y = Math.Round(dy, 0, MidpointRounding.ToEven) * (Malla / 2) + ObjectPosY0 - Math.Round(yinicial, 0, MidpointRounding.ToEven) * (Malla / 2);
                }

                if (MoviendoPunto)
                {
                    ListaPuntos[IdMoviendoPunto - 1].X = PuntoAux.X;
                    ListaPuntos[IdMoviendoPunto - 1].Y = PuntoAux.Y;
                }
            }

            if (MouseIzdaDown == true && e.Button == MouseButtons.Left && btnForzarCursor.Checked == false)
            {
                if (FiguraDebajo && IdArrastrar > 0 && btnVistaAxonometrica.Checked == false)
                {
                    //Modificamos los valores del centro libremente
                    ListaFiguras[IdArrastrar - 1].X = ObjectPosX0 + xr - Xi;
                    ListaFiguras[IdArrastrar - 1].Y = ObjectPosY0 + yr - Yi;
                }

                if (PuntoDebajo && IdPuntos > 0)
                {
                    ListaPuntos[IdPuntos - 1].X = ObjectPosX0 + xr - Xi;
                    ListaPuntos[IdPuntos - 1].Y = ObjectPosY0 + yr - Yi;
                }

            }

            int cont = ListaFiguras.Count;
            int cont2 = ListaFiguras.Count + ListaPuntos.Count;
            int[] buff = new int[512];
            GL.SelectBuffer(buff.Length, buff);
            GL.RenderMode(RenderingMode.Select);
            GL.InitNames();
            GL.PushName(int.MaxValue);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Translate(glControl1.Width - 2 * e.X, glControl1.Height - 2 * (glControl1.Height - e.Y), 0);
            GL.Scale(glControl1.Width, glControl1.Height, 1);
            //Aqui tiene que haber lo mismo que donde se pinta GLcontrol1
            GL.Ortho(xmin1, xmax1, ymin1, ymax1, 3 * xmin1, 3 * xmax1);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();
            //Aqui dibujamos desde cero con los LoadName

            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Rotate(-AngRotX1, 1, 0, 0);
            GL.Rotate(-AngRotY1, 0, 1, 0);

            for (int i = 0; i < ListaFiguras.Count; i++)
            {
                GL.LoadName(i + 1);
                ListaFiguras[i].Dibujar(RR, GG, BB);
            }

            for (int i = 0; i < ListaPuntos.Count; i++)
            {
                GL.LoadName(cont + i + 1);
                ListaPuntos[i].Dibujar((float)R2, 60 / 255, 238 / 255, 238 / 255);
            }
            for (int i = 0; i < ListaPuntosCT.Count; i++)
            {
                GL.LoadName(cont2 + i + 1);
                ListaPuntosCT[i].Dibujar((float)(R2 * 0.7), 0, 0, 1);
            }

            //Aqui terminamos de dibujar
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            hitsGlcontrol1 = GL.RenderMode(RenderingMode.Render);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.PopMatrix();


            //Si hits >0 raton tiene algo debajo y hay que procesarlo
            //En buff[3] nos sale el identificador de la figura seleccionada 
            //Hay que devolver este identificador y procesarlo 
            if (hitsGlcontrol1 > 0)
            {
                if (buff[3] <= cont)
                {
                    IdFiguras = buff[3];
                }
                else if (buff[3] <= cont2)
                {
                    IdPuntos = buff[3] - cont;
                }
                else
                {
                    IdPuntoCT = buff[3] - cont2;
                }
                //El identificador devuelve un numero que es el orden en el que se han dibujado las figuras
            }
            //Si no hay nada debajo del mouse el identificador es cero
            if (hitsGlcontrol1 == 0)
            {
                IdPuntos = 0;
                IdFiguras = 0;
                IdPuntoCT = 0;
            }

            if (agarrar == true) { FiguraAux = null; }

            txtCdgX.Text = Math.Round(cdgx, Decimales).ToString(CultureInfo.InvariantCulture); txtCdgX.Refresh();
            txtCdgY.Text = Math.Round(cdgy, Decimales).ToString(CultureInfo.InvariantCulture); txtCdgY.Refresh();
            txtIx.Text = Math.Round(Ix, Decimales).ToString(CultureInfo.InvariantCulture); txtIx.Refresh();
            txtIy.Text = Math.Round(Iy, Decimales).ToString(CultureInfo.InvariantCulture); txtIy.Refresh();
            txtIxy.Text = Math.Round(Ixy, Decimales).ToString(CultureInfo.InvariantCulture); txtIxy.Refresh();
            txtArea.Text = Math.Round(AreaTotal, Decimales).ToString(CultureInfo.InvariantCulture); txtArea.Refresh();
            txtIxg.Text = Math.Round(Ixg, Decimales).ToString(CultureInfo.InvariantCulture); txtIxg.Refresh();
            txtIyg.Text = Math.Round(Iyg, Decimales).ToString(CultureInfo.InvariantCulture); txtIyg.Refresh();
            txtIxgyg.Text = Math.Round(Ixgyg, Decimales).ToString(CultureInfo.InvariantCulture); txtIxgyg.Refresh();
            txtIxp.Text = Math.Round(Ixp, Decimales).ToString(CultureInfo.InvariantCulture); txtIxp.Refresh();
            txtIyp.Text = Math.Round(Iyp, Decimales).ToString(CultureInfo.InvariantCulture); txtIyp.Refresh();
            txtIxPers.Text = Math.Round(Ixpers, Decimales).ToString(CultureInfo.InvariantCulture); txtIxPers.Refresh();
            txtIyPers.Text = Math.Round(Iypers, Decimales).ToString(CultureInfo.InvariantCulture); txtIyPers.Refresh();
            txtIxyPers.Text = Math.Round(Ixypers, Decimales).ToString(CultureInfo.InvariantCulture); txtIxyPers.Refresh();
            txtRGiroX.Text = Math.Round(ix, Decimales).ToString(CultureInfo.InvariantCulture); txtRGiroX.Refresh();
            txtRGiroY.Text = Math.Round(iy, Decimales).ToString(CultureInfo.InvariantCulture); txtRGiroY.Refresh();
            txtRGiroXG.Text = Math.Round(ixG, Decimales).ToString(CultureInfo.InvariantCulture); txtRGiroXG.Refresh();
            txtRGiroYG.Text = Math.Round(iyG, Decimales).ToString(CultureInfo.InvariantCulture); txtRGiroYG.Refresh();
            txtSigma.Text = Math.Round(Sigma, 6).ToString(CultureInfo.InvariantCulture); txtSigma.Refresh();
            txtPhi.Text = Math.Round(Phi, Decimales).ToString(CultureInfo.InvariantCulture); txtPhi.Refresh();
            txtIpolar.Text = Math.Round(Ip, Decimales).ToString(CultureInfo.InvariantCulture); txtIpolar.Refresh();
            txtIpolarG.Text = Math.Round(Ipg, Decimales).ToString(CultureInfo.InvariantCulture); txtIpolarG.Refresh();
            txtWx.Text = Math.Round(Wx, Decimales).ToString(CultureInfo.InvariantCulture); txtWx.Refresh();
            txtWy.Text = Math.Round(Wy, Decimales).ToString(CultureInfo.InvariantCulture); txtWy.Refresh();
            txtWxg.Text = Math.Round(Wxg, Decimales).ToString(CultureInfo.InvariantCulture); txtWxg.Refresh();
            txtWyg.Text = Math.Round(Wyg, Decimales).ToString(CultureInfo.InvariantCulture); txtWyg.Refresh();


            txtSigmaN.Refresh();
            txtSigmaMy.Refresh();
            txtSigmaMx.Refresh();
            txtSigmaMin.Refresh();

            CalculoPandeo();

            glControl1.Refresh();
        }

        private void GlControl1_MouseUp(object sender, MouseEventArgs e)
        {
            RectanguloSeleccion = false;

            if (e.Button == MouseButtons.Middle)
            {
                RuedaPress1 = false;
                Cursor.Current = Cursors.Default;
            }

            if (e.Button == MouseButtons.Right)
            {
                MouseDchaDown = false;
            }


            if (e.Button == MouseButtons.Left)
            {
                IdMoviendoPunto = 0;
                MoviendoPunto = false;
                MouseIzdaDown = false;

                if (btnMover.Checked)
                {
                    agarrar = false;
                }

                if (FiguraDebajo == false && MouseIzdaDown == false && FiguraAux != null)
                {
                    BtnClic = false;

                    if (btnRectangulo.Checked && (xf - xinicio != 0 && yf - yinicio != 0))
                    {
                        Rectangulo rect = new Rectangulo(FiguraAux.Ancho, FiguraAux.Alto, FiguraAux.X, FiguraAux.Y, 0)
                        {
                            NumeroFigura = ListaFiguras.Count + 1
                        };
                        ListaFiguras.Add(rect);
                        btnRectangulo.Checked = false;
                        FiguraSeleccionada = true;
                        IdFiguraSeleccionada = ListaFiguras.LastIndexOf(rect) + 1;
                    }
                    if (btnCirculo.Checked)
                    {
                        Circulo circ = new Circulo(FiguraAux.X, FiguraAux.Y, FiguraAux.R)
                        {
                            NumeroFigura = ListaFiguras.Count + 1
                        };
                        ListaFiguras.Add(circ);
                        btnCirculo.Checked = false;
                        FiguraSeleccionada = true;
                        IdFiguraSeleccionada = ListaFiguras.LastIndexOf(circ) + 1;
                    }

                    if (btnCuartoCirculo.Checked)
                    {
                        double x = xf - xinicio, y = yf - yinicio, theta = Math.Atan2(y, x) * 180.0 / Math.PI;
                        CuartoCirculo cuart = new CuartoCirculo(FiguraAux.X, FiguraAux.Y, FiguraAux.R, theta)
                        {
                            NumeroFigura = ListaFiguras.Count + 1
                        };
                        ListaFiguras.Add(cuart);
                        btnCuartoCirculo.Checked = false;
                        FiguraSeleccionada = true;
                        IdFiguraSeleccionada = ListaFiguras.LastIndexOf(cuart) + 1;
                    }

                    if (btnSemiCirculo.Checked)
                    {
                        double x = xf - xinicio, y = yf - yinicio, theta = Math.Atan2(y, x) * 180.0 / Math.PI;
                        Semicirculo semicirc = new Semicirculo(FiguraAux.X, FiguraAux.Y, FiguraAux.R, theta)
                        {
                            NumeroFigura = ListaFiguras.Count + 1
                        };
                        ListaFiguras.Add(semicirc);
                        btnSemiCirculo.Checked = false;
                        FiguraSeleccionada = true;
                        IdFiguraSeleccionada = ListaFiguras.LastIndexOf(semicirc) + 1;
                    }

                    if (btnTrianguloRectangulo.Checked && (xf - xinicio != 0 && yf - yinicio != 0))
                    {
                        TrianguloRectangulo triang = new TrianguloRectangulo(xf - xinicio, yinicio - yf, FiguraAux.X, FiguraAux.Y, 0)
                        {
                            NumeroFigura = ListaFiguras.Count + 1
                        };
                        ListaFiguras.Add(triang);
                        btnTrianguloRectangulo.Checked = false;
                        FiguraSeleccionada = true;
                        IdFiguraSeleccionada = ListaFiguras.LastIndexOf(triang) + 1;
                    }
                    FiguraAux = null;
                }
            }
            if (IdFiguras > 0 && e.Button == MouseButtons.Left)
            {

                IdArrastrar = 0;
            }
            glControl1.Refresh();
        }

        private void GlControl1_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                RuedaPress1 = true;
            }

            if (e.Button == MouseButtons.Left)
            {
                MouseIzdaDown = true;
                if (IdFiguras > 0)
                {
                    Xi = xr;
                    Yi = yr;
                    ObjectPosX0 = ListaFiguras[IdFiguras - 1].X;
                    ObjectPosY0 = ListaFiguras[IdFiguras - 1].Y;
                    IdArrastrar = IdFiguras;
                    //Guardamos la figura con este estado
                    Figura fig = CopyAnObject<Figura>.Copiar(ListaFiguras[IdFiguras - 1]);
                    ListaUndo.Add(fig);
                    //-----------------------------------------------------------
                }
                if (IdPuntoCT > 0)
                {
                    IdPuntoCTSeleccionado = IdPuntoCT;
                }
                if (IdPuntoCT == 0)
                {
                    IdPuntoCTSeleccionado = 0;
                }

                if (IdFiguras == 0 && IdPuntos == 0)
                {
                    RectanguloSeleccion = true;
                    IdFiguraSeleccionada = 0;
                    FiguraSeleccionada = false;
                }

                if (IdFiguras == 0)
                {
                    IdArrastrar = 0;
                    if (btnForzarCursor.Checked && PuntoAux != null)
                    {
                        xinicio = PuntoAux.X;
                        yinicio = PuntoAux.Y;
                    }
                    else
                    {
                        xinicio = xr;
                        yinicio = yr;
                    }

                    if (btnMover.Checked)
                    {
                        agarrar = true;
                    }
                }

                if (IdPuntos > 0)
                {
                    MoviendoPunto = true;
                    IdMoviendoPunto = IdPuntos;
                    IdPuntoSeleccionado = IdPuntos;
                    PuntoSeleccionado = true;
                    ObjectPosX0 = ListaPuntos[IdPuntos - 1].X;
                    ObjectPosY0 = ListaPuntos[IdPuntos - 1].Y;
                    if (btnForzarCursor.Checked)
                    {
                        Xi = PuntoAux.X;
                        Yi = PuntoAux.Y;
                    }
                    else
                    {
                        Xi = xr;
                        Yi = yr;
                    }
                }

                if (IdPuntos == 0)
                {
                    IdPuntoSeleccionado = 0;
                    PuntoSeleccionado = false;
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                MouseDchaDown = true;

                if (IdFiguras > 0)
                {
                    IdNegativa = IdFiguras;
                    MenuEditarFIguras.Show(Cursor.Position);
                }

                if (IdPuntos > 0)
                {
                    MenuEditarFIguras.Show(Cursor.Position);
                }

                if (IdPuntos == 0)
                {

                }
            }
            glControl1.Refresh();
        }

        private void GlControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (IdFiguras > 0)
                {
                    IdFiguraSeleccionada = IdFiguras;
                    FiguraSeleccionada = true;
                }
            }
        }

        private void GlControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                RuedaPress1 = false;
            }
        }

        private void GlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                foreach (ToolStripButton btn in BarraHerramientas.Items)
                {
                    btn.Checked = false;
                }
                NodoInicial = null; NodoFinal = null;
            }
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
            }

            if (e.Control && e.KeyCode == Keys.Y)
            {
                Redo();
            }
            if (e.KeyCode == Keys.ControlKey && MouseIzdaDown)
            {
                RuedaPress1 = true;
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                CopiarFigura();
            }

            if (e.Control && e.KeyCode == Keys.V)
            {
                PegarFigura();
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (FiguraSeleccionada)
                {
                    ListaFiguras.RemoveAt(IdFiguraSeleccionada - 1);
                }

                IdFiguras = 0;
                if (PuntoSeleccionado)
                {
                    ListaPuntos.RemoveAt(IdPuntoSeleccionado - 1);
                }

                IdPuntos = 0;

                PuntoSeleccionado = false;
                IdPuntoSeleccionado = 0;
                FiguraSeleccionada = false;
                IdFiguraSeleccionada = 0;
                glControl1.Refresh();
            }
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Calcular_dimensiones_iniciales1();
            GL.Ortho(xmin1, xmax1, ymin1, ymax1, -100, 300);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            //-----------------------------------------------------------------------------------------------------
            glControl2.Refresh();
            GL.Rotate(-AngRotX1, 1, 0, 0);
            GL.Rotate(-AngRotY1, 0, 1, 0);
            Calculos();
            TensionMaxima();

            AlineacionAxial();
            AlineacionCarasX();
            AlineacionCarasY();
            AlineacionRadialX();
            AlineacionRadialY();


            //-----------------------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------------------
            //LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA-LUZ ACTIVA           
            GL.Enable(EnableCap.Lighting);


            Esfuerzos();
            //Dibujamos el cdg total
            if (CdgT != null)
            {
                Esfera esf = new Esfera(Const1, cdgx, cdgy, 0);
                esf.Dibujar(1.0, 0.0, 1.0);
            }

            if (PuntoSeleccionado && IdPuntoSeleccionado > 0)
            {
                ListaPuntos[IdPuntoSeleccionado - 1].Seleccionado(R2);
            }


            foreach (Punto punt in ListaPuntos)
            {
                punt.Dibujar((float)(R2 * 0.8), 0.6, 0, 0.6);
            }

            if (FiguraAux != null)
            {
                FiguraAux.Dibujar(0.0, 0.0, 1.0);
            }

            //Color de los puntos cuando tienen el mouse encima
            if (IdPuntos > 0 && ListaPuntos.Count > 0)
            {
                ListaPuntos[IdPuntos - 1].Seleccionado(R2);
                ListaPuntos[IdPuntos - 1].Dibujar((float)(R2 * 0.8), 0.9, 0, 0.9);
            }

            GL.PushMatrix();
            GL.LoadIdentity();
            if (PuntoAux != null)
            {
                if (IdFiguras == 0 && Dibujando)
                {
                    PuntoAux.Dibujar((float)(Const1 * 0.7), 0, 0, 1);
                }
            }
            GL.PopMatrix();

            if (FiguraSeleccionada && IdFiguraSeleccionada > 0)
            {
                ListaFiguras[IdFiguraSeleccionada - 1].Seleccionada();

            }
            else if (!Dibujando)
            {
                txtAlto.Clear(); txtAncho.Clear(); txtDx.Clear(); txtDy.Clear(); txtRadio.Clear(); txtAngulo.Clear();
            }

            if (txtAxial.TextLength > 0)
            {
                txtSigmaN.Text = SigmaN.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtSigmaN.Text = "0";
            }
            if (txtFlectorX.TextLength > 0)
            {
                txtSigmaMx.Text = SigmaMx.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtSigmaMx.Text = "0";
            }
            if (txtFlectorY.TextLength > 0)
            {
                txtSigmaMy.Text = SigmaMy.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtSigmaMy.Text = "0";
            }



            //LUZ INACTIVA-LUZ INACTIVA-LUZ INACTIVA-LUZ INACTIVA-LUZ INACTIVA-LUZ INACTIVA-LUZ INACTIVA-LUZ INACTIVA
            GL.Disable(EnableCap.Lighting);

            TensionNormal();

            for (int i = 0; i < ListaFiguras.Count; i++)
            {
                if (ListaFiguras[i].Negativa)
                {
                    ListaFiguras[i].Dplano = Dplanos * 2;
                    if (IdFiguras - 1 == i)//Color con mouse encima
                    {
                        ListaFiguras[IdFiguras - 1].Dibujar(0.72, 0.72, 0.72);
                    }
                    else
                    {
                        ListaFiguras[i].Dibujar(1.0, 1.0, 1.0);
                    }
                }
                else
                {
                    if (!btnMapaColor.Checked)
                    {
                        if (IdFiguras - 1 == i)//Color con mouse encima
                        {
                            ListaFiguras[IdFiguras - 1].Dibujar(RR - 0.15, GG - 0.15, BB - 0.15);
                        }
                        else
                        {
                            ListaFiguras[i].Dibujar(RR, GG, BB);
                        }
                    }

                }
                ListaFiguras[i].Cortante(Vy, Vx, Iy, Ix, cdgy, cdgx);
            }

            if (btnEjesPpales.Checked)
            {
                EjesPrincipales();
            }
            if (btnLineaNeutra.Checked)
            {
                DibujarLineaNeutra();
            }

            Cuadricula1();

            GL.Enable(EnableCap.Lighting);
            Ejes(0, 0, 0, 0.9 * Const1);
            if (btnEjesCDG.Checked)
            {
                Triedro(cdgx, cdgy, 0);
            }
            DefinirEjes();
            GL.Disable(EnableCap.Lighting);

            Vector2d txtEjeX = PantallaAReales(BuffGlobalesX[1], BuffGlobalesX[2], 1);
            Vector2d txtEjeY = PantallaAReales(BuffGlobalesY[1], BuffGlobalesY[2], 1);
            Vector2d txtEjeZ = PantallaAReales(BuffGlobalesZ[1], BuffGlobalesZ[2], 1);

            if (BuffGlobalesX[1] > 0 && BuffGlobalesX[1] < glControl1.Width)
            {
                DrawText(txtEjeX.X, -txtEjeX.Y - 2 * cy1, "X", 0.7, 0.0, 0.0, AngRotX1, AngRotY1, 0.25 * Const1);
            }

            if (BuffGlobalesY[1] > 0 && BuffGlobalesY[1] < glControl1.Width)
            {
                DrawText(txtEjeY.X, -txtEjeY.Y - 2 * cy1, "Y", 0.0, 0.7, 0.0, AngRotX1, AngRotY1, 0.25 * Const1);
            }

            if (BuffGlobalesZ[1] > 0 && BuffGlobalesZ[1] < glControl1.Width)
            {
                DrawText(txtEjeZ.X, -txtEjeZ.Y - 2 * cy1, "Z", 0.0, 0.0, 0.7, AngRotX1, AngRotY1, 0.25 * Const1);
            }

            if (btnEjesCDG.Checked)
            {
                Vector2d txtCdgX = PantallaAReales(BuffLocalesX[1], BuffLocalesX[2], 1);
                Vector2d txtCdgY = PantallaAReales(BuffLocalesY[1], BuffLocalesY[2], 1);
                Vector2d txtCdgZ = PantallaAReales(BuffLocalesZ[1], BuffLocalesZ[2], 1);

                DrawText(txtCdgX.X, -txtCdgX.Y - 2 * cy1, "X", 0.7, 0.0, 0.0, AngRotX1, AngRotY1, 0.25 * Const1);
                DrawText(txtCdgY.X, -txtCdgY.Y - 2 * cy1, "Y", 0.0, 0.7, 0.0, AngRotX1, AngRotY1, 0.25 * Const1);
                DrawText(txtCdgZ.X, -txtCdgZ.Y - 2 * cy1, "Z", 0.0, 0.0, 0.7, AngRotX1, AngRotY1, 0.25 * Const1);
            }

            glControl1.SwapBuffers();
        }

        private void GlControl1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.LineSmooth);
            GL.Enable(EnableCap.PolygonSmooth);
            GL.Enable(EnableCap.PointSmooth);
            GL.Hint(HintTarget.PointSmoothHint, HintMode.Nicest);


            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
            Luces(new Vector3(0.6f, 0.6f, 0.6f), new Vector3(0.4f, 0.4f, 0.4f), new Vector3(0.0f, 0.0f, 0.0f), 50.0f);
            GL.ClearColor(1.0f, 1.0f, 1.0f, 0.0f);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.DepthFunc(DepthFunction.Less);
            GL.Enable(EnableCap.DepthTest);
        }

        internal void SplashStart()
        {
            Application.Run(new FormSplashScreen());
        }
        //EVENTOS DEL MOUSE------------------------------------------------------------------------------------------

        private void GlControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            mouseanteriorzoom = mousezoom;
            mousezoom = e;

            if (e.Delta > 0 && xmax1 < 2.5 * dimEjes)//zoom out
            {
                zoom *= 1.1f;
            }
            if (e.Delta < 0 && xmax1 > dimEjes / 6.0)//zoom in
            {
                zoom *= 0.9f;
            }
            glControl1.Refresh();
        }
        private void GlControl3_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && xmax3 < 2.5 * dimEjes)
            {
                zoom *= 1.1f;
            }
            if (e.Delta < 0 && xmax3 > dimEjes / 6.0)
            {
                zoom *= 0.9f;
            }
            glControl3.Refresh();
        }


        public void MetodoMatricial()
        {
            EnsamblarMatriz();
            VectorCargas();
            VectorDesplazamientos();
            ReducirMatriz(Kglobal);
            CalcularInversa(Kglobal);
            double[] VectorFuerzasRed = ReducirVectorFuerzas();
            ResolucionSistema(Kred, VectorFuerzasRed);
            TriangularMatriz(Kred, VectorFuerzasRed);
            ResolverSistema(Ktriang, VectorFuerzasRed);
            double[] Desplazamientos = CalcularEsfuerzos();
            ComprobarEnergiaElastica(Desplazamientos);
            CalcularReacciones(Kglobal, Desplazamientos);
        }


        //EVENTOS LOAD-----------------------------------------------------------------------------------------------
        internal void Luces(Vector3 Diff, Vector3 Ambt, Vector3 Spec, float Shininess)
        {
            //Lightning
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.ColorMaterial);
            float[] Ligthpos = { 0, 0, 200 };
            float[] LightDiff = { Diff.X, Diff.Y, Diff.Z };
            float[] LightAmbt = { Ambt.X, Ambt.Y, Ambt.Z };
            float[] LightSpec = { Spec.X, Spec.Y, Spec.Z };
            float[] MatShine = { Shininess };
            GL.ShadeModel(ShadingModel.Smooth);
            GL.Light(LightName.Light1, LightParameter.Position, Ligthpos);
            GL.Light(LightName.Light1, LightParameter.Diffuse, LightDiff);
            GL.Light(LightName.Light1, LightParameter.Ambient, LightAmbt);
            GL.Light(LightName.Light1, LightParameter.Specular, LightSpec);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, LightSpec);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, MatShine);
            GL.Enable(EnableCap.Light1);
            GL.PopMatrix();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CambioUnidades();
            glControl2.Visible = true;
            CuadroBarra.Hide();
            CuadroNodo.Hide();
            //Barra superior
            glControl1.Context.MakeCurrent(glControl1.WindowInfo);
            btnNodo.Visible = false;
            btnDeslizaderaArticX.Visible = false;
            btnDeslizaderaArticY.Visible = false;
            btnApoyoFijo.Visible = false;
            btnEmpotramiento.Visible = false;
            btnFuerzaBarra.Visible = false;
            btnFuerzaNodo.Visible = false;
            btnCargaDistribuida.Visible = false;
            btnMomentoNodo.Visible = false;
            btnMomentoBarra.Visible = false;
            btnBarraBiarticulada.Visible = false;
            btnBarraEmpotrada.Visible = false;
            btnBarraEmpArt.Visible = false;
            btnPropiedadesBarra.Visible = false;
            btnIncrementoTa.Visible = false;
            btnErrorForma.Visible = false;
            btnAsentamiento.Visible = false;
            btnCalcular.Visible = false;
            btnResultados.Visible = false;
            btnCirculo.Visible = true;
            btnRectangulo.Visible = true;
            btnCuartoCirculo.Visible = true;
            btnSemiCirculo.Visible = true;
            btnTrianguloRectangulo.Visible = true;
            btnDeslizaderaRigX.Visible = false;
            btnDeslizaderaRigY.Visible = false;
            btnUndo.Visible = true;
            btnRedo.Visible = true;

            //Barra inferior
            btnEjesCDG.Visible = true;
            btnEjesPpales.Visible = true;
            btnLineaNeutra.Visible = true;
            btnDistribucionTensiones.Visible = true;
            btnMapaColor.Visible = true;
            btnDistribucionAxiales.Visible = false;
            btnDistribucionCortantes.Visible = false;
            btnDistribucionFlectores.Visible = false;
            btnDeformada.Visible = false;
            btnCambiarColor.Visible = true;
            btnEjesLocales.Visible = false;

            if (txtAngulo.TextLength > 0)
            {
                txtAngulo.Text = "0";
            }

            if (txtDy.TextLength > 0)
            {
                txtDy.Text = "0";
            }
            if (txtDx.TextLength > 0)
            {
                txtDx.Text = "0";
            }

            btnCambiarColor.BackColor = Color.FromArgb(255, Convert.ToInt32(RR * 255), Convert.ToInt32(GG * 255), Convert.ToInt32(BB * 255));

            FontTextureID = LoadTexture(Settings.FontBitmapFilename);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        private int LoadTexture(string filename)
        {
            using (Bitmap bitmap = new Bitmap(filename))
            {
                int texId = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, FontTextureID);
                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmap.Width, bitmap.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                bitmap.UnlockBits(data);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
                TextureWidth = bitmap.Width; TextureHeight = bitmap.Height;
                return texId;
            }
        }

        public void DrawText(double x, double y, string text, double Rojo, double Verde, double Azul, double RotX, double RotY, double scale)
        {
            GL.DepthFunc(DepthFunction.Always);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);

            GL.PushMatrix();
            GL.Rotate(RotY, 0, 1, 0);
            GL.Rotate(RotX, 1, 0, 0);
            GL.Scale(scale, scale, 0);

            GL.Begin(PrimitiveType.Quads);

            float u_step = Settings.GlyphWidth / (float)TextureWidth;
            float v_step = Settings.GlyphHeight / (float)TextureHeight;

            for (int n = 0; n < text.Length; n++)
            {
                char idx = text[n];
                float u = idx % Settings.GlyphsPerLine * u_step;
                float v = idx / Settings.GlyphsPerLine * v_step;
                GL.Color3(Rojo, Verde, Azul);
                GL.TexCoord3(u, v, 1);
                GL.Vertex2(x / scale - Settings.GlyphWidth / 2, y / scale + Settings.GlyphHeight / 2);
                GL.TexCoord2(u + u_step, v);
                GL.Vertex2(x / scale + Settings.GlyphWidth / 2, y / scale + Settings.GlyphHeight / 2);
                GL.TexCoord2(u + u_step, v + v_step);
                GL.Vertex2(x / scale + Settings.GlyphWidth / 2, y / scale - Settings.GlyphHeight / 2);
                GL.TexCoord2(u, v + v_step);
                GL.Vertex2(x / scale - Settings.GlyphWidth / 2, y / scale - Settings.GlyphHeight / 2);

                x += Settings.CharXSpacing;
            }

            GL.End();
            GL.PopMatrix();

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
            GL.DepthFunc(DepthFunction.Less);
        }


        //EVENTOS CLICK-------------------------------------------------------------------------------------------

        private void LabelEsfuerzos_Click(object sender, EventArgs e)
        {
            if (esfuerzosXYZ == true)
            {
                labelEsfuerzos.Text = "Esfuerzos CDG";
                lblMx.Text = "Mz";
                lblMy.Text = "My";
                lblVx.Text = "Vx";
                lblVy.Text = "Vy";
                lblAxial.Text = "Nx";
                esfuerzosXYZ = false;
            }
            else
            {
                labelEsfuerzos.Text = "Esfuerzos XYZ";
                lblMx.Text = "Mx";
                lblMy.Text = "My";
                lblVx.Text = "Vx";
                lblVy.Text = "Vy";
                lblAxial.Text = "Nz";
                esfuerzosXYZ = true;
            }
            glControl1.Refresh();
        }

        private void EliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PuntoSeleccionado = false;
            IdPuntoSeleccionado = 0;
            FiguraSeleccionada = false;
            IdFiguraSeleccionada = 0;
            if (IdFiguras > 0)
            {
                //Guardamos la figura con este estado
                Figura fig = CopyAnObject<Figura>.Copiar(ListaFiguras[IdFiguras - 1]);
                ListaUndo.Add(fig);
                //-----------------------------------------------------------
                ListaFiguras.RemoveAt(IdFiguras - 1); IdFiguras = 0;
            }
            if (IdPuntos > 0) { ListaPuntos.RemoveAt(IdPuntos - 1); IdPuntos = 0; }
            glControl1.Refresh();
        }

        private void AreaPosCMnuFiguras_Click(object sender, EventArgs e)
        {
            ListaFiguras[IdNegativa - 1].Negativa = false;
        }
        private void AreaNegCMnuFiguras_Click(object sender, EventArgs e)
        {
            ListaFiguras[IdNegativa - 1].Negativa = true;
        }

        //EVENTO RESIZE------------------------------------------------------------------------------------------

        private void Form1_Resize(object sender, EventArgs e)
        {
            glControl1.Refresh();
            glControl3.Refresh();
        }

        //MÉTODOS-----------------------------------------------------------------------------------------------------

        internal void UnidadesAntesDeCalcular()
        {
            txtUndsUso.Text = undsLong + "; " + undsFuerza + "; " + undsTension;
            //Pasamos todo a mm, N, MPa
            if (undsLong == "m")
            {
                multLong = 1000.0;
            }
            else if (undsLong == "cm")
            {
                multLong = 10.0;
            }
            else if (undsLong == "mm")
            {
                multLong = 1.0;
            }
            //--------------------------------------------------------------------------
            if (undsFuerza == "KN")
            {
                multFuerz = 1000.0;
            }
            else if (undsFuerza == "N")
            {
                multFuerz = 1.0;
            }
            else if (undsFuerza == "Kg")
            {
                multFuerz = 9.81;
            }
            //--------------------------------------------------------------------------
            if (undsTension == "MPa")
            {
                multPres = 1.0;
            }
            else if (undsTension == "KPa")
            {
                multPres = 1000;
            }
            else if (undsTension == "Pa")
            {
                multPres = 1000000;
            }

            foreach (Figura fig in ListaFiguras) //Pasamos de m a mm
            {
                fig.Alto *= multLong;
                fig.Ancho *= multLong;
                fig.Area *= multLong * multLong;
                fig.X *= multLong;
                fig.Y *= multLong;
                fig.R *= multLong;
                EsfuerzoAxial *= multFuerz;
                EsfuerzoMx *= multFuerz * multLong;
                EsfuerzoMy *= multFuerz * multLong;
            }
        }

        internal void UnidadesDespuesDeCalcular()
        {
            foreach (Figura fig in ListaFiguras) //Pasamos de m a mm
            {
                fig.Alto /= multLong;
                fig.Ancho /= multLong;
                fig.Area /= (multLong * multLong);
                fig.X /= multLong;
                fig.Y /= multLong;
                fig.R /= multLong;
                EsfuerzoAxial /= multFuerz;
                EsfuerzoMx /= (multFuerz * multLong);
                EsfuerzoMy /= (multFuerz * multLong);
            }
        }

        internal void CambioUnidades()
        {
            txtUndsUso.Text = undsLong + "; " + undsFuerza + "; " + undsTension;

            //Pasamos todo a mm, N, MPa
            if (undsLong == "m")
            {
                multLong = 1000.0;
            }
            else if (undsLong == "cm")
            {
                multLong = 10.0;
            }
            else if (undsLong == "mm")
            {
                multLong = 1.0;
            }
            //--------------------------------------------------------------------------
            if (undsFuerza == "KN")
            {
                multFuerz = 1000.0;
            }
            else if (undsFuerza == "N")
            {
                multFuerz = 1.0;
            }
            else if (undsFuerza == "Kg")
            {
                multFuerz = 9.81;
            }
            //--------------------------------------------------------------------------
            if (undsTension == "MPa")
            {
                multPres = 1.0;
            }
            else if (undsTension == "KPa")
            {
                multPres = 1000;
            }
            else if (undsTension == "Pa")
            {
                multPres = 1000000;
            }
            //--------------------------------------------------------------------------
            txtUndsCdgX.Text = undsLong;
            txtUndsCdgY.Text = undsLong;
            txtUndsArea.Text = undsLong + "\x00B2";
            txtUndsIx.Text = undsLong + "\x2074";
            txtUndsIy.Text = undsLong + "\x2074";
            txtUndsIpolar.Text = undsLong + "\x2074";
            txtUndsIpolarG.Text = undsLong + "\x2074";
            txtUndsIxy.Text = undsLong + "\x2074";
            txtUndsIxg.Text = undsLong + "\x2074";
            txtUndsIyg.Text = undsLong + "\x2074";
            txtUndsIxgyg.Text = undsLong + "\x2074";
            txtUndsIxp.Text = undsLong + "\x2074";
            txtUndsIyp.Text = undsLong + "\x2074";
            txtUndsIxPers.Text = undsLong + "\x2074";
            txtUndsIyPers.Text = undsLong + "\x2074";
            txtUndsIxyPers.Text = undsLong + "\x2074";
            txtUndsPhip.Text = "º";
            txtUndsRGiroX.Text = undsLong;
            txtUndsRGiroY.Text = undsLong;
            txtUndsRGiroXG.Text = undsLong;
            txtUndsRGiroYG.Text = undsLong;
            txtUndsWx.Text = undsLong + "\x00B3";
            txtUndsWy.Text = undsLong + "\x00B3";
            txtUndsWxg.Text = undsLong + "\x00B3";
            txtUndsWyg.Text = undsLong + "\x00B3";
            //---------------------------
            txtUndsPcr.Text = undsFuerza;
            //---------------------------
            txtUndsSigmaN.Text = undsTension;
            txtUndsSigmaMx.Text = undsTension;
            txtUndsSigmaMy.Text = undsTension;
            txtUndsSigma.Text = undsTension;
            txtUndsSigmaMax.Text = undsTension;
            txtUndsSigmaMin.Text = undsTension;
        }

        internal void Renumerar()
        {
            //Cuando se elimina algo volver a enumerar las cosas en orden que tengan en su lista

            for (int i = 0; i < ListaNodos.Count; i++)
            {
                ListaNodos[i].NumeroNodo = i + 1;
            }

            for (int i = 0; i < ListaBarras.Count; i++)
            {
                ListaBarras[i].NumeroBarra = i + 1;
            }

            for (int i = 0; i < ListaFuerzas.Count; i++)
            {
                ListaFuerzas[i].NumeroCarga = i + 1;
            }

            for (int i = 0; i < ListaApoyos.Count; i++)
            {
                ListaApoyos[i].NumeroApoyo = i + 1;
            }

        }

        internal void ActualizarDimensiones()
        {
            Mmax = 0; Vmax = 0; Nmax = 0; Lmax = 0; Dmax = 0;
            //Calculamos los maximos
            foreach (Barra bar in ListaBarras)
            {
                if (bar.Longitud > Lmax) { Lmax = bar.Longitud; }

                foreach (Nodo nod in bar.ListaFaseFinal)
                {
                    if (Math.Abs(nod.Nx) > Nmax) { Nmax = Math.Abs(nod.Nx); }
                    if (Math.Abs(nod.Vy) > Vmax) { Vmax = Math.Abs(nod.Vy); }
                    if (Math.Abs(nod.Mz) > Mmax) { Mmax = Math.Abs(nod.Mz); }
                    if (Math.Abs(nod.Dx) > Dmax) { Dmax = Math.Abs(nod.Dx); }//Deformada axial
                    if (Math.Abs(nod.Dy) > Dmax) { Dmax = Math.Abs(nod.Dy); }//Deformada lateral                    
                }


                if (AutoSclN)
                {
                    if (Nmax != 0) { EscAxiales = (Lmax) / (3.0 * Nmax); } else { EscAxiales = 1; }
                }
                else
                {
                    EscAxiales = ManN;
                }

                if (AutoSclV)
                {
                    if (Vmax != 0) { EscCortante = (Lmax) / (3.0 * Vmax); } else { EscCortante = 1; }
                }
                else
                {
                    EscCortante = ManV;
                }

                if (AutoSclM)
                {
                    if (Mmax != 0) { EscFlector = (Lmax) / (3.0 * Mmax); } else { EscFlector = 1; }
                }
                else
                {
                    EscFlector = ManM;
                }

                if (AutoSclDef)
                {
                    if (Dmax != 0) { EscDeformada = (Lmax) / (4.0 * Dmax); } else { EscDeformada = 1; }
                }
                else
                {
                    EscDeformada = ManDef;
                }
            }
        }

        internal void CalcularReacciones(double[,] Kglob, double[] Desplaz)
        {
            OperacionesConMatrices op = new OperacionesConMatrices();
            double[] Reacciones = op.MatxVect(Kglob, Desplaz, ListaNodos.Count);
        }

        internal double[] CalcularEsfuerzos()
        {
            double[] Sol = new double[ListaNodos.Count * 3];

            foreach (Barra bar in ListaBarras)
            {
                //Fase 1
                Vector3d vectikii, vectikij, vectfkjj, vectfkji;

                double[] vectni = new double[3];
                vectni[0] = bar.NodoInicial.DX;
                vectni[1] = bar.NodoInicial.DY;
                vectni[2] = bar.NodoInicial.DZ;


                double[] vectnf = new double[3];
                vectnf[0] = bar.NodoFinal.DX;
                vectnf[1] = bar.NodoFinal.DY;
                vectnf[2] = bar.NodoFinal.DZ;

                OperacionesConMatrices opikii = new OperacionesConMatrices();
                vectikii = opikii.CalculoEsfuerzos(bar.Klii, bar.Ttras, vectni, 3);

                OperacionesConMatrices opikij = new OperacionesConMatrices();
                vectikij = opikij.CalculoEsfuerzos(bar.Klij, bar.Ttras, vectnf, 3);

                OperacionesConMatrices opfkjj = new OperacionesConMatrices();
                vectfkjj = opfkjj.CalculoEsfuerzos(bar.Kljj, bar.Ttras, vectnf, 3);

                OperacionesConMatrices opfkji = new OperacionesConMatrices();
                vectfkji = opfkji.CalculoEsfuerzos(bar.Klji, bar.Ttras, vectni, 3);

                //Los signos es para concordar con resistencia de materiales
                bar.Nxi = -(vectikii.X + vectikij.X);
                bar.Vyi = -(vectikii.Y + vectikij.Y);
                bar.Mzi = -(vectikii.Z + vectikij.Z);
                bar.Nxf = vectfkjj.X + vectfkji.X;
                bar.Vyf = vectfkjj.Y + vectfkji.Y;
                bar.Mzf = vectfkjj.Z + vectfkji.Z;


                //Estos desplazamientos son en coordenadas locales
                OperacionesConMatrices opi = new OperacionesConMatrices();
                Vector3d vecti = opi.GlobalesALocales(new Vector3d(bar.NodoInicial.DX, bar.NodoInicial.DY, bar.NodoInicial.DZ), bar.Ttras);
                bar.NodoInicial.Dx = vecti.X;
                bar.NodoInicial.Dy = vecti.Y;
                bar.NodoInicial.Dz = vecti.Z;


                OperacionesConMatrices opj = new OperacionesConMatrices();
                Vector3d vectj = opj.GlobalesALocales(new Vector3d(bar.NodoFinal.DX, bar.NodoFinal.DY, bar.NodoFinal.DZ), bar.Ttras);
                bar.NodoFinal.Dx = vecti.X;
                bar.NodoFinal.Dy = vecti.Y;
                bar.NodoFinal.Dz = vecti.Z;

                //Calculamos los esfuerzos por puntos dentro de la barra despues de calcular los extremos
                bar.EsfuerzosFase1();
            }

            foreach (Barra bar in ListaBarras)
            {
                if (bar.GetType() == typeof(BarraArticulada))
                {
                    bar.NodoInicial.Dz = (bar.NodoFinal.Dy - bar.NodoInicial.Dy) / bar.Longitud;
                    bar.NodoInicial.DZ = (bar.NodoFinal.DY - bar.NodoInicial.DY) / bar.Longitud;
                    bar.NodoFinal.Dz = (bar.NodoFinal.Dy - bar.NodoInicial.Dy) / bar.Longitud;
                    bar.NodoFinal.DZ = (bar.NodoFinal.DY - bar.NodoInicial.DY) / bar.Longitud;
                }
            }

            List<double> ListaAux = new List<double>();
            foreach (Nodo nod in ListaNodos)
            {
                ListaAux.Add(nod.DX);
                ListaAux.Add(nod.DY);
                ListaAux.Add(nod.DZ);
            }
            for (int i = 0; i < ListaAux.Count; i++)
            {
                Sol[i] = ListaAux[i];
            }
            return Sol;
        }
        internal void CalcularInversa(double[,] Kglobal)
        {
            double[] Vect = new double[ListaNodos.Count * 3];
            for (int i = 0; i < ListaNodos.Count; i = i + 3)
            {
                Vect[i] = ListaNodos[i].FX;
                Vect[i + 1] = ListaNodos[i].FY;
                Vect[i + 2] = ListaNodos[i].FZ;
            }
            Matrix<double> K = Matrix<double>.Build.DenseOfArray(Kglobal);
            Matrix<double> Kinv = K.Inverse();
            Vector<double> F = Vector<double>.Build.Dense(Vect);
            Vector<double> X = Kinv.Multiply(F);

        }
        internal void ResolucionSistema(double[,] Kred, double[] Vect)
        {
            Matrix<double> A = Matrix<double>.Build.DenseOfArray(Kred);
            Vector<double> B = Vector<double>.Build.Dense(Vect);
            Vector<double> X = A.Solve(B);
        }
        internal double[] ResolverSistema(double[,] Mat, double[] Cargas)
        {
            //primero reducir el vector de cargas y el de desplazamientos...
            //sustitucion hacia atras
            int conttam = 0;


            for (int i = 0; i < ListaNodos.Count; i++)
            {
                if (ListaNodos[i] != null)
                {
                    if (ListaNodos[i].DX != 0) { conttam++; }
                    if (ListaNodos[i].DY != 0) { conttam++; }
                    if (ListaNodos[i].DZ != 0) { conttam++; }
                }
            }


            //Sustitucion hacia atras
            double[] resultado = new double[conttam];
            for (int i = 0; i < conttam; i++) { resultado[i] = 1; }//Sino los desplazamientos quedan como 0
            double[] VectCarg = Cargas;

            //double Anterior = 0;
            //for (int k = Cargas.Length - 1; k >= 0; k--)
            //{
            //    for (int i = k + 1; i < Cargas.Length - 1; i++)
            //    {
            //        Anterior += Mat[k, i] * resultado[i];
            //    }

            //    if (Mat[k, k] != 0) resultado[k] = (VectCarg[k] - Anterior) / Mat[k, k];
            //}

            //Sustitucion hacia atras
            for (int i = 0; i < conttam; i++) { resultado[i] = 1; }//Sino los desplazamientos quedan como 0
            VectCarg = Cargas;
            if (conttam > 0 && Cargas.Length > 0)
            {
                //resultado[conttam - 1] = VectCarg[conttam - 1] / Mat[conttam - 1, conttam - 1];
                if (Mat[conttam - 1, conttam - 1] != 0) { resultado[conttam - 1] = VectCarg[conttam - 1] / Mat[conttam - 1, conttam - 1]; }
                for (int f = conttam - 2; f >= 0; f--)
                {
                    double sum = 0;

                    for (int i = conttam - 1; i > f; i--)
                    {
                        sum += Mat[f, i] * resultado[i];
                    }

                    if (Mat[f, f] != 0) { resultado[f] = (VectCarg[f] - sum) / Mat[f, f]; }
                }
            }

            int cont = 0;

            for (int i = 0; i < ListaNodos.Count; i++)
            {
                if (ListaNodos[i] != null)
                {
                    if (ListaNodos[i].DX != 0) { ListaNodos[i].DX = resultado[cont]; cont++; }
                    if (ListaNodos[i].DY != 0) { ListaNodos[i].DY = resultado[cont]; cont++; }
                    if (ListaNodos[i].DZ != 0) { ListaNodos[i].DZ = resultado[cont]; cont++; }
                }
            }

            return resultado;
        }

        internal List<Nodo> VectorCargas()
        {
            foreach (Nodo nod in ListaNodos)
            {
                if (nod != null)
                {
                    nod.FX = nod.FY = nod.FZ = 0;
                }
            }

            foreach (Barra bar in ListaBarras)
            {
                bar.ListaFase0.Clear();
                if (bar.Carga != null)
                {
                    bar.EsfuerzosFase0(bar.Carga);
                    bar.DeformacionesFase0(bar.Carga);
                }
            }

            foreach (Nodo nod in ListaNodos)
            {
                if (nod != null)
                {
                    foreach (Carga carg in ListaFuerzas)
                    {
                        try
                        {
                            //CARGAS FASE 0
                            if (carg.NodAdjuntoi == nod)
                            {
                                nod.FX += carg.XaG;
                                nod.FY += carg.RaG;
                                nod.FZ += carg.MaG;
                            }

                            if (carg.NodAdjuntoj == nod)
                            {
                                nod.FX += carg.XbG;
                                nod.FY += carg.RbG;
                                nod.FZ += carg.MbG;
                            }

                            //CARGAS FASE 1
                            if (carg.NodAdjunto == nod)//Si la carga pertenece al nodo que estamos analizando...
                            {
                                if (carg.GetType() == typeof(FuerzaNodal))
                                {
                                    nod.FX += carg.Modulo * Math.Cos(carg.Theta * Math.PI / 180);
                                    nod.FY += carg.Modulo * Math.Sin(carg.Theta * Math.PI / 180);
                                }
                                if (carg.GetType() == typeof(MomentoNodal))
                                {
                                    nod.FZ += carg.Modulo;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                }
            }
            return ListaNodos;
        }

        internal List<Nodo> VectorDesplazamientos()
        {

            foreach (Nodo nod in ListaNodos)
            {
                //Reseteamos a los valores de inicio
                nod.DX = nod.DY = nod.DZ = 1;
                nod.Dx = nod.Dy = nod.Dz = 1;
                foreach (Apoyo ap in ListaApoyos)
                {
                    if (ap.NodoAdjunto == nod)//Si el apoyo pertenece al nodo que estamos analizando...
                    {
                        try
                        {
                            if (ap.GetType() == typeof(ApoyoDeslizaderaArticX))
                            {
                                nod.DY = 0;
                            }

                            if (ap.GetType() == typeof(ApoyoDeslizaderaArticY))
                            {
                                nod.DX = 0;
                            }

                            if (ap.GetType() == typeof(ApoyoDeslizaderaRigX))
                            {
                                nod.DY = 0; nod.DZ = 0;
                            }

                            if (ap.GetType() == typeof(ApoyoDeslizaderaRigY))
                            {
                                nod.DX = 0; nod.DZ = 0;
                            }

                            if (ap.GetType() == typeof(ApoyoArticulado))
                            {
                                nod.DX = 0; nod.DY = 0;
                            }

                            if (ap.GetType() == typeof(ApoyoEmpotramiento))
                            {
                                nod.DX = 0; nod.DY = 0; nod.DZ = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            return ListaNodos;
        }

        internal Vector2d PantallaAReales(double ex, double ey, int num)
        {
            double xreal = 0, yreal = 0;
            if (num == 1)
            {
                xreal = xmin1 + (1.0 / glControl1.Width) * ex * (xmax1 - xmin1);
                yreal = ymax1 - (1.0 / glControl1.Height) * ey * (ymax1 - ymin1);
            }

            if (num == 3)
            {
                xreal = xmin3 + (1.0 / glControl3.Width) * ex * (xmax3 - xmin3);
                yreal = ymax3 - (1.0 / glControl3.Height) * ey * (ymax3 - ymin3);
            }

            return new Vector2d(xreal, yreal);
        }
        internal void ComprobarEnergiaElastica(double[] Desplazamientos)
        {
            OperacionesConMatrices op = new OperacionesConMatrices();
            double[] VectResult = op.VectxMat(Kglobal, Desplazamientos, Desplazamientos.Length);
            double Resultado = 0.5 * op.VectxVect(VectResult, Desplazamientos, Desplazamientos.Length);
            if (Resultado > 0) { EnergiaElasticaPositiva = true; } else { EnergiaElasticaPositiva = false; }
            if (EnergiaElasticaPositiva)
            {
                foreach (Barra bar in ListaBarras)
                {
                    bar.EnergiaElasticaPositiva = true;
                }
            }
            if (!EnergiaElasticaPositiva && ListaFuerzas.Count > 0)
            {
                //MessageBox.Show(TeiestStrings.EnergiaElastica + TeiestStrings.CContorno, TeiestStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Reseteamos los calculos puesto que no son correctos
                foreach (Barra bar in ListaBarras)
                {
                    bar.EnergiaElasticaPositiva = false;
                }
            }
        }

        internal void ReducirMatriz(double[,] K)
        {
            List<double> ListaAux = new List<double>();
            foreach (Nodo nod in ListaNodos)
            {
                ListaAux.Add(nod.DX);
                ListaAux.Add(nod.DY);
                ListaAux.Add(nod.DZ);
            }
            int cont = 0;
            for (int i = 0; i < ListaAux.Count; i++)
            {
                if (ListaAux[i] != 0) { cont++; }
            }

            double[,] Kreducida = new double[cont, cont];

            int contfila = 0, contcol = 0;
            for (int j = 0; j < ListaAux.Count; j++)
            {
                for (int i = 0; i < ListaAux.Count; i++)
                {
                    if (ListaAux[i] != 0 && ListaAux[j] != 0)
                    {
                        Kreducida[contfila, contcol] = K[j, i];
                        contcol++;
                    }
                    if (contfila >= cont) { contfila = 0; }
                    if (contcol >= cont)
                    {
                        contcol = 0;
                        contfila++;
                    }
                }
            }

            Kred = new double[ListaAux.Count, ListaAux.Count];
            Kred = Kreducida;
        }
        internal double[] ReducirVectorFuerzas()
        {
            List<double> ListaAux = new List<double>();
            foreach (Nodo nod in ListaNodos)
            {
                if (nod != null)
                {
                    if (nod.DX != 0) { ListaAux.Add(nod.FX); }
                    if (nod.DY != 0) { ListaAux.Add(nod.FY); }
                    if (nod.DZ != 0) { ListaAux.Add(nod.FZ); }
                }
            }
            double[] FuerzasRed = new double[ListaAux.Count];

            for (int i = 0; i < ListaAux.Count; i++)
            {
                FuerzasRed[i] = ListaAux[i];
            }

            return FuerzasRed;
        }

        internal void TriangularMatriz(double[,] Mat, double[] VectFuerzas)
        {
            try
            {
                int cont = 0;
                for (int i = 0; i < ListaNodos.Count; i++)
                {
                    if (ListaNodos[i].DX != 0) { cont++; }
                    if (ListaNodos[i].DY != 0) { cont++; }
                    if (ListaNodos[i].DZ != 0) { cont++; }
                }

                //Hay que aplicar las transformaciones al vector de fuerzas...
                for (int k = 0; k < cont; k++)
                {
                    for (int i = k + 1; i < cont; i++)
                    {
                        if (Mat[k, k] != 0)
                        {
                            double factor = Mat[i, k] / Mat[k, k];
                            for (int j = k; j < cont; j++)
                            {
                                Mat[i, j] = Mat[i, j] - Mat[k, j] * factor;
                            }
                            VectFuerzas[i] = VectFuerzas[i] - VectFuerzas[k] * factor;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Ktriang = Mat;
        }
        internal void EnsamblarMatriz()
        {
            OperacionesConMatrices sum = new OperacionesConMatrices();

            foreach (Barra bar in ListaBarras)
            {
                bar.MatrizRigidez();
            }
            int dim = ListaNodos.Count;
            double[,][,] K = new double[dim, dim][,];
            double[,] Kf = new double[dim * 3, dim * 3];

            //Se inicia la matriz con ceros
            for (int j = 0; j < dim; j++)
            {
                for (int i = 0; i < dim; i++)
                {
                    K[j, i] = new double[3, 3];
                }
            }

            try
            {
                foreach (Barra bar in ListaBarras)
                {
                    int posi = bar.NodoInicial.NumeroNodo - 1;
                    int posj = bar.NodoFinal.NumeroNodo - 1;

                    K[posi, posi] = sum.Suma(bar.Kii, K[posi, posi]);

                    K[posj, posj] = sum.Suma(bar.Kjj, K[posj, posj]);

                    K[posi, posj] = sum.Suma(bar.Kij, K[posi, posj]);

                    K[posj, posi] = sum.Suma(bar.Kji, K[posj, posi]);
                }


                //transformamos la matriz de rigidez de una matriz de matrices a una matriz simple
                for (int bloquef = 0; bloquef < dim; bloquef++)
                {
                    for (int bloquec = 0; bloquec < dim; bloquec++)
                    {
                        for (int fila = 0; fila < 3; fila++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                Kf[fila + bloquef * 3, col + bloquec * 3] = K[bloquef, bloquec][fila, col];
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                //MessageBox.Show(e.Message.ToString(CultureInfo.InvariantCulture), TeiestStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message.ToString(CultureInfo.InvariantCulture), TeiestStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Kglobal = Kf;
        }

        internal void Esfuerzos()
        {
            double Beta;

            try
            {
                if (txtAnguloFlector.TextLength > 0) { Beta = Convert.ToDouble(txtAnguloFlector.Text, CultureInfo.InvariantCulture); } else { Beta = 0; }
                if (Beta > 360)
                {
                    double div = Math.Round(Beta / 360.0, 0, MidpointRounding.ToEven);
                    Beta -= div * 360;
                }

                if (txtFlectorX.TextLength > 0 || txtFlectorY.TextLength > 0)
                {
                    Flecha Mt = new Flecha(cdgx, cdgy, 0, 10);
                    Mt.FlechaMomento(0.7, 0.7, 0.0, Const1, 0, Beta, 1.0);
                }
            }
            catch (FormatException e)
            {
                //MessageBox.Show(e.Message.ToString(CultureInfo.InvariantCulture), TeiestStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message.ToString(CultureInfo.InvariantCulture), TeiestStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        internal void Calcular_dimensiones_iniciales3()
        {
            double ancho = 1.0, alto;

            ancho *= dimEjes * zoom;
            alto = ancho * glControl3.Height / glControl3.Width;

            xmin3 = -(ancho * 0.5) - cx3;
            xmax3 = (ancho * 0.5) - cx3;
            ymin3 = -(alto * 0.5) - cy3;
            ymax3 = (alto * 0.5) - cy3;

            Const3 = 5 * ancho / glControl3.Width;
        }

        internal void Calcular_dimensiones_iniciales1()
        {
            double ancho = 1.0, alto;

            ancho *= dimEjes * zoom;

            alto = ancho * glControl1.Height / glControl1.Width;

            xmin1 = -(ancho / 2) - cx1;
            xmax1 = (ancho / 2) - cx1;
            ymin1 = -(alto / 2) - cy1;
            ymax1 = (alto / 2) - cy1;

            //Para saber de que tamaño dibujar el cdg
            Const1 = 5 * ancho / glControl1.Width;

            //Tamaño de la separacion de ayuda para unir figuras
            Pixel = 10 * ancho / glControl1.Width;
        }

        internal void Cuadricula3()
        {
            if (btnRejilla.Checked)
            {
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(1, 0xAAAA);

                try
                {
                    if (Malla > 0)
                    {
                        GL.Begin(PrimitiveType.Lines);
                        for (double i = 0; i <= xmax3; i += Malla)
                        {
                            if (i % 4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(i, ymin3);
                            GL.Vertex2(i, ymax3);
                        }

                        for (double i = 0; i >= xmin3; i -= Malla)
                        {
                            if (i % -4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(i, ymin3);
                            GL.Vertex2(i, ymax3);
                        }
                        GL.End();
                    }
                    if (Malla > 0)
                    {
                        GL.Begin(PrimitiveType.Lines);
                        for (double j = 0; j <= ymax3; j += Malla)
                        {
                            if (j % 4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(xmin3, j);
                            GL.Vertex2(xmax3, j);
                        }

                        for (double j = 0; j >= ymin3; j -= Malla)
                        {
                            if (j % -4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(xmin3, j);
                            GL.Vertex2(xmax3, j);
                        }
                        GL.End();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                GL.Disable(EnableCap.LineStipple);
            }
        }

        internal void Cuadricula1()
        {
            GL.Enable(EnableCap.LineStipple);
            GL.LineStipple(1, 0xAAAA);
            GL.DepthFunc(DepthFunction.Always);
            if (btnRejilla.Checked)
            {

                try
                {
                    if (Malla > 0)
                    {
                        GL.Begin(PrimitiveType.Lines);
                        for (double i = 0; i <= xmax1; i += Malla)
                        {
                            if (i % 4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(i, ymin1);
                            GL.Vertex2(i, ymax1);
                        }

                        for (double i = 0; i >= xmin1; i -= Malla)
                        {
                            if (i % -4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(i, ymin1);
                            GL.Vertex2(i, ymax1);
                        }
                        GL.End();
                    }
                    if (Malla > 0)
                    {
                        GL.Begin(PrimitiveType.Lines);
                        for (double j = 0; j <= ymax1; j += Malla)
                        {
                            if (j % 4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(xmin1, j);
                            GL.Vertex2(xmax1, j);
                        }

                        for (double j = 0; j >= ymin1; j -= Malla)
                        {
                            if (j % -4 == 0) { GL.Color3(0.5, 0.5, 0.5); } else { GL.Color3(0.8, 0.8, 0.8); }
                            GL.Vertex2(xmin1, j);
                            GL.Vertex2(xmax1, j);
                        }
                        GL.End();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            GL.DepthFunc(DepthFunction.Less);
            GL.Disable(EnableCap.LineStipple);
        }

        internal void Calculos()
        {
            //UnidadesAntesDeCalcular();
            AreaTotal = 0; Ix = 0; Iy = 0; Ixy = 0; cdgx = 0; cdgy = 0; Phi = 0;
            foreach (Figura fig in ListaFiguras)
            {
                //Inercias,areas... del conjunto
                AreaTotal += fig.Area;
                Ix += fig.IX;
                Iy += fig.IY;
                Ixy += fig.IXY;
                cdgx += (fig.Area * fig.Cdgx);
                cdgy += (fig.Area * fig.Cdgy);
            }
            //cdg del conjunto
            cdgx /= AreaTotal;
            cdgy /= AreaTotal;
            CdgT = new Punto(cdgx, cdgy);

            Ixg = Ix - AreaTotal * (cdgy) * (cdgy);
            Iyg = Iy - AreaTotal * (cdgx) * (cdgx);
            Ixgyg = Ixy - AreaTotal * (cdgx) * (cdgy);

            //----------------------------------------------------------------------------------------------------------
            if (Ixg > (Ixg + Iyg) / 2)
            {
                Ixp = (Ixg + Iyg) / 2 + Math.Sqrt(Math.Pow((Ixg - Iyg) / 2, 2) + Ixgyg * Ixgyg);
                Iyp = (Ixg + Iyg) / 2 - Math.Sqrt(Math.Pow((Ixg - Iyg) / 2, 2) + Ixgyg * Ixgyg);
            }
            else
            {
                Ixp = (Ixg + Iyg) / 2 - Math.Sqrt(Math.Pow((Ixg - Iyg) / 2, 2) + Ixgyg * Ixgyg);
                Iyp = (Ixg + Iyg) / 2 + Math.Sqrt(Math.Pow((Ixg - Iyg) / 2, 2) + Ixgyg * Ixgyg);
            }

            if (Iyg != Ixg)
            {
                Phi = (1.0 / 2.0) * Math.Atan(2.0 * Ixgyg / (Iyg - Ixg)) * 180.0 / Math.PI;
            }

            SigmaN = Math.Round(EsfuerzoAxial * multFuerz / (AreaTotal * Math.Pow(multLong, 2)), 9) * multPres;
            if (IdFiguras > 0) { SigmaMx = Math.Round(EsfuerzoMx * multFuerz * multLong * (yr - cdgy) * multLong / (Ixg * Math.Pow(multLong, 4)), 9) * multPres; } else { SigmaMx = 0; }
            if (IdFiguras > 0) { SigmaMy = Math.Round(-EsfuerzoMy * multFuerz * multLong * (xr - cdgx) * multLong / (Iyg * Math.Pow(multLong, 4)), 9) * multPres; } else { SigmaMy = 0; }
            Sigma = SigmaN + SigmaMx + SigmaMy;


            //Para ejes definidos por el usuario
            if (txtAnguloEjes.TextLength > 0)
            {
                try
                {
                    double[] Vector = new double[3];
                    double Ang = Convert.ToDouble(txtAnguloEjes.Text, CultureInfo.InvariantCulture);
                    Mohr circulo = new Mohr();
                    Vector = circulo.Calcular(Ixg, Iyg, Ixgyg, Ang);
                    Ixpers = Vector[0];
                    Iypers = Vector[1];
                    Ixypers = Vector[2];
                }
                catch (FormatException ex)
                {
                    //MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), TeiestStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), TeiestStrings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            Ip = Ix + Iy;
            Ipg = Ixg + Iyg;

            ix = Math.Sqrt(Ix / AreaTotal);
            iy = Math.Sqrt(Iy / AreaTotal);

            ixG = Math.Sqrt(Ixg / AreaTotal);
            iyG = Math.Sqrt(Iyg / AreaTotal);

            ModuloSeccion();
            Wx = Ix / YWy;
            Wy = Iy / XWx;

            Wxg = Ixg / YgWy;
            Wyg = Iyg / XgWx;

            if (txtVy.TextLength > 0) { txy = Convert.ToDouble(txtVy.Text, CultureInfo.InvariantCulture) * Qx / (Ix); } else { txy = 0; }
            if (txtVx.TextLength > 0) { txz = Convert.ToDouble(txtVx.Text, CultureInfo.InvariantCulture) * Qy / (Iy); } else { txz = 0; }

            //UnidadesDespuesDeCalcular();
        }
        internal void ModuloSeccion()
        {
            double Mx, My; ;

            if (txtFlectorX.TextLength > 0) { Mx = Convert.ToDouble(txtFlectorX.Text, CultureInfo.InvariantCulture); } else { Mx = 0; }
            if (txtFlectorY.TextLength > 0) { My = Convert.ToDouble(txtFlectorY.Text, CultureInfo.InvariantCulture); } else { My = 0; }
            List<Vector3d> Lista;
            XgWx = 0; YgWy = 0; //Segun centroide
            XWx = 0; YWy = 0; //Segun ejes globales
            foreach (Figura fig in ListaFiguras)
            {
                Lista = fig.DistribucionTensiones(cdgx, cdgy, Mx, My, Ixg, Iyg, SigmaN);
                for (int i = 0; i < Lista.Count; i++)
                {
                    if (YgWy < Math.Abs(Lista[i].Y - cdgy)) { YgWy = Math.Abs(Lista[i].Y - cdgy); }
                    if (XgWx < Math.Abs(Lista[i].X - cdgx)) { XgWx = Math.Abs(Lista[i].X - cdgx); }
                    if (XWx < Math.Abs(Lista[i].X)) { XWx = Math.Abs(Lista[i].X); }
                    if (YWy < Math.Abs(Lista[i].Y)) { YWy = Math.Abs(Lista[i].Y); }
                }
            }
        }
        internal void TensionMaxima()
        {
            double Sigma, Mx, My; ;

            if (txtFlectorX.TextLength > 0) { Mx = Convert.ToDouble(txtFlectorX.Text, CultureInfo.InvariantCulture); } else { Mx = 0; }
            if (txtFlectorY.TextLength > 0) { My = Convert.ToDouble(txtFlectorY.Text, CultureInfo.InvariantCulture); } else { My = 0; }
            List<Vector3d> Lista;
            SigmaMax = 0;
            SigmaMin = 0;
            foreach (Figura fig in ListaFiguras)
            {
                if (fig.Negativa == false)
                {
                    Lista = fig.DistribucionTensiones(cdgx, cdgy, Mx, My, Ixg, Iyg, SigmaN);
                    for (int i = 0; i < Lista.Count; i++)
                    {
                        Sigma = SigmaN + (Mx * (Lista[i].Y - cdgy)) / (Ixg) - (My * (Lista[i].X - cdgx)) / (Iyg);
                        if (Sigma >= SigmaMax)
                        {
                            SigmaMax = Sigma;
                        }
                        if (Sigma <= SigmaMin)
                        {
                            SigmaMin = Sigma;
                        }
                    }
                }
            }
            SigmaMax = Math.Round(SigmaMax, 3);
            SigmaMin = Math.Round(SigmaMin, 3);
            txtSigmaMax.Text = SigmaMax.ToString(CultureInfo.InvariantCulture); txtSigmaMax.Refresh();
            txtSigmaMin.Text = SigmaMin.ToString(CultureInfo.InvariantCulture); txtSigmaMin.Refresh();
        }

        internal void TensionNormal()
        {
            double Mx, My;
            List<Vector3d> Lista;

            if (txtFlectorX.TextLength > 0) { Mx = Convert.ToDouble(txtFlectorX.Text, CultureInfo.InvariantCulture); } else { Mx = 0; }
            if (txtFlectorY.TextLength > 0) { My = Convert.ToDouble(txtFlectorY.Text, CultureInfo.InvariantCulture); } else { My = 0; }
            foreach (Figura fig in ListaFiguras)
            {
                if (txtFlectorX.TextLength > 0 && txtFlectorY.TextLength > 0 && txtAxial.TextLength > 0) { fig.TieneEsfuerzo = false; } else { fig.TieneEsfuerzo = true; }

                if (!fig.Negativa)
                {
                    if (btnMapaColor.Checked)
                    {
                        fig.MapaTensional(cdgx, cdgy, Mx, My, SigmaN, Ixg, Iyg, SigmaMax, SigmaMin, RR, GG, BB);
                    }

                    if (btnDistribucionTensiones.Checked)
                    {
                        //fig.PlanoTensional(cdgx, cdgy, Mx, My, SigmaN, Ixg, Iyg, SigmaMax, SigmaMin);
                        Lista = fig.DistribucionTensiones(cdgx, cdgy, Mx, My, Ixg, Iyg, SigmaN);
                        for (int i = 0; i < Lista.Count; i++)
                        {
                            GL.Begin(PrimitiveType.Lines);
                            Sigma = Mx * (Lista[i].Y - cdgy) / Ixg - My * (Lista[i].X - cdgx) / Iyg;
                            GL.Color3(0.7, 0, 0);
                            GL.Vertex3(Lista[i].X, Lista[i].Y, (Sigma * 4 * Malla + SigmaN * 4 * Malla) / SigmaMax);
                            GL.Vertex3(Lista[i].X, Lista[i].Y, 0);
                            GL.End();
                        }
                    }
                }
            }
        }


        internal void CalculoQ()
        {
            List<Figura> Lista = new List<Figura>();
            //CopyAnObject<> cop = new CopyAnObject<>();

            //Ordenados de izda a dcha y de abajo a arriba
            Lista = ListaFiguras;
            Lista = (from item in Lista orderby item.Cdgx, item.Cdgy select item).ToList();

            //hay que tener en cuenta 
            foreach (Figura fig in ListaFiguras)
            {
                //fig.CoordCortante();
            }
        }

        internal void CalculoPandeo()
        {
            double Lk = 0, Imin;
            try
            {
                if (txtLongitudPandeo.TextLength > 0) { Lk = Convert.ToDouble(txtLongitudPandeo.Text, CultureInfo.InvariantCulture); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Ixg >= Iyg)
            {
                Imin = Iyg;
            }
            else
            {
                Imin = Ixg;
            }
            if (Lk != 0)
            {
                Pcr = (Math.PI * Math.PI * ModuloYoung * Imin) / (Lk * Lk);
                txtCargaCritica.Text = Pcr.ToString(CultureInfo.InvariantCulture);
            }


            txtCargaCritica.Refresh();
        }

        internal void DibujarLineaNeutra()
        {
            GL.DepthFunc(DepthFunction.Always);
            double N, Mx, My;
            try
            {
                if (txtAxial.TextLength > 0) { N = Convert.ToDouble(txtAxial.Text, CultureInfo.InvariantCulture); } else { N = 0; }
                if (txtFlectorX.TextLength > 0) { Mx = Convert.ToDouble(txtFlectorX.Text, CultureInfo.InvariantCulture); } else { Mx = 0; }
                if (txtFlectorY.TextLength > 0) { My = Convert.ToDouble(txtFlectorY.Text, CultureInfo.InvariantCulture); } else { My = 0; }

                double x1 = xmin1 + cdgx;
                double y1 = ((My * Ixg) / (Mx * Iyg)) * xmin1 + cdgy - (N * Ixg) / (Mx * AreaTotal);
                double x2 = xmax1 + cdgx;
                double y2 = ((My * Ixg) / (Mx * Iyg)) * xmax1 + cdgy - (N * Ixg) / (Mx * AreaTotal);
                double Ang = Math.Atan2(y2, x2) * 180.0 / Math.PI;
                LineaNeutra = new Linea(x1, y1, x2, y2);
                LineaNeutra.Dibujar(1.0, 60.0 / 255, 1.0, false, 1.5f, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GL.DepthFunc(DepthFunction.Less);
        }
        internal void DefinirEjes()
        {
            if (!string.IsNullOrEmpty(txtAnguloEjes.Text))
            {
                double angulo = Convert.ToDouble(txtAnguloEjes.Text, CultureInfo.InvariantCulture);
                Flecha x = new Flecha(cdgx, cdgy, 0, 11);
                Flecha y = new Flecha(cdgx, cdgy, 0, 11);
                x.FlechaSimple(123.0 / 255, 19.0 / 255, 71.0 / 255, 0.9 * Const1, 0, angulo);
                y.FlechaSimple(123.0 / 255, 19.0 / 255, 71.0 / 255, 0.9 * Const1, 0, angulo + 90);
            }
        }
        internal void Ejes(double X, double Y, double Z, double cte)
        {
            Esfera esf = new Esfera(cte, X, Y, Z);
            esf.Dibujar(1.0, 1.0, 0.0);
            GL.DepthFunc(DepthFunction.Always);
            EjeX = new Flecha(X, Y, Z, 11);
            EjeX.FlechaSimple(0.7, 0.0, 0.0, cte, 0, 0);
            EjeY = new Flecha(X, Y, Z, 11);
            EjeY.FlechaSimple(0.0, 0.7, 0.0, cte, 0, 90);
            EjeZ = new Flecha(X, Y, Z, 11);
            EjeZ.FlechaSimple(0.0, 0.0, 1.0, cte, -90, 0);
            GL.DepthFunc(DepthFunction.Less);

            GL.FeedbackBuffer(BuffGlobalesX.Length, FeedbackType.Gl2D, BuffGlobalesX);
            GL.RenderMode(RenderingMode.Feedback);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(16 * cte, 0, 0);
            GL.End();
            GL.RenderMode(RenderingMode.Render);
            GL.FeedbackBuffer(BuffGlobalesY.Length, FeedbackType.Gl2D, BuffGlobalesY);
            GL.RenderMode(RenderingMode.Feedback);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(0.2 * cte, 16 * cte, 0);
            GL.End();
            GL.RenderMode(RenderingMode.Render);
            GL.FeedbackBuffer(BuffGlobalesZ.Length, FeedbackType.Gl2D, BuffGlobalesZ);
            GL.RenderMode(RenderingMode.Feedback);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(0, 0, 16 * cte);
            GL.End();
            GL.RenderMode(RenderingMode.Render);
        }

        internal void EjesPrincipales()
        {
            GL.PushMatrix();
            GL.DepthFunc(DepthFunction.Always);
            GL.Translate(cdgx, cdgy, 0);
            GL.Rotate(Phi, 0, 0, -1);
            GL.LineWidth(2f);


            GL.Begin(PrimitiveType.Lines);
            //Eje vertical
            if (Ixp > Iyp) { GL.Color3(1.0, 0.0, 0.0); } else { GL.Color3(0.0, 0.0, 1.0); }
            GL.Vertex2(0, glControl1.Height / 2);
            GL.Vertex2(0, 0);
            GL.Vertex2(0, -glControl1.Height / 2);
            GL.Vertex2(0, 0);

            if (Ixp > Iyp) { GL.Color3(0.0, 0.0, 1.0); } else { GL.Color3(1.0, 0.0, 0.0); }

            //Eje horizontal
            GL.Vertex2(glControl1.Width / 2, 0);
            GL.Vertex2(0, 0);
            GL.Vertex2(-glControl1.Width / 2, 0);
            GL.Vertex2(0, 0);
            GL.End();
            GL.DepthFunc(DepthFunction.Less);
            GL.PopMatrix();
        }

        internal void Triedro(double X, double Y, double Z)
        {
            GL.DepthFunc(DepthFunction.Always);
            EjeX = new Flecha(X, Y, Z, 11);
            EjeX.FlechaSimple(0.7, 0.0, 0.0, 0.9 * Const1, -90, 0);
            EjeY = new Flecha(X, Y, Z, 11);
            EjeY.FlechaSimple(0.0, 0.7, 0.0, 0.9 * Const1, 0, -90);
            EjeZ = new Flecha(X, Y, Z, 11);
            EjeZ.FlechaSimple(0.0, 0.0, 0.7, 0.9 * Const1, 0, 0);
            GL.DepthFunc(DepthFunction.Less);

            GL.FeedbackBuffer(BuffLocalesX.Length, FeedbackType.Gl2D, BuffLocalesX);
            GL.RenderMode(RenderingMode.Feedback);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(X, Y, Z + 15 * Const1);
            GL.End();
            GL.RenderMode(RenderingMode.Render);
            GL.FeedbackBuffer(BuffLocalesY.Length, FeedbackType.Gl2D, BuffLocalesY);
            GL.RenderMode(RenderingMode.Feedback);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(X, Y - 15 * Const1, Z);
            GL.End();
            GL.RenderMode(RenderingMode.Render);
            GL.FeedbackBuffer(BuffLocalesZ.Length, FeedbackType.Gl2D, BuffLocalesZ);
            GL.RenderMode(RenderingMode.Feedback);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(X + 15 * Const1, Y, Z);
            GL.End();
            GL.RenderMode(RenderingMode.Render);
        }

        internal void AlineacionAxial()
        {
            //Comprobamos la figura que estamos moviendo
            double deltax, deltay;
            for (int i = 0; i < ListaFiguras.Count; i++)
            {
                if (IdArrastrar - 1 != i && ListaFiguras.Count > 0 && IdArrastrar > 0)
                {
                    deltax = Math.Abs(ListaFiguras[IdArrastrar - 1].X - ListaFiguras[i].X);
                    deltay = Math.Abs(ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[i].Y);
                    if (deltax < Pixel)
                    {
                        ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X;
                        Linea lin = new Linea(ListaFiguras[IdArrastrar - 1].X, ListaFiguras[IdArrastrar - 1].Y, ListaFiguras[i].X, ListaFiguras[i].Y);
                        lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                    }
                    if (deltay < Pixel)
                    {
                        ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y;
                        Linea lin = new Linea(ListaFiguras[IdArrastrar - 1].X, ListaFiguras[IdArrastrar - 1].Y, ListaFiguras[i].X, ListaFiguras[i].Y);
                        lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                    }
                }
            }
        }

        internal void AlineacionCarasX()
        {
            double x1, y1, x2, y2;
            if (IdArrastrar > 0)
            {
                for (int i = 0; i < ListaFiguras.Count; i++)
                {
                    double deltaX = ListaFiguras[i].X - ListaFiguras[IdArrastrar - 1].X;
                    if (Math.Abs(deltaX) < Pixel + ListaFiguras[i].Ancho / 2.0 + ListaFiguras[IdArrastrar - 1].Ancho / 2.0 && Math.Abs(deltaX) > -Pixel + ListaFiguras[i].Ancho / 2.0 + ListaFiguras[IdArrastrar - 1].Ancho / 2.0)
                    {
                        if (deltaX > 0)//Por la izquierda
                        {
                            ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0 - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }
                        }

                        if (deltaX < 0)//Por la derecha
                        {
                            ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0 + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }

                        }
                    }

                    if (Math.Abs(deltaX) >= ListaFiguras[i].Ancho / 2 - ListaFiguras[IdArrastrar - 1].Ancho / 2 - Pixel && Math.Abs(deltaX) < ListaFiguras[i].Ancho / 2 - ListaFiguras[IdArrastrar - 1].Ancho / 2 + Pixel)
                    {
                        if (deltaX > 0)//Por la izquierda
                        {
                            ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0 + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }
                        }

                        if (deltaX < 0)//Por la derecha
                        {
                            ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0 - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }
                        }
                    }
                }
            }
        }
        internal void AlineacionCarasY()
        {
            double x1, y1, x2, y2;
            if (IdArrastrar > 0)
            {
                for (int i = 0; i < ListaFiguras.Count; i++)
                {
                    double deltaY = ListaFiguras[i].Y - ListaFiguras[IdArrastrar - 1].Y;
                    if (Math.Abs(deltaY) < Pixel + ListaFiguras[i].Alto / 2.0 + ListaFiguras[IdArrastrar - 1].Alto / 2.0 && Math.Abs(deltaY) > -Pixel + ListaFiguras[i].Alto / 2.0 + ListaFiguras[IdArrastrar - 1].Alto / 2.0)
                    {
                        if (deltaY > 0)//Por abajo
                        {
                            ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0 - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].Y)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }

                        }

                        if (deltaY < 0)//Por arriba
                        {
                            ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0 + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].X)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }
                        }
                    }

                    if (Math.Abs(deltaY) >= ListaFiguras[i].Alto / 2 - ListaFiguras[IdArrastrar - 1].Alto / 2 - Pixel && Math.Abs(deltaY) < ListaFiguras[i].Alto / 2 - ListaFiguras[IdArrastrar - 1].Alto / 2 + Pixel)
                    {
                        if (deltaY > 0)//Por abajo
                        {
                            ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0 + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].X)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }

                        }

                        if (deltaY < 0)//Por arriba
                        {
                            ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0 - ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                            if (ListaFiguras[IdArrastrar - 1].GetType() == typeof(Rectangulo) && ListaFiguras[i].GetType() == typeof(Rectangulo))
                            {
                                if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].X)
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X + ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                else
                                {
                                    x1 = ListaFiguras[IdArrastrar - 1].X - ListaFiguras[IdArrastrar - 1].Ancho / 2.0;
                                    y1 = ListaFiguras[IdArrastrar - 1].Y + ListaFiguras[IdArrastrar - 1].Alto / 2.0;
                                    x2 = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2.0;
                                    y2 = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2.0;
                                }
                                Linea lin = new Linea(x1, y1, x2, y2);
                                lin.Dibujar(1.0, 0.0, 0.0, true, 2f, false);
                            }
                        }
                    }
                }
            }
        }
        internal void AlineacionPlanaX()
        {
            //Comprobamos la figura que estamos moviendo
            double deltax;

            for (int i = 0; i < ListaFiguras.Count; i++)
            {
                if (IdArrastrar - 1 != i && ListaFiguras.Count > 0 && IdArrastrar > 0)
                {
                    try
                    {
                        deltax = Math.Abs(ListaFiguras[IdArrastrar - 1].X - ListaFiguras[i].X);

                        if (deltax <= ListaFiguras[IdArrastrar - 1].Ancho / 2 + ListaFiguras[i].Ancho / 2 + Pixel && deltax > ListaFiguras[IdArrastrar - 1].Ancho / 2 + ListaFiguras[i].Ancho / 2 - Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].X < ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2 - ListaFiguras[IdArrastrar - 1].Ancho / 2;
                            }

                            if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2 + ListaFiguras[IdArrastrar - 1].Ancho / 2;
                            }

                        }

                        if (deltax >= ListaFiguras[i].Ancho / 2 - ListaFiguras[IdArrastrar - 1].Ancho / 2 - Pixel && deltax < ListaFiguras[i].Ancho / 2 - ListaFiguras[IdArrastrar - 1].Ancho / 2 + Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].X < ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X - ListaFiguras[i].Ancho / 2 + ListaFiguras[IdArrastrar - 1].Ancho / 2;
                            }

                            if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X + ListaFiguras[i].Ancho / 2 - ListaFiguras[IdArrastrar - 1].Ancho / 2;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        internal void AlineacionPlanaY()
        {
            //Comprobamos la figura que estamos moviendo
            double deltay;

            for (int i = 0; i < ListaFiguras.Count; i++)
            {
                if (IdArrastrar - 1 != i && ListaFiguras.Count > 0 && IdArrastrar > 0)
                {
                    try
                    {
                        deltay = Math.Abs(ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[i].Y);

                        if (deltay <= ListaFiguras[IdArrastrar - 1].Alto / 2 + ListaFiguras[i].Alto / 2 + Pixel && deltay > ListaFiguras[IdArrastrar - 1].Alto / 2 + ListaFiguras[i].Alto / 2 - Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].Y < ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2 - ListaFiguras[IdArrastrar - 1].Alto / 2;
                            }

                            if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2 + ListaFiguras[IdArrastrar - 1].Alto / 2;
                            }
                        }

                        if (deltay >= ListaFiguras[i].Alto / 2 - ListaFiguras[IdArrastrar - 1].Alto / 2 - Pixel && deltay < ListaFiguras[i].Alto / 2 - ListaFiguras[IdArrastrar - 1].Alto / 2 + Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].Y < ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y - ListaFiguras[i].Alto / 2 + ListaFiguras[IdArrastrar - 1].Alto / 2;
                            }

                            if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y + ListaFiguras[i].Alto / 2 - ListaFiguras[IdArrastrar - 1].Alto / 2;
                            }
                        }

                    }
                    catch
                    {

                    }
                }
            }
        }

        internal void AlineacionRadialX()
        {
            //Comprobamos la figura que estamos moviendo
            double deltax;

            for (int i = 0; i < ListaFiguras.Count; i++)
            {
                if (IdArrastrar - 1 != i && ListaFiguras.Count > 0 && IdArrastrar > 0)
                {
                    try
                    {
                        deltax = Math.Abs(ListaFiguras[IdArrastrar - 1].X - ListaFiguras[i].X);

                        if (deltax <= ListaFiguras[IdArrastrar - 1].R + ListaFiguras[i].R + Pixel && deltax > ListaFiguras[IdArrastrar - 1].R + ListaFiguras[i].R - Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].X < ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X - ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R;
                            }

                            if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X + ListaFiguras[i].R + ListaFiguras[IdArrastrar - 1].R;
                            }
                        }

                        if (deltax >= ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R - Pixel && deltax < ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R + Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].X < ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X - ListaFiguras[i].R + ListaFiguras[IdArrastrar - 1].R;
                            }

                            if (ListaFiguras[IdArrastrar - 1].X > ListaFiguras[i].X)
                            {
                                ListaFiguras[IdArrastrar - 1].X = ListaFiguras[i].X + ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        internal void AlineacionRadialY()
        {
            //Comprobamos la figura que estamos moviendo
            double deltay;

            for (int i = 0; i < ListaFiguras.Count; i++)
            {
                if (IdArrastrar - 1 != i && ListaFiguras.Count > 0 && IdArrastrar > 0)
                {
                    try
                    {
                        deltay = Math.Abs(ListaFiguras[IdArrastrar - 1].Y - ListaFiguras[i].Y);

                        if (deltay <= ListaFiguras[IdArrastrar - 1].R + ListaFiguras[i].R + Pixel && deltay > ListaFiguras[IdArrastrar - 1].R + ListaFiguras[i].R - Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].Y < ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y - ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R;
                            }

                            if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y + ListaFiguras[i].R + ListaFiguras[IdArrastrar - 1].R;
                            }
                        }

                        if (deltay >= ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R - Pixel && deltay < ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R + Pixel)
                        {
                            if (ListaFiguras[IdArrastrar - 1].Y < ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y - ListaFiguras[i].R + ListaFiguras[IdArrastrar - 1].R;
                            }

                            if (ListaFiguras[IdArrastrar - 1].Y > ListaFiguras[i].Y)
                            {
                                ListaFiguras[IdArrastrar - 1].Y = ListaFiguras[i].Y + ListaFiguras[i].R - ListaFiguras[IdArrastrar - 1].R;
                            }
                        }
                    }
                    catch
                    {

                    }

                }
            }
        }

        internal void ShowProperties()
        {
            if (IdNodoSeleccionado > 0 && ListaNodos[IdNodoSeleccionado - 1] != null)
            {
                txtNodoCx.Text = ListaNodos[IdNodoSeleccionado - 1].X.ToString(CultureInfo.InvariantCulture);
                txtNodoCy.Text = ListaNodos[IdNodoSeleccionado - 1].Y.ToString(CultureInfo.InvariantCulture);
                txtNumNodo.Text = ListaNodos[IdNodoSeleccionado - 1].NumeroNodo.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtNodoCx.Clear();
                txtNodoCy.Clear();
                txtNumNodo.Clear();
            }
            if (IdBarraSeleccionada > 0 && ListaBarras[IdBarraSeleccionada - 1] != null)
            {
                double x = ListaBarras[IdBarraSeleccionada - 1].X1 - ListaBarras[IdBarraSeleccionada - 1].X0;
                double y = ListaBarras[IdBarraSeleccionada - 1].Y1 - ListaBarras[IdBarraSeleccionada - 1].Y0;
                double L = Math.Sqrt(x * x + y * y);
                double Nx = Math.Round(ListaBarras[IdBarraSeleccionada - 1].NodoInicial.Nx, 3);
                double Vyi = Math.Round(ListaBarras[IdBarraSeleccionada - 1].NodoInicial.Vy, 3);
                double Vyf = Math.Round(ListaBarras[IdBarraSeleccionada - 1].NodoFinal.Vy, 3);
                double Mzi = Math.Round(ListaBarras[IdBarraSeleccionada - 1].NodoInicial.Mz, 3);
                double Mzf = Math.Round(ListaBarras[IdBarraSeleccionada - 1].NodoFinal.Mz, 3);

                txtLongitudBarra.Text = L.ToString(CultureInfo.InvariantCulture);
                txtYoungBarra.Text = ListaBarras[IdBarraSeleccionada - 1].EYoung.ToString(CultureInfo.InvariantCulture);
                txtAreaBarra.Text = ListaBarras[IdBarraSeleccionada - 1].Area.ToString(CultureInfo.InvariantCulture);
                txtInerciaBarra.Text = ListaBarras[IdBarraSeleccionada - 1].Inercia.ToString(CultureInfo.InvariantCulture);
                txtNumBarra.Text = ListaBarras[IdBarraSeleccionada - 1].NumeroBarra.ToString(CultureInfo.InvariantCulture);
                txtNx.Text = Nx.ToString(CultureInfo.InvariantCulture);
                txtVyi.Text = Vyi.ToString(CultureInfo.InvariantCulture);
                txtVyf.Text = Vyf.ToString(CultureInfo.InvariantCulture);
                txtMzi.Text = Mzi.ToString(CultureInfo.InvariantCulture);
                txtMzf.Text = Mzf.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                txtLongitudBarra.Clear();
                txtYoungBarra.Clear();
                txtAreaBarra.Clear();
                txtInerciaBarra.Clear();
                txtNumBarra.Clear();
                txtNx.Clear();
                txtVyi.Clear();
                txtVyf.Clear();
                txtMzi.Clear();
                txtMzf.Clear();
            }
            if (IdPuntoSeleccionado > 0 && ListaPuntos[IdPuntoSeleccionado - 1] != null)
            {
                if (ListaPuntos[IdPuntoSeleccionado - 1].GetType() == typeof(Punto))
                {

                    labelAlto.Visible = false; txtAlto.Visible = false;
                    labelAncho.Visible = false; txtAncho.Visible = false;
                    labelRadio.Visible = false; txtRadio.Visible = false;
                    labelAngulo.Visible = false; txtAngulo.Visible = false;
                    labelDx.Visible = true; txtDx.Visible = true;
                    labelDy.Visible = true; labelDy.Visible = true;
                    txtDx.Text = ListaPuntos[IdPuntoSeleccionado - 1].X.ToString(CultureInfo.InvariantCulture);
                    txtDy.Text = ListaPuntos[IdPuntoSeleccionado - 1].Y.ToString(CultureInfo.InvariantCulture);
                }
            }

            if (IdFiguraSeleccionada > 0 && ListaFiguras[IdFiguraSeleccionada - 1] != null)
            {
                Figura FigSeleccionada = ListaFiguras[IdFiguraSeleccionada - 1];
                if (FigSeleccionada.GetType() == typeof(Circulo))
                {
                    CuadroPropiedades.Height = 85;
                    labelAlto.Visible = false; txtAlto.Visible = false;
                    labelAncho.Visible = false; txtAncho.Visible = false;
                    labelRadio.Visible = true; txtRadio.Visible = true; txtRadio.Text = FigSeleccionada.R.ToString(CultureInfo.InvariantCulture);
                    labelAngulo.Visible = false; txtAngulo.Visible = false;
                    labelDx.Visible = true; txtDx.Visible = true; txtDx.Text = FigSeleccionada.X.ToString(CultureInfo.InvariantCulture);
                    labelDy.Visible = true; labelDy.Visible = true; txtDy.Text = FigSeleccionada.Y.ToString(CultureInfo.InvariantCulture);
                }
                if (FigSeleccionada.GetType() == typeof(Rectangulo))
                {
                    CuadroPropiedades.Height = 127;
                    labelAlto.Visible = true; txtAlto.Visible = true; labelAlto.Text = "Alto"; txtAlto.Text = FigSeleccionada.Alto.ToString(CultureInfo.InvariantCulture);
                    labelAncho.Visible = true; txtAncho.Visible = true; labelAncho.Text = "Ancho"; txtAncho.Text = FigSeleccionada.Ancho.ToString(CultureInfo.InvariantCulture);
                    labelRadio.Visible = false; txtRadio.Visible = false;
                    labelAngulo.Visible = true; txtAngulo.Visible = true; txtAngulo.Text = FigSeleccionada.Theta.ToString(CultureInfo.InvariantCulture);
                    labelDx.Visible = true; txtDx.Visible = true; txtDx.Text = FigSeleccionada.X.ToString(CultureInfo.InvariantCulture);
                    labelDy.Visible = true; labelDy.Visible = true; txtDy.Text = FigSeleccionada.Y.ToString(CultureInfo.InvariantCulture);
                }
                if (FigSeleccionada.GetType() == typeof(TrianguloRectangulo))
                {
                    CuadroPropiedades.Height = 127;
                    labelAlto.Visible = true; txtAlto.Visible = true; labelAlto.Text = "Altura"; txtAlto.Text = Math.Abs(FigSeleccionada.Alto).ToString(CultureInfo.InvariantCulture);
                    labelAncho.Visible = true; txtAncho.Visible = true; labelAncho.Text = "Base"; txtAncho.Text = Math.Abs(FigSeleccionada.Ancho).ToString(CultureInfo.InvariantCulture);
                    labelRadio.Visible = false; txtRadio.Visible = false;
                    labelAngulo.Visible = true; txtAngulo.Visible = true; txtAngulo.Text = FigSeleccionada.Theta.ToString(CultureInfo.InvariantCulture);
                    labelDx.Visible = true; txtDx.Visible = true; txtDx.Text = FigSeleccionada.X.ToString(CultureInfo.InvariantCulture);
                    labelDy.Visible = true; labelDy.Visible = true; txtDy.Text = FigSeleccionada.Y.ToString(CultureInfo.InvariantCulture);
                }
                if (FigSeleccionada.GetType() == typeof(Semicirculo) || FigSeleccionada.GetType() == typeof(CuartoCirculo))
                {
                    CuadroPropiedades.Height = 106;
                    labelAlto.Visible = false; txtAlto.Visible = false;
                    labelAncho.Visible = false; txtAncho.Visible = false;
                    labelRadio.Visible = true; txtRadio.Visible = true; txtRadio.Text = FigSeleccionada.R.ToString(CultureInfo.InvariantCulture);
                    labelAngulo.Visible = true; txtAngulo.Visible = true; txtAngulo.Text = FigSeleccionada.Theta.ToString(CultureInfo.InvariantCulture);
                    labelDx.Visible = true; txtDx.Visible = true; txtDx.Text = FigSeleccionada.X.ToString(CultureInfo.InvariantCulture);
                    labelDy.Visible = true; labelDy.Visible = true; txtDy.Text = FigSeleccionada.Y.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
        //BOTONES----------------------------------------------------------------------------------------------------------


        private void Click_BarraHerramientasDibujado(object sender, EventArgs e)
        {
            foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
            {
                if (item == sender)
                {
                    item.Checked = true;
                }

                if ((item != null) && (item != sender))
                {
                    item.Checked = false;
                }
            }
            BarraAux = null; NodoInicial = null; NodoFinal = null;
            if (sender == btnPropiedadesBarra)
            {
                foreach (ToolStripButton item in ((ToolStripButton)sender).GetCurrentParent().Items)
                {
                    if (item == sender)
                    {
                        item.Checked = true;
                    }

                    if ((item != null) && (item != sender))
                    {
                        item.Checked = false;
                    }
                }
                BarraAux = null; NodoInicial = null; NodoFinal = null;
                FormPropiedadesBarra form = new FormPropiedadesBarra
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                btnPropiedadesBarra.Checked = false;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Barra barr in ListaBarras)
                    {
                        barr.EYoung = form.MaterialEnUso.EYoung;
                        barr.Area = form.PerfilEnUso.A;
                        if (form.EjeFuerte) { barr.Inercia = form.PerfilEnUso.Iy; } else { barr.Inercia = form.PerfilEnUso.Iz; }
                        barr.Alfa = form.MaterialEnUso.Alfa;
                        barr.TipoCTE = form.PerfilEnUso.TipoCTE;
                    }
                }
                form.Dispose();
            }

            if (sender == btnUndo) { Undo(); btnUndo.Checked = false; }
            if (sender == btnRedo) { Redo(); btnRedo.Checked = false; }
            if (sender == btnRectangulo)
            {
                BtnClic = true;
                FiguraSeleccionada = false;
                panelPropiedadesDcha.Height = 100;
                panelPropiedadesIzda.Height = 100;
                labelAlto.Show(); txtAlto.Show(); labelAlto.Text = "Alto";
                labelAncho.Show(); txtAncho.Show(); labelAncho.Text = "Ancho";
                labelRadio.Hide(); txtRadio.Hide();
                labelAngulo.Show(); txtAngulo.Show();
                labelDx.Show(); txtDx.Show();
                labelDy.Show(); txtDy.Show();
            }
            if (sender == btnTrianguloRectangulo)
            {
                BtnClic = true;
                FiguraSeleccionada = false;
                panelPropiedadesDcha.Height = 100;
                panelPropiedadesIzda.Height = 100;
                labelAlto.Show(); txtAlto.Show(); labelAlto.Text = "Altura";
                labelAncho.Show(); txtAncho.Show(); labelAncho.Text = "Base";
                labelRadio.Hide(); txtRadio.Hide();
                labelAngulo.Show(); txtAngulo.Show();
                labelDx.Show(); txtDx.Show();
                labelDy.Show(); txtDy.Show();
            }
            if (sender == btnCuartoCirculo)
            {
                BtnClic = true;
                FiguraSeleccionada = false;
                panelPropiedadesDcha.Height = 80;
                panelPropiedadesIzda.Height = 80;
                labelAlto.Hide(); txtAlto.Hide();
                labelAncho.Hide(); txtAncho.Hide();
                labelRadio.Show(); txtRadio.Show();
                labelAngulo.Show(); txtAngulo.Show();
                labelDx.Show(); txtDx.Show();
                labelDy.Show(); txtDy.Show();
            }
            if (sender == btnSemiCirculo)
            {
                BtnClic = true;
                FiguraSeleccionada = false;
                panelPropiedadesDcha.Height = 80;
                panelPropiedadesIzda.Height = 80;
                labelAlto.Hide(); txtAlto.Hide();
                labelAncho.Hide(); txtAncho.Hide();
                labelRadio.Show(); txtRadio.Show();
                labelAngulo.Show(); txtAngulo.Show();
                labelDx.Show(); txtDx.Show();
                labelDy.Show(); txtDy.Show();
            }
            if (sender == btnCirculo)
            {
                BtnClic = true;
                FiguraSeleccionada = false;
                panelPropiedadesDcha.Height = 60;
                panelPropiedadesIzda.Height = 60;
                labelAlto.Hide(); txtAlto.Hide();
                labelAncho.Hide(); txtAncho.Hide();
                labelRadio.Show(); txtRadio.Show();
                labelAngulo.Hide(); txtAngulo.Hide();
                labelDx.Show(); txtDx.Show();
                labelDy.Show(); txtDy.Show();
            }
            if (sender == btnAbrir)
            {
                AbrirDoc();
                btnAbrir.Checked = false;
            }
            if (sender == btnGuardar)
            {
                GuardarDoc();
                btnGuardar.Checked = false;
            }
            if (sender == btnCalcular)
            {
                btnCalcular.Checked = false;
                MetodoMatricial();
                ActualizarDimensiones();
                glControl3.Refresh();
            }
            if (sender == btnResultados)
            {
                btnResultados.Checked = false;
                FormResultados form = new FormResultados(ListaBarras)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                form.ShowDialog();
                form.Dispose();
            }
        }


        private void Click_BarraMenuSuperior(object sender, EventArgs e)
        {
            if (sender == cmnuAjustes)
            {
                FormAjustes form = new FormAjustes(undsLong, undsFuerza, undsTension, dimEjes, Malla, EscDeformada, EscAxiales, EscCortante, EscFlector, AutoSclDef, AutoSclN, AutoSclV, AutoSclM)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AutoSclDef = form.AutoDef;
                    AutoSclN = form.AutoN;
                    AutoSclV = form.AutoV;
                    AutoSclM = form.AutoM;

                    undsLong = form.UndsLongi;
                    undsFuerza = form.UndsFuerz;
                    undsTension = form.UndsTension;
                    ManDef = form.EscDef;
                    ManN = form.EscAxial;
                    ManV = form.EscCortante;
                    ManM = form.EscFlector;
                    dimEjes = form.DimEjes;
                    Malla = form.Malla;

                    CambioUnidades();

                    txtUndsArea.Refresh();
                    txtUndsCdgX.Refresh();
                    txtUndsCdgY.Refresh();
                    txtUndsIx.Refresh();
                    txtUndsIy.Refresh();
                    txtUndsIxy.Refresh();
                    txtUndsIxPers.Refresh();
                    txtUndsIyPers.Refresh();
                    txtUndsIxyPers.Refresh();
                    txtUndsIpolar.Refresh();
                    txtUndsIpolarG.Refresh();
                    txtUndsSigma.Refresh();
                    txtUndsSigmaMin.Refresh();
                    txtUndsSigmaMx.Refresh();
                    txtUndsSigmaMy.Refresh();
                    txtUndsSigmaN.Refresh();
                    txtUndsPcr.Refresh();
                    txtUndsPhip.Refresh();
                    txtUndsIxg.Refresh();
                    txtUndsIyg.Refresh();
                    txtUndsIxgyg.Refresh();
                    txtUndsIxp.Refresh();
                    txtUndsIyp.Refresh();
                    txtUndsRGiroX.Refresh();
                    txtUndsRGiroY.Refresh();
                    txtUndsRGiroXG.Refresh();
                    txtUndsRGiroYG.Refresh();
                    txtUndsWx.Refresh();
                    txtUndsWy.Refresh();
                    txtUndsWxg.Refresh();
                    txtUndsWyg.Refresh();
                }
                form.Dispose();
            }
            if (sender == cmnuNuevo) { NuevoDoc(); }
            if (sender == cmnuAbrir) { AbrirDoc(); }
            if (sender == cmnuGuardar) { GuardarDoc(); }
        }
        //------------------------------------------------------------------------------------------

        private void TxtModuloFlector_KeyUp(object sender, KeyEventArgs e)
        {
            double Modulo, Angulo;
            try
            {
                if (txtModuloFlector.TextLength > 0)
                {
                    Modulo = Convert.ToDouble(txtModuloFlector.Text, CultureInfo.InvariantCulture);
                    if (txtAnguloFlector.TextLength == 0) { Angulo = 0; } else { Angulo = Convert.ToDouble(txtAnguloFlector.Text, CultureInfo.InvariantCulture) * Math.PI / 180; }
                    txtFlectorX.Text = Convert.ToString(Math.Round(Modulo * Math.Cos(Angulo), 3), CultureInfo.InvariantCulture);
                    txtFlectorY.Text = Convert.ToString(Math.Round(Modulo * Math.Sin(Angulo), 3), CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                txtModuloFlector.Clear();
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            glControl1.Refresh();
        }

        private void TxtAnguloFlector_KeyUp(object sender, KeyEventArgs e)
        {
            double Modulo, Angulo;
            try
            {
                if (txtAnguloFlector.TextLength > 0)
                {
                    Angulo = Convert.ToDouble(txtAnguloFlector.Text, CultureInfo.InvariantCulture) * Math.PI / 180;
                    if (txtModuloFlector.TextLength == 0) { Modulo = 0; } else { Modulo = Convert.ToDouble(txtModuloFlector.Text, CultureInfo.InvariantCulture); }
                    txtFlectorX.Text = Convert.ToString(Math.Round(Modulo * Math.Cos(Angulo), 3), CultureInfo.InvariantCulture);
                    txtFlectorY.Text = Convert.ToString(Math.Round(Modulo * Math.Sin(Angulo), 3), CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                txtAnguloFlector.Clear();
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            glControl1.Refresh();
        }

        private void TxtFlectorX_KeyUp(object sender, KeyEventArgs e)
        {
            double Mx, My;
            try
            {
                if (txtFlectorX.TextLength > 0)
                {
                    Mx = Convert.ToDouble(txtFlectorX.Text, CultureInfo.InvariantCulture);
                    if (txtFlectorY.TextLength == 0) { My = 0; } else { My = Convert.ToDouble(txtFlectorY.Text, CultureInfo.InvariantCulture); }
                    txtModuloFlector.Text = Convert.ToString(Math.Round(Math.Sqrt(Mx * Mx + My * My), 3), CultureInfo.InvariantCulture);
                    txtAnguloFlector.Text = Convert.ToString(Math.Round(Math.Atan2(My, Mx) * 180 / Math.PI, 3), CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                txtFlectorX.Clear();
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            glControl1.Refresh();
        }

        private void TxtFlectorY_KeyUp(object sender, KeyEventArgs e)
        {
            double Mx, My;
            try
            {
                if (txtFlectorY.TextLength > 0)
                {
                    My = Convert.ToDouble(txtFlectorY.Text, CultureInfo.InvariantCulture);
                    if (txtFlectorX.TextLength == 0) { Mx = 0; } else { Mx = Convert.ToDouble(txtFlectorX.Text, CultureInfo.InvariantCulture); }
                    txtModuloFlector.Text = Convert.ToString(Math.Round(Math.Sqrt(Mx * Mx + My * My), 3), CultureInfo.InvariantCulture);
                    txtAnguloFlector.Text = Convert.ToString(Math.Round(Math.Atan2(My, Mx) * 180 / Math.PI, 3), CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                txtFlectorY.Clear();
                MessageBox.Show(ex.Message.ToString(CultureInfo.InvariantCulture), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            glControl1.Refresh();
        }



    }

}






