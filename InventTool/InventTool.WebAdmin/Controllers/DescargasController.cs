using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.WebAdmin.Controllers
{
    public class DescargasController : Controller
    {
        DescargasBL _descargasBL;
        ToolUsersBL _toolUsersBL;
        public DescargasController()
        {
            _descargasBL = new DescargasBL();
            _toolUsersBL = new ToolUsersBL();
        }
        // GET: Descargas
        public ActionResult Index()
        {
            var ListadeDescargas = _descargasBL.ObtenerDescargas();
            return View(ListadeDescargas);
        }

        public ActionResult Crear()
        {
            var nuevaDescarga = new Descarga();
            var toolUsers = _toolUsersBL.ObtenerUsuarios();

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario");

            return View(nuevaDescarga);
        }
        [HttpPost]
        public ActionResult Crear (Descarga descarga)
        {
            if (ModelState.IsValid)
            {
                if (descarga.ToolUsersId == 0)
                {
                    ModelState.AddModelError("ToolUsersId", "Seleccione un Usuario");
                    return View(descarga);
                }
                _descargasBL.GuardarDescarga(descarga);
                return RedirectToAction("Index");
            }

            var toolUsers = _toolUsersBL.ObtenerUsuarios();

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario");

            return View(descarga);
        }

        public ActionResult Editar(int id)
        {
            var descarga = _descargasBL.ObtenerDescarga(id);
            var toolUsers = _toolUsersBL.ObtenerUsuarios();

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario", descarga.ToolUsersId);

            return View(descarga);
        }

        [HttpPost]
        public ActionResult Editar(Descarga descarga)
        {
            if (ModelState.IsValid)
            {
                if (descarga.ToolUsersId == 0)
                {
                    ModelState.AddModelError("ToolUsersId", "Seleccione un usuario");
                    return View(descarga);
                }

                _descargasBL.GuardarDescarga(descarga);

                return RedirectToAction("Index");
            }

            var toolUsers = _toolUsersBL.ObtenerUsuarios();

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario", descarga.ToolUsersId);

            return View(descarga);
        }

        public ActionResult Detalle(int id)
        {
            var descarga = _descargasBL.ObtenerDescarga(id);

            return View(descarga);
        }
    }
}