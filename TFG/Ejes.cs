using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    public class Ejes
    {
        internal double cx, cy, cz;
        internal Ejes(double x, double y, double z)
        {
            cx = x;
            cy = y;
            cz = z;
        }


        internal void Triedro(double Size, double RR, double GG, double BB)
        {
            Cilindro cilx = new Cilindro(0.9 * Size, 10 * Size, cx, cy, cz);
            cilx.Dibujar(RR, 0, 0, 0, 0);
            Cilindro cily = new Cilindro(0.9 * Size, 10 * Size, cx, cy, cz);
            cily.Dibujar(0, GG, 0, 0, 90);
            Cilindro cilz = new Cilindro(0.9 * Size, 10 * Size, cx, cy, cz);
            cilz.Dibujar(0, 0, BB, -90, 0);
            Cono conx = new Cono(2 * Size, 4.0 * Size, cx + 10.0 * Size, cy, cz);
            conx.Dibujar(RR, 0, 0, 0, 0, 1);
            Cono cony = new Cono(2 * Size, 4.0 * Size, cx, cy + 10.0 * Size, cz);
            cony.Dibujar(0, GG, 0, 0, 90, 1);
            Cono conz = new Cono(2 * Size, 4.0 * Size, cx, cy, cz + 10.0 * Size);
            conz.Dibujar(0, 0, BB, -90, 0, 1);
        }

        internal void EjesLocales(double Size, double Ang)
        {
            GL.PushMatrix();
            GL.Translate(0, 0, 10);
            Cilindro cilx = new Cilindro(0.9 * Size, 10 * Size, cx, cy, cz);
            cilx.Dibujar(0.7, 0, 0, 0, 0);
            Cilindro cily = new Cilindro(0.9 * Size, 10 * Size, cx, cy, cz);
            cily.Dibujar(0, 0.7, 0, 0, Ang + 90);
            Cono conx = new Cono(2 * Size, 4.0 * Size, cx + 10.0 * Size, cy, cz);
            conx.Dibujar(0.7, 0, 0, 0, 0, 1);
            Cono cony = new Cono(2 * Size, 4.0 * Size, cx, cy + 10.0 * Size, cz);
            cony.Dibujar(0, 0.7, 0, 0, Ang + 90, 1);
            GL.PopMatrix();
        }
    }
}
