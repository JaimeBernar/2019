using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    class ApoyoDeslizaderaArticX : Apoyo
    {
        public ApoyoDeslizaderaArticX(double x, double y)
        {
            X = x;
            Y = y;
        }
        internal override void Dibujar2D(double TAM, double RR, double GG, double BB)
        {
            int increm = 20;
            GL.PushMatrix();
            GL.Translate(X, Y, 0);
            GL.Rotate(0, 0, 0, 1);
            GL.PushMatrix();
            double[] datos = new double[4];
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(RR, GG, BB);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(-TAM * 0.5, -TAM * 0.85, 0);
            GL.Vertex3(TAM * 0.5, -TAM * 0.85, 0);
            GL.End();
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Translate(0, 0 - TAM, 0);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(TAM / 6.0 * Math.Cos(i * (Math.PI / 180)), TAM / 6.0 * Math.Sin(i * (Math.PI / 180)), 0);
                Vector3d Vect2 = new Vector3d(TAM / 6.0 * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), TAM / 6.0 * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 0);
                Vector3d Vect3 = new Vector3d(0, 0, 0);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            }
            GL.End();
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Translate(0 - 0.35 * TAM, 0 - TAM, 0);
            GL.Rotate(Theta, 0, 0, 1);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(TAM / 6.0 * Math.Cos(i * (Math.PI / 180)), TAM / 6.0 * Math.Sin(i * (Math.PI / 180)), 0);
                Vector3d Vect2 = new Vector3d(TAM / 6.0 * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), TAM / 6.0 * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 0);
                Vector3d Vect3 = new Vector3d(0, 0, 0);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            }
            GL.End();
            GL.PopMatrix();

            GL.PushMatrix();
            GL.Translate(+0.35 * TAM, -TAM, 0);
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(TAM / 6.0 * Math.Cos(i * (Math.PI / 180)), TAM / 6.0 * Math.Sin(i * (Math.PI / 180)), 0);
                Vector3d Vect2 = new Vector3d(TAM / 6.0 * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), TAM / 6.0 * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 0);
                Vector3d Vect3 = new Vector3d(0, 0, 0);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            }
            GL.End();
            GL.PopMatrix();
            GL.PopMatrix();
        }
    }
}
