using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Entidades;
using Lógica;

namespace Presentación
{
    public partial class NuevoProducto : Form
    {
        private E_Producto objProducto = new E_Producto();
        private L_Productos productoCN = new L_Productos();
        


        public NuevoProducto()
        {
            InitializeComponent();
        }

        private void NuevoProducto_Load(object sender, EventArgs e)
        {
            llenarCBProveedor();
            llenarCBUnidad();
            llenarCBCategoria();
            //llenarCodigo();
        }


        //Todo esto es para redimensionar el form con los paneles.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void NuevoProducto_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        //Programación de los botones
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {

                objProducto.Categoria = cBcategoria.SelectedIndex;
                objProducto.Tipo = tBtipo.Text;
                objProducto.Marca = tBmarca.Text;
                objProducto.Serie = tBserie.Text;
                objProducto.Descripción = tBdescrip.Text;
                objProducto.PrecioCompra = float.Parse(tBprecioCompra.Text);
                objProducto.UnidadMedida1 = Convert.ToInt32(cBunidadMedida.SelectedIndex);
                objProducto.Stock = float.Parse(tBstock.Text);
                objProducto.Proveedor = cBproveedor.SelectedIndex;



                productoCN.insertarProducto(objProducto);
                MessageBox.Show("Producto Ingresado Correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ingresar el producto por " + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        public void llenarCodigo()
        {
            tBcodigo.Text = productoCN.obtenerCod();
        }
        public void llenarCBCategoria()
        {
            cBcategoria.DataSource = productoCN.mostrarCategorias();
            cBcategoria.DisplayMember = "nombre";
            cBcategoria.ValueMember = "ID";
        }

        public void llenarCBUnidad()
        {
            cBunidadMedida.DataSource = productoCN.mostrarUnidades();
            cBunidadMedida.DisplayMember = "nombre";
            cBunidadMedida.ValueMember = "ID";
        }

        public void llenarCBProveedor()
        {
            cBproveedor.DataSource = productoCN.mostrarProveedores();
            cBproveedor.DisplayMember = "nombreComercial";
            cBproveedor.ValueMember = "idProveedor";
        }

       
    }
}
