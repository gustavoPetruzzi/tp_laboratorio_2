using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalMoneda
{
    class Program
    {
        static void Main(string[] args)
        {
            Moneda miMoneda = new Moneda(Elado.Cara);
            miMoneda.ganar += new GanarTirada(Program.ganador);
            miMoneda.perder += new PerderTirada(Program.perdedor);
            miMoneda.Tirar();
            Console.ReadLine();
        }

        public static  void ganador()
        {
            Console.WriteLine("Ganaste");
        }
        public static void perdedor(Elado lado)
        {
            Console.WriteLine("Perdiste: " + lado);
        }
    }

}
