using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nSvehiculos
{
    public class Auto: Vehiculo
    {
        protected int _cantidadAsientos;

        public Auto(String Patente, Byte ruedas, EMarcas marca, int asientos)
            : base(Patente, ruedas, marca)
        {
            this._cantidadAsientos = asientos;
        }

        public String MostrarAuto()
        {
            return string.Format("{0} - Asientos: {1}", base.Mostrar(), this._cantidadAsientos.ToString());
        }
    }
}
