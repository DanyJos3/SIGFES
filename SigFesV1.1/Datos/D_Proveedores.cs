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
    public class D_Proveedores
    {
        private Conexión conn = new Conexión();

        SqlDataReader leerFilas;
        DataTable tabla;
        SqlCommand comd = new SqlCommand();
        List<string> lista;

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



        public void insertarProveedor(E_Proveedores objProveedores, String procedimiento)
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento;
            comd.CommandType = CommandType.StoredProcedure;
            try
            {
                comd.Parameters.AddWithValue("@nombreComercial", "Tecnomega");
                comd.Parameters.AddWithValue("@RUC", objProveedores.Ruc);
                comd.Parameters.AddWithValue("@provincia", objProveedores.Provincia);
                comd.Parameters.AddWithValue("@cantón", objProveedores.Canton);
                comd.Parameters.AddWithValue("@dirección", objProveedores.Dirección);
                comd.Parameters.AddWithValue("@telfContacto", objProveedores.NumeroTelefonoContacto);
                comd.Parameters.AddWithValue("@razónSocial", objProveedores.RazonSocial);
                comd.Parameters.AddWithValue("@correoElectrónico", objProveedores.CorreoElectronico);

                comd.ExecuteNonQuery();
                comd.Parameters.Clear();
                comd.Connection = conn.cerrarConexión();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void modificarProveedor(E_Proveedores objProveedores, String procedimiento)
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento;
            comd.CommandType = CommandType.StoredProcedure;
            try
            {

                comd.Parameters.AddWithValue("@nombreComercial", objProveedores.NombreComercial);
                comd.Parameters.AddWithValue("@RUC", objProveedores.Ruc);
                comd.Parameters.AddWithValue("@provincia", objProveedores.Provincia);
                comd.Parameters.AddWithValue("@cantón", objProveedores.Canton);
                comd.Parameters.AddWithValue("@dirección", objProveedores.Dirección);
                comd.Parameters.AddWithValue("@telfContacto", objProveedores.NumeroTelefonoContacto);
                comd.Parameters.AddWithValue("@razónSocial", objProveedores.RazonSocial);
                comd.Parameters.AddWithValue("@correoElectrónico", objProveedores.CorreoElectronico);

                comd.ExecuteNonQuery();
                comd.Parameters.Clear();
                comd.Connection = conn.cerrarConexión();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        public void cambiarEstado(String RUC, String procedimiento)
        {
            comd.Connection = conn.abrirConexión();
            comd.CommandText = procedimiento;
            comd.CommandType = CommandType.StoredProcedure;
            //MessageBox.Show("" + RUC, "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            try
            {

                
                //comd.Parameters.AddWithValue("@nombreComercial", objProveedores.NombreComercial);
                comd.Parameters.AddWithValue("@RUC", RUC);
                //comd.Parameters.AddWithValue("@provincia", objProveedores.Provincia);
               // comd.Parameters.AddWithValue("@cantón", objProveedores.Canton);
                //comd.Parameters.AddWithValue("@dirección", objProveedores.Dirección);
                //comd.Parameters.AddWithValue("@telfContacto", objProveedores.NumeroTelefonoContacto);
                //comd.Parameters.AddWithValue("@razónSocial", objProveedores.RazonSocial);
                //comd.Parameters.AddWithValue("@correoElectrónico", objProveedores.CorreoElectronico);

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
