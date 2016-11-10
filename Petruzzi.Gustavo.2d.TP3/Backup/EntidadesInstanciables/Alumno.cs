using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
namespace EntidadesInstanciables
{

    

    

    public sealed class Alumno : PersonaGimnasio
    {


        public enum EEstadoCuenta
        {
            Deudor,
            MesPrueba,
            AlDia
        }


        protected Gimnasio.EClases _claseQueToma;
        protected EEstadoCuenta _estadoCuenta;
        #region Constructores
        public Alumno(int id, String nombre, String apellido, String dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, String nombre, String apellido, String dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        // Constructor XML
        public Alumno()
        {

        }
        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.MostrarDatos());
            retorno.Append("ESTADO DE CUENTA: ");
            retorno.AppendLine(this._estadoCuenta.ToString());
            retorno.AppendLine(this.ParticiparEnClase());
            return retorno.ToString();
        }
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma.ToString();
        }
        #endregion
        #region Sobrecargas
        public static Boolean operator !=(Alumno a, Gimnasio.EClases clase)
        {
            Boolean retorno = false;
            if (!object.Equals(a, null) && a._claseQueToma != clase)
                retorno = true;
            return retorno;
        }

        public static Boolean operator ==(Alumno a, Gimnasio.EClases clase)
        {
            return (!(a != clase) && a._estadoCuenta != EEstadoCuenta.Deudor);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }

}
