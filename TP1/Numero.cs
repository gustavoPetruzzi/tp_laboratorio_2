using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP1
{
    class Numero
    {
        private double _numero;

        #region Constructores
        /// <summary>
        /// inicializa la instancia del objeto, asignando 0 a su atributo
        /// </summary>
        public Numero() : this(0)
        {
        }

        /// <summary>
        /// inicializa la instancia del objeto, asignando lo pasado por parametro a su atributo
        /// </summary>
        /// <param name="numero">tipo de dato string a ser asignado al atributo del objeto (previa validacion)</param>
        public Numero(string numero)
        {
            setNumero(numero);
        }

        /// <summary>
        /// inicializa la instancia del objeto, asignando segun lo pasado por parametro a su atributo
        /// </summary>
        /// <param name="numero">tipo de dato double a ser asignado al atributo del objeto</param>
        public Numero(double numero)
        {
            this._numero = numero;
        }
        #endregion 

        /// <summary>
        /// El metodo me devuelve un dato de tipo double con el numero cargado
        /// </summary>
        /// <returns>Un dato de tipo double con el numero cargado en el objeto</returns>
        public double getNumero()
        {
            return this._numero;
        }


        /// <summary>
        /// El metodo asigna el parametro pasado al atributo _numero (validandolo antes)
        /// </summary>
        /// <param name="numero">tipo de dato string a asignar al atributo _numero</param>
        private void setNumero(string numero)
        {
            this._numero = Numero.validarNumero(numero);
        }

        /// <summary>
        /// El metodo valido que el string pasado por parametro sea un numero
        /// </summary>
        /// <param name="numeroString">tipo de dato string a ser validado</param>
        /// <returns>Devuelve el numero, si el string es un numero, sino 0</returns>
        private static double validarNumero(string numeroString)
        {
            double retorno= 0;
            double.TryParse(numeroString, out retorno);
            return retorno;
        }

    }
}
