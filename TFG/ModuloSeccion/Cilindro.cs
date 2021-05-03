using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    public class Cilindro
    {
        internal double R, h, x, y, z;
        public Cilindro(double Diametro, double Altura, double cx, double cy, double cz)
        {
            R = Diametro / 2;
            h = Altura;
            x = cx;
            y = cy;
            z = cz;
        }


        internal void Dibujar(double RR, double GG, double BB, double Theta, double Phi)
        {
            double increm = 20;
            GL.PushMatrix();
            GL.Translate(x, y, z);
            GL.Rotate(Theta, 0, 1, 0);
            GL.Rotate(Phi, 0, 0, 1);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect5 = new Vector3d(0, 0, 0);
                Vector3d Vect6 = new Vector3d(0, R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d Vect7 = new Vector3d(0, R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));

                Vector3d L3 = new Vector3d(Vect6 - Vect5);
                Vector3d L4 = new Vector3d(Vect7 - Vect5);
                Vector3d Perp2 = new Vector3d(Vector3d.Cross(L3, L4));
                Perp2.Normalize();
                GL.Normal3(Perp2);
                GL.Vertex3(Vect5.X, Vect5.Y, Vect5.Z);
                GL.Vertex3(Vect6.X, Vect6.Y, Vect6.Z);
                GL.Vertex3(Vect7.X, Vect7.Y, Vect7.Z);
            }
            GL.End();
            GL.Begin(PrimitiveType.TriangleFan);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect9 = new Vector3d(h, 0, 0);
                Vector3d Vect10 = new Vector3d(h, R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d Vect11 = new Vector3d(h, R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));

                Vector3d L5 = new Vector3d(Vect10 - Vect9);
                Vector3d L6 = new Vector3d(Vect11 - Vect10);
                Vector3d Perp3 = new Vector3d(Vector3d.Cross(L6, L5));
                Perp3.Normalize();
                GL.Normal3(Perp3);
                GL.Vertex3(Vect9.X, Vect9.Y, Vect9.Z);
                GL.Vertex3(Vect10.X, Vect10.Y, Vect10.Z);
                GL.Vertex3(Vect11.X, Vect11.Y, Vect11.Z);
            }
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(0, R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d Vect2 = new Vector3d(0, R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));
                Vector3d Vect3 = new Vector3d(h, R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180));
                Vector3d Vect4 = new Vector3d(h, R * Math.Sin(i * (Math.PI / 180)), R * Math.Cos(i * (Math.PI / 180)));
                Vector3d L1 = new Vector3d(Vect2 - Vect1);
                Vector3d L2 = new Vector3d(Vect3 - Vect1);
                Vector3d Perp = new Vector3d(Vector3d.Cross(L2, L1));
                Perp.Normalize();
                GL.Normal3(Perp);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
                GL.Vertex3(Vect4.X, Vect4.Y, Vect4.Z);
            }
            GL.End();


            GL.Rotate(-Theta, 0, 1, 0);
            GL.Rotate(-Phi, 0, 0, 1);
            GL.Translate(-x, -y, -z);
            GL.LoadIdentity();
            GL.PopMatrix();

        }

        internal void DibujarPlano(double RR, double GG, double BB, double Theta, double Phi)
        {
            GL.PushMatrix();
            GL.Translate(x, y, z);
            GL.Rotate(Theta, 0, 1, 0);
            GL.Rotate(Phi, 0, 0, 1);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Vertex3(0, R, 0);
            GL.Vertex3(0, -R, 0);
            GL.Vertex3(h, -R, 0);
            GL.Vertex3(h, R, 0);
            GL.End();
            GL.PopMatrix();

        }
    }
}
