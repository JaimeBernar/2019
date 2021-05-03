﻿using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    internal class MomentoBarra : Carga
    {
        internal double Proporcion;
        public MomentoBarra(Barra Barra, double Mod, double Prop)
        {
            BarraAsociada = Barra;
            Proporcion = Prop;
            Modulo = Mod;
        }

        internal override void Dibujar(double cte, double RR, double GG, double BB, double Theta)
        {
            double increm = 3;
            Xi = BarraAsociada.Longitud * Proporcion;
            int cont = 0;
            double X = BarraAsociada.X0 + Proporcion * BarraAsociada.Longitud * Math.Cos(BarraAsociada.Angulo * Math.PI / 180.0);
            double Y = BarraAsociada.Y0 + Proporcion * BarraAsociada.Longitud * Math.Sin(BarraAsociada.Angulo * Math.PI / 180.0);
            GL.PushMatrix();
            GL.Translate(X, Y, 0);
            if (Modulo < 0) { GL.Rotate(180.0f, 0, 1, 0); }
            for (double i = 0; i < 25 * increm; i += increm)
            {
                Cilindro cil = new Cilindro(cte / 1.5, cte / 1.75, (2.5 * cte * Math.Cos(i * increm * Math.PI / 180)), (2.5 * cte * Math.Sin(i * increm * Math.PI / 180)), 0);
                cil.Dibujar(RR, GG, BB, 0, (i * increm) + 90);
                cont += 3;
            }
            Cono con = new Cono(1.75 * cte, 2 * cte, 2.5 * cte * Math.Cos(cont * increm * Math.PI / 180), 2.5 * cte * Math.Sin(cont * increm * Math.PI / 180), 0);
            con.Dibujar(RR, GG, BB, 0, (cont * increm) + 90, 1);
            GL.PopMatrix();
        }
        internal override void Dibujar2D(double cte, double RR, double GG, double BB, double Theta)
        {
            int increm = 10;
            double Rint = 4 * cte;
            double Rext = 5 * cte;
            Xi = BarraAsociada.Longitud * Proporcion;
            double X = BarraAsociada.X0 + Proporcion * BarraAsociada.Longitud * Math.Cos(BarraAsociada.Angulo * Math.PI / 180.0);
            double Y = BarraAsociada.Y0 + Proporcion * BarraAsociada.Longitud * Math.Sin(BarraAsociada.Angulo * Math.PI / 180.0);

            GL.PushMatrix();
            GL.Translate(X, Y, 5);
            if (Modulo < 0) { GL.Rotate(180.0f, 0, 1, 0); }
            GL.Begin(PrimitiveType.QuadStrip);
            GL.Color3(RR, GG, BB);
            for (int i = 0; i + increm <= 270; i += increm)
            {
                GL.Vertex3(Rext * Math.Cos(i * Math.PI / 180.0), Rext * Math.Sin(i * Math.PI / 180.0), 0);
                GL.Vertex3(Rint * Math.Cos(i * Math.PI / 180.0), Rint * Math.Sin(i * Math.PI / 180.0), 0);
                GL.Vertex3(Rext * Math.Cos((i + increm) * Math.PI / 180.0), Rext * Math.Sin((i + increm) * Math.PI / 180.0), 0);
                GL.Vertex3(Rint * Math.Cos((i + increm) * Math.PI / 180.0), Rint * Math.Sin((i + increm) * Math.PI / 180.0), 0);
            }
            GL.End();
            GL.PopMatrix();
            GL.PushMatrix();
            GL.Translate(X, Y - (Rint + Rext) / 2, 5);
            if (Modulo < 0) { GL.Rotate(180.0f, 0, 1, 0); }
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(0, 1.5 * cte, 0);
            GL.Vertex3(0, 1.5 * -cte, 0);
            GL.Vertex3(4 * cte, 0, 0);
            GL.End();
            GL.PopMatrix();
        }
    }
}
