using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace TFG
{
    [Serializable]
    public class Nodo
    {

        public int NumeroNodo { get; set; }
        public int NumeroNodoK { get; set; }

        public Apoyo ApoyoAsociado { get; set; }
        public List<Barra> ListaBarrasAsociadas { get; } = new List<Barra>();

        public Nodo(double Cx, double Cy, double Cz)
        {
            X = Cx;
            Y = Cy;
            Z = Cz;
        }

        //FUERZAS Y MOMENTOS
        public double FX { get; set; } = 0;
        public double FY { get; set; } = 0;
        public double FZ { get; set; } = 0;

        //DESPLAZAMIENTOS GLOBALES
        public double DX { get; set; } = 1;
        public double DY { get; set; } = 1;
        public double DZ { get; set; } = 1;

        //DESPLAZAMIENTOS LOCALES
        public double Dx { get; set; } = 1;
        public double Dy { get; set; } = 1;
        public double Dz { get; set; } = 1;


        // Centros
        internal double X { get; set; }
        internal double Y { get; set; }
        internal double Z { get; set; }

        //Esfuerzos
        internal double Nx { get; set; }
        internal double Vy { get; set; }
        internal double Mz { get; set; }

        internal bool Articulado { get; set; }
        internal bool Rigido { get; set; }

        internal void Dibujar(double R, double RR, double GG, double BB)
        {
            GL.PushMatrix();
            double increRad = Math.PI / 10.0;
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(RR, GG, BB);
            for (double teta = 0; teta < Math.PI; teta += increRad)
            {
                for (double phi = 0; phi < 2 * Math.PI; phi += increRad)
                {   //VERTICE 1
                    Vector3d Vertice1 = new Vector3d
                    {
                        Z = Z + (R) * (Math.Sin(teta)) * (Math.Cos(phi + increRad)),
                        X = X + (R) * (Math.Sin(teta)) * (Math.Sin(phi + increRad)),
                        Y = Y + (R) * (Math.Cos(teta))
                    };

                    //VERTICE 2
                    Vector3d Vertice2 = new Vector3d
                    {
                        Z = Z + (R) * (Math.Sin(teta + increRad)) * (Math.Cos(phi + increRad)),
                        X = X + (R) * (Math.Sin(teta + increRad)) * (Math.Sin(phi + increRad)),
                        Y = Y + (R) * (Math.Cos(teta + increRad))
                    };
                    //VERTICE 3
                    Vector3d Vertice3 = new Vector3d
                    {
                        Z = Z + (R) * (Math.Sin(teta + increRad)) * (Math.Cos(phi)),
                        X = X + (R) * (Math.Sin(teta + increRad)) * (Math.Sin(phi)),
                        Y = Y + (R) * (Math.Cos(teta + increRad))
                    };
                    //VERTICE 4
                    Vector3d Vertice4 = new Vector3d
                    {
                        Z = Z + (R) * (Math.Sin(teta)) * (Math.Cos(phi)),
                        X = X + (R) * (Math.Sin(teta)) * (Math.Sin(phi)),
                        Y = Y + (R) * (Math.Cos(teta))
                    };


                    //TRIANGULO 1
                    Vector3d L1 = new Vector3d(Vertice2 - Vertice1);
                    Vector3d L2 = new Vector3d(Vertice1 - Vertice4);
                    Vector3d Perp1 = new Vector3d(Vector3d.Cross(L1, L2));
                    Perp1.Normalize();
                    GL.Normal3(Perp1);
                    GL.Vertex3(Vertice1.X, Vertice1.Y, Vertice1.Z);
                    GL.Vertex3(Vertice2.X, Vertice2.Y, Vertice2.Z);
                    GL.Vertex3(Vertice3.X, Vertice3.Y, Vertice3.Z);
                    //TRIANGULO2
                    Vector3d L3 = new Vector3d(Vertice4 - Vertice2);
                    Vector3d L4 = new Vector3d(Vertice4 - Vertice1);
                    Vector3d Perp2 = new Vector3d(Vector3d.Cross(L3, L4));
                    Perp2.Normalize();
                    GL.Normal3(Perp2);
                    GL.Vertex3(Vertice1.X, Vertice1.Y, Vertice1.Z);
                    GL.Vertex3(Vertice3.X, Vertice3.Y, Vertice3.Z);
                    GL.Vertex3(Vertice4.X, Vertice4.Y, Vertice4.Z);
                }
            }
            GL.End();
            GL.PopMatrix();

            if (Articulado)
            {
                CoronaCircular corfinal = new CoronaCircular(X, Y, 0, R * 0.7, 1.4 * R, 2 * R);
                corfinal.Dibujar(0.5, 0.5, 0.5);
            }
        }

        internal void Dibujar2D(double R, double RR, double GG, double BB)
        {
            int increm = 20;

            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), 10);
                Vector3d Vect2 = new Vector3d(X + R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 10);
                Vector3d Vect3 = new Vector3d(X, Y, 10);
                Vector3d L1 = new Vector3d(Vect2 - Vect1);
                Vector3d L2 = new Vector3d(Vect3 - Vect1);
                Vector3d Perp = new Vector3d(Vector3d.Cross(L1, L2));
                Perp.Normalize();
                GL.Normal3(Perp);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            }
            GL.End();
            bool NodoArt = false;
            bool NodoRig = false;
            foreach (Barra bar in ListaBarrasAsociadas)
            {
                if (bar.GetType() == typeof(BarraArticulada))
                {
                    NodoArt = true;
                }

                if (bar.GetType() == typeof(BarraRigida))
                {
                    NodoRig = true;
                }

                if (bar.GetType() == typeof(BarraRigidaArticulada))
                {
                    if (bar.NodoInicial == this)
                    {
                        NodoRig = true;
                    }
                    else
                    {
                        NodoArt = true;
                    }
                }
            }

            if (NodoArt)
            {
                CoronaCircular cor = new CoronaCircular(X, Y, 15, 0.95 * R, 1.75 * R);
                cor.Dibujar2D(0.45, 0.45, 0.45);
            }

            if (NodoRig)
            {
                CoronaRectangular cor = new CoronaRectangular(X, Y, 15, 3 * R, 1.5 * R);
                cor.Dibujar2D(0.45, 0.45, 0.45);
            }
        }
    }
}
