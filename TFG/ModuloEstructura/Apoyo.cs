using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    public class Apoyo
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Theta { get; set; }
        public double Dx { get; set; } = 1;
        public double Dy { get; set; } = 1;
        public double Dz { get; set; } = 1;

        public int NumeroApoyo { get; set; }

        public Nodo NodoAdjunto { get; set; }

        public Apoyo()
        {

        }
        internal virtual void Dibujar2D(double TAM, double RR, double GG, double BB) { }
        internal void Dibujar(double TAM, double RR, double GG, double BB)
        {
            //Deslizadera
            {
                GL.PushMatrix();
                GL.Translate(X, Y, 0);
                GL.Rotate(Theta, 0, 0, 1);
                double[] datos = new double[4];
                Cono con = new Cono(5 * TAM, 4 * TAM, 0, 0, 0);
                con.DibujarDesdePunta(RR, GG, BB, 0, 180);
                datos[3] = 1;

                Esfera esf = new Esfera(3 * TAM / 4, (4.5 * TAM), 0, 0);
                esf.Dibujar(RR, GG, BB);

                Esfera esf2 = new Esfera(3 * TAM / 4, (4.5 * TAM), 1.75 * TAM, 0);
                esf2.Dibujar(RR, GG, BB);

                Esfera esf3 = new Esfera(3 * TAM / 4, (4.5 * TAM), -1.75 * TAM, 0);
                esf3.Dibujar(RR, GG, BB);

                GL.PopMatrix();
            }

            //Fijo
            {
                GL.PushMatrix();
                double[] datos = new double[4];
                Cono con = new Cono(5 * TAM, 4 * TAM, X, Y, 0);
                con.DibujarDesdePunta(RR, GG, BB, 0, Theta + 90);
                datos[3] = 1;
                GL.PopMatrix();
            }

            //Empotramiento
            {
                GL.PushMatrix();
                GL.Translate(0, 0, 2.5 * TAM);
                double[] datos = new double[4];
                Rectangulo rect = new Rectangulo(2.5 * TAM, 5 * TAM, X, Y, Theta + 90);
                rect.DibujarExtruido(RR, GG, BB, 5 * TAM);
                datos[3] = 3;
                GL.PopMatrix();
            }
        }

    }
}
