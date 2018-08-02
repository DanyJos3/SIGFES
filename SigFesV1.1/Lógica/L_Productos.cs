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
        private D_Productos productosCD;


        public DataTable MostrarProd()
        {
            productosCD = new D_Productos();
            DataTable tabla = new DataTable();
            tabla = productosCD.mostrarTodos();

            return tabla;
        }

        public void insertarProducto(E_Producto objProducto)
        {
            productosCD = new D_Productos();
            productosCD.insertarProducto(objProducto);
        }
    }
}
