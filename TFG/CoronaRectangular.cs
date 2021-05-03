using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    class CoronaRectangular
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Lext { get; set; }
        public double Lint { get; set; }
        public CoronaRectangular(double cx, double cy, double cz, double LadoExt, double LadoInt)
        {
            X = cx;
            Y = cy;
            Z = cz;
            Lint = LadoInt;
            Lext = LadoExt;
        }
        public CoronaRectangular(double cx, double cy, double LadoExt, double LadoInt)
        {
            X = cx;
            Y = cy;
            Lint = LadoInt;
            Lext = LadoExt;
        }
        internal void Dibujar2D(double RR, double GG, double BB)
        {
            GL.PushMatrix();
            GL.Translate(X, Y, Z);
            //Arriba
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0, 0, 1.0);
            GL.Vertex3(-Lext * 0.5, Lext * 0.5, 0);
            GL.Vertex3(Lext * 0.5, Lext * 0.5, 0);
            GL.Vertex3(Lext * 0.5, Lint * 0.5, 0);
            GL.Vertex3(-Lext * 0.5, Lint * 0.5, 0);
            GL.End();
            //Izquierda
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0, 0, 1.0);
            GL.Vertex3(-Lext * 0.5, Lint * 0.5, 0);
            GL.Vertex3(-Lint * 0.5, Lint * 0.5, 0);
            GL.Vertex3(-Lint * 0.5, -Lint * 0.5, 0);
            GL.Vertex3(-Lext * 0.5, -Lint * 0.5, 0);
            GL.End();
            //Abajo
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0, 0, 1.0);
            GL.Vertex3(-Lext * 0.5, -Lext * 0.5, 0);
            GL.Vertex3(Lext * 0.5, -Lext * 0.5, 0);
            GL.Vertex3(Lext * 0.5, -Lint * 0.5, 0);
            GL.Vertex3(-Lext * 0.5, -Lint * 0.5, 0);
            GL.End();
            //Derecha
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0, 0, 1.0);
            GL.Vertex3(Lext * 0.5, Lint * 0.5, 0);
            GL.Vertex3(Lint * 0.5, Lint * 0.5, 0);
            GL.Vertex3(Lint * 0.5, -Lint * 0.5, 0);
            GL.Vertex3(Lext * 0.5, -Lint * 0.5, 0);
            GL.End();
            GL.PopMatrix();
        }
    }
}
