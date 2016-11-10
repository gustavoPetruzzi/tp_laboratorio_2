using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using EntidadesInstanciables;
namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {


        public enum EEstadoCuenta
        {
            Deudor,
            MesPrueba,
            AlDia
        }


        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #region Constructores
        /// <summary>
        /// Constructor publico. Solamente inicializa el atributo ._claseQueToma
        /// </summary>
        /// <param name="id">Identificador del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clases que toma el alumno</param>
        public Alumno(int id, String nombre, String apellido, String dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Identificador del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">Dni del alumno</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clases que toma el alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del alumno</param>
        public Alumno(int id, String nombre, String apellido, String dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }


        
        /// <summary>
        /// Constructor por defecto para poder serializar XML
        /// </summary>
        public Alumno()
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Reescribe el metodo MostrarDatos.
        /// </summary>
        /// <returns>
        /// Devuelve un String con los datos de la clase base y ademas el estado de cuenta y las clases en las que
        /// participa.
        /// </returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.MostrarDatos());
            retorno.Append("ESTADO DE CUENTA: ");
            retorno.AppendLine(this._estadoCuenta.ToString());
            retorno.AppendLine(this.ParticiparEnClase());
            return retorno.ToString();
        }


        /// <summary>
        /// Reescribe el metodo abstracto de la clase base.
        /// </summary>
        /// <returns>Devuelve un String con las clases en las que participa.</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }
        #endregion
        #region Sobrecargas
        /// <summary>
        /// Compara un objeto de tipo alumno con un enumerado de tipo clase.
        /// Sobrecarga ==.
        /// </summary>
        /// <param name="a"> Objeto de tipo alumno </param>
        /// <param name="clase">Enumerado de tipo clase</param>
        /// <returns>Devuelve true si el no toma la clase pasada por parametro</returns>
        public static Boolean operator !=(Alumno a, Gimnasio.EClases clase)
        {
            Boolean retorno = false;
            if (!object.Equals(a, null) && a._claseQueToma != clase)
                retorno = true;
            return retorno;
        }


        /// <summary>
        /// Compara un objeto de tipo alumno con un enumerado de tipo clase
        /// </summary>
        /// <param name="a"> Objeto de tipo alumno</param>
        /// <param name="clase">Enumerado de tipo clase</param>
        /// <returns>
        /// Devuelve true si el alumno toma la clase pasada por parametro y si el atributo _estadoCuenta es distinto
        /// de Deudor
        /// </returns>
        public static Boolean operator ==(Alumno a, Gimnasio.EClases clase)
        {
            return (!(a != clase) && a._estadoCuenta != EEstadoCuenta.Deudor);
        }


        /// <summary>
        /// Sobrecarga del operador ToString()
        /// </summary>
        /// <returns>Devuelve un String con los datos del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }

}
