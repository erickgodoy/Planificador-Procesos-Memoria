using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestor_de_Procesos_y_Memoria
{
    public partial class PlanificadorDeMemoria : Form
    {
        CListaMemoriaTrabajo MyList = new CListaMemoriaTrabajo();
        CListaMemoria MyListMemory = new CListaMemoria();

        int contDGV1 = 0;
        int contDGV2 = 0;


        public PlanificadorDeMemoria()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = dataGridView2.Rows.Add();
            dataGridView2.Rows[n].Cells[0].Value = contDGV1;
            dataGridView2.Rows[n].Cells[1].Value = maskedTextBox1.Text;

            int valor = Convert.ToInt32(maskedTextBox1.Text);

            MyListMemory.Insertar(contDGV1, valor, 0);
            contDGV1++;

            maskedTextBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n = dataGridView4.Rows.Add();

            contDGV2++;
            dataGridView4.Rows[n].Cells[0].Value = contDGV2;
            dataGridView4.Rows[n].Cells[1].Value = textBox2.Text;
            dataGridView4.Rows[n].Cells[2].Value = textBox3.Text;

            double tll = Convert.ToDouble(textBox1.Text);
            int tamaño = Convert.ToInt32(textBox2.Text);
            double tiempo = Convert.ToDouble(textBox3.Text);

            MyList.Insertar(contDGV2, tamaño, tiempo, tll);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyList.FCFS_PA(MyListMemory);

            int total = MyList.TotalNodos();
            int n;

            double TRM;
            double sumTR = 0;
            
            for(int i =1; i <= total; i++)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = Convert.ToString(MyList.ObtTrabajo(i));
                dataGridView1.Rows[n].Cells[1].Value = Convert.ToString(MyList.ObtTLL(i)/10);
                dataGridView1.Rows[n].Cells[2].Value = Convert.ToString(MyList.ObtTF(i) / 10);
                dataGridView1.Rows[n].Cells[3].Value = Convert.ToString(MyList.ObtTR(i) / 10);
                sumTR = sumTR + MyList.ObtTR(i) / 10;
            }

            TRM = sumTR;
            TRM = TRM / total;

            label9.Text = Convert.ToString(sumTR);
            label10.Text = Convert.ToString(TRM);
        }
    }
}
