using ADO.Intergrupo.Maestros.Modelos;
using ADO.Intergrupo.Servicio;
using ApiRest.Intergrupo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Intergrupo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmpleadosController : Controller
    {
        [HttpGet]
        public IEnumerable<Empleados> Get()
        {
            List<Empleados> emps = new List<Empleados>();
            List<EmpleadosBack> empsBck = new List<EmpleadosBack>();

            empsBck = new Servicio().ListaEmpleados();

            foreach (EmpleadosBack epmBack in empsBck)
            {
                Empleados emp = new Empleados();
                emp.idEmpleado = epmBack.idEmpleado;
                emp.NombreEmpleado = epmBack.NombreEmpleado;
                emp.ApellidoEmpleado = epmBack.ApellidoEmpleado;
                emp.Email = epmBack.Email;
                emp.DocIdent = epmBack.DocIdent;
                emp.Cargo = epmBack.Cargo;
                emp.Estado = epmBack.Estado;
                emps.Add(emp);
            }
            return (emps);
        }
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            EmpleadosBack epmBack = new Servicio().BuscarEmpleado(id);

            if (string.IsNullOrEmpty(epmBack.NombreEmpleado))
            {
                return NotFound();
            }
            else
            {
                Empleados emp = new Empleados();
                emp.idEmpleado = epmBack.idEmpleado;
                emp.NombreEmpleado = epmBack.NombreEmpleado;
                emp.ApellidoEmpleado = epmBack.ApellidoEmpleado;
                emp.Email = epmBack.Email;
                emp.DocIdent = epmBack.DocIdent;
                emp.Cargo = epmBack.Cargo;
                emp.Estado = epmBack.Estado;

                return Ok(emp);
            }
        }
        [HttpPost]
        public ActionResult Post(Models.Empleados emp)
        {
            if (ModelState.IsValid)
            {
                EmpleadosBack empBack = new EmpleadosBack();

                empBack.idEmpleado = emp.idEmpleado;
                empBack.NombreEmpleado = emp.NombreEmpleado;
                empBack.ApellidoEmpleado = emp.ApellidoEmpleado;
                empBack.Email = emp.Email;
                empBack.DocIdent = emp.DocIdent;
                empBack.Cargo = emp.Cargo;
                empBack.Estado = emp.Estado;

                new Servicio().CrearEmpleado(empBack);

                return Created($"Empleados/{emp.DocIdent}", emp);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, Empleados emp)
        {
            EmpleadosBack empBack = new Servicio().BuscarEmpleado(id);

            if (empBack.DocIdent == emp.DocIdent)
            {
                empBack.idEmpleado = emp.idEmpleado;
                empBack.NombreEmpleado = emp.NombreEmpleado;
                empBack.ApellidoEmpleado = emp.ApellidoEmpleado;
                empBack.Email = emp.Email;
                empBack.DocIdent = emp.DocIdent;
                empBack.Cargo = emp.Cargo;
                empBack.Estado = emp.Estado;
                new Servicio().EditarEmpleado(empBack);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            EmpleadosBack empBakc = new Servicio().BuscarEmpleado(id);

            if  (!string.IsNullOrEmpty(empBakc.DocIdent))
            {
                new Servicio().EliminarEmpleado(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
