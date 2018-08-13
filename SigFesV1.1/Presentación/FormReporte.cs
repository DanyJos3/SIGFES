using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lógica;

namespace Presentación
{
    public partial class FormReporte : Form
    {
       
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
               mostarTodos();
        }

       
        private void mostarTodos()
        {
           
        }

      
       

       
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desea hacer un nuevo reporte","aviso",MessageBoxButtons.YesNo);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Se generó el reporte exitosamente", "aviso", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

 }

