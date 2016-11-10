using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivos
{
    public interface IArchivo<T>
    {
        Boolean Guardar(String archivo, T datos);
        Boolean Leer(String archivo, out T datos);
    }
}
