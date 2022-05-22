using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Mostrar()
        {
            Atributos.Usuario usuario = new Atributos.Usuario();
            Atributos.Result result = LogicaNegocio.Usuario.MostrarTodo();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al encontrar los datos";
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Formulario(int? IdUsuario)
        {
            Atributos.Usuario usuario = new Atributos.Usuario();
            Atributos.Result result = new Atributos.Result();

            if (IdUsuario == null)
            {
                return View();
            }
            else
            {

                result = LogicaNegocio.Usuario.MostrarUno(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (Atributos.Usuario)result.Object;

                    return View(usuario);
                }
            }
            return PartialView("Modal");
        }

        [HttpPost]

        public ActionResult Formulario(Atributos.Usuario usuario)
        {
            Atributos.Result result = new Atributos.Result();


            if (usuario.IdUsuario == 0)
            {
                result = LogicaNegocio.Usuario.Agregar(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = "Usuario Ingresado Correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al ingresar al nuevo Usuario";
                }
            }
            else
            {
                result = LogicaNegocio.Usuario.Actualizar(usuario);
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


        public ActionResult Eliminar(int IdUsuario)
        {
            Atributos.Result result = LogicaNegocio.Usuario.Eliminar(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Message = "El usuario se elimno correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar al usuario";
            }
            return PartialView("Modal");
        }
    }
}