using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Intergrupo.Models
{
    public class Login
    {
        [Required(ErrorMessage="Usuario es obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Contraseña es obligatorio")]
        public string Contrasena { get; set; }
    }
}
