using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.WebAdmin.Controllers
{
    public class UbicacionController : Controller
    {

        UbicacionesBL _ubicacionesBL;

        public UbicacionController()
        {
            _ubicacionesBL = new UbicacionesBL();
        }
        // GET: Ubicaciones
        public ActionResult Index()
        {

            var ListadeUbicaciones = _ubicacionesBL.ObtenerUbicacion();

            return View(ListadeUbicaciones);
        }

        public ActionResult Crear()
        {
            var nuevaUbicacion = new Ubicacion();

            return View(nuevaUbicacion);
        }
        [HttpPost]
        public ActionResult Crear(Ubicacion ubicacion)
        {

            if (ModelState.IsValid){
                if (ubicacion.Area != ubicacion.Area.Trim())
                {
                    ModelState.AddModelError("Area", "No dejar espacios al inicio, ni al final");
                    return View(ubicacion);
                }

                _ubicacionesBL.GuardarUbicacion(ubicacion);
                return RedirectToAction("Index");

            }
            else
            {
                return View(ubicacion);
            }
        }

        public ActionResult Editar(int id)
        {
            var herramentalU = _ubicacionesBL.ObtenerUbicacion(id);
            return View(herramentalU);
        }

        [HttpPost]
        public ActionResult Editar(Ubicacion ubicacion)
        {
            if (ModelState.IsValid)
            {
                if (ubicacion.Area != ubicacion.Area.Trim())
                {
                    ModelState.AddModelError("Area", "No dejar espacios al inicio, ni al final");
                    return View(ubicacion);
                }

                _ubicacionesBL.GuardarUbicacion(ubicacion);
                return RedirectToAction("Index");

            }
            else
            {
                return View(ubicacion);
            }
        }

        public ActionResult Detalle(int id)
        {
            var herramentalU = _ubicacionesBL.ObtenerUbicacion(id);
            return View(herramentalU);
        }


        public ActionResult Eliminar(int id)
        {
            var herramentalU = _ubicacionesBL.ObtenerUbicacion(id);
            return View(herramentalU);
        }

        [HttpPost]
        public ActionResult Eliminar(Ubicacion herramental)
        {
            _ubicacionesBL.EliminarUbicacion(herramental.Id);
            return RedirectToAction("Index");
        }
    }
}