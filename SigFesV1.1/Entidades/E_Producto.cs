using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;



namespace Entidades
{

    public class E_Producto
    {
        int código;
        int categoria;
        string marca;
        string serie;
        string tipo;
        string descripción;
        float precioCompra;
        int unidadMedida;
        float stock;
        int proveedor;
        string estado;
        
        public int Categoria { get => categoria; set => categoria = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Serie { get => serie; set => serie = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Descripción { get => descripción; set => descripción = value; }
        public float PrecioCompra { get => precioCompra; set => precioCompra = value; }
        public float Stock { get => stock; set => stock = value; }
        public int Proveedor { get => proveedor; set => proveedor = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Código { get => código; set => código = value; }
        public int UnidadMedida1 { get => unidadMedida; set => unidadMedida = value; }
    }
}
