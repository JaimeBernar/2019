using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    internal class BarraArticulada : Barra
    {
        public BarraArticulada(Vector3d Inicio, Vector3d Final)
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

            //Rectangulo ppal
            GL.PushMatrix();
            GL.Translate(X0, Y0, 0);
            GL.Rotate(Angulo, 0, 0, 1.0);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Vertex3(0, -Radio / 2.0, 0);
            GL.Vertex3(0, Radio / 2.0, 0);
            GL.Vertex3(Longitud - Radio, Radio / 2.0, 0);
            GL.Vertex3(Longitud - Radio, -Radio / 2.0, 0);
            GL.End();
            GL.PopMatrix();

            CoronaCircular Corcircini = new CoronaCircular(X0, Y0, 3, Radio * 0.6, 1.2 * Radio, 2 * Radio);
            Corcircini.ExtremoArticulado(RR - 0.2, GG - 0.2, BB - 0.2, Angulo);

            CoronaCircular Corcircfin = new CoronaCircular(X1, Y1, 3, Radio * 0.6, 1.2 * Radio, 2 * Radio);
            Corcircfin.ExtremoArticulado(RR - 0.2, GG - 0.2, BB - 0.2, Angulo + 180.0);
        }

        internal override void MatrizRigidez()
        {
            double E = EYoung;
            double L = Longitud;
            double A = Area;

            double Theta = Angulo * Math.PI / 180.0;

            double c = Math.Cos(Theta), s = Math.Sin(Theta);
            T = new double[3, 3];
            Ttras = new double[3, 3];

            T[0, 0] = c; T[0, 1] = -s; T[0, 2] = 0;
            T[1, 0] = s; T[1, 1] = c; T[1, 2] = 0;
            T[2, 0] = 0; T[2, 1] = 0; T[2, 2] = 1;


            OperacionesConMatrices op = new OperacionesConMatrices();
            Ttras = op.Traspuesta(T);

            //Submatrices en ejes globales
            {
                /*
                 [K11 K12]
                 [K21 K22]             
                 */
                Kii = new double[3, 3];
                Kjj = new double[3, 3];
                Kij = new double[3, 3];
                Kji = new double[3, 3];
                //MATRIZ K11
                Kii[0, 0] = (E * A * c * c) / L;
                Kii[0, 1] = (E * A * c * s) / L;
                Kii[0, 2] = 0;
                Kii[1, 0] = (E * A * c * s) / L;
                Kii[1, 1] = (E * A * s * s) / L;
                Kii[1, 2] = 0;
                Kii[2, 0] = Kii[2, 1] = Kii[2, 2] = 0;
                //MATRIZ K12
                Kij[0, 0] = (-E * A * c * c) / L;
                Kij[0, 1] = (-E * A * c * s) / L;
                Kij[0, 2] = 0;
                Kij[1, 0] = (-E * A * c * s) / L;
                Kij[1, 1] = (-E * A * s * s) / L;
                Kij[1, 2] = 0;
                Kij[2, 0] = Kij[2, 1] = Kij[2, 2] = 0;

                Kjj = Kii;
                Kji = Kij;
            }

            //Submatrices en ejes locales
            {
                /*
                    [K11 K12]
                    [K21 K22]             
                */
                Klii = new double[3, 3];
                Kljj = new double[3, 3];
                Klij = new double[3, 3];
                Klji = new double[3, 3];
                //MATRIZ K11
                Klii[0, 0] = E * A / L;
                Klii[0, 1] = 0;
                Klii[0, 2] = 0;
                Klii[1, 0] = 0;
                Klii[1, 1] = 0;
                Klii[1, 2] = 0;
                Klii[2, 0] = Klii[2, 1] = Klii[2, 2] = 0;
                //MATRIZ K12
                Klij[0, 0] = -E * A / L;
                Klij[0, 1] = 0;
                Klij[0, 2] = 0;
                Klij[1, 0] = 0;
                Klij[1, 1] = 0;
                Klij[1, 2] = 0;
                Klij[2, 0] = Klij[2, 1] = Klij[2, 2] = 0;

                Kljj = Klii;
                Klji = Klij;
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
            double iz = Inercia;
            double area = Area;
            double elas = EYoung;


            double x0 = NodoInicial.Dx; // Deformacion axial en el punto inicial
            double y0 = NodoInicial.Dy; // Deformacion lateral en el punto inicial
            double gz0 = NodoInicial.Dz; // Giro en el punto inicial
            ListaFase1[0].Dx = x0;
            ListaFase1[0].Dy = y0;
            ListaFase1[0].Dz = gz0;

            double M0z = Mzi;
            double Q0y = Vyi;
            // Derivada de la deformada en el punto inicial
            double vpri0 = gz0;

            double x, y, gz, Nx, Mz, lambda, yd;
            for (int i = 1; i < NumeroPuntos; i++)
            {
                double ax = i * dx;
                // Deformacion axial XL
                Nx = ListaFase1[i].Nx;
                x = x0 + Nx * dx / (elas * area);
                ListaFase1[i].Dx = x;
                // Giro ZL
                Mz = ListaFase1[i].Mz;
                gz = (NodoFinal.Dy - NodoInicial.Dy) / Longitud;
                ListaFase1[i].Dz = gz;
                // Derivada de la deformada
                yd = gz;
                // Deformacion transversal YL
                lambda = M0z * dx * dx / 3.0 + Mz * dx * dx / 6.0;
                //y = y0 + vpri0 * dx + lambda / (EYoung * Inercia);
                y = NodoInicial.Dy + (NodoFinal.Dy - NodoInicial.Dy) * ax / Longitud;
                ListaFase1[i].Dy = y;
                // Valores para el incremento siguiente
                x0 = x;
                M0z = Mz;
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
                double Ra = (2.0 * Q1YL + Q2YL) * Longitud / 6.0;
                double Rb = (2.0 * Q1YL + Q2YL) * Longitud / 6.0;

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
                    gz = (-L * (2 * Q1YL + Q2YL) * x * x) / (12 * EI) + (Q1YL * x * x * x) / (6 * EI) + ((Q2YL - Q1YL) * x * x * x * x) / (24 * L * EI) + ((7 * Q2YL + 8 * Q1YL) * L * L * L) / (360.0 * EI);
                    ListaFase0[i].Dz = gz;

                    //Deformacion lateral
                    v = x * (L - x) / (360.0 * L * EI) * (3.0 * (Q1YL - Q2YL) * x * x * x - 3.0 * (4.0 * Q1YL + Q2YL) * L * x * x + (8.0 * Q1YL + 7.0 * Q2YL) * (L * L * x + L * L * L));
                    ListaFase0[i].Dy = v;
                }
            }
            else if (carga.GetType() == typeof(FuerzaBarra))
            {

                double py = 0, px = 0;
                double a = carga.Xi;
                double b = L - a;
                double P = carga.Modulo;

                if (carga.SegunEje == "YL") { py = P; px = 0; }
                else if (carga.SegunEje == "YG") { py = P * c; px = P * s; }
                else if (carga.SegunEje == "XL") { py = 0.0; px = P; }
                else if (carga.SegunEje == "XG") { py = -P * s; px = P * c; }

                double dx = Longitud / (NumeroPuntos - 1);
                double v;
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    //Deformacion lateral
                    if (x <= a)
                    {
                        v = ((py * b * L * x) / (6.0 * EI)) * (1 - (b * b) / (L * L) - (x * x) / (L * L));
                    }
                    else
                    {
                        v = ((py * L * a * (L - x)) / (6.0 * EI)) * (1 - (a * a) / (L * L) - ((L - x) * (L - x)) / (L * L));
                    }
                    ListaFase0[i].Dy = v;
                }
            }
            else if (carga.GetType() == typeof(MomentoBarra))
            {
                double a = carga.Xi;
                double b = Longitud - a;
                double v;
                double M = carga.Modulo;
                double dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    ListaFase0[i].Dx = 0;
                    //Deformacion lateral
                    if (x <= a)
                    {
                        v = -(M * L * x / (6.0 * EI)) * (1 - (3.0 * b * b) / (L * L) - (x * x) / (L * L));
                    }
                    else
                    {
                        v = (M * L * (L - x)) / (6.0 * EI) * (1.0 - (3.0 * a * a) / (L * L) - ((L - x) * (L - x)) / (L * L));
                    }
                    ListaFase0[i].Dy = v;
                }
            }
            else if (carga.GetType() == typeof(CargaTermica))
            {
                double u, v, gz, dx;
                dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < ListaFase0.Count; i++)
                {
                    double x = i * dx;
                    //Desplazamiento axial con teorema de la deformacion axial
                    u = Alfa * carga.Tmedia * x;
                    ListaFase0[i].Dx = u;

                    //Giro en Z
                    gz = -Alfa * carga.Tgrad * x;
                    ListaFase0[i].Dz = gz;

                    //Deformacion lateral
                    v = -Alfa * carga.Tgrad * x * x / 2.0;
                    ListaFase0[i].Dy = v;
                    ListaFase0[i].Dx = ListaFase0[i].Dy = ListaFase0[i].Dz = 0;
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
                double Na = (2.0 * Q1XL + Q2XL) * Longitud / 6.0;
                double Nb = (Q1XL + 2.0 * Q2XL) * Longitud / 6.0;
                double Va = (2.0 * Q1YL + Q2YL) * Longitud / 6.0;
                double Vb = (Q1YL + 2.0 * Q2YL) * Longitud / 6.0;
                double dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    double N = Na - Q1XL * x - (Q2XL - Q1XL) * x * x / (2.0 * Longitud);
                    double V = L * (2.0 * Q1YL + Q2YL) / 6.0 - ((Q1YL * (2.0 * L - x) + Q2YL * x) * x) / (2 * L);
                    double M = -(L * (2.0 * Q1YL + Q2YL) * x / 6.0 - ((Q1YL * (3.0 * L - x) + Q2YL * x) * x * x) / (6 * L));

                    Nodo nod = new Nodo(X0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Cos(Theta), Y0 + (Longitud * i) / (NumeroPuntos - 1) * Math.Sin(Theta), 0)
                    {
                        Nx = N,
                        Vy = V,
                        Mz = M
                    };
                    ListaFase0.Add(nod);
                }

                carga.Xa = Na;
                carga.Xb = Nb;
                carga.Ma = 0;
                carga.Mb = 0;
                carga.Ra = Va;
                carga.Rb = Vb;
            }
            else if (carga.GetType() == typeof(MomentoBarra))
            {
                double a = carga.Xi;
                double b = Longitud - a;

                double Ra = carga.Modulo / Longitud;
                double Rb = carga.Modulo / Longitud;
                double dx = Longitud / (NumeroPuntos - 1);
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    double N = 0;
                    double V = 0;
                    double M = 0;
                    if (x < a)
                    {
                        V = Ra;
                        M = Ra * x;
                    }
                    else
                    {
                        V = Ra;
                        M = -carga.Modulo * (L - x) / L;
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
                carga.Ma = 0;
                carga.Mb = 0;
                carga.Ra = Ra;
                carga.Rb = Ra;
            }
            else if (carga.GetType() == typeof(CargaTermica))
            {
                double TMedia = carga.Tmedia;
                double N = 0, M;
                for (int i = 0; i < NumeroPuntos; i++)
                {
                    N = -EYoung * Area * Alfa * TMedia;
                    M = 0;
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

            }
            else if (carga.GetType() == typeof(FuerzaBarra))
            {
                double py = 0, px = 0;
                double a = carga.Xi;
                double b = L - a;
                double P = carga.Modulo;

                if (carga.SegunEje == "YL") { py = P; px = 0; }
                else if (carga.SegunEje == "YG") { py = P * c; px = P * s; }
                else if (carga.SegunEje == "XL") { py = 0.0; px = P; }
                else if (carga.SegunEje == "XG") { py = -P * s; px = P * c; }


                double Ra = -(py * b) / L;
                double Rb = (py * a) / L;
                double dx = Longitud / (NumeroPuntos - 1);

                for (int i = 0; i < NumeroPuntos; i++)
                {
                    double x = i * dx;
                    double N = 0;
                    double V = 0;
                    double M = 0;
                    if (x <= a)
                    {
                        N = px * b / L;
                        V = -Ra;
                        M = Ra * x;
                    }
                    else
                    {
                        N = -px * a / L;
                        V = -Ra - py;
                        M = Ra * x + py * (x - a);
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
                carga.Ma = 0;
                carga.Mb = 0;
                carga.Ra = Ra;
                carga.Rb = Rb;
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
