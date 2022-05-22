using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        } //Convertir Imagen a Bytes para poder insertarla en la Base de Datos
        public ActionResult Mostrar() //Mostrar Todos los productos Existentes en la Base de Datos
        {
            Atributos.Producto producto = new Atributos.Producto();
            Atributos.Result result = LogicaNegocio.Producto.MostrarTodo();
            if (result.Correct)
            {
                producto.Productos = result.Objects;
                return View(producto);
            }
            else
            {
                ViewBag.Message = "Ocurrio un Error";
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Formulario(int? IdProducto) 
        {
            Atributos.Producto producto = new Atributos.Producto();
            Atributos.Result result = new Atributos.Result();

            if (IdProducto == null)
            {
                
                return View(producto);
            }
            else
            {

                result = LogicaNegocio.Producto.MostrarUno(IdProducto.Value);
                if (result.Correct)
                {
                    producto = (Atributos.Producto)result.Object;

                    return View(producto);
                }
            }
            return PartialView("Modal");
        }

        [HttpPost]
        public ActionResult Formulario(Atributos.Producto producto)
        {
            Atributos.Result result = new Atributos.Result();
            HttpPostedFileBase file = Request.Files["ImagenData"];

            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBytes(file);
            }


            if (producto.IdProducto == 0)
            {
                result = LogicaNegocio.Producto.Agregar(producto);
                if (result.Correct)
                {
                    ViewBag.Message = "Producto Ingresado Correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al Registrar el Producto";
                }
            }
            else
            {
                result = LogicaNegocio.Producto.Actualizar(producto);
                if (result.Correct)
                {
                    ViewBag.Message = "Actualizacion Exitosa";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al Actualizar";
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Eliminar(int IdProducto)
        {
            Atributos.Result result = LogicaNegocio.Producto.Eliminar(IdProducto);
            if (result.Correct)
            {
                ViewBag.Message = "Producto Eliminado Correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un Error al Eliminar el Producto";
            }
            return PartialView("Modal");
        }
    }
}