using Presentación;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lógica;
using Entidades;

namespace Presentación
{
    public partial class Proveedor : Form
    {

        L_Proveedores proveedor = new L_Proveedores();
        //L_Productos productoCN = new L_Productos();
        public Proveedor()
        {
            InitializeComponent();
        }

       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void Proveedor_Load(object sender, EventArgs e)
        {
            // mostarProveedoresActivos();
            //mostarProveedoresInactivos();
            //mostarTodos();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormRegistrarProveedores rp = new FormRegistrarProveedores();
            rp.ShowDialog();
            mostarTodos();
        }

        public void mostarTodos()
        {
            dGVprov.DataSource = proveedor.MostrarProveedor();
        }


        /*private void mostarProveedoresActivos()
        {
           dataGridView2.DataSource = proveedor.mostrarProveedoresActivos();
        }*/

       /* private void mostarProveedoresInactivos()
        {
            dataGridView2.DataSource = proveedor.mostrarProveedoresInactivos();
        }*/

        private void button3_Click(object sender, EventArgs e)
        {

            if (dGVprov.SelectedRows.Count > 0)
            {
                E_Proveedores objProveedor = new E_Proveedores();
                //objProveedor.Estado = int.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                objProveedor.Estado = bool.Parse(dGVprov.CurrentRow.Cells[1].Value.ToString());
                objProveedor.NombreComercial = dGVprov.CurrentRow.Cells[2].Value.ToString();
                objProveedor.Ruc = dGVprov.CurrentRow.Cells[3].Value.ToString();
                objProveedor.Provincia = dGVprov.CurrentRow.Cells[4].Value.ToString();
                objProveedor.Canton = dGVprov.CurrentRow.Cells[5].Value.ToString();
                objProveedor.Dirección = dGVprov.CurrentRow.Cells[6].Value.ToString();
                objProveedor.NumeroTelefonoContacto = dGVprov.CurrentRow.Cells[7].Value.ToString();
                objProveedor.RazonSocial = dGVprov.CurrentRow.Cells[8].Value.ToString();
                objProveedor.CorreoElectronico = dGVprov.CurrentRow.Cells[9].Value.ToString();
                // MessageBox.Show(dataGridView2.CurrentRow.Cells[1].Value.ToString(), "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);



                //String text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                // MessageBox.Show(text, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ModificarProveedor mp = new ModificarProveedor(objProveedor, this);
                mp.ShowDialog();
            }else
            {
                MessageBox.Show("No se ha seleccionado un proveedor", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            mostarTodos();
        }

   

        private void button4_Click(object sender, EventArgs e)
        {

            if (dGVprov.SelectedRows.Count > 0)
            {
                //E_Proveedores objProveedor = new E_Proveedores();
                String Ruc = dGVprov.CurrentRow.Cells[3].Value.ToString();
                proveedor.cambiarEstado(Ruc);
                mostarTodos();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            mostarTodos();

        }

       

        public void limpiarGrid()
        {
            while (dGVprov.RowCount >= 1)
            {

                dGVprov.Rows.Remove(dGVprov.CurrentRow);

            }
        }
        private void cBopc_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cBopc.SelectedIndex == 0)
            {
                limpiarGrid();
                this.tBbuscar.Enabled = true;
                this.tBbuscar.Text = "";
                this.btnBuscar.Enabled = true;
                

            }
            else if (cBopc.SelectedIndex == 1)
            {
                limpiarGrid();
                this.tBbuscar.Enabled = true;
                this.tBbuscar.Text = "";
                this.btnBuscar.Enabled = true;
                
            }
            else if (cBopc.SelectedIndex == 2)
            {
                limpiarGrid();
                this.tBbuscar.Enabled = false;
                this.tBbuscar.Text = "Buscar...";
                this.btnBuscar.Enabled = true;
                

            }
            else
            {
                MessageBox.Show("Parámetro de búsqueda inválido");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cBopc.SelectedIndex == 0)
            {
                dGVprov.DataSource = proveedor.buscarPorRUC(tBbuscar.Text.Trim());
            }
            else if (cBopc.SelectedIndex == 1)
            {
                dGVprov.DataSource = proveedor.buscarPorNombreComercial(tBbuscar.Text.Trim());

            }
            else if (cBopc.SelectedIndex == 2)
            {
                dGVprov.DataSource = proveedor.MostrarProveedor();

            }
            else
            {
                MessageBox.Show("Parámetro inválido");
            }

            if(dGVprov.Rows.Count == 0)
            {
                MessageBox.Show("No existe el Proveedor");
            }
        }
    }
}
