using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excepciones;
namespace EntidadesInstanciables
{
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

        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        #region Indexador
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
        #region Propiedades XML

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public List<Instructor> Instructores
        {
            get { return this._instructores; }
            set { this._instructores = value; }
        }

        public List<Jornada> Jornada
        {
            get { return this._jornada; }
            set { this._jornada = value; }
        }



        #endregion
        #region Sobrecargas

        public static Boolean operator ==(Gimnasio g, Alumno a)
        {
            Boolean retorno = false;
            if (!object.Equals(g, null) && !object.Equals(a, null))
            {
                foreach (Alumno alumno in g._alumnos)
                {
                    if ((EntidadesAbstractas.PersonaGimnasio) alumno == (EntidadesAbstractas.PersonaGimnasio) a)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        public static Boolean operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }


        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor instructor in g._instructores)
            {
                if (instructor == clase)
                    return instructor;
            }
            throw new SinInstructorException();

        }

                            // SI NO HAY NINGUN INSTRUCTOR QUE DEVUELVO?
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor instructor in g._instructores)
            {
                if (instructor != clase)
                    return instructor;
            }
            throw new SinInstructorException();
        }


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
        public static Boolean operator !=(Gimnasio g, Instructor I)
        {
            return !(g == I);
        }


        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            Boolean exist = false;
            if(!Object.Equals(g, null) && !object.Equals(a,null))
            {
                if (g == a)
                    throw new AlumnoRepetidoException();
                else
                    g._alumnos.Add(a);

            }
            return g;
        }
        

        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases clase)
        {
            if(!object.Equals(g, null) && !object.Equals(clase,null))
            {
                foreach (Instructor instructor in g._instructores)
                {
                    if (instructor == clase)
                    {
                        Jornada jornadaAgregar = new Jornada(clase, instructor);
                        for (int i = 0; i < g._alumnos.Count; i++)
                        {
                            if (g._alumnos[i] == clase)
                                jornadaAgregar += g._alumnos[i];
                        }
                        g._jornada.Add(jornadaAgregar);
                        break;
                    }
                    else
                        throw new SinInstructorException();
                }
            }
            return g;
        }


        public static Gimnasio operator +(Gimnasio g, Instructor I)
        {
            Boolean exist = false;
            if(!object.Equals(g,null) && !object.Equals(I,null))
            {
                foreach (Instructor instructor in g._instructores)
                {
                    if( instructor == I)
                    {
                        exist = true;
                        break;
                    }
                }
                if(!exist)
                    g._instructores.Add(I);
            }
            return g;
        }



        private static String MostrarDatos(Gimnasio gim)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("JORNADA:");
            foreach (Jornada jornada in gim._jornada)
            {
                retorno.AppendLine(jornada.ToString());
                retorno.AppendLine("<------------------------------------------>");
            }
            return retorno.ToString();
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        #endregion


        public static Boolean Guardar(Gimnasio gim)
        {
            Archivos.Xml < Gimnasio > miXml = new Archivos.Xml<Gimnasio>();
            try
            {
                String path = Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory) + "\\Gimnasio.xml";
                miXml.Guardar(path, gim);
                return true;
            }
            catch (Exception arc)
            {

                throw new Excepciones.ArchivoException(arc);
            }
        }

    }
}
