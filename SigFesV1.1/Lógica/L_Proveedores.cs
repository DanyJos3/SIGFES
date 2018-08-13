using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lógica
{
     public class L_Proveedores
    {
        private D_Proveedores proveedoresCD = new D_Proveedores();
        private DataTable tabla;

        public DataTable MostrarProveedor()
        {
            tabla = new DataTable();
            tabla = proveedoresCD.listar("SPproveedoresActivos");
            return tabla;
        }

        public DataTable mostrarProveedores()
        {
            DataTable tabla = new DataTable();
            tabla = proveedoresCD.listar("SPproveedoresInactivos");
            return tabla;
        }
        
        public void insertarProveedores(E_Proveedores objProveedores)
        {
            proveedoresCD.insertarProveedor(objProveedores, "SPinsertarProveedor");
        }

        public DataTable mostrarProvincias()
        {

            DataTable tabla = new DataTable();
            tabla = proveedoresCD.listar("SPobtenerProvincias");
            return tabla;
        }



        public void modificarProveedor(E_Proveedores objProveedores)
        {
            proveedoresCD.modificarProveedor(objProveedores, "SPmodificarProveedor");
        }

        public void cambiarEstado(String RUC)
        {
            proveedoresCD.cambiarEstado(RUC, "SPModificarEstadoProveedor");
        }


        public DataTable buscarPorRUC(String parametro)
        {
            tabla = new DataTable();
            tabla = proveedoresCD.buscar(parametro, "SPproveedoresporRuc");
            return tabla;
        }
        public DataTable buscarPorNombreComercial(String parametro)
        {
            tabla = new DataTable();
            tabla = proveedoresCD.buscar(parametro, "SPproveedoresporNombre");
            return tabla;
        }


        public DataTable buscarCantones(string parametro)
        {
            tabla = new DataTable();
            tabla = proveedoresCD.buscar(parametro, "SPobtenerCanton");
            return tabla;
        }
    }
}
