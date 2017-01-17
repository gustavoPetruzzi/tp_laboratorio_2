using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceExp
{
    class Program
    {
        static void Main(string[] args)
        {
            claseInt interfeis = new claseInt();
            if(((ExpInterface)interfeis).algo)
                Console.WriteLine("hola");
            Console.ReadKey();

        }
    }
}
