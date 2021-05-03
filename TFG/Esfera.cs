using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TFG
{
    [Serializable]
    public class Esfera
    {
        internal double x, y, z, R;
        public Esfera(double Radio, double cx, double cy, double cz)
        {
            R = Radio;
            x = cx;
            y = cy;
            z = cz;
        }

        internal void Dibujar(double RR, double GG, double BB)
        {
            GL.PushMatrix();
            double increRad = Math.PI / 10.0;
            //if (increRad > 0.62) { increRad = 0.62; }//El incremento minimo para que mantenga calidad en todo momento
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(RR, GG, BB);
            for (double teta = 0; teta < Math.PI; teta += increRad)
            {
                for (double phi = 0; phi < 2 * Math.PI; phi += increRad)
                {   //VERTICE 1
                    Vector3d Vertice1 = new Vector3d
                    {
                        Z = z + (R) * (Math.Sin(teta)) * (Math.Cos(phi + increRad)),
                        X = x + (R) * (Math.Sin(teta)) * (Math.Sin(phi + increRad)),
                        Y = y + (R) * (Math.Cos(teta))
                    };

                    //VERTICE 2
                    Vector3d Vertice2 = new Vector3d
                    {
                        Z = z + (R) * (Math.Sin(teta + increRad)) * (Math.Cos(phi + increRad)),
                        X = x + (R) * (Math.Sin(teta + increRad)) * (Math.Sin(phi + increRad)),
                        Y = y + (R) * (Math.Cos(teta + increRad))
                    };
                    //VERTICE 3
                    Vector3d Vertice3 = new Vector3d
                    {
                        Z = z + (R) * (Math.Sin(teta + increRad)) * (Math.Cos(phi)),
                        X = x + (R) * (Math.Sin(teta + increRad)) * (Math.Sin(phi)),
                        Y = y + (R) * (Math.Cos(teta + increRad))
                    };
                    //VERTICE 4
                    Vector3d Vertice4 = new Vector3d
                    {
                        Z = z + (R) * (Math.Sin(teta)) * (Math.Cos(phi)),
                        X = x + (R) * (Math.Sin(teta)) * (Math.Sin(phi)),
                        Y = y + (R) * (Math.Cos(teta))
                    };


                    //TRIANGULO 1
                    Vector3d L1 = new Vector3d(Vertice2 - Vertice1);
                    Vector3d L2 = new Vector3d(Vertice1 - Vertice4);
                    Vector3d Perp1 = new Vector3d(Vector3d.Cross(L1, L2));
                    Perp1.Normalize();
                    GL.Normal3(Perp1);
                    GL.Vertex3(Vertice1.X, Vertice1.Y, Vertice1.Z);
                    GL.Vertex3(Vertice2.X, Vertice2.Y, Vertice2.Z);
                    GL.Vertex3(Vertice3.X, Vertice3.Y, Vertice3.Z);
                    //TRIANGULO2
                    Vector3d L3 = new Vector3d(Vertice4 - Vertice2);
                    Vector3d L4 = new Vector3d(Vertice4 - Vertice1);
                    Vector3d Perp2 = new Vector3d(Vector3d.Cross(L3, L4));
                    Perp2.Normalize();
                    GL.Normal3(Perp2);
                    GL.Vertex3(Vertice1.X, Vertice1.Y, Vertice1.Z);
                    GL.Vertex3(Vertice3.X, Vertice3.Y, Vertice3.Z);
                    GL.Vertex3(Vertice4.X, Vertice4.Y, Vertice4.Z);
                }
            }
            GL.End();
            GL.PopMatrix();
        }
    }
}
