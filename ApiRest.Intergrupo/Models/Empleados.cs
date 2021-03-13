using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Intergrupo.Models
{
    public class Empleados
    {
        public int idEmpleado { get; set; }
        [Required(ErrorMessage="NombreEmpleado es obligatorio")]
        public string NombreEmpleado { get; set; }
        [Required(ErrorMessage = "ApellidoEmpleado es obligatorio")]
        public string ApellidoEmpleado { get; set; }
        [Required(ErrorMessage = "Email es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "DocIdent es obligatorio")]
        public string DocIdent { get; set; }
        [Required(ErrorMessage = "Cargo es obligatorio")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
