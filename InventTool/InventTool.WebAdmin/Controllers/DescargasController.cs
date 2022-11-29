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
        HerramentalBL _herramentalBL;
        public DescargasController()
        {
           
            _descargasBL = new DescargasBL();
            _toolUsersBL = new ToolUsersBL();
            _herramentalBL = new HerramentalBL();
        }
        // GET: Descargas
        public ActionResult Index()
        {
            
            var ListadeDescargas = _descargasBL.ObtenerDescargas();
          
            //var ListadeDescargasDetalle = _descargasBL.ObtenerDescargaDetalle();

            return View(ListadeDescargas);

        }
    


        public ActionResult Crear()
        {
            var nuevaDescarga = new Descarga();
            var toolUsers = _toolUsersBL.ObtenerUsuariosActivos();
            

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario");
            //ViewBag.HerramentalId = new SelectList(herramental, "Id", "Descripcion");

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

            var toolUsers = _toolUsersBL.ObtenerUsuariosActivos();
            //var herramental = _herramentalBL.ObtenerHerramentalActivos();

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario");
            //ViewBag.HerramentalId = new SelectList(herramental, "Id", "Descripcion");

            return View(descarga);
        }

        public ActionResult Editar(int id)
        {
            var descarga = _descargasBL.ObtenerDescarga(id);
            var toolUsers = _toolUsersBL.ObtenerUsuariosActivos();
            //var herramental = _herramentalBL.ObtenerHerramentalActivos();

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario", descarga.ToolUsersId);
            //ViewBag.HerramentalId = new SelectList(herramental, "Id", "Descripcion", descarga.HerramentalId);

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

            var toolUsers = _toolUsersBL.ObtenerUsuariosActivos();
            //var herramental = _herramentalBL.ObtenerHerramentalActivos();

            ViewBag.ToolUsersId = new SelectList(toolUsers, "Id", "NombreUsuario", descarga.ToolUsersId);
            //ViewBag.HerramentalId = new SelectList(herramental, "Id", "Descripcion", descarga.HerramentalId);

            return View(descarga);
        }

        public ActionResult Detalle(int id)
        {
            var descarga = _descargasBL.ObtenerDescarga(id);

            return View(descarga);
        }



        public ActionResult DescargarHerramental(int id)
        {
            var descarga = _descargasBL.ObtenerDescarga(id);

            return View(descarga);
        }


    }
}