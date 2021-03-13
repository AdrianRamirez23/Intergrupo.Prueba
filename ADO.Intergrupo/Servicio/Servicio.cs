using ADO.Intergrupo.Maestros.Modelos;
using ADO.Intergrupo.Negocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Intergrupo.Servicio
{
    public class Servicio
    {
        public List<EmpleadosBack> ListaEmpleados()
        {
            return new EmpleadosBL().ListaEmpleados();
        }
        public void CrearEmpleado(EmpleadosBack emp)
        {
            new EmpleadosBL().CrearEmpleado(emp);
        }
        public EmpleadosBack BuscarEmpleado(string id)
        {
            return new EmpleadosBL().BuscarEmpleado(id);
        }
        public void EditarEmpleado(EmpleadosBack emp)
        {
            new EmpleadosBL().EditarEmpleado(emp);
        }
        public void EliminarEmpleado(string id)
        {
            new EmpleadosBL().EliminarEmpleado(id);
        }
        public List<UsuariosBack> ListarUsuarios()
        {
            return new UsuariosBL().ListarUsuarios();
        }
        public UsuariosBack BuscarUsuario(string Usuario)
        {
            return new UsuariosBL().BuscarUsuario(Usuario);
        }
        public UsuariosBack ValidarUsuario(string Usuario)
        {
            return new UsuariosBL().ValidarUsuario(Usuario);
        }
        public void CrearUsuario(UsuariosBack usr)
        {
            new UsuariosBL().CrearUsuario(usr);
        }
    }
}
