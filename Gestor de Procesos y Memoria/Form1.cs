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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PlanificadorDeProcesos pp1 = new PlanificadorDeProcesos();
            pp1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlanificadorDeMemoria pm1 = new PlanificadorDeMemoria();
            pm1.Show();
        }
    }
}
