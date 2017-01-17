using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nSvehiculos
{
    public class Vehiculo
    {
        private String _patente;
        private Byte _cantRuedas;
        private EMarcas _marca;

        public String Patente
        {
            get
            {
                return this._patente;
            }
        }

        public EMarcas Marca
        {
            get
            {
                return this._marca;
            }
        }

        protected String Mostrar()
        {
            return string.Format("Patente: {0} - Cantidad de Ruedas {1} - Marca: {2} ", this._patente, this._cantRuedas, this._marca);
        }

        public Vehiculo(string patente, Byte cantidad, EMarcas marca)
        {
            this._patente = patente;
            this._cantRuedas = cantidad;
            this._marca = marca;
        }

        public static Boolean operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            Boolean retorno = false;
            if (!object.Equals(vehiculo1, null) && !object.Equals(vehiculo2, null) && object.Equals(vehiculo1._patente, vehiculo2._patente) && object.Equals(vehiculo1._marca, vehiculo2._marca))
            {
                retorno = true;
            }
            return retorno;
        }

    }
}
