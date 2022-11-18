using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.WebAdmin.Controllers
{
    public class ToolUsersController : Controller
    {
         ToolUsersBL _toolUsersBL;

        public ToolUsersController()
        {
            _toolUsersBL = new ToolUsersBL();
        }

        // GET: Usuarios
        public ActionResult Index()
        {

            var listadeUsuarios = _toolUsersBL.ObtenerUsuarios();

            return View(listadeUsuarios);
        }

        public ActionResult Crear()
        {
            var nuevoToolUser = new ToolUsers();

            return View(nuevoToolUser);
        }
        [HttpPost]
        public ActionResult Crear(ToolUsers toolUsers)
        {

            if (ModelState.IsValid)
            {
                if (toolUsers.NombreUsuario != toolUsers.NombreUsuario.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No dejar espacios al inicio, ni al final");
                    return View(toolUsers);
                }

                _toolUsersBL.GuardarUsuarios(toolUsers);
                return RedirectToAction("Index");

            }
            else
            {
                return View(toolUsers);
            }
        }

        public ActionResult Editar(int id)
        {
            var toolUsers = _toolUsersBL.ObtenerUsuarios(id);
            return View(toolUsers);
        }

        [HttpPost]
        public ActionResult Editar(ToolUsers toolUsers)
        {
            if (ModelState.IsValid)
            {
                if (toolUsers.NombreUsuario != toolUsers.NombreUsuario.Trim())
                {
                    ModelState.AddModelError("NombreUsuario", "No dejar espacios al inicio, ni al final");
                    return View(toolUsers);
                }

                _toolUsersBL.GuardarUsuarios(toolUsers);
                return RedirectToAction("Index");

            }
            else
            {
                return View(toolUsers);
            }
        }

        public ActionResult Detalle(int id)
        {
            var toolUsers = _toolUsersBL.ObtenerUsuarios(id);
            return View(toolUsers);
        }


        public ActionResult Eliminar(int id)
        {
            var toolUsers = _toolUsersBL.ObtenerUsuarios(id);
            return View(toolUsers);
        }

        [HttpPost]
        public ActionResult Eliminar(ToolUsers toolUsers)
        {
            _toolUsersBL.EliminarUsuarios(toolUsers.Id);
            return RedirectToAction("Index");
        }

    }
}