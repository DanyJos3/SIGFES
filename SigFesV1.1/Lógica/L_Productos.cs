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

        public DataTable MostrarProdDisponibles()
        {
            tabla = new DataTable();
            tabla = productosCD.listar("SPmostrarProductosDisponibles");
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

        public void modificarStock(int codigo, string cantidad)
        {
            productosCD.modificarStock(codigo, cantidad, "SPmodificarStock");
        }

        public void inhabilitar(int codigo)
        {
            productosCD.cambiarEstado(codigo, "SPinhabilitar");
        }
        public void habilitar(int codigo)
        {
            productosCD.cambiarEstado(codigo, "SPhabilitar");
        }


        //Busquedas.....
        public DataTable buscarPorCod(String parametro)
        {
            tabla = new DataTable();
            tabla = productosCD.buscar(parametro,"SPbuscarPorCod");
            return tabla;
        }
        public DataTable buscarPorCategoria(String parametro)
        {
            tabla = new DataTable();
            tabla = productosCD.buscar(parametro,"SPbuscarPorCategoria");
            return tabla;
        }
        public DataTable buscarPorTipo(String parametro)
        {
            tabla = new DataTable();
            tabla = productosCD.buscar(parametro,"SPbuscarPorTipo");
            return tabla;
        }

    }

}
