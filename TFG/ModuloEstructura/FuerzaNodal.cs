using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    public class FuerzaNodal : Carga
    {
        public FuerzaNodal(double cx, double cy, double Mod, double Angulo)
        {
            X = cx;
            Y = cy;
            Modulo = Mod;
            Theta = Angulo;
        }

        internal override void Dibujar(double cte, double RR, double GG, double BB, double Theta)
        {
            GL.DepthFunc(DepthFunction.Always);
            GL.PushMatrix();
            Flecha flech = new Flecha(X, Y, 0, 7 * cte);
            flech.FlechaSimple(RR, GG, BB, 1, 0, Theta);
            GL.PopMatrix();
            GL.DepthFunc(DepthFunction.Less);
        }

        internal override void Dibujar2D(double cte, double RR, double GG, double BB, double Theta)
        {
            Flecha flech = new Flecha(X, Y, 5, 0.7 * cte);
            flech.Flecha2D(RR, GG, BB, Theta);
        }

    }
}
