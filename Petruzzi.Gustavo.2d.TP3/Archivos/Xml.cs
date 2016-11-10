using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Implementacion del metodo Guardar de la interfaz IArchivo. Serializa un objeto de tipo T a XML
        /// </summary>
        /// <param name="archivo">Objeto de tipo String que indica donde se guarda</param>
        /// <param name="datos">Objeto de tipo T, que indica el Objeto que se va a serializar en xml</param>
        /// <returns>Devuelve true si pudo serializar o lanza una exception si no pudo serializar</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter xArchivo = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializado = new XmlSerializer(typeof(T));
                    serializado.Serialize(xArchivo, datos);
                    return true;
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }   
        }
        /// <summary>
        /// Implementacion del metodo Guardar de la interfaz IArchivo. Serializa un objeto de tipo T a XML
        /// </summary>
        /// <param name="archivo">Objeto de tipo String que indica donde se guarda</param>
        /// <param name="datos">Objeto de tipo out T, que indica donde Objeto se va a deserializar el xml</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader xArchivo = new XmlTextReader(archivo))
                {
                    XmlSerializer deserializado = new XmlSerializer(typeof(T));
                    datos = (T) deserializado.Deserialize(xArchivo);
                    return true;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
