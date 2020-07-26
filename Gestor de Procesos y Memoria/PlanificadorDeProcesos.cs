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
    public partial class PlanificadorDeProcesos : Form
    {
        CListaProceso MyList = new CListaProceso();
        public PlanificadorDeProcesos()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();

            dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
            string nombre = textBox1.Text;
            int tllegada = Convert.ToInt32(textBox2.Text);
            int tejecucion = Convert.ToInt32(textBox3.Text);

            MyList.Insertar(nombre, tllegada, tejecucion);
            
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MyList.FCFS();

            int total = MyList.TotalNodos();
            int n;

            double promTR = 0;
            double promTE = 0;

            for (int i = 1; i < total; i++)
            {
                n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = Convert.ToString(MyList.ObtNombre(i));
                dataGridView3.Rows[n].Cells[1].Value = Convert.ToString(MyList.Obttll(i));
                dataGridView3.Rows[n].Cells[2].Value = Convert.ToString(MyList.Obtejec(i));
                dataGridView3.Rows[n].Cells[3].Value = Convert.ToString(MyList.ObtIni(i));
                dataGridView3.Rows[n].Cells[4].Value = Convert.ToString(MyList.ObtFin(i));
                dataGridView3.Rows[n].Cells[5].Value = Convert.ToString(MyList.ObtRet(i));
                dataGridView3.Rows[n].Cells[6].Value = Convert.ToString(MyList.ObtEsp(i));
                promTR = promTR + MyList.ObtRet(i);
                promTE = promTE + MyList.ObtEsp(i);
            }

            promTR = promTR / (total - 1);
            promTE = promTE / (total - 1);

            label8.Text = Convert.ToString(promTR);
            label9.Text = Convert.ToString(promTE);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MyList.SPN();

            int total = MyList.TotalNodos();

            int n;
            double promTR = 0;
            double promTE = 0;

            for (int i = 1; i < total; i++)
            {
                n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = Convert.ToString(MyList.ObtNombre(i));
                dataGridView3.Rows[n].Cells[1].Value = Convert.ToString(MyList.Obttll(i));
                dataGridView3.Rows[n].Cells[2].Value = Convert.ToString(MyList.Obtejec(i));
                dataGridView3.Rows[n].Cells[3].Value = Convert.ToString(MyList.ObtIni(i));
                dataGridView3.Rows[n].Cells[4].Value = Convert.ToString(MyList.ObtFin(i));
                dataGridView3.Rows[n].Cells[5].Value = Convert.ToString(MyList.ObtRet(i));
                dataGridView3.Rows[n].Cells[6].Value = Convert.ToString(MyList.ObtEsp(i));
                promTR = promTR + MyList.ObtRet(i);
                promTE = promTE + MyList.ObtEsp(i);
            }

            promTR = promTR / (total - 1);
            promTE = promTE / (total - 1);

            label8.Text = Convert.ToString(promTR);
            label9.Text = Convert.ToString(promTE);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MyList.SRT();

            int total = MyList.TotalNodos();

            int n;
            double promTR = 0;
            double promTE = 0;

            for (int i = 1; i < total; i++)
            {
                n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = Convert.ToString(MyList.ObtNombre(i));
                dataGridView3.Rows[n].Cells[1].Value = Convert.ToString(MyList.Obttll(i));
                dataGridView3.Rows[n].Cells[2].Value = Convert.ToString(MyList.Obtejec(i));
                dataGridView3.Rows[n].Cells[3].Value = Convert.ToString(MyList.ObtIni(i));
                dataGridView3.Rows[n].Cells[4].Value = Convert.ToString(MyList.ObtFin(i));
                dataGridView3.Rows[n].Cells[5].Value = Convert.ToString(MyList.ObtRet(i));
                dataGridView3.Rows[n].Cells[6].Value = Convert.ToString(MyList.ObtEsp(i));
                promTR = promTR + MyList.ObtRet(i);
                promTE = promTE + MyList.ObtEsp(i);
            }

            promTR = promTR / (total - 1);
            promTE = promTE / (total - 1);

            label8.Text = Convert.ToString(promTR);
            label9.Text = Convert.ToString(promTE);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int quantum = Convert.ToInt32(textBox4.Text);
            MyList = MyList.RR(quantum);

            int total = MyList.TotalNodos();

            int n;
            double promTR = 0;
            double promTE = 0;

            for (int i = 1; i < total; i++)
            {
                n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = Convert.ToString(MyList.ObtNombre(i));
                dataGridView3.Rows[n].Cells[1].Value = Convert.ToString(MyList.Obttll(i));
                dataGridView3.Rows[n].Cells[2].Value = Convert.ToString(MyList.Obtejec(i));
                dataGridView3.Rows[n].Cells[3].Value = Convert.ToString(MyList.ObtIni(i));
                dataGridView3.Rows[n].Cells[4].Value = Convert.ToString(MyList.ObtFin(i));
                dataGridView3.Rows[n].Cells[5].Value = Convert.ToString(MyList.ObtRet(i));
                dataGridView3.Rows[n].Cells[6].Value = Convert.ToString(MyList.ObtEsp(i));
                promTR = promTR + MyList.ObtRet(i);
                promTE = promTE + MyList.ObtEsp(i);
            }

            promTR = promTR / (total - 1);
            promTE = promTE / (total - 1);

            label8.Text = Convert.ToString(promTR);
            label9.Text = Convert.ToString(promTE);
        }
    }
}
