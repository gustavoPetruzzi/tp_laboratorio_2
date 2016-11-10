using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Excepciones;
namespace EntidadesAbstractas
{
    
    [Serializable]
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
        /// <summary>
        /// Constructor publico, que no recibe dni
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="Apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(String nombre, string Apellido, ENacionalidad nacionalidad)
        {
            this._nacionalidad = nacionalidad;
            this.Nombre = nombre;
            this.Apellido = Apellido;
        }


        /// <summary>
        /// Constructor publico, que recibe un tipo entero para el dni.
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="Apellido">Apellido de la persona</param>
        /// <param name="Dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(String nombre, String Apellido, int Dni, ENacionalidad nacionalidad) : this(nombre, Apellido, nacionalidad)
        {
            this.Dni = Dni;
        }


        /// <summary>
        /// Constructor publico, que recibe un String para el dni.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="Dni">Dni de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(String nombre, String apellido, String Dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = Dni;
        }

                                                      
        /// <summary>
        /// Constructor por defecto utilizado para serializar xml
        /// </summary>
        public Persona()
        {
            
        }
        #endregion


        #region Propiedades
        /// <summary>
        /// Nombre de la persona
        /// </summary>
        public String Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// Apellido de la persona
        /// </summary>


        public String Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Nacionalidad de la persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }


        /// <summary>
        /// Dni de la persona
        /// </summary>
        public int Dni
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }

     


        /// <summary>
        /// Convierte el dni pasado como String a un dni de tipo int y lo asigna a la persona
        /// </summary>
        public String StringToDni
        {
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }


        #endregion
        #region Privado
        /// <summary>
        /// Metodo privado para validar el dni con su respectiva nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a ser comparada con el dni</param>
        /// <param name="dato">dni a ser comparado con la nacionalidad</param>
        /// <returns>
        /// si el dni se corresponde con la nacionalidad, devuelve el dni, sino lanza una excepcion
        /// </returns>
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


        /// <summary>
        /// Valida que el dato pasado sea un dni  y que se corresponda con la nacionalidad pasada por parametro.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad a ser comparada con el dni.</param>
        /// <param name="dato">Dni a ser comparado con la nacionalidad.</param>
        /// <returns>Si el dato es un dni, devuelve el dni sino lanza una excepcion. </returns>
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


        /// <summary>
        /// Valida que el nombre y el apellido ingresado sea valido.s
        /// </summary>
        /// <param name="dato">String a validar.</param>
        /// <returns>Devuelve el dato validado o un String vacio si no es valido.</returns>
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
        /// <summary>
        /// Sobrecarga el metodo toString() para devolver el nombre completo y la nacionalidad de una persona
        /// </summary>
        /// <returns> Devuelve un String con los datos de una persona</returns>
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
