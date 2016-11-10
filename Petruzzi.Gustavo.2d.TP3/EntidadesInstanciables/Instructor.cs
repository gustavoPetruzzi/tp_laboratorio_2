using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using System.Xml.Serialization;
namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #region Constructores
        /// <summary>
        /// Constructor Estatico. Inicializa el atributo estativo _random.
        /// </summary>
        
            
        static Instructor()
        {
            _random = new Random();
        }


        /// <summary>
        /// Constructor Publico. Inicializa el Queque de clases del gimnasio y le asigna 2 clases random
        /// </summary>
        /// <param name="id">Identificador del Instructor</param>
        /// <param name="nombre">Nombre del Instructor</param>
        /// <param name="apellido">Apellido del Instructor</param>
        /// <param name="dni">Dni del Instructor</param>
        /// <param name="nacionalidad">Nacionalidad del Instructor</param>
        public Instructor(int id, String nombre, String apellido, String dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
               
            this._randomClases();
            this._randomClases();
        }


        // CONSTRUCTOR SERIALIZAR
        /// <summary>
        /// Constructor por defecto utilizado para serializar xml
        /// </summary>
        public Instructor()
        {
            
        }
        #endregion


        /// <summary>
        /// Metodo privado que asigna 2 clases al Queue de clases
        /// </summary>
        private void _randomClases()
        {
            int numero = _random.Next(0, 4);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)numero);
        }


        #region Sobrecarga
        /// <summary>
        /// Reescribe el metodo MostrarDatos() para que devuelve los datos de la clase base y ademas las clases que 
        /// da el instructor.
        /// </summary>
        /// <returns>Devuelve un String con los datos de la clase base y las clases del instructor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.MostrarDatos());
            retorno.Append(this.ParticiparEnClase());
            return retorno.ToString();

        }
        /// <summary>
        /// Reescribe el metodo ParticiparEnClase().
        /// </summary>
        /// <returns>Devuelve un String con las clases que da el instructor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            if (this._clasesDelDia != null)
            {
                retorno.AppendLine("CLASE DEL DIA: ");
                foreach (Gimnasio.EClases clase in this._clasesDelDia)
                {
                    retorno.AppendLine(clase.ToString());
                }
            }
            return retorno.ToString();
        }


        /// <summary>
        /// Reescribe el metodo ToString().
        /// </summary>
        /// <returns>Devuelve un String con los datos del Instructor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Compara un Instructor con una clase
        /// </summary>
        /// <param name="I">Objeto de tipo Instructor</param>
        /// <param name="clase">Enumerado de tipo EClases</param>
        /// <returns>Devuelve true si el Instructor da la clase.</returns>
        public static Boolean operator == (Instructor I, Gimnasio.EClases clase)
        {
            Boolean retorno = false;
            if(!object.Equals(I,null) && !object.Equals(clase, null))
            {
                foreach (Gimnasio.EClases Eclase in I._clasesDelDia)
                {
                    if(Eclase == clase)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }

        public static Boolean operator !=(Instructor I, Gimnasio.EClases clase)
        {
            return !(I == clase);
        }
        #endregion

       
        


    }
}
