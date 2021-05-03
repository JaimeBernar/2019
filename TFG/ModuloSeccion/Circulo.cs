using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace TFG
{
    [Serializable]
    public class Circulo : Figura
    {
        private double Signo;

        public Circulo(double centrox, double centroy, double radio)
        {
            R = radio;
            X = centrox;
            Y = centroy;
        }

        internal override void Calculos()
        {
            if (Negativa) { Area = -Math.PI * R * R; } else { Area = Math.PI * R * R; }
            Cdgx = X;
            Cdgy = Y;

            if (Negativa) { Signo = -1; } else { Signo = 1; }
            //calculamos la inercia respecto a su cdg
            if (Negativa) { InerciaXG = -1.0 / 4 * Math.PI * Math.Pow(R, 4); } else { InerciaXG = 1.0 / 4 * Math.PI * Math.Pow(R, 4); }
            if (Negativa) { InerciaYG = -1.0 / 4 * Math.PI * Math.Pow(R, 4); } else { InerciaYG = 1.0 / 4 * Math.PI * Math.Pow(R, 4); }
            //calculamos la inercia respecto a su cdg y unos ejes paralelos a los generales
            //En el circulo los ejes siempre son principales puesto que siempre hay simetría respecto al cdg   
            InerciaXP = InerciaXG;
            InerciaYP = InerciaYG;
            InerciaXPYP = InerciaXGYG;
            //Calculamos la inercia respecto a los generales con steiner
            IX = InerciaXP + Signo * Math.PI * Math.Pow(R, 2) * Cdgy * Cdgy;
            IY = InerciaYP + Signo * Math.PI * Math.Pow(R, 2) * Cdgx * Cdgx;
            IXY = InerciaXPYP + Signo * Math.PI * Math.Pow(R, 2) * Cdgx * Cdgy;
        }
        internal override void Dibujar(double RR, double GG, double BB)
        {
            Calculos();
            int increm = 8;
            GL.PushMatrix();

            if (Negativa)
            {
                GL.Translate(0.0, 0.0, Dplano);
            }
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = Theta; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), 0);
                Vector3d Vect2 = new Vector3d(X + R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 0);
                Vector3d Vect3 = new Vector3d(X, Y, 0);
                Vector3d L1 = new Vector3d(Vect2 - Vect1);
                Vector3d L2 = new Vector3d(Vect3 - Vect1);
                Vector3d Perp = new Vector3d(Vector3d.Cross(L1, L2));
                Perp.Normalize();
                GL.Normal3(Perp);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
                GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
                GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            }
            GL.End();

            if (Negativa)
            {
                GL.Translate(0.0, 0.0, -Dplano * 2);
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Color3(RR, GG, BB);
                for (double i = Theta; i < 360; i += increm)
                {
                    Vector3d Vect1 = new Vector3d(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), 0);
                    Vector3d Vect2 = new Vector3d(X + R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 0);
                    Vector3d Vect3 = new Vector3d(X, Y, 0);
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
                }
                GL.End();
            }

            GL.PopMatrix();
        }
        internal override void DibujarExtruido(double RR, double GG, double BB, double Lext)
        {
            int increm = 5;
            GL.PushMatrix();
            GL.Begin(PrimitiveType.TriangleFan);
            GL.Color3(RR, GG, BB);
            for (double i = Theta; i < 360; i += increm)
            {
                GL.Normal3(0, 0, -1);
                GL.Vertex3(X, Y, -Lext);
                GL.Vertex3(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), -Lext);
                GL.Vertex3(X + R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), -Lext);
            }
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            for (double i = Theta; i < 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), -Lext);
                Vector3d Vect2 = new Vector3d(X + R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), -Lext);
                Vector3d Vect3 = new Vector3d(X + R * Math.Cos((i) * (Math.PI / 180) + increm * Math.PI / 180), Y + R * Math.Sin((i) * (Math.PI / 180) + increm * Math.PI / 180), 0);
                Vector3d Vect4 = new Vector3d(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), 0);
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
            }
            GL.End();
            GL.PopMatrix();
        }
        internal override void Seleccionada()
        {
            double increm = 1;
            GL.LineWidth(3f);
            GL.Begin(PrimitiveType.LineStrip);
            for (double i = Theta; i <= Theta + 360; i += increm)
            {
                Vector3d Vect1 = new Vector3d(X + R * Math.Cos(i * (Math.PI / 180)), Y + R * Math.Sin(i * (Math.PI / 180)), 0);
                GL.Color3(159.0 / 255, 15.0 / 255, 240.0 / 255);
                GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
            }
            GL.End();
            GL.LineWidth(1f);
        }

        internal override List<Vector3d> DistribucionTensiones(double cdgx, double cdgy, double Mx, double My, double Ixgt, double Iygt, double SigmaN)
        {
            double Div = 20;//Numero de incrementos de radio
            double Unid = R / Div; //Inremento de un radio al siguiente
            double Sectores = 80; // Numero de sectores             
            List<Vector3d> Lista = new List<Vector3d>();
            Vector3d vect;
            double Angulo = Theta * Math.PI / 180;
            double IncreAng = (360.0 / Sectores);

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
            for (double j = 0; j <= Div; j++)
            {
                for (double i = 0; i <= Sectores; i++)
                {
                    vect.X = (R - j * Unid) * Math.Cos((i * IncreAng) * Math.PI / 180);
                    vect.Y = (R - j * Unid) * Math.Sin((i * IncreAng) * Math.PI / 180);
                    vect.Z = 0;
                    vect = Vector3d.Transform(vect, MatRot);
                    vect.X = vect.X + X;
                    vect.Y = vect.Y + Y;
                    Lista.Add(vect);
                }
            }
            GL.PopMatrix();
            return Lista;
        }

        internal override void MapaTensional(double cdgx, double cdgy, double Mx, double My, double SigmaN, double Ixgt, double Iygt, double SigmaMax, double SigmaMin, double RR, double GG, double BB)
        {
            double escala = 0.5, divisiones = 45.0;
            Vector3d vect, vectsig;
            double Theta = base.Theta * Math.PI / 180.0;
            double Sigma, Sigmasig;
            double divy = R / escala, IncreAng, Rd = R;

            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-Theta),
                M12 = -Math.Sin(-Theta),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-Theta),
                M22 = Math.Cos(-Theta),
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

            IncreAng = (360.0 / divisiones) * Math.PI / 180.0;
            for (double j = 0; (j + 1) * escala <= Rd; j++)
            {
                GL.Begin(PrimitiveType.TriangleStrip);
                for (double i = 0; IncreAng * i <= Math.PI * 2; i++)
                {
                    vect.X = (Rd - j * escala) * Math.Cos(IncreAng * i);
                    vect.Y = (Rd - j * escala) * Math.Sin(IncreAng * i);
                    vect.Z = 0;
                    vect = Vector3d.Transform(vect, MatRot);
                    vect.X += X;
                    vect.Y += Y;
                    Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);


                    vectsig.X = (Rd - (j + 1) * escala) * Math.Cos(IncreAng * i);
                    vectsig.Y = (Rd - (j + 1) * escala) * Math.Sin(IncreAng * i);
                    vectsig.Z = 0;
                    vectsig = Vector3d.Transform(vectsig, MatRot);
                    vectsig.X += X;
                    vectsig.Y += Y;
                    Sigmasig = SigmaN + (Mx * (vectsig.Y - cdgy)) / (Ixgt) - (My * (vectsig.X - cdgx)) / (Iygt);

                    InterpolarColor intcol = new InterpolarColor(RR, GG, BB);
                    intcol.Interpolar(Sigma, SigmaMax, SigmaMin, SigmaN);
                    GL.Color3(intcol.RR, intcol.GG, intcol.BB);
                    GL.Vertex2(vect.X, vect.Y);
                    intcol.Interpolar(Sigmasig, SigmaMax, SigmaMin, SigmaN);
                    GL.Color3(intcol.RR, intcol.GG, intcol.BB);
                    GL.Vertex2(vectsig.X, vectsig.Y);
                }
                GL.End();
            }
            GL.PopMatrix();
        }

    }
}
