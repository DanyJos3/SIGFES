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
            mostarTodos();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoProducto frm = new NuevoProducto();
            frm.ShowDialog();
            mostarTodos();

        }


        private void mostarTodos()
        {
            dGVproductos.DataSource = productoCN.MostrarProd();
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
            mostarTodos();
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dGVproductos.SelectedRows.Count > 0)
            {
                DarBaja frm = new DarBaja();
                frm.tBcódigo.Text = dGVproductos.CurrentRow.Cells[0].Value.ToString();
                //frm.tBcantidad.Text = dGVproductos.CurrentRow.Cells[8].Value.ToString();
                frm.Show();

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProducto frm = new AgregarProducto();
            frm.tBcodigo.Text = dGVproductos.CurrentRow.Cells[0].Value.ToString();
            frm.tbTipo.Text = dGVproductos.CurrentRow.Cells[2].Value.ToString();
            frm.tBmarca.Text = dGVproductos.CurrentRow.Cells[3].Value.ToString();
            //frm.tBcantidad.Text = dGVproductos.CurrentRow.Cells[8].Value.ToString();
            frm.Show();
        }

       
    }
}
