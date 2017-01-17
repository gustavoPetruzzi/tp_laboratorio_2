using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace parcialTren
{
    public class TrenElectrico : Tren
    {
        protected List<Pasajero> _pasajeros;

        public List<Pasajero> Pasajeros
        {
            get
            {
                return this._pasajeros;
            }
        }

        public TrenElectrico(int cantidadMaxPasajeros, Boolean motor, String destino)
            : base(cantidadMaxPasajeros, motor, destino)
        {
            this._pasajeros = new List<Pasajero>();
        }
        #region Metodos

        public static Boolean operator ==(TrenElectrico T1, Pasajero p1)
        {
            Boolean retorno = false;
            foreach (Pasajero pasajero in T1.Pasajeros)
            {
                if (pasajero.Nombre == p1.Nombre && pasajero.Apellido == p1.Apellido && pasajero.Rango == p1.Rango)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        public override void Ingresar(Pasajero pasajero)
        {
            if (this._cantMaxPasajeros < this._pasajeros.Count)
            {
                if (this == pasajero)
                {
                    this.Pasajeros.Add(pasajero);
                }
            }
        }
        #endregion

    }
}
