using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Common
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Archivo.txt";
            using (StreamWriter archivo = new StreamWriter(path, true))
            {
                
                StreamReader a = new StreamReader();
                
                archivo.WriteLine("Puto el que lee");
            }

        }
    }
}
