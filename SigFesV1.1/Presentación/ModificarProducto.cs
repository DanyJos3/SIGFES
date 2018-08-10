using Entidades;
using Lógica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Presentación
{
    public partial class ModificarProducto : Form
    {
        private L_Productos productoCN = new L_Productos();
        private E_Producto objProducto = new E_Producto();

        //Todo esto es para redimensionar el form con los paneles.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        public ModificarProducto()
        {
            InitializeComponent();
        }

       
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                objProducto.Código = Convert.ToUInt16(tBcodigo.Text.Trim());
                //objProducto.Categoria = cBcategoria.SelectedIndex;
                //objProducto.Tipo = tBtipo.Text;
                objProducto.Marca = tBmarca.Text;
                //objProducto.Serie = tBserie.Text;
                objProducto.Descripción = tBdescrip.Text;
                objProducto.PrecioCompra = float.Parse(tBprecioCompra.Text);
                //objProducto.UnidadMedida1 = Convert.ToInt32(cBunidadMedida.SelectedIndex);
                //objProducto.Stock = float.Parse(tBstock.Text);
                //objProducto.Proveedor = cBproveedor.SelectedIndex;



                productoCN.modificarProducto(objProducto);
                MessageBox.Show("Se Modifico Correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar el producto por " + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
