using ADO.Intergrupo.Maestros.ADO;
using ADO.Intergrupo.Maestros.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Intergrupo.Negocio
{
    class UsuariosBL
    {
        internal List<UsuariosBack> ListarUsuarios()
        {
            return new UsuariosADO().ListarUsuarios();
        }
        internal UsuariosBack BuscarUsuario(string Usuario)
        {
            return new UsuariosADO().BuscarUsuario(Usuario);
        }
        internal UsuariosBack ValidarUsuario(string Usuario)
        {
            return new UsuariosADO().ValidarUsuario(Usuario);
        }
        internal void CrearUsuario(UsuariosBack usr)
        {
            new UsuariosADO().CrearUsuario(usr);
        }
    }
}
