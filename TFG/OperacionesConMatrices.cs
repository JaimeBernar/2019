using OpenTK;
using System;

namespace TFG
{
    [Serializable]
    internal class OperacionesConMatrices
    {
        public OperacionesConMatrices()
        {

        }

        internal Vector3d LocalesAGlobales(Vector3d vect, double[,] T)
        {
            Vector3d Resul;
            Resul.X = T[0, 0] * vect.X + T[0, 1] * vect.Y + T[0, 2] * vect.Z;
            Resul.Y = T[1, 0] * vect.X + T[1, 1] * vect.Y + T[1, 2] * vect.Z;
            Resul.Z = T[2, 0] * vect.X + T[2, 1] * vect.Y + T[2, 2] * vect.Z;

            return Resul;
        }

        internal Vector3d GlobalesALocales(Vector3d vect, double[,] Ttras)
        {
            Vector3d Resul;
            Resul.X = Ttras[0, 0] * vect.X + Ttras[0, 1] * vect.Y + Ttras[0, 2] * vect.Z;
            Resul.Y = Ttras[1, 0] * vect.X + Ttras[1, 1] * vect.Y + Ttras[1, 2] * vect.Z;
            Resul.Z = Ttras[2, 0] * vect.X + Ttras[2, 1] * vect.Y + Ttras[2, 2] * vect.Z;

            return Resul;
        }
        internal double[,] Suma(double[,] Mat1, double[,] Mat2)
        {
            double[,] Resul = new double[3, 3];

            Resul[0, 0] = Mat1[0, 0] + Mat2[0, 0];
            Resul[0, 1] = Mat1[0, 1] + Mat2[0, 1];
            Resul[0, 2] = Mat1[0, 2] + Mat2[0, 2];
            Resul[1, 0] = Mat1[1, 0] + Mat2[1, 0];
            Resul[1, 1] = Mat1[1, 1] + Mat2[1, 1];
            Resul[1, 2] = Mat1[1, 2] + Mat2[1, 2];
            Resul[2, 0] = Mat1[2, 0] + Mat2[2, 0];
            Resul[2, 1] = Mat1[2, 1] + Mat2[2, 1];
            Resul[2, 2] = Mat1[2, 2] + Mat2[2, 2];

            return Resul;
        }

        internal double[,] Traspuesta(double[,] Mat)
        {
            double[,] Result = new double[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Result[i, j] = Mat[j, i];
                }
            }

            return Result;
        }

        internal Vector3d CalculoEsfuerzos(double[,] Knudo, double[,] Tnudo, double[] Dnudo, int tam)
        {
            Vector3d Esfuerzos = new Vector3d();
            double[,] Multiplicacion = new double[tam, tam];

            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    Multiplicacion[i, j] = 0;
                    for (int z = 0; z < tam; z++)
                    {
                        Multiplicacion[i, j] = Knudo[i, z] * Tnudo[z, j] + Multiplicacion[i, j];
                    }
                }
            }

            Esfuerzos.X = Multiplicacion[0, 0] * Dnudo[0] + Multiplicacion[0, 1] * Dnudo[1] + Multiplicacion[0, 2] * Dnudo[2];
            Esfuerzos.Y = Multiplicacion[1, 0] * Dnudo[0] + Multiplicacion[1, 1] * Dnudo[1] + Multiplicacion[1, 2] * Dnudo[2];
            Esfuerzos.Z = Multiplicacion[2, 0] * Dnudo[0] + Multiplicacion[2, 1] * Dnudo[1] + Multiplicacion[2, 2] * Dnudo[2];

            return Esfuerzos;
        }

        internal double[] MatxVect(double[,] Mat, double[] vect, int tam)
        {
            double[] Result = new double[tam];

            for (int j = 0; j < tam; j++)
            {
                for (int i = 0; i < tam; i++)
                {
                    Result[j] = Mat[j, i] * vect[i] + Result[j];
                }
            }

            return Result;
        }

        internal double[] VectxMat(double[,] Mat, double[] vect, int tam)
        {
            double[] Result = new double[tam];

            for (int j = 0; j < tam; j++)
            {
                for (int i = 0; i < tam; i++)
                {
                    Result[j] = Mat[i, j] * vect[i] + Result[j];
                }
            }

            return Result;
        }

        internal double VectxVect(double[] vect1, double[] vect2, int tamVect)
        {
            double Result = 0;
            for (int i = 0; i < tamVect; i++)
            {
                Result += vect1[i] * vect2[i];
            }
            return Result;
        }
    }
}
