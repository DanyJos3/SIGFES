using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Datos;
using Entidades;

namespace Lógica

{
    public class L_Usuario
    {
        D_Usuario datosUser = new D_Usuario();


        public SqlDataReader iniciarSesion(E_Usuario obj)
        {
            SqlDataReader loguear;
            loguear = datosUser.iniciarSesionP(obj.Cedúla, obj.Constraseña);
            return loguear;
        }


    }
}
