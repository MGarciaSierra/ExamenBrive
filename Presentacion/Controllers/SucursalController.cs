using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
      
        public ActionResult Mostrar() 
        {
            Atributos.Sucursal sucursal = new Atributos.Sucursal();
            Atributos.Result result = LogicaNegocio.Sucursal.MostrarTodo();
            if (result.Correct)
            {
                sucursal.Sucursales = result.Objects;
                return View(sucursal);
            }
            else
            {
                ViewBag.Message = "Ocurrio un Error";
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Formulario(int? IdSucursal)
        {
            Atributos.Sucursal sucursal = new Atributos.Sucursal();
            Atributos.Result result = new Atributos.Result();

            if (IdSucursal == null)
            {

                return View(sucursal);
            }
            else
            {

                result = LogicaNegocio.Sucursal.MostrarUno(IdSucursal.Value);
                if (result.Correct)
                {
                    sucursal = (Atributos.Sucursal)result.Object;

                    return View(sucursal);
                }
            }
            return PartialView("Modal");
        }

        [HttpPost]
        public ActionResult Formulario(Atributos.Sucursal sucursal)
        {
            Atributos.Result result = new Atributos.Result();
     
            if (sucursal.IdSucursal == 0)
            {
                result = LogicaNegocio.Sucursal.Agregar(sucursal);
                if (result.Correct)
                {
                    ViewBag.Message = "Sucursal Ingresada Correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al Registrar la nueva Sucursal";
                }
            }
            else
            {
                result = LogicaNegocio.Sucursal.Actualizar(sucursal);
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

        public ActionResult Eliminar(int IdSucursal)
        {
            Atributos.Result result = LogicaNegocio.Sucursal.Eliminar(IdSucursal);
            if (result.Correct)
            {
                ViewBag.Message = "Sucursal Eliminada Correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un Error al Eliminar la Sucursal";
            }
            return PartialView("Modal");
        }
    }
}