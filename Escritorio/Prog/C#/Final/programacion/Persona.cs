using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace programacion
{
    public class Persona
    {
        public String nombre;
        public String apellido;

        public Persona(String nombre, String apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            
        }

        public Persona()
        {
        }
        public static Boolean operator ==(Persona pers1, Persona pers2)
        {
            if (!object.Equals(pers1, null) && !object.Equals(pers2, null) && pers1.apellido == pers2.apellido)
                return true;
            return false;
        }
        public static Boolean operator !=(Persona pers1, Persona pers2)
        {
            return !(pers1 == pers2);
        }

        public static explicit operator String(Persona p)
        {
            return p.nombre;
        }

    }
}
