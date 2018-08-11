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
    public partial class FormProductos : Form
    {

        L_Productos productoCN = new L_Productos();

        public FormProductos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NuevoProducto frm = new NuevoProducto();
            //frm.ShowDialog();

            


        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            mostarTodos();
        }



        private void mostarTodos()
        {
            dGVproductos.DataSource = productoCN.MostrarProd();
        }

    }
}
