using Lógica;
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

        private void dGVproductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (this.dGVproductos.Columns[e.ColumnIndex].Name == "Estado")
            {
                if ((Convert.ToString(e.Value).Trim()).Equals("inactivo"))
                {

                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.DarkRed;

                }
                else if ((Convert.ToString(e.Value).Trim()).Equals("activo"))
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.LimeGreen;
                }

            }
        }
    }
}
