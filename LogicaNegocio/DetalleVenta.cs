using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class DetalleVenta
    {
        public static Atributos.Result Agregar(Atributos.DetalleVenta detalleVenta)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(AccesoDatos.Conexion.GetConnectionString()))
                {
                    string query = "AgregarDetalleventa";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdVenta", SqlDbType.Int);
                        collection[0].Value = detalleVenta.Venta.IdVenta;

                        collection[1] = new SqlParameter("IdSucursal", SqlDbType.Int);
                        collection[1].Value = detalleVenta.Sucursal.IdSucursal;

                        collection[2] = new SqlParameter("Cantidad", SqlDbType.Decimal);
                        collection[2].Value = detalleVenta.Cantidad;

                        collection[3] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[3].Value = detalleVenta.Producto.IdProducto;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla VentaProducto";
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


        public static Atributos.Result DetalleVentaIdVenta(int IdVenta)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (AccesoDatos.BriveSucursalEntitiest context = new AccesoDatos.BriveSucursalEntitiest())
                {
                    var query = context.DetalleVentaIdVenta(IdVenta).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {

                            Atributos.DetalleVenta ventaProducto = new Atributos.DetalleVenta();

                            ventaProducto.IdDetalleVenta = obj.IdDetalleVenta;
                            ventaProducto.Venta = new Atributos.Venta();
                            ventaProducto.Venta.IdVenta = obj.IdVenta.Value;
                            ventaProducto.Cantidad = obj.Cantidad.Value;
                            ventaProducto.Producto = new Atributos.Producto();
                            ventaProducto.Producto.IdProducto = obj.IdProducto.Value;
                            ventaProducto.Producto.Nombre = obj.Nombre;
                            ventaProducto.Producto.Precio = obj.Precio.Value;
                            ventaProducto.Producto.Descripcion = obj.Descripcion;
                            ventaProducto.Producto.Imagen = obj.Imagen;
                            ventaProducto.Venta.Total = obj.Total.Value;

                            result.Objects.Add(ventaProducto);

                        }
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Venta";
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

