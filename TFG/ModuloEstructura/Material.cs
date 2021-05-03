using System;

namespace TFG
{
    [Serializable]
    public class Material
    {
        public string Nombre { get; set; }
        public double Peso { get; set; }
        public double EYoung { get; set; }
        public double Alfa { get; set; }
        public Material(string Nombre_, double Peso_, double EYoung_, double Alfa_)
        {
            Nombre = Nombre_;
            Peso = Peso_;
            EYoung = EYoung_;
            Alfa = Alfa_;
        }
    }
}
