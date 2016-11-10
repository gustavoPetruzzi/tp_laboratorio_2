using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException: Exception
    {
        private static String mensajeBase = "Dni Invalido ";
        /// <summary>
        /// Constructor Publico.
        /// </summary>
        public DniInvalidoException() : base(mensajeBase)
        {

        }
        /// <summary>
        /// Constructor publico. Recibe un objeto de tipo Exception que se pasa a la clase base.
        /// </summary>
        /// <param name="e">Objeto de tipo Exception</param>
        public DniInvalidoException(Exception e) : base(mensajeBase, e)
        {

        }
        /// <summary>
        /// Constructor publico.Recibe un objeto de tipo String que se pasa a la clase base.
        /// </summary>
        /// <param name="message">Objeto de tipo String</param>
        public DniInvalidoException(String message) : this(message, null)
        {

        }
        /// <summary>
        /// Constructor publico.Recibe un objeto de tipo String y un objeto de tipo Exception 
        /// que se pasan a la clase base.
        /// </summary>
        /// <param name="message">Objeto de tipo String</param>
        /// <param name="e">Objeto de tipo Exception</param>
        public DniInvalidoException(string message, Exception e) : base(mensajeBase + message, e)
        {

        }
    }
}

