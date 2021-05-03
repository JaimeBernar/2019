using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    internal class Linea
    {

        private readonly double a, b, c, d;
        internal Linea(double x1, double y1, double x2, double y2)
        {
            a = x1;
            b = y1;
            c = x2;
            d = y2;
        }

        internal void Dibujar(double RR, double GG, double BB, bool stipple, float grosor, bool light)
        {
            if (stipple)
            {
                GL.Enable(EnableCap.LineStipple);
                GL.LineStipple(3, 0xAAAA);
            }
            if (!light)
            {
                GL.Disable(EnableCap.Lighting);
            }
            GL.LineWidth(grosor);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(RR, GG, BB);
            GL.Vertex2(a, b);
            GL.Vertex2(c, d);
            GL.End();
            GL.LineWidth(1f);
            if (!light)
            {
                GL.Enable(EnableCap.Lighting);
            }
            if (stipple)
            {
                GL.Disable(EnableCap.LineStipple);
            }


        }

    }
}
