using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Excepciones;
namespace EntidadesAbstractas
{
    

    public abstract class Persona
    {


        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }


        private String _apellido;
        private String _nombre;
        private int _dni;
        private ENacionalidad _nacionalidad;


        #region Constructores
        public Persona(String nombre, string Apellido, ENacionalidad nacionalidad)
        {
            this._nacionalidad = nacionalidad;
            this.Nombre = nombre;
            this.Apellido = Apellido;
        }
        public Persona(String nombre, String Apellido, int Dni, ENacionalidad nacionalidad) : this(nombre, Apellido, nacionalidad)
        {
            this.Dni = Dni;
        }
        public Persona(String nombre, String apellido, String Dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = Dni;
        }
        // Constructor XML
        public Persona()
        {

        }
        #endregion
        #region Propiedades
        public int Dni
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }

        public String Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }


        public String Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public String StringToDni
        {
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }


        #endregion
        #region Privado
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (!(dato > 1 && dato < 89999999))
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (!(dato > 89999999))
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                default:
                    break;
            }
            return dato;

        }

        private int ValidarDni(ENacionalidad nacionalidad, String dato)
        {
            int numero = 0;
            try
            {
                numero = int.Parse(dato.Replace(".", string.Empty));
            }
            catch (Exception exc)
            {
                throw new DniInvalidoException(exc);
            }
            return ValidarDni(nacionalidad, numero);
        }

        private String ValidarNombreApellido(String dato)
        {
            Regex aBuscar = new Regex("[A-Za-z]+");
            Match valido = aBuscar.Match(dato);
            if (valido.Success)
                return dato;
            else
                return "";

        }
        #endregion
        #region Sobrecargas

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            retorno.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());
            return retorno.ToString();
        }
        #endregion

    }
}
