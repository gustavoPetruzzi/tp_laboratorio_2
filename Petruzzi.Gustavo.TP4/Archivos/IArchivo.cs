using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo a ser implementado por la clase que implemente IArchivo. Guarda lo pasado por parametro.
        /// </summary>
        /// <param name="datos">Datos de tipo genericos a ser guardado en el archivo</param>
        /// <returns>Devuelve un booleano si pudo guardar.</returns>
        bool guardar(T datos);

        /// <summary>
        /// Metodo a ser implementado por la clase que implemente IArchivo. Lee y lo guarda en una lista.
        /// </summary>
        /// <param name="datos">Lista de tipo genericos que es devuelto si pudo leer</param>
        /// <returns>Devuelve un booleano si pudo leer el archivo.</returns>
        bool leer(out List<T> datos);
    }
}
