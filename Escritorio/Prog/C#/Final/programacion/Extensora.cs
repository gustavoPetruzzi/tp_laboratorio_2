using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace programacion
{
    public static class Extensora
    {
        public static string NombrePersona(this Persona p)
        {
            return p.nombre;
        }
    }
}
