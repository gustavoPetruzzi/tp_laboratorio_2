using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using Archivos;
namespace EntidadesInstanciables
{
    public class Jornada
    {
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        private List<Alumno> _alumnos;

        #region Constructores
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion
        
        #region Sobrecarga
        // ME IMPORTA EL ESTADO DE LA CUENTA DEL ALUMNO?
        public static Boolean operator ==(Jornada j, Alumno a)
        {
            Boolean retorno = false;
            if (!object.Equals(j, null) && !object.Equals(a, null))
            {
                foreach (PersonaGimnasio alumno in j._alumnos)
                {
                    if (alumno == a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }

            return retorno;
        }
        public static Boolean operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append("CLASE DE " + this._clase + " POR ");
            retorno.AppendLine(this._instructor.ToString());
            retorno.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this._alumnos)
            {
                retorno.Append(alumno.ToString());
            }
            return retorno.ToString();
        }
        #endregion
        public static Boolean Guardar(Jornada jornada)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\archivo.txt";
            Texto texto = new Texto();
            try
            {
                texto.Guardar(ruta, jornada.ToString());
                return true;
            }
            catch (Excepciones.ArchivoException archExc)
            {
                throw new Excepciones.ArchivoException(archExc);
            }
        }
        #region Propiedades xml
       
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Gimnasio.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        
        public Instructor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        

        


        #endregion
    }
}

