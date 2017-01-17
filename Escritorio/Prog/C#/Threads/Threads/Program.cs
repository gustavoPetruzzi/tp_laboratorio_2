using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Productor miProductor = new Productor();
            Consumidor miConsumidor = new Consumidor(miProductor);
            Thread hiloProductor = new Thread(miProductor.generarProducto);
            Thread hiloConsumidor = new Thread(miConsumidor.consumir);
            hiloProductor.Start();
            
            Console.ReadKey(true);
            hiloConsumidor.Start();

        }
    }
}
