using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    class ApoyoEmpotramiento : Apoyo
    {
        public ApoyoEmpotramiento(double x, double y)
        {
            X = x;
            Y = y;
        }
        internal override void Dibujar2D(double TAM, double RR, double GG, double BB)
        {
            GL.PushMatrix();
            GL.Translate(0, 0, 30 * TAM);
            double[] datos = new double[4];
            Rectangulo rect = new Rectangulo(0.5 * TAM, TAM, X, Y, Theta + 90);
            rect.Dibujar(RR, GG, BB);
            datos[3] = 3;
            GL.PopMatrix();
        }
    }
}
