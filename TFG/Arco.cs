using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    internal class Arco
    {
        public double cx, cy, Radio, Theta, Beta; public float thnss;
        internal Arco(double x, double y, double R, double AnguloInicio, double AnguloFinal, float grosor)
        {
            cx = x;
            cy = y;
            Radio = R;
            Theta = AnguloFinal;
            Beta = AnguloInicio;
            thnss = grosor;
        }

        internal void Dibujar(double RR, double GG, double BB)
        {
            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(RR, GG, BB);
            for (double i = Beta; i <= Theta; i += 5)
            {
                GL.Vertex2(cx + Radio * Math.Cos(i * (Math.PI / 180)), cy + Radio * Math.Sin(i * (Math.PI / 180)));
            }
            GL.End();
        }
        internal void FlechaCurva(double RR, double GG, double BB, double constant)
        {
            GL.PointSize(thnss);
            GL.PushMatrix();
            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(RR, GG, BB);
            for (double i = Beta; i < Theta - 4 * constant; i += 1)
            {
                GL.Vertex2(cx + Radio * Math.Cos(i * (Math.PI / 180)), cy + Radio * Math.Sin(i * (Math.PI / 180)));
            }
            GL.End();
            GL.Translate(cx + Radio * Math.Cos((Theta - 6 * constant) * (Math.PI / 180)), cy + Radio * Math.Sin((Theta - 6 * constant) * (Math.PI / 180)), 0);
            GL.Rotate(Theta + 90, 0, 0, 1);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex2(0, constant);
            GL.Vertex2(0, -constant);
            GL.Vertex2(3 * constant, 0);
            GL.End();
            GL.Translate(-(cx + Radio * Math.Cos((Theta - 6 * constant) * (Math.PI / 180))), -(cy + Radio * Math.Sin((Theta - 6 * constant) * (Math.PI / 180))), 0);
            GL.Rotate(-(Theta + 90), 0, 0, 1);
            GL.PopMatrix();
        }
    }
}
