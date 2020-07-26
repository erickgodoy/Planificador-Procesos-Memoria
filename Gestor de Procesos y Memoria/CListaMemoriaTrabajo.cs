using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestor_de_Procesos_y_Memoria
{
    class CListaMemoriaTrabajo
    {
        private CNodoMemoriaTrabajo cabeza;
        private CNodoMemoriaTrabajo aux;
        public CListaMemoriaTrabajo()
        {
            cabeza = new CNodoMemoriaTrabajo();
            cabeza.Siguiente = null;
            cabeza.COM = true;
        }
        public void Insertar(int numero, int tamaño, double tiempo, double tll)
        {
            aux = cabeza;

            while (aux.Siguiente != null)
            {
                aux = aux.Siguiente;
            }

            CNodoMemoriaTrabajo temp = new CNodoMemoriaTrabajo();

            temp.NUM = numero;
            temp.TAMAÑO = tamaño;
            temp.TIEMPO = tiempo;
            temp.TLL = tll;

            temp.COM = false;
            temp.Siguiente = null;

            aux.Siguiente = temp;
        }

        public void FCFS_PA(CListaMemoria lMemoria)
        {
            aux = cabeza.Siguiente;
            CNodoMemoria node;
            while (aux != null)
            {
                node = lMemoria.RetInicio();
                while (aux.TAMAÑO > node.VAL)
                {
                    node = node.Siguiente;
                }
                node.TIEMPO += aux.TIEMPO;
                aux.TF = node.TIEMPO;
                aux.TR = aux.TF - aux.TLL;
                aux.COM = true;

                aux = aux.Siguiente;
            }
        }

        public int TotalNodos()
        {
            int cont = 0;
            aux = cabeza.Siguiente;
            while (aux != null)
            {
                cont++;
                aux = aux.Siguiente;
            }

            return cont;
        }

        public int ObtTrabajo(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.NUM;
        }

        public double ObtTLL(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TLL;
        }

        public double ObtTF(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TF;
        }

        public double ObtTR(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TR;
        }

    }
}
