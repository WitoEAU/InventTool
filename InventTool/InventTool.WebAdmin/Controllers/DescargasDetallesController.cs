using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.WebAdmin.Controllers
{
    public class DescargasDetallesController : Controller
    {
        DescargasBL _descargasBL;
        HerramentalBL _herramentalBL;
        
        

        public DescargasDetallesController()
        {
            _descargasBL = new DescargasBL();
            _herramentalBL = new HerramentalBL();
        }

        // GET: DescargasDetalle
        public ActionResult Index(int id)
        {
            var descarga = _descargasBL.ObtenerDescarga(id);
            descarga.ListadeDescargaDetalle = _descargasBL.ObtenerDescargaDetalle(id);

            return View(descarga);
        }

        public ActionResult Crear(int id)
        {
            var nuevaDescargaDetalle = new DescargaDetalle();
            nuevaDescargaDetalle.DescargaId = id;

            var herramental = _herramentalBL.ObtenerHerramentalActivos();
            ViewBag.herramentalId = new SelectList(herramental, "Id", "Descripcion");


            return View(nuevaDescargaDetalle);
        }

        [HttpPost]
        public ActionResult Crear(DescargaDetalle descargaDetalle)
        {
            if (ModelState.IsValid)
            {
                if (descargaDetalle.HerramentalId == 0)
                {
                    ModelState.AddModelError("HerramentalId", "Seleccione un herramental");
                    return View(descargaDetalle);
                }

                _descargasBL.GuardarDescargaDetalle(descargaDetalle);
                return RedirectToAction("Index", new { id = descargaDetalle.DescargaId });
            }
            
            var herramental = _herramentalBL.ObtenerHerramentalActivos();
            ViewBag.herramentalId = new SelectList(herramental, "Id", "Descripcion");

            return View(descargaDetalle);
        }

        public ActionResult Eliminar(int id)
        {
            var descargaDetalle = _descargasBL.ObtenerDescargaDetallePorId(id);

            return View(descargaDetalle);
        }

        [HttpPost]
        public ActionResult Eliminar(DescargaDetalle descargaDetalle)
        {
            _descargasBL.EliminarDescargaDetalle(descargaDetalle.Id);

            return RedirectToAction("Index", new { id = descargaDetalle.DescargaId });
        }
    }
}