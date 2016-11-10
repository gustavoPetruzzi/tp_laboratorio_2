using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor por defecto de AlumnoRepetidoException.
        /// </summary>
        public AlumnoRepetidoException():base("Alumno repetido")
        {

        }
    }
}
