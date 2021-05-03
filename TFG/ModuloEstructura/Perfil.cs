using System;

namespace TFG
{
    [Serializable]
    public class Perfil
    {
        public string Nombre { get; set; }
        public double A { get; set; }
        public double Iz { get; set; }
        public double Iy { get; set; }
        public int TipoCTE { get; set; }
        /// <summary>
        /// Crea un nuevo perfil con las propiedades deseadas
        /// </summary>
        /// <param name="Nombre_">Nombre identificativo del perfil</param> 
        /// <param name="A_">Area de la sección trasversal</param> 
        /// <param name="Iz_">Inercia a flexión en Z</param> 
        /// <param name="Iy_">Inercia a flexión en Y</param> 
        /// <param name="Cte">Tipo de perfil segun el CTE</param> 
        public Perfil(string Nombre, double A, double Iz, double Iy, int Cte)
        {
            this.Nombre = Nombre;
            this.A = A;
            this.Iz = Iz;
            this.Iy = Iy;
            TipoCTE = Cte;
        }
    }
}
