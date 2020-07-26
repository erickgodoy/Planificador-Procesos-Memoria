using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestor_de_Procesos_y_Memoria
{
    class CListaProceso
    {
        private CNodoProceso cabeza;

        private CNodoProceso aux;
        private CNodoProceso aux2;

        public CListaProceso()
        {
            cabeza = new CNodoProceso();
            cabeza.Siguiente = null;
            cabeza.Anterior = null;
            cabeza.COM = true;
        }

        public void Insertar(string nombre, int tlleg, int tejec)
        {
            aux = cabeza;

            while (aux.Siguiente != null)
            {
                aux = aux.Siguiente;
            }

            CNodoProceso temp = new CNodoProceso();

            temp.NPROCESO = nombre;
            temp.TLL = tlleg;
            temp.TEJEC = tejec;

            temp.COM = false;
            temp.TEJAUX = temp.TEJEC;

            temp.Siguiente = null;

            aux.Siguiente = temp;
            temp.Anterior = aux;
        }
        public void Eliminar()
        {
            if (cabeza.Siguiente != null)
            {
                cabeza = cabeza.Siguiente;
                cabeza.Anterior = null;
            }
        }

        public void Ordenar()
        {
            aux = cabeza.Siguiente;
            CNodoProceso temp = new CNodoProceso();

            while (aux.Siguiente != null)
            {
                aux2 = aux.Siguiente;
                while (aux2 != null)
                {
                    if (aux.TLL > aux2.TLL)
                    {
                        temp.NPROCESO = aux.NPROCESO;
                        temp.TLL = aux.TLL;
                        temp.TEJEC = aux.TEJEC;
                        temp.TI = aux.TI;
                        temp.TF = aux.TF;
                        temp.TR = aux.TR;
                        temp.TE = aux.TE;

                        aux.NPROCESO = aux2.NPROCESO;
                        aux.TLL = aux2.TLL;
                        aux.TEJEC = aux2.TEJEC;
                        aux.TI = aux2.TI;
                        aux.TF = aux2.TF;
                        aux.TR = aux2.TR;
                        aux.TE = aux2.TE;

                        aux2.NPROCESO = temp.NPROCESO;
                        aux2.TLL = temp.TLL;
                        aux2.TEJEC = temp.TEJEC;
                        aux2.TI = temp.TI;
                        aux2.TF = temp.TF;
                        aux2.TR = temp.TR;
                        aux2.TE = temp.TE;
                    }
                    aux2 = aux2.Siguiente;
                }
                aux = aux.Siguiente;
            }
        }


        public int SumTEjec()
        {
            int sum = 0;
            aux = cabeza.Siguiente;

            while (aux != null)
            {
                sum = sum + aux.TEJEC;
                aux = aux.Siguiente;
            }

            return sum;
        }
        public int TotalNodos()
        {
            int total = 0;
            aux = cabeza;
            while (aux != null)
            {
                total = total + 1;
                aux = aux.Siguiente;
            }
            return total;
        }
        public void FCFS()
        {
            int n = 0;
            int total = SumTEjec();

            aux = cabeza;

            while (aux != null)
            {
                aux.TI = n;
                n = n + aux.TEJEC;
                aux.TF = n;
                aux.TR = aux.TF - aux.TLL;
                aux.TE = aux.TI - aux.TLL;
                aux = aux.Siguiente;
            }
        }

        public void SPN()
        {
            int n = 0;
            aux = cabeza.Siguiente;
            aux.TI = n;
            n = n + aux.TEJEC;
            aux.TF = n;
            aux.TR = aux.TF - aux.TLL;
            aux.TE = aux.TI - aux.TLL;
            aux.COM = true;
            int min;
            CNodoProceso tmp = new CNodoProceso();
            int totalS = TotalNodos();
            totalS -= 2;
            for (int i = 0; i < totalS; i++)
            {
                aux2 = cabeza.Siguiente;
                while (aux2.COM == true)
                {
                    aux2 = aux2.Siguiente;
                }
                min = aux2.TEJEC;
                tmp = aux2;
                while (aux2.Siguiente != null)
                {
                    if (min > aux2.Siguiente.TEJEC && aux2.Siguiente.COM == false)
                    {
                        min = aux2.Siguiente.TEJEC;
                        tmp = aux2.Siguiente;
                    }
                    aux2 = aux2.Siguiente;
                }
                tmp.TI = n;
                n = n + tmp.TEJEC;
                tmp.TF = n;
                tmp.TR = tmp.TF - tmp.TLL;
                tmp.TE = tmp.TI - tmp.TLL;
                tmp.COM = true;
            }
        }

        public void SRT2()
        {
            int n = 0;
            int total;
            total = SumTEjec();

            aux = cabeza.Siguiente;
            aux.TI = n;

            int min;
            CNodoProceso tmp = new CNodoProceso();

            while (n < total)
            {
                if (aux.Siguiente != null)
                {
                    if (n == aux.Siguiente.TLL)
                    {
                        if (aux.Siguiente.TEJAUX <= aux.TEJAUX)
                        {
                            aux = aux.Siguiente;
                            aux.TI = n;
                        }
                        else
                        {
                            aux.TEJAUX--;
                            n++;
                            if (aux.TEJAUX == 0)
                            {
                                aux.TF = n;
                                aux.COM = true;
                                aux = aux.Siguiente;
                                aux.TI = n;
                            }
                        }
                    }
                    else
                    {
                        aux.TEJAUX--;
                        n++;
                        if (aux.TEJAUX == 0)
                        {
                            aux.TF = n;
                            aux.COM = true;
                        }
                    }
                }
                else
                {
                    aux2 = aux;
                    while (aux2 != cabeza && aux2.COM == true)
                    {
                        aux2 = aux2.Anterior;
                    }
                    min = aux2.TEJAUX;
                    tmp = aux2;

                    while (aux2.Anterior != cabeza)
                    {
                        if (min > aux2.Anterior.TEJAUX && aux2.Anterior.COM == false)
                        {
                            min = aux2.Anterior.TEJAUX;
                            tmp = aux2.Anterior;
                        }
                        aux2 = aux2.Anterior;
                    }
                    tmp.COM = true;
                    n = n + tmp.TEJAUX;
                    tmp.TEJAUX = 0;
                    tmp.TF = n;
                }
            }

            aux = cabeza.Siguiente;
            while (aux != null)
            {
                aux.TR = aux.TF - aux.TLL;
                aux.TE = aux.TI - aux.TLL;
                aux = aux.Siguiente;
            }

        }

        public void SRT()
        {
            int n = 0;
            int total;
            total = SumTEjec();

            int min;
            CNodoProceso tmp = new CNodoProceso();


            while (n < total)
            {
                aux2 = cabeza.Siguiente;
                while (aux2.Siguiente != null)
                {
                    aux2 = aux2.Siguiente;
                }

                while (aux2.TLL > n && aux2.Anterior != cabeza)
                {
                    aux2 = aux2.Anterior;
                }

                while (aux2.COM == true && aux2.Anterior != cabeza)
                {
                    aux2 = aux2.Anterior;
                }

                min = aux2.TEJAUX;
                tmp = aux2;

                while (aux2.Anterior != cabeza)
                {
                    if (min > aux2.Anterior.TEJAUX && aux2.COM != true)
                    {
                        min = aux2.TEJAUX;
                        tmp = aux2;
                    }
                    aux2 = aux2.Anterior;
                }
                if (tmp.TI == 0 && tmp != cabeza.Siguiente)
                {
                    tmp.TI = n;
                }
                tmp.TEJAUX--;
                n++;
                if (tmp.TEJAUX == 0)
                {
                    tmp.TF = n;
                    tmp.COM = true;
                }
            }

            aux = cabeza.Siguiente;
            while (aux != null)
            {
                aux.TR = aux.TF - aux.TLL;
                aux.TE = aux.TI - aux.TLL;
                aux = aux.Siguiente;
            }

        }

        public void InsertarRR(CNodoProceso c)
        {
            aux = cabeza;

            while (aux.Siguiente != null)
            {
                aux = aux.Siguiente;
            }

            CNodoProceso temp = new CNodoProceso();

            temp.NPROCESO = c.NPROCESO;
            temp.TLL = c.TLL;
            temp.TEJEC = c.TEJEC;

            temp.TI = c.TI;
            temp.TF = c.TF;
            temp.TR = c.TR;
            temp.TE = c.TE;

            temp.COM = c.COM;
            temp.TEJAUX = c.TEJAUX;

            temp.Siguiente = null;

            aux.Siguiente = temp;
            temp.Anterior = aux;
        }

        public int ExecRR(int q, int n)
        {
            aux = cabeza.Siguiente;
            if ((aux.TEJAUX - q) <= 0)
            {
                if (aux.TLL != 0 && aux.TI == 0)
                {
                    aux.TI = n;
                }
                aux.COM = true;
                q = aux.TEJAUX;
                n += q;
                aux.TEJAUX = 0;
                aux.TF = n;
               
            }
            else
            {
                if (aux.TLL != 0 && aux.TI == 0)
                {
                    aux.TI = n;
                }
                aux.TEJAUX -= q;
            }
            return q;
        }

        public void CompletarRR(int q, int n)
        {
            int total = SumTEjec();
            while (n < total)   
            {
                aux = cabeza.Siguiente;
                if ((aux.TEJAUX - q) <= 0 && aux.COM != true)
                {
                    if (aux.TI == 0 && aux.TLL != 0)
                    {
                        aux.TI = n;
                    }
                    aux.COM = true;
                    n += aux.TEJAUX;
                    aux.TEJAUX = 0;
                    aux.TF = n;
                }
                else
                {
                    if (aux.COM != true)
                    {
                        if (aux.TLL != 0 && aux.TI == 0)
                        {
                            aux.TI = n;
                        }
                        aux.TEJAUX -= q;
                        n += q;
                    }
                }
                InsertarRR(aux);
                Eliminar();
            }

            aux = cabeza.Siguiente;
            while (aux != null)
            {
                aux.TR = aux.TF - aux.TLL;
                aux.TE = aux.TI - aux.TLL;
                aux = aux.Siguiente;
            }
            Ordenar();
        }

        public CNodoProceso GetFirst()
        {
            return cabeza.Siguiente;
        }

        public CListaProceso RR(int quantum)
        {
            int n = 0;
            int q;
            CListaProceso ListAux = new CListaProceso();
            ListAux.InsertarRR(cabeza.Siguiente);

            aux = cabeza.Siguiente;

            while (aux != null)
            {
                q = ListAux.ExecRR(quantum, n);
                n += q;
               
                if(aux.Siguiente != null)
                {
                    aux2 = aux.Siguiente;
                    while(aux2 != null && aux2.TLL <= n)
                    {
                        ListAux.InsertarRR(aux2);
                        aux2 = aux2.Siguiente;
                    }
                    if(aux2 != null)
                    {
                        aux = aux2.Anterior.Anterior;
                    }
                    else
                    {
                        aux = aux.Siguiente;
                    }
                }
                aux = aux.Siguiente;
                ListAux.InsertarRR(ListAux.GetFirst());
                ListAux.Eliminar();
            }
            ListAux.CompletarRR(quantum, n);
            return ListAux;
        }

        public string ObtNombre(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }
            return aux.NPROCESO;
        }

        public int Obttll(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TLL;
        }

        public int Obtejec(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TEJEC;
        }
        public int ObtIni(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TI;
        }
        public int ObtFin(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TF;
        }
        public int ObtRet(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TR;
        }
        public int ObtEsp(int n)
        {
            aux = cabeza;
            for (int i = 0; i < n; i++)
            {
                aux = aux.Siguiente;
            }

            return aux.TE;
        }
    }
}
