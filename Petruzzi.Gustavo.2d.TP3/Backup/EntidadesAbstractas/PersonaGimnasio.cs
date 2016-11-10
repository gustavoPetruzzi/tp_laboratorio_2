using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio: Persona
    {
        private int _identificador;
        #region Constructores
        public PersonaGimnasio(int id, String nombre, string Apellido, String dni, ENacionalidad nacionalidad) : base(nombre, Apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }
        // Constructor XML
        public PersonaGimnasio()
        {

        }
        #endregion
        #region Metodos
        protected virtual String MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.AppendLine("CARNET NUMERO: " + this._identificador.ToString());
            return retorno.ToString();
        }
        protected abstract String ParticiparEnClase();
        #endregion

        #region Sobrecargas
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }

        public static Boolean operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            Boolean retorno = false;
            if (!object.Equals(pg1, null) && !object.Equals(pg2, null) && pg1.Equals(pg2) && (pg1.Dni == pg2.Dni || pg1._identificador == pg2._identificador))
                retorno = true;
            return retorno;
        }
        public static Boolean operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
