using ADO.Intergrupo.Maestros.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.Intergrupo.Maestros.ADO
{
    class UsuariosADO
    {
        readonly string conexion = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Intergrupo;Data Source=medti8";

        internal List<UsuariosBack> ListarUsuarios()
        {
            try
            {
                List<UsuariosBack> Urs = new List<UsuariosBack>();
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Usuarios_CRUD 1,'','','','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        UsuariosBack usr = new UsuariosBack();
                        usr.idUsuario = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                        usr.Usuario = rdr[1] == DBNull.Value ? "" : rdr.GetString(1);
                        usr.Contrasena = rdr[2] == DBNull.Value ? "" : rdr.GetString(2);
                        usr.TipoUsuario = rdr[3] == DBNull.Value ? "" : rdr.GetString(3);
                        usr.Estado = rdr[4] == DBNull.Value ? false : rdr.GetBoolean(4);
                      
                        Urs.Add(usr);
                    }
                    return Urs;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        internal UsuariosBack BuscarUsuario(string Usuario)
        {
            try
            {
                UsuariosBack usr = new UsuariosBack();
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Usuarios_CRUD 2,'','"+Usuario+"','','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        usr.idUsuario = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                        usr.Usuario = rdr[1] == DBNull.Value ? "" : rdr.GetString(1);
                        usr.Contrasena = rdr[2] == DBNull.Value ? "" : rdr.GetString(2);
                        usr.TipoUsuario = rdr[3] == DBNull.Value ? "" : rdr.GetString(3);
                        usr.Estado = rdr[4] == DBNull.Value ? false : rdr.GetBoolean(4);
                    }
                    return usr;
                }
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        internal UsuariosBack ValidarUsuario(string Usuario)
        {
            try
            {
                UsuariosBack usr = new UsuariosBack();
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Usuarios_CRUD 6,'','" + Usuario + "','','',''";
                    SqlCommand cmd = new SqlCommand(sentencia, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        usr.idUsuario = rdr[0] == DBNull.Value ? 0 : rdr.GetInt32(0);
                        usr.Usuario = rdr[1] == DBNull.Value ? "" : rdr.GetString(1);
                        usr.Contrasena = rdr[2] == DBNull.Value ? "" : rdr.GetString(2);
                        usr.TipoUsuario = rdr[3] == DBNull.Value ? "" : rdr.GetString(3);
                        usr.Estado = rdr[4] == DBNull.Value ? false : rdr.GetBoolean(4);
                    }
                    return usr;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        internal void CrearUsuario(UsuariosBack usr)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    string sentencia = "Usuarios_CRUD 5,'','" + usr.Usuario + "','"+usr.Contrasena+"','"+usr.TipoUsuario+"','"+usr.Estado+"'";
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
