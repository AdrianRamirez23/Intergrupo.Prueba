using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Intergrupo.Maestros.Modelos
{
    public class UsuariosBack
    {
        public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string TipoUsuario { get; set; }
        public bool Estado { get; set; }
    }
}
