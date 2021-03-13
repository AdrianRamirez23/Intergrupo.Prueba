using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Intergrupo.Models
{
    public class Usuarios
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "Usuario es obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Contrasena es obligatorio")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "TipoUsuario es obligatorio")]
        public string TipoUsuario { get; set; }
        [Required(ErrorMessage = "Estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
