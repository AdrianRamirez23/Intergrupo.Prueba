using ADO.Intergrupo.Maestros.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.Intergrupo.Maestros.ADO
{
    class EmpleadosADO
    {
        readonly string conexion = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Intergrupo;Data Source=medti8";

        internal List<EmpleadosBack> ListaEmpleados()
        {
            try
            {
                List<EmpleadosBack> emps = new List<EmpleadosBack>();
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Empleados_CRUD 1,'','','','','','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmpleadosBack emp = new EmpleadosBack();
                        emp.idEmpleado= rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                        emp.NombreEmpleado= rdr[1] == DBNull.Value ? "" : rdr.GetString(1);
                        emp.ApellidoEmpleado= rdr[2] == DBNull.Value ? "" : rdr.GetString(2);
                        emp.Email= rdr[3] == DBNull.Value ? "" : rdr.GetString(3);
                        emp.DocIdent= rdr[4] == DBNull.Value ? "" : rdr.GetString(4);
                        emp.Cargo= rdr[5] == DBNull.Value ? "" : rdr.GetString(5);
                        emp.Estado= rdr[6] == DBNull.Value ? false : rdr.GetBoolean(6);
                        emps.Add(emp);
                    }
                    return emps;
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        internal EmpleadosBack BuscarEmpleado(string id)
        {
            try
            {
                EmpleadosBack emp = new EmpleadosBack();
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Empleados_CRUD 2,'','','','','" + id + "','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        emp.idEmpleado = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                        emp.NombreEmpleado = rdr[1] == DBNull.Value ? "" : rdr.GetString(1);
                        emp.ApellidoEmpleado = rdr[2] == DBNull.Value ? "" : rdr.GetString(2);
                        emp.Email = rdr[3] == DBNull.Value ? "" : rdr.GetString(3);
                        emp.DocIdent = rdr[4] == DBNull.Value ? "" : rdr.GetString(4);
                        emp.Cargo = rdr[5] == DBNull.Value ? "" : rdr.GetString(5);
                        emp.Estado = rdr[6] == DBNull.Value ? false : rdr.GetBoolean(6);
                       
                    }
                    return emp;
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        internal void CrearEmpleado(EmpleadosBack emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Empleados_CRUD 5,'','" + emp.NombreEmpleado + "','" + emp.ApellidoEmpleado + "','" + emp.Email + "','" + emp.DocIdent + "','" + emp.Cargo + "','" + emp.Estado + "'";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        internal void EditarEmpleado(EmpleadosBack emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Empleados_CRUD 3,'','" + emp.NombreEmpleado + "','" + emp.ApellidoEmpleado + "','" + emp.Email + "','" + emp.DocIdent + "','" + emp.Cargo + "','" + emp.Estado + "'";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        internal void EliminarEmpleado(string id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Empleados_CRUD 4,'','','','','" + id + "','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
    }
}
