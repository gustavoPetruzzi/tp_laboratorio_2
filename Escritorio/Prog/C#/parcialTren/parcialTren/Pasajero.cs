using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace parcialTren
{
    public class Pasajero
    {
        public enum Rangos
        {
            Azafata,
            Cocinero,
            Maquinista,
            Cliente
        }

        public String Apellido;
        public String Nombre;
        public Rangos Rango;

        public Pasajero(String nombre, String Apellido, Rangos rango)
        {
            this.Nombre = nombre;
            this.Apellido = Apellido;
            this.Rango = rango;
        }




        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine("Nombre: " + this.Nombre);
            retorno.AppendLine("Apellido: " + this.Apellido);
            retorno.AppendLine("Rango: " + this.Rango);
            return retorno.ToString();
        }

    }
}
