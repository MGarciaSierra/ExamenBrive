using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Sucursal
    {
        public static Atributos.Result Agregar(Atributos.Sucursal sucursal)
        {

            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "SucursalAgregar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[3];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = sucursal.Nombre;

                        collection[1] = new SqlParameter("Direccion", SqlDbType.VarChar);
                        collection[1].Value = sucursal.Direccion;

                        collection[2] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[2].Value = sucursal.Telefono;


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
                        cmd.CommandText = "SucursalMostrar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();


                        DataTable SucursalTable = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(SucursalTable);

                        if (SucursalTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in SucursalTable.Rows)
                            {
                                Atributos.Sucursal sucursal = new Atributos.Sucursal();


                                sucursal.IdSucursal = int.Parse(row[0].ToString());
                                sucursal.Nombre = row[1].ToString();
                                sucursal.Direccion = row[2].ToString();
                                sucursal.Telefono = row[3].ToString();
                                
                                result.Objects.Add(sucursal);
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

        public static Atributos.Result MostrarUno(int IdSucursal)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "SucursalMostrarUno";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdSucursal", SqlDbType.Int);
                        collection[0].Value = IdSucursal;

                        cmd.Parameters.AddRange(collection);

                        DataTable sucursalTable = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(sucursalTable);

                        if (sucursalTable.Rows.Count > 0)
                        {

                            DataRow row = sucursalTable.Rows[0];
                            Atributos.Sucursal sucursal = new Atributos.Sucursal();


                            sucursal.IdSucursal = int.Parse(row[0].ToString());
                            sucursal.Nombre = row[1].ToString();
                            sucursal.Direccion = row[2].ToString();
                            sucursal.Telefono = row[3].ToString();


                            result.Object = sucursal;

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

        public static Atributos.Result Actualizar(Atributos.Sucursal sucursal)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "SucursalActualizar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();


                        SqlParameter[] collection = new SqlParameter[4];
                        collection[0] = new SqlParameter("IdSucursal", SqlDbType.Int);
                        collection[0].Value = sucursal.IdSucursal;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = sucursal.Nombre;

                        collection[2] = new SqlParameter("Direccion", SqlDbType.VarChar);
                        collection[2].Value = sucursal.Direccion;

                        collection[3] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[3].Value = sucursal.Telefono;


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

        public static Atributos.Result Eliminar(int IdSucursal)
        {

            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "SucursalEliminar";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdSucursal", SqlDbType.Int);
                        collection[0].Value = IdSucursal;

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
