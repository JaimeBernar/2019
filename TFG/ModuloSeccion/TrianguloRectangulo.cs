using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;



namespace TFG
{
    [Serializable]
    public class TrianguloRectangulo : Figura
    {
        private readonly double signox;
        private readonly double signoy;
        private double Signo;

        public TrianguloRectangulo(double bb, double hh, double centrox, double centroy, double angulo)
        {
            Ancho = bb;
            Alto = hh;
            Theta = angulo;
            X = centrox;
            Y = centroy;
            if (Ancho > 0) { signox = 1; } else { signox = -1; }
            if (Alto > 0) { signoy = 1; } else { signoy = -1; }
        }


        internal override void Calculos()
        {
            double x = Math.Abs(Ancho);
            double y = Math.Abs(Alto);

            if (Negativa) { Area = -x * y / 2.0; } else { Area = x * y / 2.0; }
            Cdgx = X + (1.0 / 3) * Math.Sqrt(Math.Pow(y, 2) + Math.Pow(x, 2)) * Math.Cos((Math.Atan2(Alto, Ancho) + Theta * Math.PI / 180));
            Cdgy = Y + (1.0 / 3) * Math.Sqrt(Math.Pow(y, 2) + Math.Pow(x, 2)) * Math.Sin((Math.Atan2(Alto, Ancho) + Theta * Math.PI / 180));

            if (Negativa) { Signo = -1; } else { Signo = 1; }
            //calculamos la inercia respecto a su cdg
            if (Negativa) { InerciaXG = -(1.0 / 36) * x * y * y * y; } else { InerciaXG = (1.0 / 36) * x * y * y * y; }
            if (Negativa) { InerciaYG = -(1.0 / 36) * y * x * x * x; } else { InerciaYG = (1.0 / 36) * y * x * x * x; }
            if (Negativa) { InerciaXGYG = -Signo * signox * signoy * (1.0 / 72) * Math.Pow(x, 2) * Math.Pow(y, 2); } else { InerciaXGYG = -Signo * signox * signoy * (1.0 / 72) * Math.Pow(x, 2) * Math.Pow(y, 2); }
            //calculamos la inercia respecto a su cdg y unos ejes girados a los generales

            double C = ((InerciaXG + InerciaYG) / 2);
            double R = Math.Sqrt(Math.Pow((InerciaXG - InerciaYG) / 2, 2) + InerciaXGYG * InerciaXGYG);
            double Angulo = 2 * Theta * Math.PI / 180;//En el circulo de Mohr el angulo es el doble
            double Alpha = Math.Atan2(InerciaXGYG, ((InerciaXG - InerciaYG) / 2)); //Angulo del cual partimos
            if (InerciaXG > InerciaYG)
            {
                InerciaXP = C + R * Math.Cos(Angulo + Alpha);
                InerciaYP = C - R * Math.Cos(Angulo + Alpha);
                InerciaXPYP = R * Math.Sin(Angulo + Alpha);
            }
            else
            {
                InerciaXP = C + R * Math.Cos(Angulo + Alpha);
                InerciaYP = C - R * Math.Cos(Angulo + Alpha);
                InerciaXPYP = R * Math.Sin(Angulo + Alpha);
            }
            //Calculamos la inercia respecto a los generales con steiner
            IX = InerciaXP + Signo * 1.0 / 2 * x * y * Cdgy * Cdgy;
            IY = InerciaYP + Signo * 1.0 / 2 * x * y * Cdgx * Cdgx;
            IXY = InerciaXPYP + Signo * 1.0 / 2 * x * y * Cdgx * Cdgy;
        }
        internal override void Dibujar(double RR, double GG, double BB)
        {
            Calculos();
            GL.PushMatrix();
            if (Negativa)
            {
                GL.Translate(0.0, 0.0, Dplano);
            }
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(RR, GG, BB);
            Vector3d Vect20 = new Vector3d(X, Y, 0);
            Vector3d Vect21 = new Vector3d(X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180), 0);
            Vector3d Vect22 = new Vector3d(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), 0);
            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(Vect20.X, Vect20.Y, Vect20.Z);
            GL.Vertex3(Vect21.X, Vect21.Y, Vect21.Z);
            GL.Vertex3(Vect22.X, Vect22.Y, Vect22.Z);
            GL.End();
            if (Negativa)
            {
                GL.Translate(0.0, 0.0, -Dplano * 2);
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(RR, GG, BB);
                GL.Vertex3(Vect20.X, Vect20.Y, Vect20.Z);
                GL.Vertex3(Vect21.X, Vect21.Y, Vect21.Z);
                GL.Vertex3(Vect22.X, Vect22.Y, Vect22.Z);
                GL.End();
            }

            GL.PopMatrix();
        }

        internal override void Seleccionada()
        {

            Linea Lbase = new Linea(X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180), X, Y);
            Linea LAltura = new Linea(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), X, Y);
            Linea LHipot = new Linea(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180));

            Lbase.Dibujar(159.0 / 255, 15.0 / 255, 240.0 / 255, false, 3f, false);
            LAltura.Dibujar(159.0 / 255, 15.0 / 255, 240.0 / 255, false, 3f, false);
            LHipot.Dibujar(159.0 / 255, 15.0 / 255, 240.0 / 255, false, 3f, false);

        }

        internal override void DibujarExtruido(double RR, double GG, double BB, double Lext)
        {
            GL.PushMatrix();
            //back
            {
                GL.Begin(PrimitiveType.Triangles);
                Vector3d Vect9 = new Vector3d(X, Y, -Lext);
                Vector3d Vect10 = new Vector3d(X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180), -Lext);
                Vector3d Vect11 = new Vector3d(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), -Lext);
                Vector3d L5 = new Vector3d(Vect10 - Vect9);
                L5.Normalize();
                Vector3d L6 = new Vector3d(Vect11 - Vect9);
                L6.Normalize();
                Vector3d Perp3 = new Vector3d(Vector3d.Cross(L6, L5));
                Perp3.Normalize();
                GL.Normal3(Perp3);
                GL.Color3(RR, GG, BB);
                GL.Vertex3(Vect9.X, Vect9.Y, Vect9.Z);
                GL.Vertex3(Vect10.X, Vect10.Y, Vect10.Z);
                GL.Vertex3(Vect11.X, Vect11.Y, Vect11.Z);
                GL.End();
            }

            //bottom
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(RR, GG, BB);
                Vector3d Vect5 = new Vector3d(X, Y, -Lext);
                Vector3d Vect6 = new Vector3d(X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180), -Lext);
                Vector3d Vect7 = new Vector3d(X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180), 0);
                Vector3d Vect8 = new Vector3d(X, Y, 0);
                Vector3d L3 = new Vector3d(Vect6 - Vect5);
                L3.Normalize();
                Vector3d L4 = new Vector3d(Vect7 - Vect5);
                L4.Normalize();
                Vector3d Perp2 = new Vector3d(Vector3d.Cross(L3, L4));
                Perp2.Normalize();
                GL.Normal3(Perp2);
                GL.Vertex3(Vect5.X, Vect5.Y, Vect5.Z);
                GL.Vertex3(Vect6.X, Vect6.Y, Vect6.Z);
                GL.Vertex3(Vect7.X, Vect7.Y, Vect7.Z);
                GL.Vertex3(Vect8.X, Vect8.Y, Vect8.Z);
                GL.End();
            }

            //Hipot
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(RR, GG, BB);
                Vector3d Vect1 = new Vector3d(X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180), -Lext);
                Vector3d Vect2 = new Vector3d(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), -Lext);
                Vector3d Vect3 = new Vector3d(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), 0);
                Vector3d Vect4 = new Vector3d(X + Ancho * Math.Cos(Theta * Math.PI / 180), Y + Ancho * Math.Sin(Theta * Math.PI / 180), 0);
                Vector3d L1 = new Vector3d(Vect2 - Vect1);
                L1.Normalize();
                Vector3d L2 = new Vector3d(Vect3 - Vect1);
                L2.Normalize();
                Vector3d Perp = new Vector3d(Vector3d.Cross(L1, L2));
                Perp.Normalize();
                GL.Normal3(Perp);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
                GL.Vertex3(Vect4.X, Vect4.Y, Vect4.Z);
                GL.End();
            }

            //cateto
            {
                GL.Begin(PrimitiveType.Quads);
                Vector3d Vect13 = new Vector3d(X, Y, -Lext);
                Vector3d Vect14 = new Vector3d(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), -Lext);
                Vector3d Vect15 = new Vector3d(X - Alto * Math.Sin(Theta * Math.PI / 180), Y + Alto * Math.Cos(Theta * Math.PI / 180), 0);
                Vector3d Vect16 = new Vector3d(X, Y, 0);
                Vector3d L7 = new Vector3d(Vect14 - Vect13);
                L7.Normalize();
                Vector3d L8 = new Vector3d(Vect15 - Vect13);
                L8.Normalize();
                Vector3d Perp4 = new Vector3d(Vector3d.Cross(L8, L7));
                Perp4.Normalize();
                GL.Normal3(Perp4);
                GL.Color3(RR, GG, BB);
                GL.Vertex3(Vect13.X, Vect13.Y, Vect13.Z);
                GL.Vertex3(Vect14.X, Vect14.Y, Vect14.Z);
                GL.Vertex3(Vect15.X, Vect15.Y, Vect15.Z);
                GL.Vertex3(Vect16.X, Vect16.Y, Vect16.Z);
                GL.End();
            }
            GL.PopMatrix();
        }

        internal override List<Vector3d> DistribucionTensiones(double cdgx, double cdgy, double Mx, double My, double Ixgt, double Iygt, double SigmaN)
        {
            double Angulo = Theta * Math.PI / 180;
            int div = 20;
            int colum = div;
            double escy = Alto / div;
            double escx = Ancho / div;
            double Iniciox = X;
            double Inicioy = Y;
            List<Vector3d> Lista = new List<Vector3d>();
            Vector3d vect;
            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-Angulo),
                M12 = -Math.Sin(-Angulo),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-Angulo),
                M22 = Math.Cos(-Angulo),
                M23 = 0,
                M24 = 0,
                M31 = 0,
                M32 = 0,
                M33 = 1,
                M34 = 0,
                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 0
            };

            for (int j = 0; j <= div; j++)
            {
                for (int i = 0; i <= colum; i++)
                {
                    //Comprobar calculo de tensiones
                    vect = new Vector3d((0 + i * escx), (0 + j * escy), 0);
                    vect = Vector3d.Transform(vect, MatRot);
                    vect.X += Iniciox; vect.Y += Inicioy;
                    Lista.Add(vect);
                }
                colum--;
            }

            return Lista;
        }


        internal override void MapaTensional(double cdgx, double cdgy, double Mx, double My, double SigmaN, double Ixgt, double Iygt, double SigmaMax, double SigmaMin, double RR, double GG, double BB)
        {
            double Angulo = Theta * Math.PI / 180;
            int div = 20;
            int colum = div;
            double escy = Alto / div;
            double escx = Ancho / div;
            double Iniciox = X;
            double Inicioy = Y;
            double Sigma, SigmaSig;
            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-Angulo),
                M12 = -Math.Sin(-Angulo),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-Angulo),
                M22 = Math.Cos(-Angulo),
                M23 = 0,
                M24 = 0,
                M31 = 0,
                M32 = 0,
                M33 = 1,
                M34 = 0,
                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 0
            };

            GL.PushMatrix();
            GL.Translate(Iniciox, Inicioy, 0);
            GL.Rotate(Theta, 0, 0, 1);

            for (int j = 0; j <= div; j++)
            {
                GL.Begin(PrimitiveType.TriangleStrip);
                for (int i = 0; i <= colum; i++)
                {
                    //Comprobar calculo de tensiones
                    Vector3d vect = new Vector3d((0 + i * escx), (0 + j * escy), 0);
                    vect = Vector3d.Transform(vect, MatRot);
                    vect.X += Iniciox; vect.Y += Inicioy;

                    Vector3d vectSig = new Vector3d((0 + i * escx), (0 + (j + 1) * escy), 0);
                    vectSig = Vector3d.Transform(vectSig, MatRot);
                    vectSig.X += Iniciox; vectSig.Y += Inicioy;

                    Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);
                    SigmaSig = SigmaN + (Mx * (vectSig.Y - cdgy)) / (Ixgt) - (My * (vectSig.X - cdgx)) / (Iygt);

                    InterpolarColor intcol = new InterpolarColor(RR, GG, BB);
                    intcol.Interpolar(Sigma, SigmaMax, SigmaMin, SigmaN);
                    if (TieneEsfuerzo == false) { GL.Color3(RR, GG, BB); } else { GL.Color3(intcol.RR, intcol.GG, intcol.BB); }
                    GL.Color3(intcol.RR, intcol.GG, intcol.BB);
                    GL.Vertex2((0 + i * escx), (0 + j * escy));
                    if (i < colum)
                    {
                        intcol.Interpolar(SigmaSig, SigmaMax, SigmaMin, SigmaN);
                        if (TieneEsfuerzo == false) { GL.Color3(RR, GG, BB); } else { GL.Color3(intcol.RR, intcol.GG, intcol.BB); }
                        GL.Vertex2((0 + i * escx), (0 + (j + 1) * escy));
                    }
                }
                GL.End();
                colum--;
            }

            GL.PopMatrix();
        }



    }
}
