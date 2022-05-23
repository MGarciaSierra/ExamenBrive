using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class VentaController : Controller
    {
		// GET: Venta
		[HttpGet]
		public ActionResult MostrarProductos() //Muestra los Productos que el usuario puede comprar
		{

			Atributos.Result result = LogicaNegocio.Producto.MostrarTodo(); //LLama a al metodo de productos para mostrar todos los productos existentes
			Atributos.Producto producto = new Atributos.Producto(); //Nueva instanci de Producto

			if (result.Correct)
			{
			    producto.Productos = result.Objects; //Unboxing de todos los productos
				return View(producto); //Mandamos a la vista la lista de objetos de productos
			}
			else
			{
				ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage; //Mensaje de Error
				return PartialView("Modal"); //Vista modal en caso de algun Error
			}

		}

		[HttpGet]
		public ActionResult Carrito(int? IdProducto)   //Metodo Carrito puede recibir un IdProducto o no
		{
			Atributos.Result result = new Atributos.Result();
			result.Objects = new List<object>();
			if (IdProducto != null)     //si IdProducto viene en null
			{
				if (Session["Carrito"] == null)  //Si el carrito no tiene productos agregados
				{

					Atributos.DetalleVenta  ventaProducto = new Atributos.DetalleVenta(); 

					ventaProducto.Producto = new Atributos.Producto();
					ventaProducto.Producto.IdProducto = IdProducto.Value; //Evaluar el del Producto

					ventaProducto.Cantidad = 1; //Inicializar Cantidad 

					Atributos.Result resultProducto = LogicaNegocio.Producto.MostrarUno(IdProducto.Value); //Traer los datos de el producto selccionado en el carrito

					if (resultProducto.Correct)
					{
						ventaProducto.Producto = (Atributos.Producto)resultProducto.Object; //Unboxing de los datos del producto selccionado

						result.Objects.Add(ventaProducto); //Mandar los datos a la vista
					}

					Session["Carrito"] = result.Objects;
				}

				else //En caso que el carrito tenga ya productos selccionados
				{
					result.Objects = (List<Object>)Session["Carrito"];

					bool Existe = false;
					var indice = 0;

					foreach (Atributos.DetalleVenta ventaProducto in result.Objects) //Recorrer los productos selccionados
					{
						if (ventaProducto.Producto.IdProducto == IdProducto)
						{
							Existe = true;
							indice = result.Objects.IndexOf(ventaProducto);

						}
					}

					if (Existe == true) //Si  existe el producto en el carrito
					{
						foreach (Atributos.DetalleVenta ventaProducto in result.Objects)
						{
							ventaProducto.Cantidad = ventaProducto.Cantidad + 1; //Aumentar 1 a la cantidad de el producto
						}
					}
					else //En caso de que no este seleccionado en el carrito 
					{

						Atributos.DetalleVenta ventaProducto = new Atributos.DetalleVenta();

						ventaProducto.Producto = new Atributos.Producto();
						ventaProducto.Producto.IdProducto = IdProducto.Value;
						ventaProducto.Cantidad = 1;


						Atributos.Result resultProducto = LogicaNegocio.Producto.MostrarUno(IdProducto.Value);

						if (resultProducto.Correct)
						{
							ventaProducto.Producto = (Atributos.Producto)resultProducto.Object;

							result.Objects.Add(ventaProducto); //Mandara los datos del nuevo producto al carrito

						}

						Session["Carrito"] = result.Objects;

					}

				}
			}

			return View(result);
		}

		public ActionResult Sumar(int IdProducto)
		{
			Atributos.Result result = new Atributos.Result();

			result.Objects = (List<Object>)Session["Carrito"];//Unboxing de la lista

			foreach (Atributos.DetalleVenta ventaProducto in result.Objects) //para comparar
			{
				if (ventaProducto.Producto.IdProducto == IdProducto)
				{

					ventaProducto.Cantidad += 1;//Aumenta la cantidad en 1

				}
			}
			return View("Carrito", result);
		} // Metodo que le agrega 1 a la Cantidad del producto en la lista de Venta 

		public ActionResult Restar(int IdProducto)
		{
			Atributos.Result result = new Atributos.Result();

			result.Objects = (List<Object>)Session["Carrito"];//Unboxing de la Lista en el Carrito

			foreach (Atributos.DetalleVenta ventaProducto in result.Objects) 
			{

				if (ventaProducto.Producto.IdProducto == IdProducto)
				{
					ventaProducto.Cantidad -= 1; //Resta uno a la cantidad mostrada en el carrito
				}
			}
			return View("Carrito", result);
		}

		public ActionResult Eliminar(int IdProducto) //Eliminar producto seleccionado del Carrito
		{
			Atributos.Result result = new Atributos.Result();
			result.Objects = (List<Object>)Session["Carrito"];

			var indice = 0; 

			foreach (Atributos.DetalleVenta ventaProducto in result.Objects)
			{
				if (ventaProducto.Producto.IdProducto == IdProducto)
				{

					indice = result.Objects.IndexOf(ventaProducto);

				}
			}

			result.Objects.RemoveAt(indice);
			Session["Carrito"] = result.Objects;

			return View("Carrito", result);
		}

		public decimal GetTotal(List<object> Objects) //Calcular la Cantidad Total de Precio de los Prodcutos Seleccionados
		{
			decimal Total = 0;

			foreach (Atributos.DetalleVenta ventaProducto in Objects)
			{
				Total += ventaProducto.Producto.Precio * ventaProducto.Cantidad;
			}

			return Total;
		} 
		public ActionResult Procesar() //Realizar el Proceso de la Compra
		{

			Atributos.Result result = new Atributos.Result();
			result.Objects = (List<Object>)Session["Carrito"];

			Atributos.Venta venta = new Atributos.Venta();

			venta.Usuario = new Atributos.Usuario();
			venta.Usuario.IdUsuario = 1;

			venta.MetodoPago = new Atributos.MetodoPago();
			venta.MetodoPago.IdMetodoPago = 1;

			venta.Total = GetTotal(result.Objects);

			result = LogicaNegocio.Venta.Agregar(venta, result.Objects);


			return RedirectToAction("Mostrar","DetalleVenta", new { IdVenta = venta.IdVenta });
			Session.Clear();

		} 

		public ActionResult ModalCompra()  //Modal de Confirmacion de Compra
		{
			
			ViewBag.Message = "¿Deseas Finalizar tu compra?";
			return PartialView("Modal");
		}

	}
}