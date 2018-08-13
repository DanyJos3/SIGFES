using Presentación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentación
{
    public partial class FormServicios : Form
    {
        public FormServicios()
        {
            InitializeComponent();
        }

        private void FormServicios_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoServicio frm = new NuevoServicio();
            frm.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ModificarServicio frm = new ModificarServicio();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se muestra el resultado de la búsqueda", "aviso", MessageBoxButtons.OK);
        }
    }
}
