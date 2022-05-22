using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Usuario
    {
        //
        public static Atributos.Result Agregar(Atributos.Usuario usuario)
        {

            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "UsuarioAgregar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[5];
                        collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[0].Value = usuario.UserName;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                        collection[4].Value = usuario.FechaNacimiento;

                        cmd.Parameters.AddRange(collection);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }

                }

            }
            catch (System.Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static Atributos.Result MostrarTodo()
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "UsuarioMostrarTodo";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();


                        DataTable UsuarioTable = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(UsuarioTable);

                        if (UsuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in UsuarioTable.Rows)
                            {
                                Atributos.Usuario usuario = new Atributos.Usuario();


                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.UserName = row[1].ToString();
                                usuario.Nombre = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                usuario.FechaNacimiento = (row[5].ToString());

                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = true;
                           
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;

                result.Ex = ex;
            }

            return result;
        }
        public static Atributos.Result MostrarUno(int IdUsuario)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "UsuarioMostrarUno";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {

                            DataRow row = usuarioTable.Rows[0];
                            Atributos.Usuario usuario = new Atributos.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();      
                            usuario.FechaNacimiento = (row[5].ToString());
                         
                            result.Object = usuario;

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error!!!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static Atributos.Result Actualizar(Atributos.Usuario usuario)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "UsuarioActualizar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();


                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[1].Value = usuario.UserName;

                        collection[2] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[2].Value = usuario.Nombre;

                        collection[3] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;

                        collection[4] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[4].Value = usuario.ApellidoMaterno;

                        collection[5] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                        collection[5].Value = usuario.FechaNacimiento;

                        cmd.Parameters.AddRange(collection);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
            }
            return result;
        }

        public static Atributos.Result Eliminar(int IdUsuario)
        {

            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "UsuarioEliminar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }

                }

            }
            catch (System.Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

    }
}
