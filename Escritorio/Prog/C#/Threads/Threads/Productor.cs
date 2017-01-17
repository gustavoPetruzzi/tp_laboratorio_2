using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    public class Productor
    {
        public int productos;
        public int cantidadMaxima;
        
        private Boolean _dormido;
        public Productor()
        {
            this.cantidadMaxima = 5;
            this._dormido = false;
        }
        public void generarProducto()
        {
            this._dormido = true;
            do
            {
                if (this.productos < this.cantidadMaxima)
                {
                    this.productos++;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("El productor ha agregado un producto");
                }
                if (this.productos == this.cantidadMaxima && !(this._dormido))
                {
                    Console.WriteLine("Se ha llegado a la cantidad maxima");
                    this._dormido = true;
                }
                Thread.Sleep(3001);
            } while (true);
        }
    }
}
