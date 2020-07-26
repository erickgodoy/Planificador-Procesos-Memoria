using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestor_de_Procesos_y_Memoria
{
    class CNodoProceso
    {
        private string nombreProceso;
        private int tll;
        private int tEjec;
        private int ti;
        private int tf;
        private int tr;
        private int te;

        private bool completado;
        private int tEjecAux;

        private CNodoProceso siguiente = null;
        private CNodoProceso anterior = null;

        public string NPROCESO { get => nombreProceso; set => nombreProceso = value; }
        public int TLL { get => tll; set => tll = value; }
        public int TEJEC { get => tEjec; set => tEjec = value; }
        public int TI { get => ti; set => ti = value; }
        public int TF { get => tf; set => tf = value; }
        public int TR { get => tr; set => tr = value; }
        public int TE { get => te; set => te = value; }

        public bool COM { get => completado; set => completado = value; }
        public int TEJAUX { get => tEjecAux; set => tEjecAux = value; }

        internal CNodoProceso Siguiente { get => siguiente; set => siguiente = value; }
        internal CNodoProceso Anterior { get => anterior; set => anterior = value; }

    }
}
