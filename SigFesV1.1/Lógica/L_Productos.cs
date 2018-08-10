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
    public class L_Productos
    {
        private D_Productos productosCD = new D_Productos();
        private DataTable tabla;

        public DataTable MostrarProd()
        {
            tabla = new DataTable();
            tabla = productosCD.listar("SPmostrarProductosTodos");
            return tabla;
        }

        public DataTable mostrarCategorias()
        {
            tabla = new DataTable();
            tabla = productosCD.listar("SPcategorias");

            return tabla;
        }

        public DataTable mostrarUnidades()
        {
            tabla = new DataTable();
            tabla = productosCD.listar("SPunidades");
            return tabla;
        }

        public DataTable mostrarProveedores()
        {

            DataTable tabla = new DataTable();
            tabla = productosCD.listar("SPproveedores");
            return tabla;
        }

        public String obtenerCod()
        {
            String codigo;
            codigo = productosCD.nuevoCodigo();
            return codigo;
        }

       

        public void insertarProducto(E_Producto objProducto)
        {
            productosCD.insertarProducto(objProducto,"SPinsertarProducto");
        }

        public void modificarProducto(E_Producto objProducto)
        {
            productosCD.modificarProducto(objProducto,"SPmodificarProducto1");
        }


    }

}
