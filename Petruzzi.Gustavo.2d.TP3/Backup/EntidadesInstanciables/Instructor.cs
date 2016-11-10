using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
//para serializar
using System.Xml.Serialization;
namespace EntidadesInstanciables
{
    public class Instructor : PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;
        #region Constructores

        static Instructor()
        {
            _random = new Random();
        }

        public Instructor(int id, String nombre, String apellido, String dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
            this._randomClases();
        }
        // CONSTRUCTOR SERIALIZAR
        public Instructor()
        {

        }
        #endregion

        private void _randomClases()
        {
            int numero = _random.Next(0, 2);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)numero);
        }
        #region Sobrecarga
        protected override string MostrarDatos()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Append(base.MostrarDatos());
            retorno.Append(this.ParticiparEnClase());
            return retorno.ToString();

        }

        protected override string ParticiparEnClase()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("CLASE DEL DIA: ");
            foreach (Gimnasio.EClases clase in this._clasesDelDia)
            {
                retorno.AppendLine(clase.ToString());
            }
            return retorno.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

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

        #region Propiedades XML
        
        //[XmlArray]
        //public List<Gimnasio.EClases> ClasesDelDia
        //{
        //    get { return this.queueToList(this._clasesDelDia); }
        //    set { this._clasesDelDia = this.listToQueue( value); }
        //}
        #endregion
        #region Metodos XML
        private List<Gimnasio.EClases> queueToList(Queue<Gimnasio.EClases> queue)
        {
            List<Gimnasio.EClases> retorno = null;
            if(!object.Equals(queue,null))
            {
                retorno = new List<Gimnasio.EClases>(queue);
                
            }
            return retorno;
        }
        private Queue<Gimnasio.EClases> listToQueue(List<Gimnasio.EClases> list)
        {
            return new Queue<Gimnasio.EClases>(list);
        }
        #endregion


    }
}
