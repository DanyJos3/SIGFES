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

        private void cBcategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tBmarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            char[] NoPermitir = { '-', '_', 'é', 'ý', 'ú', 'í', 'ñ', 'ó', 'á', 'ë', 'ÿ', 'ü', 'ï', 'ö', 'ä', 'ê', 'û', 'î', 'ô', 'â' };
            char[] Permitir = {  };

            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten caráceteres ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            
        }

        private void tBserie_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                char[] NoPermitir = { '-', '_', 'é', 'ý', 'ú', 'í', 'ñ', 'ó', 'á', 'ë', 'ÿ', 'ü', 'ï', 'ö', 'ä', 'ê', 'û', 'î', 'ô', 'â' };
                char[] Permitir = {  };

                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsNumber(e.KeyChar)))
                {
                    MessageBox.Show("Solo se permiten letras y números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Handled = true;
                    return;
                }
               
            
        }

        private void tBstock_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < tBstock.Text.Length; i++)
            {
                if (tBstock.Text[i] == ',')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se permiten 2 decimales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 44)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void tBprecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < this.tBprecioCompra.Text.Length; i++)
            {
                if (this.tBprecioCompra.Text[i] == ',')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    MessageBox.Show("Solo se permiten 2 decimales");
                    e.Handled = true;

                    return;


                }

            }


            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 44)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
    }
}
