using ADO.Intergrupo.Maestros.ADO;
using ADO.Intergrupo.Maestros.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADO.Intergrupo.Negocio
{
    class EmpleadosBL
    {
        internal List<EmpleadosBack> ListaEmpleados()
        {
            return new EmpleadosADO().ListaEmpleados();
        }
        internal void CrearEmpleado(EmpleadosBack emp)
        {
            new EmpleadosADO().CrearEmpleado(emp);
        }
        internal EmpleadosBack BuscarEmpleado(string id)
        {
            return new EmpleadosADO().BuscarEmpleado(id);
        }
        internal void EditarEmpleado(EmpleadosBack emp)
        {
            new EmpleadosADO().EditarEmpleado(emp);
        }
        internal void EliminarEmpleado(string id)
        {
            new EmpleadosADO().EliminarEmpleado(id);
        }
    }
}
