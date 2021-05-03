using System;

namespace TFG
{
    [Serializable]
    internal class FuerzaBarra : Carga
    {
        internal double Proporcion;
        public FuerzaBarra(Barra barra, double Mod, string Eje, double Prop)
        {
            BarraAsociada = barra;
            Proporcion = Prop;
            Modulo = Mod;
            SegunEje = Eje;
        }

        internal override void Dibujar(double cte, double RR, double GG, double BB, double Theta)
        {
            double Angulo = 0;
            Xi = BarraAsociada.Longitud * Proporcion;
            double X = BarraAsociada.X0 + Proporcion * BarraAsociada.Longitud * Math.Cos(BarraAsociada.Angulo * Math.PI / 180.0);
            double Y = BarraAsociada.Y0 + Proporcion * BarraAsociada.Longitud * Math.Sin(BarraAsociada.Angulo * Math.PI / 180.0);
            if (SegunEje == "XG")
            {
                if (Modulo > 0) { Angulo = 0.0; } else { Angulo = 180.0; }
            }
            else if (SegunEje == "YG")
            {
                if (Modulo > 0) { Angulo = 90.0; } else { Angulo = 270.0; }
            }
            else if (SegunEje == "XL")
            {
                if (Modulo > 0) { Angulo = BarraAsociada.Angulo; } else { Angulo = BarraAsociada.Angulo + 180.0; }
            }
            else if (SegunEje == "YL")
            {
                if (Modulo > 0) { Angulo = BarraAsociada.Angulo + 90.0; } else { Angulo = BarraAsociada.Angulo + 270.0; }
            }
            Flecha flechi = new Flecha(X, Y, 0, 7 * cte);
            flechi.FlechaSimple(RR, GG, BB, 1, 0, Angulo);
        }

        internal override void Dibujar2D(double cte, double RR, double GG, double BB, double Theta)
        {
            double Angulo = 0;
            Xi = BarraAsociada.Longitud * Proporcion;
            double X = BarraAsociada.X0 + Proporcion * BarraAsociada.Longitud * Math.Cos(BarraAsociada.Angulo * Math.PI / 180.0);
            double Y = BarraAsociada.Y0 + Proporcion * BarraAsociada.Longitud * Math.Sin(BarraAsociada.Angulo * Math.PI / 180.0);
            if (SegunEje == "XG")
            {
                if (Modulo > 0) { Angulo = 0.0; } else { Angulo = 180.0; }
            }
            else if (SegunEje == "YG")
            {
                if (Modulo > 0) { Angulo = 90.0; } else { Angulo = 270.0; }
            }
            else if (SegunEje == "XL")
            {
                if (Modulo > 0) { Angulo = BarraAsociada.Angulo; } else { Angulo = BarraAsociada.Angulo + 180.0; }
            }
            else if (SegunEje == "YL")
            {
                if (Modulo > 0) { Angulo = BarraAsociada.Angulo + 90.0; } else { Angulo = BarraAsociada.Angulo + 270.0; }
            }
            Flecha flechi = new Flecha(X, Y, 0, 0.7 * cte);
            flechi.Flecha2D(RR, GG, BB, Angulo);
        }
    }
}
