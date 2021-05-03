using System;

namespace TFG
{
    [Serializable]
    internal class InterpolarColor
    {
        private double bB;
        private double rR;
        private double gG;
        private readonly double Rojo, Verde, Azul;
        public InterpolarColor(double RedInicial, double GreenInicial, double BlueInicial)
        {
            Rojo = RedInicial;
            Verde = GreenInicial;
            Azul = BlueInicial;
        }

        public double RR { get => rR; set => rR = value; }
        public double GG { get => gG; set => gG = value; }
        public double BB { get => bB; set => bB = value; }

        public void Interpolar(double Sigma, double SigmaMax, double SigmaMin, double SigmaN)
        {
            SigmaMax -= SigmaN;
            SigmaMin -= SigmaN;
            double SigmaMedia = (SigmaMax + SigmaMin) / 2;
            double SigmaMedMin = (SigmaMedia + SigmaMin) / 2;
            double SigmaMedMax = (SigmaMedia + SigmaMax) / 2;

            //RR
            if (Sigma >= SigmaMedia && Sigma < SigmaMedMax) { RR = 1.0 * (Sigma - SigmaMedia) / (SigmaMedMax - SigmaMedia); }
            if (Sigma < SigmaMedia) { RR = 0.0; }
            if (Sigma > SigmaMedMax) { RR = 1.0; }
            //BB
            if (Sigma >= SigmaMedMin && Sigma <= SigmaMedia) { BB = -1.0 * (Sigma - SigmaMedMin) / (SigmaMedia - SigmaMedMin) + 1.0; }
            if (Sigma < SigmaMedMin) { BB = 1.0; }
            if (Sigma > SigmaMedia) { BB = 0.0; }
            //GG            
            if (Sigma < SigmaMedMin) { GG = 1.0 * (Sigma - SigmaMin) / (SigmaMedMin - SigmaMin); }
            if (Sigma > SigmaMedMax) { GG = -1.0 * (Sigma - SigmaMedMax) / (SigmaMax - SigmaMedMax) + 1.0; }
            if (Sigma > SigmaMedMin && Sigma < SigmaMedMax) { GG = 1.0; }
            if (Sigma < SigmaMin || Sigma > SigmaMax) { GG = 0.0; }

            if (SigmaMax == 0) { RR = Rojo; GG = Verde; BB = Azul; }
        }
    }
}
