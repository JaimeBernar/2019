using System;

namespace TFG
{
    [Serializable]
    internal class Mohr
    {
        public Mohr()
        {

        }

        internal double[] Calcular(double Ix, double Iy, double Ixy, double Angulo)
        {
            double[] Inercias = new double[3];
            double C = ((Ix + Iy) / 2);
            double R = Math.Sqrt(Math.Pow((Ix - Iy) / 2, 2) + Ixy * Ixy);
            double Theta = 2 * Angulo * Math.PI / 180;//En el circulo de Mohr el angulo es el doble
            double Alpha = Math.Atan2(Ixy, ((Ix - Iy) / 2)); //Angulo del cual partimos
            if (Ix > Iy)
            {
                Ix = C + R * Math.Cos(Theta + Alpha);
                Iy = C - R * Math.Cos(Theta + Alpha);
                Ixy = R * Math.Sin(Theta + Alpha);
            }
            else
            {
                Ix = C - R * Math.Cos(Theta + Alpha);
                Iy = C + R * Math.Cos(Theta + Alpha);
                Ixy = R * Math.Sin(Theta + Alpha);
            }

            Inercias[0] = Ix;
            Inercias[1] = Iy;
            Inercias[2] = Ixy;
            return Inercias;
        }
    }
}
