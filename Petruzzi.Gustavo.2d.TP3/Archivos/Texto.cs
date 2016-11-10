using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        /// <summary>
        /// Implementacion del metodo Guardar de la Interfaz IArchivo. Guarda un achivo en formato de texto
        /// </summary>
        /// <param name="archivo">Objeto de tipo String que indica donde se guarda</param>
        /// <param name="datos">Objeto de tipo String que indica lo que se va a guardar</param>
        /// <returns>Devuelve true si pudo guardar o lanza una excepcion de tipo ArchivoException</returns>
        public bool Guardar(string archivo, string datos)
        {
            
            if(File.Exists(archivo))
            {
                try
                {
                    using (StreamWriter sArchivo = new StreamWriter(archivo, true))
                    {
                        sArchivo.WriteLine(datos.ToString());
                    }
                    return true; 
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sArchivo = new StreamWriter(archivo))
                    {
                        sArchivo.WriteLine(datos.ToString());
                    }
                    return true;

                }
                catch (Exception e)
                {

                    throw e;
                }
            }
            
        }


        /// <summary>
        /// Implementacion del metodo Guardar de la Interfaz IArchivo. Lee un archivo en formato de texto
        /// </summary>
        /// <param name="archivo">Objeto de tipo String que indica de donde se lee</param>
        /// <param name="datos">Objeto de tipo out String donde se guarda lo leido</param>
        /// <returns>Devuelve true si pudo leer o lanza una exception de tipo ArchivoException sino.</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader aLeer = new StreamReader(archivo))
                {
                    datos = aLeer.ReadToEnd();
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
