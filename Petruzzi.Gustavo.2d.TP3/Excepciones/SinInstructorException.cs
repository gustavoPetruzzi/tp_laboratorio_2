using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class SinInstructorException: Exception
    {
        /// <summary>
        /// Constructor publico.
        /// </summary>
        public SinInstructorException():base("No hay instructor para esa clase")
        {
            
        }
    }
}
