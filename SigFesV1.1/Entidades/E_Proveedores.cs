using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class E_Proveedores
    {
        bool estado;
        string nombreComercial;
        string ruc;
        //string[] provincias = new string[24] { "Azuay", "Bolivar", "Cañar", "Carchi", "Chimborazo", "Cotopaxi", "El Oro", "Esmeraldas", "Galapagos", "Guayas", "Imbabura", "Loja", "Los Ríos", "Manabí", "Morona Santiago", "Napo", "Orellana", "Pastaza", "Pichincha", "SantaElena", "Santo Domingo de los Tsáchilas", "Sucumbiís", "Tungurahua", "Zamora Chinchipe"};
        string provincia;
        string canton;
        string dirección;
        string numeroTelefonoContacto;
        string razonSocial;
        string correoElectronico;



        public bool Estado { get => estado; set => estado = value; }
        public string NombreComercial { get => nombreComercial; set => nombreComercial = value; }
        public string Ruc { get => ruc; set => ruc = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Canton { get => canton; set => canton = value; }
        public string Dirección { get => dirección; set => dirección = value; }
        public string NumeroTelefonoContacto { get => numeroTelefonoContacto; set => numeroTelefonoContacto = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string CorreoElectronico { get => correoElectronico; set => correoElectronico = value; }
    }
}
