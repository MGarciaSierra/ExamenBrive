using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Venta
    {
        public static Atributos.Result Agregar(Atributos.Venta venta, List<object> Objects)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = "AgregarVenta";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = venta.Usuario.IdUsuario;

                        collection[1] = new SqlParameter("Total", SqlDbType.Decimal);
                        collection[1].Value = venta.Total;

                        collection[2] = new SqlParameter("IdMetodoPago", SqlDbType.Int);
                        collection[2].Value = venta.MetodoPago.IdMetodoPago;

                        collection[3] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[3].Direction = ParameterDirection.Output;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                       
                        venta.IdVenta = Convert.ToInt32(cmd.Parameters["IdVenta"].Value);

                        foreach (Atributos.DetalleVenta ventaProducto in Objects)
                        {
                            ventaProducto.Venta = new Atributos.Venta();
                            ventaProducto.Venta.IdVenta = venta.IdVenta;
                            ventaProducto.Sucursal = new Atributos.Sucursal();
                            ventaProducto.Sucursal.IdSucursal = 1;

                            DetalleVenta.Agregar(ventaProducto);
                        }

                        if (RowsAffected > 0)
                        {

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al insertar el registro Venta";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }

    }
}

