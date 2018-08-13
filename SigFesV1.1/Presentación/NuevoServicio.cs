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
    public partial class NuevoServicio : Form
    {
        public NuevoServicio()
        {
            InitializeComponent();
        }

        

        private void cBcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cBunidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Servicio Registrado", "aviso", MessageBoxButtons.OK);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se cancela el registro del servicio", "aviso", MessageBoxButtons.OK);
        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
