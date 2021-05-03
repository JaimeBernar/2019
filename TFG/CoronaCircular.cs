using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    class CoronaCircular
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Rext { get; set; }
        public double Rint { get; set; }
        public double L { get; set; }
        public CoronaCircular(double cx, double cy, double cz, double RadioInt, double RadioExt, double Lextr)
        {
            X = cx;
            Y = cy;
            Z = cz;
            Rext = RadioExt;
            Rint = RadioInt;
            L = Lextr;
        }
        public CoronaCircular(double cx, double cy, double cz, double RadioInt, double RadioExt)
        {
            X = cx;
            Y = cy;
            Z = cz;
            Rext = RadioExt;
            Rint = RadioInt;
        }
        internal void Dibujar(double RR, double GG, double BB)
        {
            int N = 5;
            int N2 = 5;
            //float[] LightSpec = { 0,0,0 };
            //GL.Light(LightName.Light1, LightParameter.Specular, LightSpec);
            GL.Color3(RR, GG, BB);
            //Tapa delante
            for (int i = 0; i <= N; ++i)
            {
                double angle1 = 2.0 * Math.PI * i / N;
                double angle2 = 2.0 * Math.PI * (i + 0.5) / N;
                double angle3 = 2.0 * Math.PI * (i + 1) / N;

                GL.Begin(PrimitiveType.TriangleFan);
                GL.Normal3(0, 0, 1.0);
                GL.Vertex3(X + Math.Cos(angle2) * Rext, Y + Math.Sin(angle2) * Rext, Z + L / 2);
                for (int j = 0; j <= N2; ++j)
                {
                    double a = angle1 + (angle3 - angle1) * j / N2;
                    GL.Vertex3(X + Math.Cos(a) * Rint, Y + Math.Sin(a) * Rint, Z + L / 2);
                }
                GL.End();
            }

            for (int i = 0; i <= N; ++i)
            {
                double angle1 = 2 * Math.PI * (i - 0.5) / N;
                double angle2 = 2 * Math.PI * i / N;
                double angle3 = 2 * Math.PI * (i + 0.5) / N;

                GL.Begin(PrimitiveType.TriangleFan);
                GL.Normal3(0, 0, 1.0);
                GL.Vertex3(X + Math.Cos(angle2) * Rint, Y + Math.Sin(angle2) * Rint, Z + L / 2);
                for (int j = 0; j <= N2; ++j)
                {
                    double a = angle1 + (angle3 - angle1) * j / N2;
                    GL.Vertex3(X + Math.Cos(a) * Rext, Y + Math.Sin(a) * Rext, Z + L / 2);
                }
                GL.End();
            }
            //Tapa detras
            for (int i = 0; i <= N; ++i)
            {
                double angle1 = 2.0 * Math.PI * i / N;
                double angle2 = 2.0 * Math.PI * (i + 0.5) / N;
                double angle3 = 2.0 * Math.PI * (i + 1) / N;

                GL.Begin(PrimitiveType.TriangleFan);
                GL.Normal3(0, 0, -1.0);
                GL.Vertex3(X + Math.Cos(angle2) * Rext, Y + Math.Sin(angle2) * Rext, Z - L / 2);
                for (int j = 0; j <= N2; ++j)
                {
                    double a = angle1 + (angle3 - angle1) * j / N2;
                    GL.Vertex3(X + Math.Cos(a) * Rint, Y + Math.Sin(a) * Rint, Z - L / 2);
                }
                GL.End();
            }

            for (int i = 0; i <= N; ++i)
            {
                double angle1 = 2 * Math.PI * (i - 0.5) / N;
                double angle2 = 2 * Math.PI * i / N;
                double angle3 = 2 * Math.PI * (i + 0.5) / N;

                GL.Begin(PrimitiveType.TriangleFan);
                GL.Normal3(0, 0, -1.0);
                GL.Vertex3(X + Math.Cos(angle2) * Rint, Y + Math.Sin(angle2) * Rint, Z - L / 2);
                for (int j = 0; j <= N2; ++j)
                {
                    double a = angle1 + (angle3 - angle1) * j / N2;
                    GL.Vertex3(X + Math.Cos(a) * Rext, Y + Math.Sin(a) * Rext, Z - L / 2);
                }
                GL.End();
            }

            //Circulo interior
            int increm = 10;
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(X + Rint * Math.Cos(i * (Math.PI / 180)), Y + Rint * Math.Sin(i * (Math.PI / 180)), Z + L / 2);
                Vector3d Vect2 = new Vector3d(X + Rint * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + Rint * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), Z + L / 2);
                Vector3d Vect3 = new Vector3d(X + Rint * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + Rint * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), Z - L / 2);
                Vector3d Vect4 = new Vector3d(X + Rint * Math.Cos(i * (Math.PI / 180)), Y + Rint * Math.Sin(i * (Math.PI / 180)), Z - L / 2);
                Vector3d L1 = new Vector3d(Vect2 - Vect1);
                Vector3d L2 = new Vector3d(Vect3 - Vect1);
                Vector3d Perp = new Vector3d(Vector3d.Cross(L1, L2));
                Perp.Normalize();
                GL.Normal3(Perp);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
                GL.Vertex3(Vect4.X, Vect4.Y, Vect4.Z);
            }
            GL.End();

            //Circulo exterior
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            for (double i = 0; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(X + Rext * Math.Cos(i * (Math.PI / 180)), Y + Rext * Math.Sin(i * (Math.PI / 180)), Z + L / 2);
                Vector3d Vect2 = new Vector3d(X + Rext * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + Rext * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), Z + L / 2);
                Vector3d Vect3 = new Vector3d(X + Rext * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + Rext * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), Z - L / 2);
                Vector3d Vect4 = new Vector3d(X + Rext * Math.Cos(i * (Math.PI / 180)), Y + Rext * Math.Sin(i * (Math.PI / 180)), Z - L / 2);
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

        }

        internal void Dibujar2D(double RR, double GG, double BB)
        {
            int increm = 10;
            GL.PushMatrix();
            GL.Translate(X, Y, 5);
            GL.Begin(PrimitiveType.QuadStrip);
            GL.Color3(RR, GG, BB);
            for (int i = 0; i + increm <= 360; i += increm)
            {
                GL.Vertex3(Rext * Math.Cos(i * Math.PI / 180.0), Rext * Math.Sin(i * Math.PI / 180.0), 0);
                GL.Vertex3(Rint * Math.Cos(i * Math.PI / 180.0), Rint * Math.Sin(i * Math.PI / 180.0), 0);
                GL.Vertex3(Rext * Math.Cos((i + increm) * Math.PI / 180.0), Rext * Math.Sin((i + increm) * Math.PI / 180.0), 0);
                GL.Vertex3(Rint * Math.Cos((i + increm) * Math.PI / 180.0), Rint * Math.Sin((i + increm) * Math.PI / 180.0), 0);
            }
            GL.End();
            GL.PopMatrix();
        }

        internal void ExtremoArticulado(double RR, double GG, double BB, double Theta)
        {
            GL.PushMatrix();
            GL.Translate(X, Y, Z);
            GL.Rotate(Theta - 90, 0, 0, 1);
            GL.Color3(RR - 0.1, GG - 0.1, BB - 0.1);
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(-0.85 * Rext, +0.5 * Rext, 0);
            GL.Vertex3(+0.85 * Rext, +0.5 * Rext, 0);
            GL.Vertex3(+Rext * 0.5, +2 * Rext, 0);
            GL.Vertex3(-Rext * 0.5, +2 * Rext, 0);
            GL.End();
            GL.PopMatrix();
        }
    }
}
