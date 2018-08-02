using Lógica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista
{

   

    public partial class TodosProductos : Form
    {

        L_Productos productoCN = new L_Productos();
        public TodosProductos()
        {
            InitializeComponent();
        }


        private void mostarTodos()
        {
            dGVproductos.DataSource = productoCN.MostrarProd();
        }

        private void TodosProductos_Load(object sender, EventArgs e)
        {
            mostarTodos();
        }
    }
}
