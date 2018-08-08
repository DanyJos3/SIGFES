using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class Conexión
    {

        SqlConnection con;

        public Conexión()
        {
            con = new SqlConnection("Server=192.170.0.2 ; DataBase=SIGFES; Integrated Security=false");
        }

        public SqlConnection abrirConexión()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;

        }


        public SqlConnection cerrarConexión()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;

        }
    }

}
