using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClaseMoneda.cs
{
    public enum Elado
    {
        Cara,
        Cruz
    }
    public delegate void ganarMoneda();
    public delegate void PerderMoneda(Elado lado);

    public class Moneda
    {
        protected Elado _ladoElegido;
        private static Random _ladoTirado;

        public event ganarMoneda ganar;
        public event PerderMoneda perder;
        static Moneda()
        {
            _ladoTirado = new Random();
        }

        public Moneda(Elado lado)
        {
            this._ladoElegido = lado;
        }

        public void Tirar()
        {
            Elado lado = (Elado)_ladoTirado.Next(0, 2);
            if (this._ladoElegido == lado)
                this.ganar();
            else
                this.perder(lado);
        }


    }
}
