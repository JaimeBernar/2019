using System;


namespace TFG
{
    [Serializable]
    internal class CargaDistribuida : Carga
    {

        public CargaDistribuida(Barra Barra, double Qnodoi, double Qnodoj, string Eje)
        {
            BarraAsociada = Barra;
            Qi = Qnodoi;
            Qj = Qnodoj;
            SegunEje = Eje;
        }

        internal override void Dibujar(double cte, double RR, double GG, double BB, double Theta)
        {
            double Qiesc, Qjesc;
            double Anguloi = 0, Anguloj = 0;
            //Escalar las flechas...
            if (Qi > Qj)
            {
                Qiesc = 7;
                Qjesc = 7 * Math.Abs(Qj / Qi);
            }
            else
            {
                Qjesc = 7;
                Qiesc = 7 * Math.Abs(Qi / Qj);
            }

            if (SegunEje == "XG")
            {
                if (Qi > 0) { Anguloi = 0.0; } else { Anguloi = 180.0; }
                if (Qj > 0) { Anguloj = 0.0; } else { Anguloj = 180.0; }
            }
            else if (SegunEje == "YG")
            {
                if (Qi > 0) { Anguloi = 90.0; } else { Anguloi = 270.0; }
                if (Qj > 0) { Anguloj = 90.0; } else { Anguloj = 270.0; }
            }
            else if (SegunEje == "XL")
            {
                if (Qi > 0) { Anguloi = Anguloj = BarraAsociada.Angulo; } else { Anguloi = Anguloj = BarraAsociada.Angulo + 180.0; }

            }
            else if (SegunEje == "YL")
            {
                if (Qi > 0) { Anguloi = BarraAsociada.Angulo + 90.0; } else { Anguloi = BarraAsociada.Angulo + 270.0; }
                if (Qj > 0) { Anguloj = BarraAsociada.Angulo + 90.0; } else { Anguloj = BarraAsociada.Angulo + 270.0; }
            }
            Flecha flechi = new Flecha(BarraAsociada.X0, BarraAsociada.Y0, 0, Qiesc * cte);
            flechi.FlechaSimple(RR, GG, BB, 1, 0, Anguloi);

            Flecha flechf = new Flecha(BarraAsociada.X1, BarraAsociada.Y1, 0, Qjesc * cte);
            flechf.FlechaSimple(RR, GG, BB, 1, 0, Anguloj);

            double a = BarraAsociada.X0 + Qiesc * 1.28 * cte * Math.Cos((Anguloi) * Math.PI / 180.0);
            double b = BarraAsociada.Y0 + Qiesc * 1.28 * cte * Math.Sin((Anguloi) * Math.PI / 180.0);
            double c = BarraAsociada.X1 + Qjesc * 1.28 * cte * Math.Cos((Anguloj) * Math.PI / 180.0);
            double d = BarraAsociada.Y1 + Qjesc * 1.28 * cte * Math.Sin((Anguloj) * Math.PI / 180.0);
            Linea lin = new Linea(a, b, c, d);
            lin.Dibujar(RR, GG, BB, false, 2f, false);
        }

        internal override void Dibujar2D(double cte, double RR, double GG, double BB, double Theta)
        {
            double Qiesc, Qjesc;
            double Anguloi = 0, Anguloj = 0;
            //Escalar las flechas...
            if (Qi > Qj)
            {
                Qiesc = 0.7;
                Qjesc = 0.7 * Math.Abs(Qj / Qi);
            }
            else
            {
                Qjesc = 0.7;
                Qiesc = 0.7 * Math.Abs(Qi / Qj);
            }

            if (SegunEje == "XG")
            {
                if (Qi > 0) { Anguloi = 0.0; } else { Anguloi = 180.0; }
                if (Qj > 0) { Anguloj = 0.0; } else { Anguloj = 180.0; }
            }
            else if (SegunEje == "YG")
            {
                if (Qi > 0) { Anguloi = 90.0; } else { Anguloi = 270.0; }
                if (Qj > 0) { Anguloj = 90.0; } else { Anguloj = 270.0; }
            }
            else if (SegunEje == "XL")
            {
                if (Qi > 0) { Anguloi = Anguloj = BarraAsociada.Angulo; } else { Anguloi = Anguloj = BarraAsociada.Angulo + 180.0; }

            }
            else if (SegunEje == "YL")
            {
                if (Qi > 0) { Anguloi = BarraAsociada.Angulo + 90.0; } else { Anguloi = BarraAsociada.Angulo + 270.0; }
                if (Qj > 0) { Anguloj = BarraAsociada.Angulo + 90.0; } else { Anguloj = BarraAsociada.Angulo + 270.0; }
            }
            Flecha flechi = new Flecha(BarraAsociada.X0, BarraAsociada.Y0, 5, Qiesc * cte);
            flechi.Flecha2D(RR, GG, BB, Anguloi);

            Flecha flechf = new Flecha(BarraAsociada.X1, BarraAsociada.Y1, 5, Qjesc * cte);
            flechf.Flecha2D(RR, GG, BB, Anguloj);

            double a = BarraAsociada.X0 + Qiesc * 20 * cte * Math.Cos((Anguloi) * Math.PI / 180.0);
            double b = BarraAsociada.Y0 + Qiesc * 20 * cte * Math.Sin((Anguloi) * Math.PI / 180.0);
            double c = BarraAsociada.X1 + Qjesc * 20 * cte * Math.Cos((Anguloj) * Math.PI / 180.0);
            double d = BarraAsociada.Y1 + Qjesc * 20 * cte * Math.Sin((Anguloj) * Math.PI / 180.0);
            Linea lin = new Linea(a, b, c, d);
            lin.Dibujar(RR, GG, BB, false, 2f, false);
        }

    }
}
