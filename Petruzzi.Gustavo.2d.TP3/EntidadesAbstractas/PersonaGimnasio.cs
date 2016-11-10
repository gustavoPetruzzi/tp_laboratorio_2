using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    [Serializable]
    public abstract class PersonaGimnasio: Persona
    {
        private int _identificador;

        #region Constructores
        /// <summary>
        /// Constructor publico
        /// </summary>
        /// <param name="id">Identificador de una PersonaGimnasio.</param>
        /// <param name="nombre">Nombre de una PersonaGimnasio.</param>
        /// <param name="Apellido">Apellido de una PersonaGimnasio.</param>
        /// <param name="dni">Dni de una PersonaGimnasio.</param>
        /// <param name="nacionalidad">Nacionalidad de una PersonaGimnasio.</param>
        public PersonaGimnasio(int id, String nombre, string Apellido, String dni, ENacionalidad nacionalidad) : base(nombre, Apellido, dni, nacionalidad)
        {
            this._identificador = id;
        }
        

        /// <summary>
        /// Constructor por defecto para serializar XML
        /// </summary>
        public PersonaGimnasio()
        {

        }
        #endregion


        #region Metodos
        /// <summary>
        /// Metodo virtual que devuelve los datos de un objeto de tipo PersonaGimnasio
        /// </summary>
        /// <returns>
        /// Devuelve un String con el nombre, apellido, dni, nacionalidad y el identificador de una persona
        /// </returns>
        protected virtual String MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine(base.ToString());
            retorno.AppendLine("CARNET NUMERO: " + this._identificador.ToString());
            return retorno.ToString();
        }


        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns>Devuelve un String con las clases en las que participa.</returns>
        protected abstract String ParticiparEnClase();


        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga equals para que un objeto de tipo PersonaGimnasio sea igual a otro objeto si son del mismo tipo
        /// </summary>
        /// <param name="obj"> obj a ser comparado con el objeto actual</param>
        /// <returns>Devuelve true si los 2 objetos son del mismo tipo o false si no lo son</returns>
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }


        /// <summary>
        /// Sobrecarga del operador ==. Compara 2 objeto de tipo PersonaGimnasio.
        /// </summary>
        /// <param name="pg1">Objeto de tipo PersonaGimnasio a comparar</param>
        /// <param name="pg2">Objeto de tipo PersonaGimnasio a comparar</param>
        /// <returns>
        /// Devuelve true si ambos objetos son del mismo tipo  y si tienen el mismo dni o identificador
        /// </returns>
        public static Boolean operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            Boolean retorno = false;
            if (!object.Equals(pg1, null) && !object.Equals(pg2, null) && pg1.Equals(pg2) && (pg1.Dni == pg2.Dni || pg1._identificador == pg2._identificador))
                retorno = true;
            return retorno;
        }


        /// <summary>
        /// Sobrecargar del operador !=. Compara 2 objeto de tipo PersonaGimnasio
        /// </summary>
        /// <param name="pg1">Objeto de tipo PersonaGimnasio a comparar</param>
        /// <param name="pg2">Objeto de tipo PersonaGimnasio a comparar</param>
        /// <returns>
        /// Devuelve true si ambos objetos no son del mismo tipo o si no tienen el mismo dni o identificador
        /// </returns>
        public static Boolean operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
