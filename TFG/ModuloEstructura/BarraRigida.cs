using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    internal class BarraRigida : Barra
    {
        public BarraRigida(Vector3d Inicio, Vector3d Final)
        {
            X0 = Inicio.X;
            Y0 = Inicio.Y;
            X1 = Final.X;
            Y1 = Final.Y;
        }
        internal override void Dibujar2D(double Radio, double RR, double GG, double BB)
        {
            double Theta = Angulo * Math.PI / 180.0;

            double c = Math.Cos(Theta), s = Math.Sin(Theta);
            T = new double[3, 3];
            Ttras = new double[3, 3];

            T[0, 0] = c; T[0, 1] = -s; T[0, 2] = 0;
            T[1, 0] = s; T[1, 1] = c; T[1, 2] = 0;
            T[2, 0] = 0; T[2, 1] = 0; T[2, 2] = 1;
            OperacionesConMatrices op = new OperacionesConMatrices();
            Ttras = op.Traspuesta(T);
            Longitud = Math.Sqrt((X1 - X0) * (X1 - X0) + (Y1 - Y0) * (Y1 - Y0));
            Angulo = Math.Atan2((Y1 - Y0), (X1 - X0)) * 180.0 / Math.PI;


            GL.PushMatrix();
            //Rectangulo ppal
            GL.Translate(X0, Y0, 0);
            GL.Rotate(Angulo, 0, 0, 1.0);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Vertex3(0, -Radio / 2.0, 0);
            GL.Vertex3(0, Radio / 2.0, 0);
            GL.Vertex3(Longitud, Radio / 2.0, 0);
            GL.Vertex3(Longitud, -Radio / 2.0, 0);
            GL.End();
            //////Rectangulo arriba
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR - 0.2, GG - 0.2, BB - 0.2);
            GL.Vertex3(0, -Radio / 2.0, 0);
            GL.Vertex3(0, -Radio / 1.5, 0);
            GL.Vertex3(Longitud, -Radio / 1.5, 0);
            GL.Vertex3(Longitud, -Radio / 2.0, 0);
            GL.End();
            //Rectangulo abajo
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR - 0.2, GG - 0.2, BB - 0.2);
            GL.Vertex3(0, Radio / 2.0, 0);
            GL.Vertex3(0, Radio / 1.5, 0);
            GL.Vertex3(Longitud, Radio / 1.5, 0);
            GL.Vertex3(Longitud, Radio / 2.0, 0);
            GL.End();
            GL.PopMatrix();

            //CoronaRectangular correctini = new CoronaRectangular(x0, y0,15, Radio * 0.8, 1.7 * Radio);
            //CoronaRectangular correctfin = new CoronaRectangular(x1, y1,15, Radio * 0.8, 1.7 * Radio);
            //correctini.Dibujar2D(RR - 0.2, GG - 0.2, BB - 0.2);
            //correctfin.Dibujar2D(RR - 0.2, GG - 0.2, BB - 0.2);
        }
        internal override void MatrizRigidez()
        {
            double E = EYoung;
            double L = Longitud;
            double A = Area;
            double I = Inercia;
            double Theta = Angulo * Math.PI / 180.0;

            double c = Math.Cos(Theta), s = Math.Sin(Theta);
            //T = new double[3, 3];
            //Ttras = new double[3, 3];

            //T[0, 0] = c; T[0, 1] = -s; T[0, 2] = 0;
            //T[1, 0] = s; T[1, 1] = c; T[1, 2] = 0;
            //T[2, 0] = 0; T[2, 1] = 0; T[2, 2] = 1;

            OperacionesConMatrices op = new OperacionesConMatrices();
            Ttras = op.Traspuesta(T);

            //Submatrices en ejes globales
            {
                Kii = new double[3, 3];
                Kjj = new double[3, 3];
                Kij = new double[3, 3];
                Kji = new double[3, 3];

                //MATRIZ K11
                Kii[0, 0] = ((A * c * c) + 12 * I * s * s / (L * L)) * E / L;
                Kii[0, 1] = ((A * c * s) - 12 * I * c * s / (L * L)) * E / L;
                Kii[0, 2] = (-6 * I * s / L) * E / L;
                Kii[1, 0] = ((A * c * s) - 12 * I * c * s / (L * L)) * E / L;
                Kii[1, 1] = ((A * s * s) + 12 * I * c * c / (L * L)) * E / L;
                Kii[1, 2] = (6 * I * c / (L)) * E / L;
                Kii[2, 0] = (-6 * I * s / (L)) * E / L;
                Kii[2, 1] = (6 * I * c / (L)) * E / L;
                Kii[2, 2] = (4 * I) * E / L;

                //MATRIZ K12
                Kij[0, 0] = ((-A * c * c) - 12 * I * s * s / (L * L)) * E / L;
                Kij[0, 1] = ((-A * c * s) + 12 * I * c * s / (L * L)) * E / L;
                Kij[0, 2] = (-6 * I * s / (L)) * E / L;
                Kij[1, 0] = ((-A * c * s) + 12 * I * c * s / (L * L)) * E / L;
                Kij[1, 1] = (-A * s * s - 12 * I * c * c / (L * L)) * E / L;
                Kij[1, 2] = (6 * I * c / (L)) * E / L;
                Kij[2, 0] = (6 * I * s / (L)) * E / L;
                Kij[2, 1] = (-6 * I * c / (L)) * E / L;
                Kij[2, 2] = 2 * I * E / L;

                //MATRIZ K21
                Kji[0, 0] = (-A * c * c - 12 * I * s * s / (L * L)) * E / L;
                Kji[0, 1] = (-A * c * s + 12 * I * c * s / (L * L)) * E / L;
                Kji[0, 2] = (6 * I * s / (L)) * E / L;
                Kji[1, 0] = (-A * c * s + 12 * I * c * s / (L * L)) * E / L;
                Kji[1, 1] = (-A * s * s - 12 * I * c * c / (L * L)) * E / L;
                Kji[1, 2] = (-6 * I * c / (L)) * E / L;
                Kji[2, 0] = (-6 * I * s / (L)) * E / L;
                Kji[2, 1] = (6 * I * c / (L)) * E / L;
                Kji[2, 2] = 2 * I * E / L;

                //MATRIZ K22
                Kjj[0, 0] = (A * c * c + 12 * I * s * s / (L * L)) * E / L;
                Kjj[0, 1] = (A * c * s - 12 * I * c * s / (L * L)) * E / L;
                Kjj[0, 2] = (6 * I * s / (L)) * E / L;
                Kjj[1, 0] = (A * c * s - 12 * I * c * s / (L * L)) * E / L;
                Kjj[1, 1] = (A * s * s + 12 * I * c * c / (L * L)) * E / L;
                Kjj[1, 2] = (-6 * I * c / (L)) * E / L;
                Kjj[2, 0] = (6 * I * s / (L)) * E / L;
                Kjj[2, 1] = (-6 * I * c / (L)) * E / L;
                Kjj[2, 2] = 4 * I * E / L;
            }

            //Submatrices en ejes locales
            {
                Klii = new double[3, 3];
                Kljj = new double[3, 3];
                Klij = new double[3, 3];
                Klji = new double[3, 3];

                //MATRIZ K11
                Klii[0, 0] = E * A / L;
                Klii[0, 1] = 0;
                Klii[0, 2] = 0;
                Klii[1, 0] = 0;
                Klii[1, 1] = 12 * E * I / (L * L * L);
                Klii[1, 2] = (6 * E * I / (L * L));
                Klii[2, 0] = 0;
                Klii[2, 1] = (6 * E * I / (L * L));
                Klii[2, 2] = (4 * E * I) / L;

                //MATRIZ K12
                Klij[0, 0] = -E * A / L;
                Klij[0, 1] = 0;
                Klij[0, 2] = 0;
                Klij[1, 0] = 0;
                Klij[1, 1] = -12 * E * I / (L * L * L);
                Klij[1, 2] = (6 * E * I / (L * L));
                Klij[2, 0] = 0;
                Klij[2, 1] = (-6 * E * I / (L * L));
                Klij[2, 2] = 2 * E * I / L;

                //MATRIZ K21
                Klji[0, 0] = -E * A / L;
                Klji[0, 1] = 0;
                Klji[0, 2] = 0;
                Klji[1, 0] = 0;
                Klji[1, 1] = -12 * E * I / (L * L * L);
                Klji[1, 2] = (-6 * E * I / (L * L));
                Klji[2, 0] = 0;
                Klji[2, 1] = (6 * E * I / (L * L));
                Klji[2, 2] = 2 * E * I / L;

                //MATRIZ K22
                Kljj[0, 0] = E * A / L;
                Kljj[0, 1] = 0;
                Kljj[0, 2] = 0;
                Kljj[1, 0] = 0;
                Kljj[1, 1] = 12 * E * I / (L * L * L);
                Kljj[1, 2] = (-6 * E * I / (L * L));
                Kljj[2, 0] = 0;
                Kljj[2, 1] = (-6 * E * I / (L * L));
                Kljj[2, 2] = 4 * E * I / L;
            }
        }

        internal override void EsfuerzosFase1()
        {
            ListaFase1.Clear();
            //Interpolamos linealmente los esfuerzos entre los extremos de la barra
            double Theta = Angulo * Math.PI / 180.0;
            //Primero metemos los nodos en la barra que sirven como puntos para el calculo de esfuerzos
            for (int i = 0; i < NumeroPuntos; i++)
            {
                Nodo nod = new Nodo(X0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Cos(Theta), Y0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Sin(Theta), 0);
                double dx = (Longitud * i) / (NumeroPuntos - 1);
                if (i == 0) { nod.Dx = NodoInicial.Dx; nod.Dy = NodoInicial.Dy; nod.Dz = NodoInicial.Dz; }
                if (i == NumeroPuntos - 1) { nod.Dx = NodoFinal.Dx; nod.Dy = NodoFinal.Dy; nod.Dz = NodoFinal.Dz; }
                nod.Nx = Nxi; nod.Vy = Vyi; nod.Mz = Mzi + (Mzf - Mzi) * (dx / Longitud); ;
                ListaFase1.Add(nod);
            }

            DeformacionesFase1();
            SumaFases();
        }

        internal override void DeformacionesFase1()
        {
            ////Debido a los esfuerzos por puntos podemos calcular la deformación por puntos
            ////Las deformaciones tienen que referirse respecto al punto anterior puesto que son deformaciones relativas

            double dx = Longitud / (NumeroPuntos - 1);
            double area = Area;

            double elas = EYoung;


            double u0 = NodoInicial.Dx; // Deformacion axial en el punto inicial
            double v0 = NodoInicial.Dy; // Deformacion lateral en el punto inicial
            double gz0 = NodoInicial.Dz; // Giro en el punto inicial
            ListaFase1[0].Dx = u0;
            ListaFase1[0].Dy = v0;
            ListaFase1[0].Dz = gz0;

            double M0z = Mzi;
            double Q0y = Vyi;
            // Derivada de la deformada en el punto inicial
            double vpri0 = gz0;

            double u, v, gz, Nx, Mz, lambda, vpri;
            for (int i = 1; i < NumeroPuntos; i++)
            {
                // Deformacion axial XL
                Nx = ListaFase1[i].Nx;
                u = u0 + Nx * dx / (elas * area);
                ListaFase1[i].Dx = u;
                // Giro ZL
                Mz = ListaFase1[i].Mz;
                gz = gz0 + 0.5 * (Mz + M0z) * dx / (EYoung * Inercia);
                ListaFase1[i].Dz = gz;
                // Derivada de la deformada
                vpri = gz;
                // Deformacion transversal YL
                lambda = M0z * dx * dx / 3.0 + Mz * dx * dx / 6.0;
                v = v0 + vpri0 * dx + lambda / (EYoung * Inercia);
                ListaFase1[i].Dy = v;
                // Valores para el incremento siguiente
                u0 = u;
                v0 = v;
                gz0 = gz;
                M0z = Mz;
                vpri0 = vpri;
            }

            foreach (Nodo nod in ListaFase1)
            {
                //COORDENADAS GLOBALES
                OperacionesConMatrices op = new OperacionesConMatrices();
                Vector3d vect;
                vect = op.LocalesAGlobales(new Vector3d(nod.Dx, nod.Dy, nod.Dz), T);
                nod.DX = vect.X;
                nod.DY = vect.Y;
                nod.DZ = vect.Z;
            }
        }

        internal override void DeformacionesFase0(Carga carga)
        {

            //Debido a los esfuerzos por puntos podemos calcular la deformación por puntos
            //Las deformaciones tienen que referirse respecto al punto anterior puesto que son deformaciones relativas
            double EI = EYoung * Inercia;
            double EA = EYoung * Area;
            double L = Longitud;


            double u0 = 0; //Deformacion axial en punto inicial
            double gz0 = 0; //Giro en punto inicial
            double v0 = 0;
            double Mz0 = carga.MaG;

            double Theta = Angulo * Math.PI / 180.0;
            double c = Math.Cos(Theta), s = Math.Sin(Theta);

            if (carga.GetType() == typeof(CargaDistribuida))
            {
                double Q1 = carga.Qi;
                double Q2 = carga.Qj;
                double Q1YL = 0, Q2YL = 0, Q1XL = 0, Q2XL = 0;
                if (carga.SegunEje == "YL") { Q1YL = Q1; Q2YL = Q2; Q1XL = 0; Q2XL = 0; }
                else if (carga.SegunEje == "YG") { Q1YL = Q1 * c; Q2YL = Q2 * c; Q1XL = Q1 * s; Q2XL = Q2 * s; }
                else if (carga.SegunEje == "XL") { Q1YL = 0; Q2YL = 0; Q1XL = Q1; Q2XL = Q2; }
                else if (carga.SegunEje == "XG") { Q1YL = -Q1 * s; Q2YL = -Q2 * s; Q1XL = Q1 * c; Q2XL = Q2 * c; }

                double Ma = -(3.0 * Q1YL + 2.0 * Q2YL) * Longitud * Longitud / 60.0;
                double Mb = -(2.0 * Q1YL + 3.0 * Q2YL) * Longitud * Longitud / 60.0;
                double Ra = (2.0 * Q1YL + Q2YL) * Longitud / 6.0 - (Ma - Mb) / Longitud;

                double u, v, gz, Nx, Mz, dx;
                dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < ListaFase0.Count; i++)
                {
                    double x = i * dx;
                    ////Desplazamiento axial con teorema de la deformacion axial
                    Nx = ListaFase0[i].Nx;
                    u = Nx * x / EA;
                    ListaFase0[i].Dx = u;

                    //Giro en Z
                    Mz = ListaFase0[i].Mz;
                    gz = gz0 + 0.5 * (Mz + Mz0) * x / EI;
                    ListaFase0[i].Dz = gz;

                    //Deformacion lateral
                    v = (x * x / (24.0 * L * EI)) * ((((Q2YL - Q1YL) * x * x * x) / 5.0) + (Q1YL * L * x * x) - 4.0 * Ra * L * x - 12.0 * Ma * L);
                    ListaFase0[i].Dy = v;
                }

            }
            else if (carga.GetType() == typeof(FuerzaBarra))
            {
                double a = carga.Xi;
                double b = L - a;
                double P = carga.Modulo;
                double Ma = (P * a * b * b) / (L * L);
                double Mb = -(P * a * a * b) / (L * L);
                double Ra = (P * b) / L + (Mb + Ma) / L;
                double Rb = (P * a) / L - (Mb + Ma) / L;
                double dx = Longitud / (NumeroPuntos - 1);
                double v;
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    ListaFase0[i].Dx = 0;
                    //Deformacion lateral
                    if (x <= a)
                    {
                        v = ((P * b * b * x * x) / (6 * L * L * EI)) * (3 * a - x - (2 * a * x) / L);
                    }
                    else
                    {
                        v = (P * a * a * (L - x) * (L - x)) / (6 * L * L * EI) * (3 * b - (L - x) - (2 * b * (L - x)) / L);
                    }
                    ListaFase0[i].Dy = v;
                }

                carga.Xa = 0;
                carga.Xb = 0;
                carga.Ma = (P * a * b * b) / (L * L);
                carga.Mb = -(P * a * a * b) / (L * L);
                carga.Ra = (P * b) / L + (Mb + Ma) / L;
                carga.Rb = (P * a) / L - (Mb + Ma) / L;
            }
            else if (carga.GetType() == typeof(MomentoBarra))
            {
                double a = carga.Xi;
                double b = Longitud - a;
                double M0 = carga.Modulo;
                double Ma = M0 * b / L * (2.0 - 3.0 * b / L);
                double Mb = M0 * a / L * (2.0 - 3.0 * a / L);
                double v;

                double dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    ListaFase0[i].Dx = 0;
                    //Deformacion lateral
                    if (x <= a)
                    {
                        v = (-M0 * b * x * x) / (2 * L * EI) * ((2 * a * (L - x) / (L * L)) - b / L);
                    }
                    else
                    {
                        v = ((M0 * a * (L - x) * (L - x)) / (2 * L * EI)) * ((2 * b * x) / (L * L) - a / L);
                    }
                    ListaFase0[i].Dy = v;
                }
            }
            else if (carga.GetType() == typeof(CargaTermica))
            {
                u0 = NodoInicial.Dx;
                double u, v, gz, dx;
                dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < ListaFase0.Count; i++)
                {
                    double x = i * dx;
                    //Desplazamiento axial con teorema de la deformacion axial
                    u = Alfa * carga.Tmedia * x;
                    ListaFase0[i].Dx = 0;

                    //Giro en Z
                    gz = gz0 - Alfa * carga.Tgrad * x;
                    ListaFase0[i].Dz = gz;

                    //Deformacion lateral
                    v = v0 - Alfa * carga.Tgrad * x * x / 2.0;
                    ListaFase0[i].Dy = v;
                    //ListaFase0[i].Dx = ListaFase0[i].Dy = ListaFase0[i].Dz = 0;
                }
            }


            foreach (Nodo nod in ListaFase0)
            {
                //COORDENADAS GLOBALES
                OperacionesConMatrices op = new OperacionesConMatrices();
                Vector3d vect;
                vect = op.LocalesAGlobales(new Vector3d(nod.Dx, nod.Dy, nod.Dz), T);
                nod.DX = vect.X;
                nod.DY = vect.Y;
                nod.DZ = vect.Z;
            }

        }

        internal override void EsfuerzosFase0(Carga carga)
        {
            double L = Longitud;
            double Theta = Angulo * Math.PI / 180.0;
            double c = Math.Cos(Theta), s = Math.Sin(Theta);

            ListaFase0.Clear();
            //  A||----------||B
            if (carga.GetType() == typeof(CargaDistribuida))
            {
                double Q1 = carga.Qi;
                double Q2 = carga.Qj;
                double Q1YL = 0, Q2YL = 0, Q1XL = 0, Q2XL = 0;
                if (carga.SegunEje == "YL") { Q1YL = Q1; Q2YL = Q2; Q1XL = 0; Q2XL = 0; }
                else if (carga.SegunEje == "YG") { Q1YL = Q1 * c; Q2YL = Q2 * c; Q1XL = Q1 * s; Q2XL = Q2 * s; }
                else if (carga.SegunEje == "XL") { Q1YL = 0; Q2YL = 0; Q1XL = Q1; Q2XL = Q2; }
                else if (carga.SegunEje == "XG") { Q1YL = -Q1 * s; Q2YL = -Q2 * s; Q1XL = Q1 * c; Q2XL = Q2 * c; }
                double Na = -(2.0 * Q1XL + Q2XL) * L / 6.0;
                double Nb = -(Q1XL + 2.0 * Q2XL) * L / 6.0;
                double Ma = -(3.0 * Q1YL + 2.0 * Q2YL) * (L * L) / 60.0;
                double Mb = +(2.0 * Q1YL + 3.0 * Q2YL) * (L * L) / 60.0;
                double Va = -(2.0 * Q1YL + Q2YL) * L / 6.0 + (Ma + Mb) / L;
                double Vb = -(Q1YL + 2.0 * Q2YL) * L / 6.0 - (Ma + Mb) / L;
                double dx = L / (NumeroPuntos - 1);
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    double N = -Na - Q1XL * x - (Q2XL - Q1XL) * x * x / (2.0 * L);
                    double V = -Va - Q1YL * x - (Q2YL - Q1YL) * x * x / (2.0 * L);
                    double M = Va * x - Ma + (Q1YL * x * x) / 2.0 + (Q2YL - Q1YL) * x * x * x / (6.0 * L);

                    Nodo nod = new Nodo(X0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Cos(Theta), Y0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Sin(Theta), 0)
                    {
                        Nx = N,
                        Vy = V,
                        Mz = M
                    };
                    ListaFase0.Add(nod);
                }

                carga.Xa = -Na;
                carga.Xb = -Nb;
                carga.Ma = -Ma;
                carga.Mb = -Mb;
                carga.Ra = -Va;
                carga.Rb = -Vb;
            }
            else if (carga.GetType() == typeof(MomentoBarra))
            {
                double a = carga.Xi;
                double b = Longitud - a;
                double M0 = carga.Modulo;
                double Ma = M0 * b / L * (2.0 - 3.0 * b / L);
                double Mb = M0 * a / L * (2.0 - 3.0 * a / L);
                double Ra = M0 / L + (Mb + Ma) / L;
                double Rb = M0 / L + (Mb + Ma) / L;
                double Pa = 6.0 * M0 * a * b / (L * L * L);
                double dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    double N = 0;
                    double V = M0 / L + (Mb + Ma) / L;
                    double M = 0;
                    if (x < a)
                    {
                        //M = -M0 * b / L * (3 * a / L * (1 - 2.0 * x / L) - 1);
                        M = Pa * x - Ma;
                    }
                    else
                    {
                        //M = M0 * a / L * (3 * b / L * (1 - 2.0 * (L - x) / L) - 1);
                        M = Pa * x - Ma - M0;
                    }

                    Nodo nod = new Nodo(X0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Cos(Theta), Y0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Sin(Theta), 0)
                    {
                        Nx = N,
                        Vy = V,
                        Mz = M
                    };
                    ListaFase0.Add(nod);
                }
                carga.Xa = 0;
                carga.Xb = 0;
                carga.Ma = -M0 * b / L * (2.0 - 3.0 * b / L);
                carga.Mb = -M0 * a / L * (2.0 - 3.0 * a / L);
                carga.Ra = -M0 / L + (Mb + Ma) / L;
                carga.Rb = M0 / L + (Mb + Ma) / L;
            }
            else if (carga.GetType() == typeof(CargaTermica))
            {
                double TMedia = carga.Tmedia;
                double Gradiente = carga.Tgrad;
                double N = 0, M = 0;
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    N = -EYoung * Area * Alfa * TMedia;
                    M = EYoung * Inercia * Alfa * Gradiente;
                    Nodo nod = new Nodo(X0 + (L * i) / (NumeroPuntos - 1) * Math.Cos(Theta), Y0 + (L * i) / (NumeroPuntos - 1) * Math.Sin(Theta), 0)
                    {
                        Nx = N,
                        Vy = 0,
                        Mz = M
                    };
                    ListaFase0.Add(nod);
                }
                carga.Xa = N;
                carga.Xb = -N;
                carga.Ma = M;
                carga.Mb = -M;
            }
            else if (carga.GetType() == typeof(FuerzaBarra))
            {
                double a = carga.Xi;
                double b = L - a;
                double P = -carga.Modulo;
                double Ma = (P * a * b * b) / (L * L);
                double Mb = -(P * a * a * b) / (L * L);
                double Ra = (P * b) / L + (Mb + Ma) / L;
                double Rb = (P * a) / L - (Mb + Ma) / L;
                double dx = Longitud / (NumeroPuntos - 1);

                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    double N = 0;
                    double V = 0;
                    double M = 0;
                    if (x <= a)
                    {
                        V = Ra;
                        M = ((P * b * x) / L) - Ma * (1 - x / L) - (P * a * a * b * x) / (L * L * L);
                    }
                    else
                    {
                        V = -Rb;
                        M = ((P * a * (L - x)) / L) - Ma * (1 - x / L) - (P * a * a * b * x) / (L * L * L);
                    }

                    Nodo nod = new Nodo(X0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Cos(Theta), Y0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Sin(Theta), 0)
                    {
                        Nx = N,
                        Vy = V,
                        Mz = M
                    };
                    ListaFase0.Add(nod);
                }
                carga.Xa = 0;
                carga.Xb = 0;
                carga.Ma = (P * a * b * b) / (L * L);
                carga.Mb = -(P * a * a * b) / (L * L);
                carga.Ra = (P * b) / L + (Mb + Ma) / L;
                carga.Rb = (P * a) / L - (Mb + Ma) / L;
            }

            Vector3d vectLi = new Vector3d();
            Vector3d vectLj = new Vector3d();
            Vector3d vectGi;
            Vector3d vectGj;

            T = new double[3, 3];
            T[0, 0] = c; T[0, 1] = -s; T[0, 2] = 0;
            T[1, 0] = s; T[1, 1] = c; T[1, 2] = 0;
            T[2, 0] = 0; T[2, 1] = 0; T[2, 2] = 1;

            vectLi.X = carga.Xa; vectLi.Y = carga.Ra; vectLi.Z = carga.Ma;
            vectLj.X = carga.Xb; vectLj.Y = carga.Rb; vectLj.Z = carga.Mb;
            OperacionesConMatrices oper = new OperacionesConMatrices();
            vectGi = oper.LocalesAGlobales(vectLi, T);
            vectGj = oper.LocalesAGlobales(vectLj, T);

            carga.XaG = vectGi.X; carga.RaG = vectGi.Y; carga.MaG = vectGi.Z;
            carga.XbG = vectGj.X; carga.RbG = vectGj.Y; carga.MbG = vectGj.Z;
        }

        internal override void SumaFases()
        {
            ListaFaseFinal.Clear();
            //Contribucion de la fase 1. Que la tienen todas las barras
            for (int i = 0; i < ListaFase1.Count; i++)
            {
                Nodo nod = new Nodo(ListaFase1[i].X, ListaFase1[i].Y, 0)
                {
                    Nx = ListaFase1[i].Nx,
                    Dx = ListaFase1[i].Dx,
                    DX = ListaFase1[i].DX,
                    Vy = ListaFase1[i].Vy,
                    Dy = ListaFase1[i].Dy,
                    DY = ListaFase1[i].DY,
                    Mz = ListaFase1[i].Mz,
                    Dz = ListaFase1[i].Dz,
                    DZ = ListaFase1[i].DZ
                };
                ListaFaseFinal.Add(nod);
            }
            //Contribucion de la fase0. Que la tienen las barras con cargas intermedias
            for (int i = 0; i < ListaFaseFinal.Count; i++)
            {
                if (i < ListaFase0.Count)
                {
                    ListaFaseFinal[i].Nx += ListaFase0[i].Nx; ListaFaseFinal[i].Dx += ListaFase0[i].Dx; ListaFaseFinal[i].DX += ListaFase0[i].DX;
                    ListaFaseFinal[i].Vy += ListaFase0[i].Vy; ListaFaseFinal[i].Dy += ListaFase0[i].Dy; ListaFaseFinal[i].DY += ListaFase0[i].DY;
                    ListaFaseFinal[i].Mz += ListaFase0[i].Mz; ListaFaseFinal[i].Dz += ListaFase0[i].Dz; ListaFaseFinal[i].DZ += ListaFase0[i].DZ;
                }
            }
        }

    }
}
