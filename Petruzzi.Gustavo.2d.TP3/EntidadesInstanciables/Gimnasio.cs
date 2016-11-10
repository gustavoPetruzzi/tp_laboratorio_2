using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
namespace EntidadesInstanciables
{
    [Serializable]
    public class Gimnasio
    {

        public enum EClases
        {                     
            Natacion,
            Pilates,
            CrossFit,
            Yoga
        }





        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;
        #region Constructores
        /// <summary>
        /// Constructor publico. Inicializa la lista de alumnos, instructores y jornadas.
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion
        #region Indexador
        /// <summary>
        /// Indexador de la lista de jornadas
        /// </summary>
        /// <param name="jornada">indice de la lista jornada</param>
        /// <returns>Devuelve una jornada segun el parametro pasado</returns>
        public Jornada this[int jornada]
        {            
            get
            {
                if (this._jornada.Count > jornada && jornada >= 0)
                {
                    return this._jornada[jornada];
                }
                else
                    return null;
            }
        }

        #endregion
        #region Propiedades 
        /// <summary>
        /// Lista de alumnos del gimnasio
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            
        }
        /// <summary>
        /// Lista de instructores del gimnasio
        /// </summary>
        public List<Instructor> Instructores
        {
            get { return this._instructores; }
            
        }
        /// <summary>
        /// Lista de jornadas del gimnasio
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this._jornada; }
            
        }



        #endregion
        #region Sobrecargas
        /// <summary>
        /// Compara un gimnasio y un alumno
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Devuelve True si son del mismo tipo y si su dni o identificador son el mismo</returns>
        public static Boolean operator ==(Gimnasio g, Alumno a)
        {
            Boolean retorno = false;
            if (!object.Equals(g, null) && !object.Equals(a, null))
            {
                foreach (Alumno alumno in g._alumnos)
                {
                    if ( alumno ==  a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        /// <summary>
        /// Compara un Gimnasio con un Alumno
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Devuelve true si no son del mismo tipo o si su dni o identificador no son el mismo</returns>
        public static Boolean operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara un objeto de tipo gimnasio y un enumerado de tipo EClases
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio</param>
        /// <param name="clase">Enumerado de tipo EClases</param>
        /// <returns>
        /// Devuelve un Instructor si el Objeto gimnasio posee un Instructor 
        /// que tenga una Eclase pasada por parametro, sino lanza una exception
        /// de tipo SinInstructorException.
        /// </returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            if(!object.Equals(g,null) && !object.Equals(clase, null))
            {
                foreach (Instructor instructor in g._instructores)
                {
                    if (instructor == clase)
                        return instructor;
                }
            }
            throw new SinInstructorException();

        }
        
        
        /// <summary>
        /// Compara un objeto de tipo Gimnasio con uno de tipo clase
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio</param>
        /// <param name="clase">Enumerado de tipo EClases</param>
        /// <returns>
        /// Devuelve el primer instructor que no tenga la clase pasada por parametro, 
        /// sino devuelve una exception del tipo SinInstructorException
        /// </returns>
                                                
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            if (!object.Equals(g, null) && !object.Equals(clase, null))
            {
                foreach (Instructor instructor in g._instructores)
                {
                    if (instructor != clase)
                        return instructor;
                }
            }
            throw new SinInstructorException();
        }

        /// <summary>
        /// Compara un gimnasio con un instructor
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio </param>
        /// <param name="I">Objeto de tipo Instructor</param>
        /// <returns>Devuelve true ya existe un instructor cargado en el gimnasio con el mismo id o dni</returns>
        public static Boolean operator ==(Gimnasio g, Instructor I)
        {
            Boolean retorno = false;
            if(!object.Equals(g,null) && !object.Equals(I, null))
            {
                foreach (Instructor instructor in g._instructores)
                {
                    if(instructor == I)
                    {
                        retorno = true;
                        break;
                    }   
                }
            }
            return retorno;
        }
        /// <summary>
        /// Compara un gimnasio con un instructor
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio </param>
        /// <param name="I">Objeto de tipo Instructor</param>
        /// <returns> Devuelve true si no existe un instructor cargado en el gimnasio con el mismo id o dni</returns>
        public static Boolean operator !=(Gimnasio g, Instructor I)
        {
            return !(g == I);
        }

        /// <summary>
        /// Agrega un alumno al listado de alumnos.
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Devuelve un gimnasio. Si el alumno no estaba cargado, lo agrega.</returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            
            if(!Object.Equals(g, null) && !object.Equals(a,null))
            {
                if (g == a)
                    throw new AlumnoRepetidoException();
                else
                    g._alumnos.Add(a);

            }
            return g;
        }
        
        /// <summary>
        /// Agrega una jornada con la clase al gimnasio si no existe una clase de ese tipo en el gimnasio 
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio</param>
        /// <param name="clase">Enumerado de tipo EClases</param>
        /// <returns>Devuelve el gimnasio pasado por parametro</returns>
        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases clase)
        {
            if(!object.Equals(g, null) && !object.Equals(clase,null))
            {
                Instructor instructor = (g == clase);
                if (instructor != null)
                {
                    Jornada jornadaAgregar = new Jornada(clase, instructor);
                    for (int i = 0; i < g._alumnos.Count; i++)
                    {
                        if (g._alumnos[i] == clase)
                            jornadaAgregar += g._alumnos[i];
                    }
                    g._jornada.Add(jornadaAgregar);
                }

            }
            return g;
        }

        /// <summary>
        /// Agrega un instructor al gimnasio si no se encuentra en la lista de instructores
        /// </summary>
        /// <param name="g">Objeto de tipo Gimnasio</param>
        /// <param name="I">Objeto de tipo Instructor</param>
        /// <returns>Devuelve el Objeto de tipo Gimnasio pasado por parametro</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor I)
        {
            
            if(!object.Equals(g,null) && !object.Equals(I,null))
            {
                if (g != I)
                {
                    g._instructores.Add(I);
                }
            }
            return g;
        }


        /// <summary>
        /// Metodo estatico privado. Muestra los datos del gimnasio
        /// </summary>
        /// <param name="gim">Objeto de tipo Gimnasio</param>
        /// <returns>Devuelve un String con los datos del Gimnasio</returns>
        private static String MostrarDatos(Gimnasio gim)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("JORNADA:");
            foreach (Jornada jornada in gim._jornada)
            {
                retorno.AppendLine(jornada.ToString());
            }
            return retorno.ToString();
        }
        /// <summary>
        /// Reescribe el metodo ToString() para devolver los datos del gimnasio
        /// </summary>
        /// <returns>Devuelve un String con los datos del gimnasio</returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        #endregion
        #region Metodos Escritura/Lectura
        /// <summary>
        /// Metodo estatico que serializa el objeto gim en formato XML
        /// </summary>
        /// <param name="gim">Objeto de tipo Gimnasio</param>
        /// <returns>Devuelve True si pudo serializar, sino lanza una excepcion de tipo ArchivoException</returns>
        public static Boolean Guardar(Gimnasio gim)
        {
            Archivos.Xml < Gimnasio > miXml = new Archivos.Xml<Gimnasio>();
            try
            {
                String path = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory) + "\\Gimnasio.xml";
                miXml.Guardar(path, gim);
                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }

        /// <summary>
        /// Metodo estatico que deserializa un objeto de tipo Gimnasio en formato xml.
        /// </summary>
        /// <param name="gim">Objeto de tipo Gimnasio.</param>
        /// <returns>Devuelve true si pudo serializar.</returns>
        public static Boolean Leer(out Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> miXml = new Archivos.Xml<Gimnasio>();
            try
            {
                String path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Gimnasio.xml";
                miXml.Leer(path, out gim);
                return true;
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
        }
        #endregion
    }
}
