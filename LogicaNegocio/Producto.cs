using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Producto
    {
      
       
        public static Atributos.Result Actualizar(Atributos.Producto producto)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (AccesoDatos.BriveSucursalEntities context = new AccesoDatos.BriveSucursalEntities())
                {
                    var query = context.ProductoActualizar(producto.IdProducto,producto.Nombre, producto.Descripcion, producto.Precio,producto.Imagen, producto.Stock);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
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
                using (AccesoDatos.BriveSucursalEntities context = new AccesoDatos.BriveSucursalEntities())
                {
                    var query = context.ProductoMostrarTodo().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            Atributos.Producto producto = new Atributos.Producto();

                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Descripcion = obj.Descripcion;
                            producto.Precio = obj.Precio.Value;
                            producto.Imagen = obj.Imagen;
                            producto.Stock = obj.Stock.Value;
                            result.Objects.Add(producto);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static Atributos.Result Agregar(Atributos.Producto producto)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (AccesoDatos.BriveSucursalEntities context = new AccesoDatos.BriveSucursalEntities())
                {
                    var query = context.ProductoAgregar(producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagen, producto.Stock);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static Atributos.Result MostrarUno(int IdProducto)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (AccesoDatos.BriveSucursalEntities context = new AccesoDatos.BriveSucursalEntities())
                {
                    var obj = context.ProductoMostrarUno(IdProducto).FirstOrDefault();

                  

                    if (obj != null)
                    {
                        
                       Atributos.Producto producto = new Atributos.Producto();

                       producto.IdProducto = obj.IdProducto;
                       producto.Nombre = obj.Nombre;
                       producto.Descripcion = obj.Descripcion;
                       producto.Precio = obj.Precio.Value;
                       producto.Imagen = obj.Imagen;
                       producto.Stock = obj.Stock.Value;

                       result.Object = producto;
                        

                       result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Atributos.Result Eliminar(int IdProducto)
        {
            Atributos.Result result = new Atributos.Result();
            try
            {
                using (AccesoDatos.BriveSucursalEntities context = new AccesoDatos.BriveSucursalEntities())
                {
                    var query = context.ProductoEliminar(IdProducto);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


    }
}
