using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class E_Usuario
    {
        int id;
        string cedúla;
        string constraseña;
        int id_rol;
        string nombres;
        string apellidos;
        string teléfono;
        string dirección;

        public int Id { get => id; set => id = value; }
        public string Cedúla { get => cedúla; set => cedúla = value; }
        public string Constraseña { get => constraseña; set => constraseña = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Teléfono { get => teléfono; set => teléfono = value; }
        public string Dirección { get => dirección; set => dirección = value; }
    }
}
