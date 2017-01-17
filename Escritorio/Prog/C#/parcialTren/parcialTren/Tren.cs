using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace parcialTren
{
    public abstract class Tren
    {
        protected int _cantMaxPasajeros;
        protected Boolean _motorEncendido;
        protected String _destino;

        public Tren(int cantidadMaxPasajeros, Boolean Motor, String Destino)
        {
            this._motorEncendido = Motor;
            this._destino = Destino;
            this._cantMaxPasajeros = cantidadMaxPasajeros;
        }


        public abstract List<Pasajero> Pasajeros { get; }

        #region Metodos
        
        public abstract void Ingresar(Pasajero pasajero);

        public virtual String IndicarDestino()
        {
            return this._destino;
        }

        public Boolean EncenderMotor()
        {
            if (!(this._motorEncendido))
            {
                this._motorEncendido = true;
            }
            return this._motorEncendido;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Destino: " + this._destino);
            retorno.AppendLine("Cantidad Maxima Pasajeros: " + this._cantMaxPasajeros);
            retorno.Append("Motor: ");
            if (this._motorEncendido)
                retorno.AppendLine("Encendido");
            else
                retorno.AppendLine("Apagado");
            return retorno.ToString();
        }


        #endregion


    }
}
