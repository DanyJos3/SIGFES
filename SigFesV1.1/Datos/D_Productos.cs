using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Windows.Forms;

namespace Datos
{
    public class D_Productos
    {
        private Conexión conn = new Conexión();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comd = new SqlCommand();



        public DataTable mostrarTodos()
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = "SPmostrarProductosTodos";
            comd.CommandType = CommandType.StoredProcedure;
            leer = comd.ExecuteReader();//Devuelve filas
            tabla.Load(leer);
            conn.cerrarConexión();
            return tabla;
        }


        public void insertarProducto(E_Producto objproductos)
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = "SPinsertarProducto";
            comd.CommandType = CommandType.StoredProcedure;
            //comd.Parameters.AddWithValue(@@código nvarchar(50),
            //comd.Parameters.AddWithValue("@categoria",objproductos.Categoria);
            //comd.Parameters.AddWithValue("@tipo", objproductos.Tipo);
            //comd.Parameters.AddWithValue("@marca", objproductos.Marca);
            //comd.Parameters.AddWithValue("@serie", objproductos.Serie);
            //comd.Parameters.AddWithValue("@descripción", objproductos.Descripción);
            //comd.Parameters.AddWithValue("@precioCompra", objproductos.PrecioCompra);
            //comd.Parameters.AddWithValue("@unidadMedida", objproductos.UnidadMedida);
            //comd.Parameters.AddWithValue("@stock", objproductos.Stock);
            //comd.Parameters.AddWithValue("@proveedor", objproductos.Proveedor);


            //exec SPinsertarProducto 2,'','','','',10,'',10,1
            try
            {
                comd.Parameters.AddWithValue("@categoria", objproductos.Categoria);
                comd.Parameters.AddWithValue("@tipo", objproductos.Tipo);
                comd.Parameters.AddWithValue("@marca", objproductos.Marca);
                comd.Parameters.AddWithValue("@serie", objproductos.Serie);
                comd.Parameters.AddWithValue("@descripción", objproductos.Descripción);
                comd.Parameters.AddWithValue("@precioCompra", objproductos.PrecioCompra);
                comd.Parameters.AddWithValue("@unidadMedida", objproductos.UnidadMedida);
                comd.Parameters.AddWithValue("@stock", objproductos.Stock);
                comd.Parameters.AddWithValue("@proveedor", objproductos.Proveedor);

                comd.ExecuteNonQuery();
                
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }
}
