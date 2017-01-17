using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace programacion
{
    public class MiException : Exception
    {
        private static String _mensaje;
        static MiException()
        {
            _mensaje = "ERROR ";
        }

        public MiException(String message, Exception inner): base(_mensaje + message, inner)
        {
        }

        public MiException(Exception inner)
            : this("", inner)
        {
        }
        public MiException(string message)
            : this(message, null)
        {
        }
        public MiException()
            : this("")
        {
        }
    }
}
