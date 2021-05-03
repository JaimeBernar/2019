using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace TFG
{
    [Serializable]
    public class Rectangulo : Figura
    {
        internal double Semidiagonal, Alpha;//Son los que pasan por G siendo paralelos a las caras del rectangulo
        private double Signo;

        public Rectangulo(double bb, double hh, double centrox, double centroy, double angulo)
        {
            Ancho = Math.Abs(bb);
            Alto = Math.Abs(hh);
            Theta = angulo;
            X = centrox;
            Y = centroy;
        }


        internal override void Calculos()
        {
            if (Negativa) { Area = -(Ancho * Alto); } else { Area = Ancho * Alto; }
            Cdgx = X; Cdgy = Y;

            if (Negativa) { Signo = -1; } else { Signo = 1; }
            //calculamos la inercia respecto a su cdg
            if (Negativa) { InerciaXG = -(1.0 / 12) * Ancho * Alto * Alto * Alto; } else { InerciaXG = (1.0 / 12) * Ancho * Alto * Alto * Alto; }
            if (Negativa) { InerciaYG = -(1.0 / 12) * Alto * Ancho * Ancho * Ancho; } else { InerciaYG = (1.0 / 12) * Alto * Ancho * Ancho * Ancho; }
            //calculamos la inercia respecto a su cdg y unos ejes girados a los generales

            double C = ((InerciaXG + InerciaYG) / 2);
            double R = Math.Sqrt(Math.Pow((InerciaXG - InerciaYG) / 2, 2) + InerciaXGYG * InerciaXGYG);
            double Angulo = 2 * Theta * Math.PI / 180;//En el circulo de Mohr el angulo es el doble
            double Alpha = Math.Atan2(InerciaXGYG, ((InerciaXG - InerciaYG) / 2)); //Angulo del cual partimos
            if (InerciaXG >= InerciaYG)
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
            IX = InerciaXP + Signo * Alto * Ancho * Cdgy * Cdgy;
            IY = InerciaYP + Signo * Alto * Ancho * Cdgx * Cdgx;
            IXY = InerciaXPYP + Signo * Alto * Ancho * Cdgx * Cdgy;

            //Calculo de las tensiones cortantes
        }

        internal override void Dibujar(double RR, double GG, double BB)
        {
            Calculos();
            GL.PushMatrix();
            GL.Translate(X, Y, 0);
            GL.Rotate(Theta, 0, 0, 1);
            if (Negativa)
            {
                GL.Translate(0.0, 0.0, Dplano);
            }

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(-Ancho / 2, -Alto / 2, 0);
            GL.Vertex3(-Ancho / 2, Alto / 2, 0);
            GL.Vertex3(Ancho / 2, Alto / 2, 0);
            GL.Vertex3(Ancho / 2, -Alto / 2, 0);
            GL.End();

            if (Negativa)
            {

                GL.Translate(0.0, 0.0, -Dplano * 2);
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(RR, GG, BB);
                GL.Normal3(0.0, 0.0, 1.0);
                GL.Vertex3(-Ancho / 2, -Alto / 2, 0);
                GL.Vertex3(-Ancho / 2, Alto / 2, 0);
                GL.Vertex3(Ancho / 2, Alto / 2, 0);
                GL.Vertex3(Ancho / 2, -Alto / 2, 0);
                GL.End();

            }

            GL.PopMatrix();

        }

        internal override void DibujarExtruido(double RR, double GG, double BB, double Lext)
        {
            double ThetaRad = Theta * Math.PI / 180;
            Semidiagonal = 1.0 / 2 * Math.Sqrt(Math.Pow(Alto, 2) + Math.Pow(Ancho, 2));
            Alpha = Math.Atan2(Alto, Ancho);
            GL.PushMatrix();
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            GL.Normal3(0.0, 0.0, 1.0);
            GL.Vertex3(X - Semidiagonal * Math.Cos(Alpha - ThetaRad), Y + Semidiagonal * Math.Sin(Alpha - ThetaRad), 0);
            GL.Vertex3(X - Semidiagonal * Math.Cos(Alpha + ThetaRad), Y - Semidiagonal * Math.Sin(Alpha + ThetaRad), 0);
            GL.Vertex3(X + Semidiagonal * Math.Cos(Alpha - ThetaRad), Y - Semidiagonal * Math.Sin(Alpha - ThetaRad), 0);
            GL.Vertex3(X + Semidiagonal * Math.Cos(Alpha + ThetaRad), Y + Semidiagonal * Math.Sin(Alpha + ThetaRad), 0);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(RR, GG, BB);
            //back
            if (Negativa)
            {
                GL.Normal3(0.0, 0.0, 1.0);
            }
            else
            {
                GL.Normal3(0.0, 0.0, -1.0);
            }
            GL.Vertex3(X - Semidiagonal * Math.Cos(Alpha - ThetaRad), Y + Semidiagonal * Math.Sin(Alpha - ThetaRad), -Lext);
            GL.Vertex3(X - Semidiagonal * Math.Cos(Alpha + ThetaRad), Y - Semidiagonal * Math.Sin(Alpha + ThetaRad), -Lext);
            GL.Vertex3(X + Semidiagonal * Math.Cos(Alpha - ThetaRad), Y - Semidiagonal * Math.Sin(Alpha - ThetaRad), -Lext);
            GL.Vertex3(X + Semidiagonal * Math.Cos(Alpha + ThetaRad), Y + Semidiagonal * Math.Sin(Alpha + ThetaRad), -Lext);

            //izda
            Vector3d Vect1 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha - ThetaRad), Y + Semidiagonal * Math.Sin(Alpha - ThetaRad), 0);
            Vector3d Vect2 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha + ThetaRad), Y - Semidiagonal * Math.Sin(Alpha + ThetaRad), 0);
            Vector3d Vect3 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha + ThetaRad), Y - Semidiagonal * Math.Sin(Alpha + ThetaRad), -Lext);
            Vector3d Vect4 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha - ThetaRad), Y + Semidiagonal * Math.Sin(Alpha - ThetaRad), -Lext);
            Vector3d L1 = new Vector3d(Vect2 - Vect1);
            L1.Normalize();
            Vector3d L2 = new Vector3d(Vect3 - Vect1);
            L2.Normalize();
            if (Negativa)
            {
                Vector3d Perp = new Vector3d(Vector3d.Cross(L1, L2));
                Perp.Normalize();
                GL.Normal3(Perp);
            }
            else
            {
                Vector3d Perp = new Vector3d(Vector3d.Cross(L2, L1));
                Perp.Normalize();
                GL.Normal3(Perp);
            }

            GL.Vertex3(Vect1.X, Vect1.Y, Vect1.Z);
            GL.Vertex3(Vect2.X, Vect2.Y, Vect2.Z);
            GL.Vertex3(Vect3.X, Vect3.Y, Vect3.Z);
            GL.Vertex3(Vect4.X, Vect4.Y, Vect4.Z);

            //top
            Vector3d Vect5 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha - ThetaRad), Y + Semidiagonal * Math.Sin(Alpha - ThetaRad), 0);
            Vector3d Vect6 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha + ThetaRad), Y + Semidiagonal * Math.Sin(Alpha + ThetaRad), 0);
            Vector3d Vect7 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha + ThetaRad), Y + Semidiagonal * Math.Sin(Alpha + ThetaRad), -Lext);
            Vector3d Vect8 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha - ThetaRad), Y + Semidiagonal * Math.Sin(Alpha - ThetaRad), -Lext);
            Vector3d L3 = new Vector3d(Vect6 - Vect5);
            L3.Normalize();
            Vector3d L4 = new Vector3d(Vect7 - Vect5);
            L4.Normalize();
            if (Negativa)
            {
                Vector3d Perp2 = new Vector3d(Vector3d.Cross(L4, L3));
                Perp2.Normalize();
                GL.Normal3(Perp2);
            }
            else
            {
                Vector3d Perp2 = new Vector3d(Vector3d.Cross(L3, L4));
                Perp2.Normalize();
                GL.Normal3(Perp2);
            }
            GL.Vertex3(Vect5.X, Vect5.Y, Vect5.Z);
            GL.Vertex3(Vect6.X, Vect6.Y, Vect6.Z);
            GL.Vertex3(Vect7.X, Vect7.Y, Vect7.Z);
            GL.Vertex3(Vect8.X, Vect8.Y, Vect8.Z);

            //dcha
            Vector3d Vect9 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha - ThetaRad), Y - Semidiagonal * Math.Sin(Alpha - ThetaRad), 0);
            Vector3d Vect10 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha + ThetaRad), Y + Semidiagonal * Math.Sin(Alpha + ThetaRad), 0);
            Vector3d Vect11 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha + ThetaRad), Y + Semidiagonal * Math.Sin(Alpha + ThetaRad), -Lext);
            Vector3d Vect12 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha - ThetaRad), Y - Semidiagonal * Math.Sin(Alpha - ThetaRad), -Lext);
            Vector3d L5 = new Vector3d(Vect10 - Vect9);
            L5.Normalize();
            Vector3d L6 = new Vector3d(Vect11 - Vect9);
            L6.Normalize();
            if (Negativa)
            {
                Vector3d Perp3 = new Vector3d(Vector3d.Cross(L5, L6));
                Perp3.Normalize();
                GL.Normal3(Perp3);
            }
            else
            {
                Vector3d Perp3 = new Vector3d(Vector3d.Cross(L6, L5));
                Perp3.Normalize();
                GL.Normal3(Perp3);
            }
            GL.Vertex3(Vect9.X, Vect9.Y, Vect9.Z);
            GL.Vertex3(Vect10.X, Vect10.Y, Vect10.Z);
            GL.Vertex3(Vect11.X, Vect11.Y, Vect11.Z);
            GL.Vertex3(Vect12.X, Vect12.Y, Vect12.Z);

            //bottom
            Vector3d Vect13 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha + ThetaRad), Y - Semidiagonal * Math.Sin(Alpha + ThetaRad), 0);
            Vector3d Vect14 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha - ThetaRad), Y - Semidiagonal * Math.Sin(Alpha - ThetaRad), 0);
            Vector3d Vect15 = new Vector3d(X + Semidiagonal * Math.Cos(Alpha - ThetaRad), Y - Semidiagonal * Math.Sin(Alpha - ThetaRad), -Lext);
            Vector3d Vect16 = new Vector3d(X - Semidiagonal * Math.Cos(Alpha + ThetaRad), Y - Semidiagonal * Math.Sin(Alpha + ThetaRad), -Lext);
            Vector3d L7 = new Vector3d(Vect14 - Vect13);
            L7.Normalize();
            Vector3d L8 = new Vector3d(Vect15 - Vect13);
            L8.Normalize();
            if (Negativa)
            {
                Vector3d Perp4 = new Vector3d(Vector3d.Cross(L7, L8));
                Perp4.Normalize();
                GL.Normal3(Perp4);
            }
            else
            {
                Vector3d Perp4 = new Vector3d(Vector3d.Cross(L8, L7));
                Perp4.Normalize();
                GL.Normal3(Perp4);
            }

            GL.Vertex3(Vect13.X, Vect13.Y, Vect13.Z);
            GL.Vertex3(Vect14.X, Vect14.Y, Vect14.Z);
            GL.Vertex3(Vect15.X, Vect15.Y, Vect15.Z);
            GL.Vertex3(Vect16.X, Vect16.Y, Vect16.Z);

            GL.End();
            GL.PopMatrix();
        }

        internal override void Cortante(double Vy, double Vz, double Iy, double Iz, double cdgy, double cdgz)
        {
            double ThetaRad = Theta * Math.PI / 180;
            double Diagonal = Math.Sqrt(Math.Pow(Alto, 2) + Math.Pow(Ancho, 2));
            Alpha = Math.Atan2(Alto, Ancho);
            double cols, filas, escala = 0.5, Cort;
            cols = Ancho / escala;
            filas = Alto / escala;
            double Iniciox = X - (Diagonal / 2) * Math.Cos(Alpha + ThetaRad);
            double Inicioy = Y - (Diagonal / 2) * Math.Sin(Alpha + ThetaRad); ;
            List<Vector3d> Lista = new List<Vector3d>();
            Vector3d vect;
            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-ThetaRad),
                M12 = -Math.Sin(-ThetaRad),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-ThetaRad),
                M22 = Math.Cos(-ThetaRad),
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




            GL.PointSize(2f);
            GL.PushMatrix();
            GL.Translate(Iniciox, Inicioy, 0);
            GL.Rotate(ThetaRad, 0, 0, 1);
            GL.Begin(PrimitiveType.Lines);
            for (int j = 0; j < filas; j++)
            {
                for (int i = 0; i <= cols; i++)
                {
                    vect = new Vector3d((0 + i * escala), (0 + j * escala), 0);
                    vect = Vector3d.Transform(vect, MatRot);
                    vect.X += Iniciox; vect.Y += Inicioy;
                    Cort = (Vy * vect.Y * escala * Ancho * (cdgy - Alto / 2 + vect.Y * escala / 2)) / (Ancho * Iz);

                    GL.Color3(0.7, 0, 0);
                    GL.Vertex3((0 + i * escala), (0 + j * escala), 0);
                    GL.Vertex3((0 + i * escala), (0 + j * escala), Cort);
                }

            }
            GL.End();

            GL.PointSize(1f);
            GL.PopMatrix();

        }
        internal override void Seleccionada()
        {
            Linea LLadoAbajo = new Linea(-Ancho / 2, -Alto / 2, Ancho / 2, -Alto / 2);
            Linea LLadoIzdo = new Linea(-Ancho / 2, -Alto / 2, -Ancho / 2, Alto / 2);
            Linea LLadoArriba = new Linea(-Ancho / 2, Alto / 2, Ancho / 2, Alto / 2);
            Linea LLadoDcho = new Linea(Ancho / 2, Alto / 2, Ancho / 2, -Alto / 2);

            GL.PushMatrix();
            GL.Translate(X, Y, 0);
            GL.Rotate(Theta, 0, 0, 1);
            LLadoAbajo.Dibujar(159.0 / 255, 15.0 / 255, 240.0 / 255, false, 3f, false);
            LLadoIzdo.Dibujar(159.0 / 255, 15.0 / 255, 240.0 / 255, false, 3f, false);
            LLadoDcho.Dibujar(159.0 / 255, 15.0 / 255, 240.0 / 255, false, 3f, false);
            LLadoArriba.Dibujar(159.0 / 255, 15.0 / 255, 240.0 / 255, false, 3f, false);
            GL.PopMatrix();
        }

        internal override List<Vector3d> DistribucionTensiones(double cdgx, double cdgy, double Mx, double My, double Ixgt, double Iygt, double SigmaN)
        {
            double ThetaRad = Theta * Math.PI / 180;
            double Diagonal = Math.Sqrt(Math.Pow(Alto, 2) + Math.Pow(Ancho, 2));
            int div = 20;
            double escy = Alto / div;
            double escx = Ancho / div;
            Alpha = Math.Atan2(Alto, Ancho);
            double Sigma;
            double Iniciox = X - (Diagonal / 2) * Math.Cos(Alpha + ThetaRad);
            double Inicioy = Y - (Diagonal / 2) * Math.Sin(Alpha + ThetaRad);
            List<Vector3d> Lista = new List<Vector3d>();
            Vector3d vect;
            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-ThetaRad),
                M12 = -Math.Sin(-ThetaRad),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-ThetaRad),
                M22 = Math.Cos(-ThetaRad),
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
                for (int i = 0; i <= div; i++)
                {
                    vect = new Vector3d((0 + i * escx), (0 + j * escy), 0);
                    vect = Vector3d.Transform(vect, MatRot);
                    vect.X += Iniciox; vect.Y += Inicioy;
                    Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);
                    vect.Z = Sigma;
                    Lista.Add(vect);
                }
            }
            return Lista;
        }

        internal override void MapaTensional(double cdgx, double cdgy, double Mx, double My, double SigmaN, double Ixgt, double Iygt, double SigmaMax, double SigmaMin, double RR, double GG, double BB)
        {
            double ThetaRad = Theta * Math.PI / 180;
            double Diagonal = Math.Sqrt(Math.Pow(Alto, 2) + Math.Pow(Ancho, 2));
            int div = 20;
            double escy = Alto / div;
            double escx = Ancho / div;
            Alpha = Math.Atan2(Alto, Ancho);
            double Sigma, SigmaSig;
            double Iniciox = X - (Diagonal / 2) * Math.Cos(Alpha + ThetaRad);
            double Inicioy = Y - (Diagonal / 2) * Math.Sin(Alpha + ThetaRad);
            Vector3d vect, vectsig;
            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-ThetaRad),
                M12 = -Math.Sin(-ThetaRad),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-ThetaRad),
                M22 = Math.Cos(-ThetaRad),
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
            for (int j = 0; j < div; j++)
            {
                GL.Begin(PrimitiveType.TriangleStrip);
                for (int i = 0; i <= div; i++)
                {
                    vect = new Vector3d((0 + i * escx), (0 + j * escy), 0);
                    vectsig = new Vector3d((0 + i * escx), (0 + (j + 1) * escy), 0);
                    vect = Vector3d.Transform(vect, MatRot);
                    vectsig = Vector3d.Transform(vectsig, MatRot);
                    vect.X += Iniciox; vect.Y += Inicioy;
                    vectsig.X += Iniciox; vectsig.Y += Inicioy;
                    Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);
                    SigmaSig = SigmaN + (Mx * (vectsig.Y - cdgy)) / (Ixgt) - (My * (vectsig.X - cdgx)) / (Iygt);
                    vect.Z = Sigma;
                    vectsig.Z = SigmaSig;
                    InterpolarColor intcol = new InterpolarColor(RR, GG, BB);
                    intcol.Interpolar(Sigma, SigmaMax, SigmaMin, SigmaN);
                    if (!TieneEsfuerzo) { GL.Color3(RR, GG, BB); } else { GL.Color3(intcol.RR, intcol.GG, intcol.BB); }
                    GL.Color3(intcol.RR, intcol.GG, intcol.BB);
                    GL.Vertex2((0 + i * escx), (0 + j * escy));
                    intcol.Interpolar(SigmaSig, SigmaMax, SigmaMin, SigmaN);
                    if (!TieneEsfuerzo) { GL.Color3(RR, GG, BB); } else { GL.Color3(intcol.RR, intcol.GG, intcol.BB); }
                    GL.Color3(intcol.RR, intcol.GG, intcol.BB);
                    GL.Vertex2((0 + i * escx), (0 + (j + 1) * escy));
                }
                GL.End();
            }
            GL.PopMatrix();
        }

        internal override void PlanoTensional(double cdgx, double cdgy, double Mx, double My, double SigmaN, double Ixgt, double Iygt, double SigmaMax, double SigmaMin)
        {
            double ThetaRad = Theta * Math.PI / 180;

            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-ThetaRad),
                M12 = -Math.Sin(-ThetaRad),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-ThetaRad),
                M22 = Math.Cos(-ThetaRad),
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
            GL.Enable(EnableCap.Blend);
            GL.Translate(X, Y, 0);
            GL.Rotate(Theta, 0, 0, 1);

            GL.Begin(PrimitiveType.Quads);
            if (!Negativa) { GL.Color4(0.7, 0, 0, 0.5); } else { GL.Color4(0.5, 0.5, 0.5, 0.5); }
            GL.Normal3(0.0, 0.0, 1.0);
            Vector3d vect = new Vector3d(-Ancho / 2, -Alto / 2, 0);
            vect = Vector3d.Transform(vect, MatRot);
            vect.X += X; vect.Y += Y;
            double Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);
            GL.Vertex3(-Ancho / 2, -Alto / 2, (Sigma * 20 + SigmaN * 20) / SigmaMax);
            vect = new Vector3d(-Ancho / 2, Alto / 2, 0);
            vect = Vector3d.Transform(vect, MatRot);
            vect.X += X; vect.Y += Y;
            Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);
            GL.Vertex3(-Ancho / 2, Alto / 2, (Sigma * 20 + SigmaN * 20) / SigmaMax);
            vect = new Vector3d(Ancho / 2, Alto / 2, 0);
            vect = Vector3d.Transform(vect, MatRot);
            vect.X += X; vect.Y += Y;
            Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);
            GL.Vertex3(Ancho / 2, Alto / 2, (Sigma * 20 + SigmaN * 20) / SigmaMax);
            vect = new Vector3d(Ancho / 2, -Alto / 2, 0);
            vect = Vector3d.Transform(vect, MatRot);
            vect.X += X; vect.Y += Y;
            Sigma = SigmaN + (Mx * (vect.Y - cdgy)) / (Ixgt) - (My * (vect.X - cdgx)) / (Iygt);
            GL.Vertex3(Ancho / 2, -Alto / 2, (Sigma * 20 + SigmaN * 20) / SigmaMax);
            GL.End();



            GL.Disable(EnableCap.Blend);
            GL.PopMatrix();
        }
        internal override List<Vector4d> TensionCortante(double Vz, double Vy, double Iz, double Iy, double cdgx, double cdgy)
        {
            double ThetaRad = Theta * Math.PI / 180;
            double Diagonal = Math.Sqrt(Math.Pow(Alto, 2) + Math.Pow(Ancho, 2));
            Alpha = Math.Atan2(Alto, Ancho);
            double cols, filas, escala = 1;
            cols = Ancho / escala;
            filas = Alto / escala;
            double Iniciox = X - (Diagonal / 2) * Math.Cos(Alpha + ThetaRad);
            double Inicioy = Y - (Diagonal / 2) * Math.Sin(Alpha + ThetaRad);
            List<Vector4d> Lista = new List<Vector4d>();
            Vector4d vect;
            Vector2d Qcort = new Vector2d();
            Matrix4d MatRot = new Matrix4d
            {
                M11 = Math.Cos(-ThetaRad),
                M12 = -Math.Sin(-ThetaRad),
                M13 = 0,
                M14 = 0,
                M21 = Math.Sin(-ThetaRad),
                M22 = Math.Cos(-ThetaRad),
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

            for (int i = 0; i <= cols; i++)
            {
                vect = new Vector4d((0 + i * escala), 0, 0, 0);
                vect = Vector4d.Transform(vect, MatRot);
                vect.X += X - Ancho / 2; vect.Y += Y;
                Qcort = CalculoQ(i * escala, 0, cdgx, cdgy);
                double txz = (Vz * Qcort.X) / (Alto * Iy);
                vect.Z = txz;
                vect.W = 0;
                ListaTxz.Add(vect);
                Lista.Add(vect);
            }
            GL.PopMatrix();

            for (int j = 0; j <= filas; j++)
            {
                vect = new Vector4d(0, (0 + j * escala), 0, 0);
                vect = Vector4d.Transform(vect, MatRot);
                vect.X += X; vect.Y += Y - Alto / 2;
                Qcort = CalculoQ(0, j * escala, cdgx, cdgy);
                double txy = (Vy * Qcort.Y) / (Ancho * Iz);
                vect.Z = 0;
                vect.W = txy;
                ListaTxy.Add(vect);
                Lista.Add(vect);
            }


            return Lista;
        }

        internal override Vector2d CalculoQ(double x, double y, double cdgx, double cdgy)
        {
            //Origen en la esquina inferior izda
            double Qz, Qy;


            if (X >= cdgx)
            {
                Qz = (Ancho - x) * Alto * ((X - cdgx) + (Ancho / 2) - (Ancho - x) / 2);
            }
            else
            {
                Qz = -(x) * Alto * ((X - cdgx) - (Ancho / 2) + (x) / 2);
            }



            if (Y >= cdgy)
            {
                Qy = (Alto - y) * Ancho * ((Y - cdgy) + (Alto / 2) - (Alto - y) / 2);
            }
            else
            {
                Qy = -(y) * Ancho * ((Y - cdgy) - (Alto / 2) + (y) / 2);
            }


            return new Vector2d(Qz, Qy);
        }

        internal override List<Vector2d> CoordCortante()
        {
            List<Vector2d> Lista = new List<Vector2d>();
            double divy, divx, iniciox, inicioy, esc = 1.0;

            if (Theta != 90 && Theta != 270)
            {
                divy = Alto / (esc * Math.Cos(Theta * Math.PI / 180));
                divx = Ancho / (esc * Math.Cos(Theta * Math.PI / 180));
                iniciox = X - Ancho / (2 * Math.Cos(Theta * Math.PI / 180));
                inicioy = Y - Alto / (2 * Math.Cos(Theta * Math.PI / 180));
            }
            else
            {
                //se intercambian el ancho y el alto
                divy = Ancho / (esc);
                divx = Alto / (esc);
                iniciox = X - Alto / (2);
                inicioy = Y - Ancho / (2);
            }

            GL.PushMatrix();
            GL.Translate(0, 0, 3);
            GL.PointSize(2f);
            for (int i = 0; i <= divx; i++)
            {
                GL.Begin(PrimitiveType.Points);
                GL.Vertex2(iniciox + i * esc, Y);
                GL.End();
            }

            for (int j = 0; j <= divy; j++)
            {
                GL.Begin(PrimitiveType.Points);
                GL.Vertex2(X, inicioy + j * esc);
                GL.End();
            }
            GL.PopMatrix();
            return Lista;
        }


    }
}
