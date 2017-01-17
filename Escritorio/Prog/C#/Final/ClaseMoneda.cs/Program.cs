using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseMoneda.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Moneda miMoneda = new Moneda(Elado.Cara);
            miMoneda.ganar += new ganarMoneda(Program.Ganador);
            miMoneda.perder += new PerderMoneda(Program.Perdedor);
            miMoneda.Tirar();
            Console.ReadLine();
        }
        public static void Ganador()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GANASTE!");
        }
        public static void Perdedor(Elado lado)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PERDISTE");
            Console.Write("Salio: " + lado);
        }
    }
}
