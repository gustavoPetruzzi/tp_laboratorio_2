using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class ArchivosException: Exception
    {
        /// <summary>
        /// Constructor publico de tipo ArchivoException. Recibe un objeto de tipo exception que se pasa como 
        /// parametro de la clase base para ser pasado como inner Exception.
        /// </summary>
        /// <param name="innerException">Objeto de tipo Exception.</param>
        public ArchivosException(Exception innerException):base("No se pudo guardar el archivo",innerException)
        {

        }
    }
}
