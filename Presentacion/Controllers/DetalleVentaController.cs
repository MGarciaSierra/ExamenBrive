using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class DetalleVentaController : Controller
    {
        // GET: DetalleVenta
       
        public ActionResult Mostrar(int IdVenta)
        {
           
            Atributos.DetalleVenta ventaProducto = new Atributos.DetalleVenta();
            Atributos.Result result = LogicaNegocio.DetalleVenta.DetalleVentaIdVenta(IdVenta);
            
            Atributos.Result resultStock = new Atributos.Result();
            
            if (result.Correct)
            {
                ventaProducto.DetalleVentas = result.Objects;
                return View("Detalle", ventaProducto);
               
            }

            else
            {
                ViewBag.Message = "Ocurrio un error al traer la informacion" + result.ErrorMessage;
            }

            return View("Detalle", ventaProducto);
        }
    }
}