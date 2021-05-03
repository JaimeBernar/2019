using OpenTK;
using System;
using System.Collections.Generic;

namespace TFG
{
    [Serializable]
    public class Figura
    {
        public bool MapaColor { get; set; }
        public double InerciaXG { get; set; }
        public double InerciaYG { get; set; }
        public double InerciaXGYG { get; set; }
        public double InerciaXP { get; set; }
        public double InerciaYP { get; set; }
        public double InerciaXPYP { get; set; }
        public double IX { get; set; }
        public double IY { get; set; }
        public double IXY { get; set; }
        public bool TieneEsfuerzo { get; set; }
        public double Dplano { get; set; }
        public List<Vector4d> ListaTxz { get; set; } = new List<Vector4d>();
        public List<Vector4d> ListaTxy { get; set; } = new List<Vector4d>();
        public double Cdgx { get; set; }
        public double Cdgy { get; set; }
        public double Area { get; set; }
        public int NumeroFigura { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
        public double Theta { get; set; }
        public double R { get; set; }
        public bool Negativa { get; set; } = false;

        internal virtual void Calculos() { }
        internal virtual void Cortante(double Vy, double Vz, double Iy, double Iz, double cdgy, double cdgz) { }
        internal virtual void Dibujar(double RR, double GG, double BB) { }

        internal virtual void Seleccionada() { }

        internal virtual void DibujarExtruido(double RR, double GG, double BB, double Lext) { }

        internal virtual List<Vector3d> DistribucionTensiones(double cdgx, double cdgy, double Mx, double My, double Ixgt, double Iygt, double SigmaN) { return new List<Vector3d>(); }


        internal virtual void MapaTensional(double cdgx, double cdgy, double Mx, double My, double SigmaN, double Ixgt, double Iygt, double SigmaMax, double SigmaMin, double RR, double GG, double BB) { }

        internal virtual List<Vector4d> TensionCortante(double Vz, double Vy, double Iz, double Iy, double cdgx, double cdgy) { return new List<Vector4d>(); }

        internal virtual Vector2d CalculoQ(double x, double y, double cdgx, double cdgy) { return new Vector2d(0, 0); }

        internal virtual List<Vector2d> CoordCortante() { return new List<Vector2d>(); }

        internal virtual void PlanoTensional(double cdgx, double cdgy, double Mx, double My, double SigmaN, double Ixgt, double Iygt, double SigmaMax, double SigmaMin) { }
    }
}
