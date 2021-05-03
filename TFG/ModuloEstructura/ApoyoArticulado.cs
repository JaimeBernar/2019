using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    class ApoyoArticulado : Apoyo
    {
        public ApoyoArticulado(double x, double y)
        {
            X = x;
            Y = y;
        }
        internal override void Dibujar2D(double TAM, double RR, double GG, double BB)
        {
            GL.PushMatrix();
            GL.Translate(X, Y, 0);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(RR, GG, BB);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(-TAM * 0.5, -TAM, 0);
            GL.Vertex3(TAM * 0.5, -TAM, 0);
            GL.End();
            GL.PopMatrix();
        }
    }
}
