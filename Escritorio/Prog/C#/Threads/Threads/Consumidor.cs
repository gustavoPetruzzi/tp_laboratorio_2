using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Threads
{
    public class Consumidor
    {
        Productor _productor;
        public Consumidor(Productor productor)
        {
            this._productor = productor;
        }

        public void consumir()
        {
            do
            {
                if (this._productor.productos > 0)
                {
                    this._productor.productos--;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Se ha consumido un producto");
                    
                }
                System.Threading.Thread.Sleep(1502);
            } while (true);
        }
    }
}
