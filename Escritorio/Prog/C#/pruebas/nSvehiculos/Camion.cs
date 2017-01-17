using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nSvehiculos
{
    public class Camion: Vehiculo
    {
        protected float _tara;
        
        public Camion(String patente, Byte ruedas, EMarcas marca, float tara):base(patente, ruedas, marca)
        {
            this._tara = tara;
        }
        
        public String MostrarCamion()
        {
            return string.Format("{0} - Peso:{1}", base.Mostrar(), this._tara);
        }
    }
}
