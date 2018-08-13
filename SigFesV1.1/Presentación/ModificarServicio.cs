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
    public partial class ModificarServicio : Form
    {
        public ModificarServicio()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Servicio Modificado", "aviso", MessageBoxButtons.OK);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se cancela la modificación del servicio", "aviso", MessageBoxButtons.OK);
        }
    }
}
