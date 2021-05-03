using System;

namespace TFG
{
    [Serializable]
    internal class CargaTermica : Carga
    {
        public CargaTermica(Barra Barra, double Tempmedia, double Tempgrad)
        {
            Barra = BarraAsociada;
            Tmedia = Tempmedia;
            Tgrad = Tempgrad;
        }
    }
}
