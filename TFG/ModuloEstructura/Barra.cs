using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace TFG
{
    [Serializable]
    public class Barra
    {
        public bool EnergiaElasticaPositiva { get; set; } = true;
        internal double X0, Y0, X1, Y1;
        public bool CargaTermica { get; set; }
        public Carga Carga { get; set; }
        public Nodo NodoInicial { get; set; }
        public Nodo NodoFinal { get; set; }
        public Barra() { }
        public Barra(Vector3d Inicio, Vector3d Final)
        {
            X0 = Inicio.X;
            Y0 = Inicio.Y;
            X1 = Final.X;
            Y1 = Final.Y;
        }

        public int TipoCTE { get; set; }
        public double Area { get; set; } = 0.000764;
        public double Inercia { get; set; } = 8.01E-07;
        public double EYoung { get; set; } = 205939650000;
        public double Alfa { get; set; } = 1.2E-05;//Coeficiente de dilatacion lineal

        public int NumeroBarra { get; set; }
        internal double Longitud { get; set; }
        internal double Angulo { get; set; }
        public double[,] Kii { get; set; }
        public double[,] Kjj { get; set; }
        public double[,] Kij { get; set; }
        public double[,] Kji { get; set; }
        public double[,] Klii { get; set; }
        public double[,] Kljj { get; set; }
        public double[,] Klij { get; set; }
        public double[,] Klji { get; set; }


        //Esfuezos en los extremos
        public double Nxi { get; set; }
        public double Vyi { get; set; }
        public double Mzi { get; set; }
        public double Nxf { get; set; }
        public double Vyf { get; set; }
        public double Mzf { get; set; }

        public double[,] T { get; set; }
        public double[,] Ttras { get; set; }

        internal virtual void MatrizRigidez() { }

        internal List<Nodo> ListaFase1 { get; set; } = new List<Nodo>();
        internal List<Nodo> ListaFase0 { get; set; } = new List<Nodo>();
        internal List<Nodo> ListaFaseFinal { get; set; } = new List<Nodo>();
        public int NumeroPuntos { get; set; } = 20;

        internal virtual void Dibujar(double Radio, double RR, double GG, double BB)
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
            Cilindro barra = new Cilindro(Radio, Longitud, X0, Y0, 0);
            barra.Dibujar(RR, GG, BB, 0, Angulo);

        }

        internal virtual void Dibujar2D(double Radio, double RR, double GG, double BB)
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
            GL.PopMatrix();
        }

        internal virtual void EsfuerzosFase1() { }

        internal virtual void DeformacionesFase1() { }

        internal virtual void EsfuerzosFase0(Carga carga) { }
        internal virtual void DeformacionesFase0(Carga carga) { }
        internal virtual void SumaFases() { }
        internal void DibujarFlector(double Esc)
        {
            if (EnergiaElasticaPositiva)
            {
                int dim = ListaFaseFinal.Count - 1;
                double theta = (Math.Atan2((Y1 - Y0), (X1 - X0)) + MathHelper.PiOver2);

                GL.LineWidth(1f);
                GL.Begin(PrimitiveType.LineStrip);
                GL.Color3(0.7, 0.0, 0.0);
                if (ListaFaseFinal.Count > 1)
                {
                    GL.Vertex3(ListaFaseFinal[0].X, ListaFaseFinal[0].Y, 0);
                    GL.Vertex3(ListaFaseFinal[0].X - ListaFaseFinal[0].Mz * Esc * Math.Cos(theta), ListaFaseFinal[0].Y - ListaFaseFinal[0].Mz * Esc * Math.Sin(theta), 0);
                    for (int i = 0; i < ListaFaseFinal.Count; i++)
                    {
                        GL.Vertex3(ListaFaseFinal[i].X - ListaFaseFinal[i].Mz * Esc * Math.Cos(theta), ListaFaseFinal[i].Y - ListaFaseFinal[i].Mz * Esc * Math.Sin(theta), 0);
                    }
                    GL.Vertex3(ListaFaseFinal[dim].X, ListaFaseFinal[dim].Y, 0);
                    GL.Vertex3(ListaFaseFinal[dim].X - ListaFaseFinal[dim].Mz * Esc * Math.Cos(theta), ListaFaseFinal[dim].Y - ListaFaseFinal[dim].Mz * Esc * Math.Sin(theta), 0);
                }
                GL.End();
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.7, 0.0, 0.0);
                if (ListaFaseFinal.Count > 1)
                {
                    for (int i = 0; i < ListaFaseFinal.Count; i++)
                    {
                        GL.Vertex3(ListaFaseFinal[i].X, ListaFaseFinal[i].Y, 0);
                        GL.Vertex3(ListaFaseFinal[i].X - ListaFaseFinal[i].Mz * Esc * Math.Cos(theta), ListaFaseFinal[i].Y - ListaFaseFinal[i].Mz * Esc * Math.Sin(theta), 0);
                    }
                }
                GL.End();
            }
        }
        internal void DibujarAxial(double Esc)
        {
            if (EnergiaElasticaPositiva)
            {
                int dim = ListaFaseFinal.Count - 1;
                double theta = (Math.Atan2((Y1 - Y0), (X1 - X0)) + MathHelper.PiOver2);

                GL.LineWidth(1f);
                GL.Begin(PrimitiveType.LineStrip);
                GL.Color3(0.0, 0.7, 0.0);
                if (ListaFaseFinal.Count > 1)
                {
                    GL.Vertex3(ListaFaseFinal[0].X, ListaFaseFinal[0].Y, 0);
                    GL.Vertex3(ListaFaseFinal[0].X - ListaFaseFinal[0].Nx * Esc * Math.Cos(theta), ListaFaseFinal[0].Y - ListaFaseFinal[0].Nx * Esc * Math.Sin(theta), 0);
                    for (int i = 0; i < ListaFaseFinal.Count; i++)
                    {
                        GL.Vertex3(ListaFaseFinal[i].X - ListaFaseFinal[i].Nx * Esc * Math.Cos(theta), ListaFaseFinal[i].Y - ListaFaseFinal[i].Nx * Esc * Math.Sin(theta), 0);
                    }
                    GL.Vertex3(ListaFaseFinal[dim].X, ListaFaseFinal[dim].Y, 0);
                    GL.Vertex3(ListaFaseFinal[dim].X - ListaFaseFinal[dim].Nx * Esc * Math.Cos(theta), ListaFaseFinal[dim].Y - ListaFaseFinal[dim].Nx * Esc * Math.Sin(theta), 0);
                }
                GL.End();
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.0, 0.7, 0.0);
                if (ListaFaseFinal.Count > 1)
                {
                    for (int i = 0; i < ListaFaseFinal.Count; i++)
                    {
                        GL.Vertex3(ListaFaseFinal[i].X, ListaFaseFinal[i].Y, 0);
                        GL.Vertex3(ListaFaseFinal[i].X - ListaFaseFinal[i].Nx * Esc * Math.Cos(theta), ListaFaseFinal[i].Y - ListaFaseFinal[i].Nx * Esc * Math.Sin(theta), 0);
                    }
                }
                GL.End();
            }
        }
        internal void DibujarCortante(double Esc)
        {
            if (EnergiaElasticaPositiva)
            {
                int dim = ListaFaseFinal.Count - 1;
                double theta = (Math.Atan2((Y1 - Y0), (X1 - X0)) + MathHelper.PiOver2);

                GL.LineWidth(1f);

                GL.Begin(PrimitiveType.LineStrip);
                GL.Color3(0.0, 0.0, 0.7);
                if (ListaFaseFinal.Count > 1)
                {
                    GL.Vertex3(ListaFaseFinal[0].X, ListaFaseFinal[0].Y, 0);
                    GL.Vertex3(ListaFaseFinal[0].X + ListaFaseFinal[0].Vy * Esc * Math.Cos(theta), ListaFaseFinal[0].Y + ListaFaseFinal[0].Vy * Esc * Math.Sin(theta), 0);
                    for (int i = 0; i < ListaFaseFinal.Count; i++)
                    {
                        GL.Vertex3(ListaFaseFinal[i].X + ListaFaseFinal[i].Vy * Esc * Math.Cos(theta), ListaFaseFinal[i].Y + ListaFaseFinal[i].Vy * Esc * Math.Sin(theta), 0);
                    }
                    GL.Vertex3(ListaFaseFinal[dim].X, ListaFaseFinal[dim].Y, 0);
                    GL.Vertex3(ListaFaseFinal[dim].X + ListaFaseFinal[dim].Vy * Esc * Math.Cos(theta), ListaFaseFinal[dim].Y + ListaFaseFinal[dim].Vy * Esc * Math.Sin(theta), 0);
                }
                GL.End();
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(0.0, 0.0, 0.7);
                if (ListaFaseFinal.Count > 1)
                {
                    for (int i = 0; i < ListaFaseFinal.Count; i++)
                    {
                        GL.Vertex3(ListaFaseFinal[i].X, ListaFaseFinal[i].Y, 0);
                        GL.Vertex3(ListaFaseFinal[i].X + ListaFaseFinal[i].Vy * Esc * Math.Cos(theta), ListaFaseFinal[i].Y + ListaFaseFinal[i].Vy * Esc * Math.Sin(theta), 0);
                    }
                }
                GL.End();
            }

        }
        internal void Deformada(double Esc)
        {
            if (EnergiaElasticaPositiva)
            {
                GL.DepthFunc(DepthFunction.Always);
                GL.LineWidth(3f);
                GL.Begin(PrimitiveType.LineStrip);
                GL.Color3(1.0, 0.5, 0.0);
                for (int i = 0; i < ListaFaseFinal.Count; i++)
                {
                    GL.Vertex3(ListaFaseFinal[i].X + Esc * ListaFaseFinal[i].DX, ListaFaseFinal[i].Y + Esc * ListaFaseFinal[i].DY, 0);
                }
                GL.End();
                GL.LineWidth(1f);
                GL.DepthFunc(DepthFunction.Less);
            }
        }

    }
}
