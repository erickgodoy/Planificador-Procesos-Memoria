using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestor_de_Procesos_y_Memoria
{
    class CListaMemoria
    {
        private CNodoMemoria cabeza;
        private CNodoMemoria aux;
        public CListaMemoria()
        {
            cabeza = new CNodoMemoria();
            cabeza.Siguiente = null;
            cabeza.COM = true;
        }
        public void Insertar(int numero, int valor, double tiempo)
        {
            aux = cabeza;

            while (aux.Siguiente != null)
            {
                aux = aux.Siguiente;
            }

            CNodoMemoria temp = new CNodoMemoria();

            temp.NUM = numero;
            temp.VAL = valor;
            temp.TIEMPO = tiempo;

            temp.COM = false;

            temp.Siguiente = null;

            aux.Siguiente = temp;
        }

        public CNodoMemoria RetInicio()
        {
            return cabeza.Siguiente;
        }
    }
}
