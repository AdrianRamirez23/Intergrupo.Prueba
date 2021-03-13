using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Intergrupo.Maestros.Modelos
{
    public class EmpleadosBack
    {
        public int idEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string Email { get; set; }
        public string DocIdent { get; set; }
        public string Cargo { get; set; }
        public bool Estado { get; set; }
    }
}
