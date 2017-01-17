using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
namespace programacion
{
    public class xmlSerializar<T>
    {
        private string _path;

        public xmlSerializar(string path)
        {
            this._path = path;
        }

        public Boolean Guardar(T datos)
        {
            try
            {
                using (XmlTextWriter xArchivo = new XmlTextWriter(this._path, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(xArchivo, datos);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
