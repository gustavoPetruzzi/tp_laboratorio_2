using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace programacion
{
    class Program
    {
        static void Main(string[] args)
        {
            claseInt prueba = new claseInt();
            ((ExpInterface)prueba).prueba();
            xmlSerializar<Persona> serializaPersona = new xmlSerializar<Persona>(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "//archivo.xml");
            Persona unaPersona = new Persona("juan", "perez");
            serializaPersona.Guardar(unaPersona);


        }
    }
}
