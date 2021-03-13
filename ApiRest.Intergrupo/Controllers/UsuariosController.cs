using ADO.Intergrupo.Maestros.Modelos;
using ADO.Intergrupo.Servicio;
using ApiRest.Intergrupo.Models;
using ApiRest.Intergrupo.Utilidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Intergrupo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        [HttpPost]
        public ActionResult Post(Usuarios user)
        {
            if (ModelState.IsValid)
            {
                UsuariosBack userBack = new Servicio().ValidarUsuario(user.Usuario);

                if (string.IsNullOrEmpty(userBack.Usuario))
                {
                    return BadRequest("Para registrar un usuario antes debe ser registrado como empleado");
                }
                else
                {
                    string Contr = new Utils().Encriptar(user.Contrasena);

                    userBack.Usuario = user.Usuario;
                    userBack.Contrasena = Contr;
                    userBack.TipoUsuario = user.TipoUsuario;
                    userBack.Estado = user.Estado;

                    new Servicio().CrearUsuario(userBack);
                    return Created($"/Usuario/{userBack.Usuario}", user);
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            List<Usuarios> Urs = new List<Usuarios>();
            List<UsuariosBack> UrsBack = new List<UsuariosBack>();

            UrsBack = new Servicio().ListarUsuarios();

            foreach (UsuariosBack UrBack in UrsBack)
            {
                Usuarios usr = new Usuarios();
                usr.idUsuario = UrBack.idUsuario;  
                usr.Usuario = UrBack.Usuario;  
                usr.Contrasena = UrBack.Contrasena;  
                usr.TipoUsuario = UrBack.TipoUsuario;  
                usr.Estado = UrBack.Estado;
                Urs.Add(usr);
            }
            return (Urs);
        }
        [HttpGet("{User}")]
        public ActionResult Get(string User)
        {
            if(!string.IsNullOrEmpty(User) )
            {
                UsuariosBack UrBack = new Servicio().BuscarUsuario(User);
                Usuarios usr = new Usuarios();
                usr.idUsuario = UrBack.idUsuario;
                usr.Usuario = UrBack.Usuario;
                usr.Contrasena = UrBack.Contrasena;
                usr.TipoUsuario = UrBack.TipoUsuario;
                usr.Estado = UrBack.Estado;
                return Ok(usr);
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
