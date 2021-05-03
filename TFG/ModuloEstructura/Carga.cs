using System;

namespace TFG
{
    [Serializable]
    public class Carga
    {
        public double Xi { get; set; }//Distancia desde el nodo inicial
        public double Qi { get; set; }//Valor carga distribuida nudo inicial
        public double Qj { get; set; }//Valor carga distribuida nudo final
        public double Tmedia { get; set; }//Temperatura media en la barra
        public double Tgrad { get; set; }//Gradiente de temperatura entre caras de la barra
        public double Error { get; set; }//Error dd forma
        public double Nx { get; set; }//Pretension axial
        public double Vy { get; set; }//Pretension cortante
        public Nodo NodAdjunto { get; set; }
        public Nodo NodAdjuntoi { get; set; }
        public Nodo NodAdjuntoj { get; set; }

        //REACCIONES DE LA FASE 0
        public double Xa { get; set; }
        public double Ra { get; set; }
        public double Ma { get; set; }
        public double Xb { get; set; }
        public double Rb { get; set; }
        public double Mb { get; set; }

        public double XaG { get; set; }
        public double RaG { get; set; }
        public double MaG { get; set; }
        public double XbG { get; set; }
        public double RbG { get; set; }
        public double MbG { get; set; }
        public string SegunEje { get; set; }
        public Barra BarraAsociada { get; set; }
        public int NumeroCarga { get; set; }
        public bool CargaNodal { get; set; }
        public double Modulo { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Theta { get; set; }

        internal virtual void Dibujar(double cte, double RR, double GG, double BB, double Theta) { }
        internal virtual void Dibujar2D(double cte, double RR, double GG, double BB, double Theta) { }

    }
}
