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
                objProducto.UnidadMedida = cBunidadMedida.Text;
                objProducto.Stock = float.Parse(tBstock.Text);
                objProducto.Proveedor = cBproveedor.SelectedIndex;

                MessageBox.Show(objProducto.Categoria + "" +
                objProducto.Tipo + "" +
                objProducto.Marca + "" +
                objProducto.Serie + "" +
                objProducto.Descripción + "" +
                objProducto.PrecioCompra + "" +
                objProducto.UnidadMedida + "" +
                objProducto.Stock + "" +
                objProducto.Proveedor + "");


                productoCN.insertarProducto(objProducto);
                MessageBox.Show("Producto Ingresado Correctamente", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ingresar el producto por " + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        //public void llenarCBMarca()
        //{
        //    String query = "select nombre from estudiantes";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.CommandText = query;
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        combobox.Items.Add(dr["nombre"].ToString());
        //    }

        //    con.Close();
        //}


    }
}
