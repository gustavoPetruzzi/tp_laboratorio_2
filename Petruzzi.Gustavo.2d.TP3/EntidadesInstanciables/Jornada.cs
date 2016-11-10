using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        private List<Alumno> _alumnos;

        #region Constructores
        /// <summary>
        /// Constructor por defecto. Inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor publico.
        /// </summary>
        /// <param name="clase"> Enumerado de tipo Gimnasio.EClases</param>
        /// <param name="instructor">Objeto de tipo Instructor</param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        
        #endregion
        

        #region Sobrecarga

        /// <summary>
        /// Sobrecarga ==. Compara un objeto tipo Jornada con uno tipo Alumno
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Devuelve true si se encuentra el alumno en la jornada </returns>
        public static Boolean operator ==(Jornada j, Alumno a)
        {
            Boolean retorno = false;
            if (!object.Equals(j, null) && !object.Equals(a, null))
            {
                foreach (Alumno alumno in j._alumnos)
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


        /// <summary>
        /// Sobrecarga !=. Compara un Objeto de tipo Jornada con uno de tipo Alumno
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Devuelve true si no se encuentra el alumno en la jornada</returns>
        public static Boolean operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }


        /// <summary>
        /// Sobrecarga +. Agrega un objeto de tipo Alumno a un objeto de tipo Jornada
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Devuelve una Jornada </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }
        /// <summary>
        /// Sobrecarga del metodo toString()
        /// </summary>
        /// <returns>Devuelve un String con todos los datos del Objeto Jornada actual</returns>
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
            retorno.AppendLine("<------------------------------------------>");
            return retorno.ToString();
        }


        #endregion
        #region Metodos Escritura/lectura texto

        /// <summary>
        /// Metodo Estatico.Guarda los datos de una jornada en un archivo txt
        /// </summary>
        /// <param name="jornada">Objeto de tipo Jornada</param>
        /// <returns>Devuelve True si logra serializar, sino lanza una excepcion</returns>
        public static Boolean Guardar(Jornada jornada)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
            Texto texto = new Texto();
            try
            {
                texto.Guardar(ruta, jornada.ToString());
                return true;
            }
            catch (Exception Exc)
            {
                throw new Excepciones.ArchivosException(Exc);
            }
        }


        /// <summary>
        /// Lee un archivo txt y lo imprime por pantalla
        /// </summary>
        /// <param name="datos">Objeto de tipo String</param>
        /// <returns>Devuelve true si pudo leer el archivo, lanza una excepcion si no lo pudo leer</returns>
        public static Boolean Leer(out String datos)
        {
            String ruta = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Jornada.txt";
            Texto texto = new Texto();
            try
            {
                texto.Leer(ruta, out datos);
                return true;
            }
            catch (Exception exc)
            {
                datos = "";
                throw new Excepciones.ArchivosException(exc); 
            }
        }
        #endregion


        #region Propiedades 
        /// <summary>
        /// Lista de alumnos cargados en la jornada
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            //set { this._alumnos = value; }
        }


        /// <summary>
        /// Clase de la jornada
        /// </summary>
        public Gimnasio.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        /// <summary>
        /// Instructor de la jornada
        /// </summary>
        public Instructor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        

        


        #endregion
    }
}

