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
    public partial class ProveedoresInactivos : Form
    {



        //String RUC;
        L_Proveedores proveedor = new L_Proveedores();
        public ProveedoresInactivos()
        {
            InitializeComponent();
            this.mostarTodos();
            
           // mostarProveedoresInactivos();

        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            // mostarProveedoresActivos();
            //mostarProveedoresInactivos();
            //mostarTodos();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dGVprov.SelectedRows.Count > 0)
            {
                String Ruc = dGVprov.CurrentRow.Cells[3].Value.ToString();
                proveedor.cambiarEstado(Ruc);
                //mostarProveedoresInactivos();
                MessageBox.Show("Proveedor dado de alta");

            }
            else
            {
                MessageBox.Show("No se ha seleccionado un proveedor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.mostarTodos();

        }
        private void mostarTodos()
        {
            dGVprov.DataSource = proveedor.mostrarProveedores();
        }

       /* private void mostarProveedoresInactivos()
        {
            dataGridView1.DataSource = proveedor.mostrarProveedoresInactivos();
            //ShowDialog(productoCN.mostrarProveedoresInactivos());
            //MessageBox.Show(productoCN.mostrarProveedoresInactivos());
        }*/

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //this.proveedor.cambiarEstado(RUC);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
