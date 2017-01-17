using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalMoneda
{
    public delegate void GanarTirada();
    public delegate void PerderTirada(Elado lado);

    public enum Elado
    {
        Cara,
        Cruz
    }
    public class Moneda
    {
        private Elado _ladoElegido;
        private static Random _alea;
        static Moneda()
        {
            _alea = new Random();
        }

        public event GanarTirada ganar;
        public event PerderTirada perder;

        public Moneda(Elado lado)
        {
            this._ladoElegido = lado;
        }

        public void Tirar()
        {
            Elado ladoTirado = (Elado)_alea.Next(0, 2);
            if (ladoTirado == this._ladoElegido)
                this.ganar();
            else
                this.perder(ladoTirado);
        }

    }
}
