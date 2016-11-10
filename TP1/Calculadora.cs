using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace TP1
{
    class Calculadora
    {
        
        /// <summary>
        /// Realiza la operacion matematica segun el parametro operador, utilizando
        /// los 2 parametros de tipo Numero como operandos
        /// </summary>
        /// <param name="numero1">Primer operando de tipo Numero</param>
        /// <param name="numero2">Segundo operando de tipo Numero</param>
        /// <param name="operador">Operador en el cual se basa la operacion</param>
        /// <returns></returns>
        public static double Operar(Numero numero1, Numero numero2, string operador)
        {
            double retorno = 0;
            
            switch (ValidarOperador(operador))
            {
                case "-":
                    retorno = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    retorno = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() == 0)
                        retorno = 0;
                    else
                        retorno = numero1.getNumero() / numero2.getNumero();
                    break;
                default:                                
                    retorno = numero1.getNumero() + numero2.getNumero();
                    break;                             
            }
            return retorno;
        }

        /// <summary>
        /// Valida el tipo de dato String pasado por parametro
        /// </summary>
        /// <param name="operador">Recibe un tipo de dato String a validar</param>
        /// <returns> Devuelve el operador validado en tipo String</returns>
        public static string ValidarOperador(string operador)
        {
            string retorno;
            switch (operador)
            {
                case "+":
                    retorno = "+";
                    break;
                case "-":
                    retorno = "-";
                    break;
                case "*":
                    retorno = "*";
                    break;
                case "/":
                    retorno = "/";
                    break;
                default:
                    retorno = "+";
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// El metodo se encarga de poner como estaba al principio los parametros pasados por parametro
        /// </summary>
        /// <param name="numero1"> tipo de dato TextBox a ser puesto como el valor del principio</param>
        /// <param name="numero2">tipo de dato TextBox a ser puesto como el valor del principio</param>
        /// <param name="operacion"> tipo de dato ComboBox a ser puesto como el valor del principio</param>
        /// <param name="resultado"> tipo de dato Label a ser puesto como el valor del principio</param>
        public static void Limpiar( TextBox numero1,  TextBox numero2,  ComboBox operacion,   Label resultado)
        {
            numero1.Text = "";
            numero2.Text = "";
            operacion.Text = "";
            resultado.Text = "";


        }
    }
}
