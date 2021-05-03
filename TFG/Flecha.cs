using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    internal class Flecha
    {
        internal double x, y, z, M;

        internal Flecha(double cx, double cy, double cz, double modulo)
        {
            x = cx;
            y = cy;
            z = cz;
            M = modulo;
        }
        internal Flecha(double cx, double cy, double Largo)
        {
            x = cx;
            y = cy;
            M = Largo;
        }
        internal void FlechaSimple(double RR, double GG, double BB, double constant, double Theta, double Phi)
        {
            GL.DepthFunc(DepthFunction.Less);
            float[] LightSpec = { 0.6f, 0.6f, 0.6f };
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, LightSpec);
            Cilindro cil = new Cilindro(M / 13 * constant, M * constant, x, y, z);
            cil.Dibujar(RR, GG, BB, Theta, Phi);
            Cono con1 = new Cono(M / 5 * constant, 3.2 * M / 10 * constant, x + M * constant * Math.Cos(Phi * Math.PI / 180) * Math.Cos(Theta * Math.PI / 180), y + M * constant * Math.Sin(Phi * Math.PI / 180) * Math.Cos(Theta * Math.PI / 180), z + M * constant * Math.Cos(Phi * Math.PI / 180) * Math.Sin(-Theta * Math.PI / 180));
            con1.Dibujar(RR, GG, BB, Theta, Phi, 1);

        }

        internal void Flecha2D(double RR, double GG, double BB, double Theta)
        {
            GL.PushMatrix();
            GL.Translate(x, y, z);
            GL.Rotate(Theta, 0, 0, 1);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0, 0, 1.0);
            GL.Vertex3(0, M * 0.65, 0);
            GL.Vertex3(15 * M, M * 0.65, 0);
            GL.Vertex3(15 * M, -M * 0.65, 0);
            GL.Vertex3(0, -M * 0.65, 0);
            GL.End();
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0, 0, 1.0);
            GL.Vertex3(20 * M, 0, 0);
            GL.Vertex3(15 * M, 1.5 * M, 0);
            GL.Vertex3(15 * M, -1.5 * M, 0);
            GL.End();
            GL.PopMatrix();
        }
        internal void FlechaMomento(double RR, double GG, double BB, double constant, double Theta, double Phi, double Alpha)
        {
            float[] LightSpec = { 0.8f, 0.8f, 0.8f };
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, LightSpec);
            Cilindro cil = new Cilindro(M / 10 * constant, M * constant, x, y, z);
            cil.Dibujar(RR, GG, BB, Theta, Phi);
            Cono con1 = new Cono(M / 5 * constant, 3 * M / 10 * constant, x + M * constant * Math.Cos(Phi * Math.PI / 180) * Math.Cos(Theta * Math.PI / 180), y + M * constant * Math.Sin(Phi * Math.PI / 180) * Math.Cos(Theta * Math.PI / 180), z + M * constant * Math.Cos(Phi * Math.PI / 180) * Math.Sin(-Theta * Math.PI / 180));
            con1.Dibujar(RR, GG, BB, Theta, Phi, 1);
            Cono con2 = new Cono(M / 5 * constant, 3 * M / 10 * constant, x + 1.2 * M * constant * Math.Cos(Phi * Math.PI / 180) * Math.Cos(Theta * Math.PI / 180), y + 1.2 * M * constant * Math.Sin(Phi * Math.PI / 180) * Math.Cos(Theta * Math.PI / 180), z + 1.2 * M * constant * Math.Cos(Phi * Math.PI / 180) * Math.Sin(-Theta * Math.PI / 180));
            con2.Dibujar(RR, GG, BB, Theta, Phi, 1);
            LightSpec[0] = 0.0f; LightSpec[1] = 0.0f; LightSpec[2] = 0.0f;
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, LightSpec);
        }



    }
}
