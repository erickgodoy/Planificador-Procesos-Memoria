using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestor_de_Procesos_y_Memoria
{
    class CNodoMemoria
    {
        private int numero;
        private int valor;
        private double tiempo;

        private bool com;

        private CNodoMemoria siguiente = null;

        public int NUM { get => numero; set => numero = value; }
        public int VAL { get => valor; set => valor = value; }
        public double TIEMPO { get => tiempo; set => tiempo = value; }
        public bool COM { get => com; set => com = value; }

        internal CNodoMemoria Siguiente { get => siguiente; set => siguiente = value; }
    }
}
