using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    public class Punto
    {

        internal double X, Y;

        public Punto(double Xr, double Yr)
        {
            X = Xr;
            Y = Yr;
        }

        internal void Dibujar(float R, double RR, double GG, double BB)
        {
            GL.DepthFunc(DepthFunction.Always);
            int increm = 20;

            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), 0);
                Vector3d Vect2 = new Vector3d(X + R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 0);
                Vector3d Vect3 = new Vector3d(X, Y, 0);
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
            GL.DepthFunc(DepthFunction.Less);
        }

        internal void Seleccionado(double R2)
        {
            Esfera esfera = new Esfera(R2 * 1.3, X, Y, 0);
            esfera.Dibujar(1.0, 1.0 / 3, 0);
        }

    }
}
