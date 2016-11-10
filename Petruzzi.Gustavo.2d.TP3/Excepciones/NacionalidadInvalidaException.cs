using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor publico. Recibe un Objeto de tipo String que se pasa a la clase base.
        /// </summary>
        /// <param name="message">Objeto de tipo String</param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }


        /// <summary>
        /// Constructor publico.
        /// </summary>
        public NacionalidadInvalidaException():this("La nacionalidad no se condice con el numero de dni ")
        {

        }
    }
}
