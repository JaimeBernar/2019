using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    public class Cono
    {
        internal double R, h, x, y, z;

        public Cono(double Diametro, double Altura, double cx, double cy, double cz)
        {
            R = Diametro / 2;
            h = Altura;
            x = cx;
            y = cy;
            z = cz;
        }


        internal void Dibujar(double RR, double GG, double BB, double Theta, double Phi, double zoom)
        {
            double increm = 24;
            GL.PushMatrix();
            GL.Translate(x, y, z);
            GL.Rotate(Theta, 0, 1, 0);
            GL.Rotate(Phi, 0, 0, 1);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(h, 0, 0);
                Vector3d Vect2 = new Vector3d(0, R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d Vect3 = new Vector3d(0, R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));
                Vector3d L1 = new Vector3d(Vect2 - Vect1);
                Vector3d L2 = new Vector3d(Vect3 - Vect2);
                Vector3d Perp = new Vector3d(Vector3d.Cross(L2, L1));
                Perp.Normalize();

                GL.Normal3(Perp);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            }
            GL.End();

            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect4 = new Vector3d(0, 0, 0);
                Vector3d Vect6 = new Vector3d(0, 0 + R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d Vect5 = new Vector3d(0, 0 + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));
                Vector3d L3 = new Vector3d(Vect5 - Vect4);
                Vector3d L4 = new Vector3d(Vect6 - Vect4);
                Vector3d Perp2 = new Vector3d(Vector3d.Cross(L3, L4));
                Perp2.Normalize();
                GL.Normal3(Perp2);
                GL.Vertex3(Vect4.X, Vect4.Y, Vect4.Z);
                GL.Vertex3(Vect5.X, Vect5.Y, Vect5.Z);
                GL.Vertex3(Vect6.X, Vect6.Y, Vect6.Z);
            }
            GL.End();
            GL.PopMatrix();

        }

        internal void DibujarDesdePunta(double RR, double GG, double BB, double Theta, double Phi)
        {
            int increm = 5;
            GL.PushMatrix();
            GL.Translate(x, y, z);
            GL.Rotate(Theta, 0, 1, 0);
            GL.Rotate(Phi, 0, 0, 1);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (int i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(0, 0, 0);
                Vector3d Vect2 = new Vector3d(-h, R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d Vect3 = new Vector3d(-h, R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));
                Vector3d L1 = new Vector3d(Vect2 - Vect1);
                L1.Normalize();
                Vector3d L2 = new Vector3d(Vect3 - Vect1);
                L2.Normalize();
                Vector3d Perp = new Vector3d(Vector3d.Cross(L2, L1));
                Perp.Normalize();
                GL.Normal3(Perp);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            }
            GL.End();

            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (int i = 0; i < 360; i += increm)
            {
                Vector3d Vect4 = new Vector3d(-h, 0, 0);
                Vector3d Vect5 = new Vector3d(-h, 0 + R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d Vect6 = new Vector3d(-h, 0 + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));
                Vector3d L3 = new Vector3d(Vect5 - Vect4);
                L3.Normalize();
                Vector3d L4 = new Vector3d(Vect6 - Vect4);
                L4.Normalize();
                Vector3d Perp2 = new Vector3d(Vector3d.Cross(L3, L4));
                Perp2.Normalize();
                GL.Normal3(Perp2);
                GL.Vertex3(Vect4.X, Vect4.Y, Vect4.Z);
                GL.Vertex3(Vect5.X, Vect5.Y, Vect5.Z);
                GL.Vertex3(Vect6.X, Vect6.Y, Vect6.Z);
            }
            GL.End();
            GL.PopMatrix();
        }
    }
}
