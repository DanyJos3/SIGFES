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

        private void FormProductos_Load(object sender, EventArgs e)
        {
            mostarDisponibles();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoProducto frm = new NuevoProducto();
            frm.ShowDialog();
            mostarDisponibles();

        }


        private void mostarTodos()
        {
            dGVproductos.DataSource = productoCN.MostrarProd();
        }

        private void mostarDisponibles()
        {
            dGVproductos.DataSource = productoCN.MostrarProdDisponibles();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarProducto frm = new ModificarProducto();
            if (dGVproductos.SelectedRows.Count > 0)
            {

                frm.tBcodigo.Text = dGVproductos.CurrentRow.Cells[0].Value.ToString();
                frm.cBcategoria.Items.Insert(0, dGVproductos.CurrentRow.Cells[1].Value.ToString());
                frm.cBcategoria.SelectedIndex = 0;
                frm.tBtipo.Text = dGVproductos.CurrentRow.Cells[2].Value.ToString();
                frm.tBmarca.Text = dGVproductos.CurrentRow.Cells[3].Value.ToString();
                frm.tBserie.Text = dGVproductos.CurrentRow.Cells[4].Value.ToString();
                frm.tBdescrip.Text = dGVproductos.CurrentRow.Cells[5].Value.ToString();
                frm.tBprecioCompra.Text = dGVproductos.CurrentRow.Cells[6].Value.ToString();
                frm.cBunidadMedida.Items.Insert(0, dGVproductos.CurrentRow.Cells[7].Value.ToString());
                frm.cBunidadMedida.SelectedIndex = 0;
                frm.tBstock.Text = dGVproductos.CurrentRow.Cells[8].Value.ToString();
                frm.cBproveedor.Items.Insert(0, dGVproductos.CurrentRow.Cells[9].Value.ToString());
                frm.cBproveedor.SelectedIndex = 0;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            mostarDisponibles();
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dGVproductos.SelectedRows.Count > 0)
            {
                DarBaja frm = new DarBaja();
                frm.tBcódigo.Text = dGVproductos.CurrentRow.Cells[0].Value.ToString();
                frm.tBunidad.Text = dGVproductos.CurrentRow.Cells[7].Value.ToString();


                frm.umedida = (dGVproductos.CurrentRow.Cells[7].Value.ToString());
                frm.codigo = Convert.ToInt32(dGVproductos.CurrentRow.Cells[0].Value.ToString());
                frm.stock = Convert.ToDecimal(dGVproductos.CurrentRow.Cells[8].Value.ToString());
               
                frm.mostrarBotones();
                //frm.tBcantidad.Text = dGVproductos.CurrentRow.Cells[8].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            mostarDisponibles();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (dGVproductos.SelectedRows.Count > 0)
            {
                AgregarProducto frm = new AgregarProducto();
                frm.tBcodigo.Text = dGVproductos.CurrentRow.Cells[0].Value.ToString();
                frm.tbTipo.Text = dGVproductos.CurrentRow.Cells[2].Value.ToString();
                frm.tBmarca.Text = dGVproductos.CurrentRow.Cells[3].Value.ToString();
                frm.tBunidad.Text = dGVproductos.CurrentRow.Cells[7].Value.ToString();


                frm.umedida = (dGVproductos.CurrentRow.Cells[7].Value.ToString());
                frm.codigo = Convert.ToInt32(dGVproductos.CurrentRow.Cells[0].Value.ToString());
                frm.stock = Convert.ToDecimal(dGVproductos.CurrentRow.Cells[8].Value.ToString());

                frm.mostrarBotones();
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mostarDisponibles();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dGVproductos.SelectedRows.Count > 0)
            {
                int auxStock = Convert.ToInt32(dGVproductos.CurrentRow.Cells[8].Value.ToString());

                MessageBox.Show(auxStock+"");
                if (auxStock == 0)
                {
                    productoCN.inhabilitar(Convert.ToInt32(dGVproductos.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("El producto de borro de la lista", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    mostarDisponibles();
                }
                else
                {
                    MessageBox.Show("Aún existe el producto en bodega", "No se puede Inhabilitar el producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un producto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cBopc_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cBopc.SelectedText);
            MessageBox.Show(cBopc.SelectedItem+"");
            MessageBox.Show(cBopc.SelectedIndex+"");

            if (cBopc.SelectedIndex == 0)
            {
                this.tBbuscar.Enabled = true;
                this.tBbuscar.Text = "";
                this.btnBuscar.Enabled = true;
                this.cBopciones.Enabled = false;

            }else if (cBopc.SelectedIndex == 1)
            {
                this.cBopciones.Enabled = false;
                this.btnBuscar.Enabled = true;
                this.tBbuscar.Enabled = true;
                this.tBbuscar.Text = "";

            }
            else if (cBopc.SelectedIndex == 2)
            {
                llenarCBCategoria();
                this.cBopciones.Enabled = true;
                this.btnBuscar.Enabled = true;
                this.tBbuscar.Enabled = true;
                this.tBbuscar.Text = "";

                
            }
            else if (cBopc.SelectedIndex == 3)
            {
                this.cBopciones.Enabled = false;
                this.btnBuscar.Enabled = true;
                this.tBbuscar.Enabled =false;
                //this.tBbuscar.Text = "";
            }
            else
            {
                MessageBox.Show("Parámetro inválido");
            }
            //MessageBox.Show(cBopc.SelectedItem+"");

            //MessageBox.Show(cBopc.SelectedIndex + "");

            //MessageBox.Show(cBopc.SelectedText + "");

          
        }


        public void llenarCBCategoria()
        {
            this.cBopciones.DataSource = productoCN.mostrarCategorias();
            this.cBopciones.DisplayMember = "nombre";
            this.cBopciones.ValueMember = "ID";
        }

      

        public void llenarCBProveedor()
        {
            cBopciones.DataSource = productoCN.mostrarProveedores();
            cBopciones.DisplayMember = "nombreComercial";
            cBopciones.ValueMember = "idProveedor";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cBopc.SelectedIndex == 0)
            {
                dGVproductos.DataSource = productoCN.buscarPorCod(tBbuscar.Text.Trim());
            }
            else if (cBopc.SelectedIndex == 1)
            {
                dGVproductos.DataSource = productoCN.buscarPorTipo(tBbuscar.Text.Trim());

            }
            else if (cBopc.SelectedIndex == 2)
            {
                dGVproductos.DataSource = productoCN.buscarPorCategoria(tBbuscar.Text.Trim());


            }
            else if (cBopc.SelectedIndex == 3)
            {
                dGVproductos.DataSource = productoCN.MostrarProdDisponibles();
            }
            else
            {
                MessageBox.Show("Parámetro inválido");
            }

        }
    }
}
