using ADO.Intergrupo.Maestros.Modelos;
using ADO.Intergrupo.Servicio;
using ApiRest.Intergrupo.Models;
using ApiRest.Intergrupo.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ApiRest.Intergrupo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public IConfiguration Configuration;
        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpPost]
        public IActionResult Post(Login log )
        {
            if (ModelState.IsValid)
            {
                UsuariosBack userBack = new Servicio().BuscarUsuario(log.Usuario);

                if (string.IsNullOrEmpty(userBack.Usuario))
                {
                    return NotFound("El usuario no existe");
                }

                string cont = new Utils().DesEncriptar(userBack.Contrasena);
                if (cont == log.Contrasena)
                {
                    var secretKey = Configuration.GetValue<string>("SecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, log.Usuario));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddHours(4),
                        SigningCredentials =new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                    var bearer_token=  JsonConvert.SerializeObject(tokenHandler.WriteToken(createdToken));

                    return Ok(bearer_token );
                }
                else
                {
                    return Forbid();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
