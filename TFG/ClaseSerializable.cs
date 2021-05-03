using System;
using System.Collections.Generic;

namespace TFG
{
    [Serializable]
    internal class ClaseSerializable
    {
        public List<Nodo> ListaNodos { get; set; }
        public List<Barra> ListaBarras { get; set; }
        public List<Apoyo> ListaApoyos { get; set; }
        public List<Carga> ListaFuerzas { get; set; }

        public List<Figura> ListaFiguras { get; set; }
    }
}
