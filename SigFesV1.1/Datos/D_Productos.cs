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

        SqlDataReader leerFilas;
        DataTable tabla;
        SqlCommand comd = new SqlCommand();
        List<string> lista;



        public string nuevoCodigo()
        {
            string cod;
            comd.Connection = conn.abrirConexión();
            comd.CommandText = "Select count(código)+1 from Productos";
            comd.CommandType = CommandType.Text;
            leerFilas = comd.ExecuteReader();

            cod = Convert.ToString(leerFilas.GetValue(0));

            leerFilas.Close(); //Cierra el reader para que no haya problemas
            conn.cerrarConexión();
            return cod;
        }


        public DataTable listar(string procedimiento)
        {
            tabla = new DataTable();
            //tabla.Clear();
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento.Trim();
            comd.CommandType = CommandType.StoredProcedure;
            leerFilas = comd.ExecuteReader();//Devuelve filas
            tabla.Load(leerFilas);

            leerFilas.Close(); //Cierra el reader para que no haya problemas
            conn.cerrarConexión();
            return tabla;
        }


        public DataTable buscar(string parametro, string procedimiento)
        {
            tabla = new DataTable();
            //tabla.Clear();
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento.Trim();
            comd.CommandType = CommandType.StoredProcedure;
            comd.Parameters.AddWithValue("@parametro", parametro);

            leerFilas = comd.ExecuteReader();//Devuelve filas
            tabla.Load(leerFilas);

            leerFilas.Close(); //Cierra el reader para que no haya problemas

            comd.Parameters.Clear();
            conn.cerrarConexión();
            return tabla;
        }




        public void insertarProducto(E_Producto objproductos, String procedimiento)
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento;
            comd.CommandType = CommandType.StoredProcedure;         
            try
            {
                comd.Parameters.AddWithValue("@categoria", objproductos.Categoria);
                comd.Parameters.AddWithValue("@tipo", objproductos.Tipo);
                comd.Parameters.AddWithValue("@marca", objproductos.Marca);
                comd.Parameters.AddWithValue("@serie", objproductos.Serie);
                comd.Parameters.AddWithValue("@descripción", objproductos.Descripción);
                comd.Parameters.AddWithValue("@precioCompra", objproductos.PrecioCompra);
                comd.Parameters.AddWithValue("@unidadMedida", objproductos.UnidadMedida1);
                comd.Parameters.AddWithValue("@stock", objproductos.Stock);
                comd.Parameters.AddWithValue("@proveedor", objproductos.Proveedor);

                comd.ExecuteNonQuery();
                comd.Parameters.Clear();
                comd.Connection = conn.cerrarConexión();
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void modificarProducto(E_Producto objproductos, String procedimiento)
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento;
            comd.CommandType = CommandType.StoredProcedure;
            try
            {

                comd.Parameters.AddWithValue("@codigo", objproductos.Código);
                //comd.Parameters.AddWithValue("@categoria", objproductos.Categoria);
                //comd.Parameters.AddWithValue("@tipo", objproductos.Tipo);
                comd.Parameters.AddWithValue("@marca", objproductos.Marca);
                //comd.Parameters.AddWithValue("@serie", objproductos.Serie);
                comd.Parameters.AddWithValue("@descripción", objproductos.Descripción);
                comd.Parameters.AddWithValue("@precioCompra", objproductos.PrecioCompra);
                //comd.Parameters.AddWithValue("@unidadMedida", objproductos.UnidadMedida1);
                //comd.Parameters.AddWithValue("@stock", objproductos.Stock);
                //comd.Parameters.AddWithValue("@proveedor", objproductos.Proveedor);

                comd.ExecuteNonQuery();
                comd.Parameters.Clear();
                comd.Connection = conn.cerrarConexión();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        public void modificarStock(int codigo, string cantidad, String procedimiento) 
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento;
            comd.CommandType = CommandType.StoredProcedure;
            try
            {
                
                comd.Parameters.AddWithValue("@codigo", codigo);
                comd.Parameters.AddWithValue("@cantidad", cantidad);

                comd.ExecuteNonQuery();
                comd.Parameters.Clear();
                comd.Connection = conn.cerrarConexión();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void cambiarEstado(int codigo, String procedimiento)
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento;
            comd.CommandType = CommandType.StoredProcedure;
            try
            {

                comd.Parameters.AddWithValue("@codigo", codigo);

                comd.ExecuteNonQuery();
                comd.Parameters.Clear();
                comd.Connection = conn.cerrarConexión();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

      
        



    }
}
