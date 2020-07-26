using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestor_de_Procesos_y_Memoria
{
    class CNodoMemoriaTrabajo
    {
        private int numero;
        private int tamaño;
        private double tiempo;

        private double tll;
        private double tf;
        private double tr;

        private bool com;

        private CNodoMemoriaTrabajo siguiente = null;

        public int NUM { get => numero; set => numero = value; }
        public int TAMAÑO { get => tamaño; set => tamaño = value; }
        public double TIEMPO { get => tiempo; set => tiempo = value; }
        public double TLL { get => tll; set => tll = value; }
        public double TF { get => tf; set => tf = value; }
        public double TR { get => tr; set => tr = value; }
        public bool COM { get => com; set => com = value; }

        internal CNodoMemoriaTrabajo Siguiente { get => siguiente; set => siguiente = value; }
    }
}
