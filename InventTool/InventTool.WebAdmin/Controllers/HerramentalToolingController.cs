using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.WebAdmin.Controllers
{
    public class HerramentalToolingController : Controller
    {
        HerramentalToolingBL _herramentalToolingBL;
        HerramentalBL _herramentalBL;
        UbicacionesBL _ubicacionesBL;
        CategoriasBL _categoriasBL;
        

        public HerramentalToolingController()
        {
            _herramentalToolingBL = new HerramentalToolingBL();
            _categoriasBL = new CategoriasBL();
            _herramentalBL = new HerramentalBL();
            _ubicacionesBL = new UbicacionesBL();
        }

        // GET: HerramentalTooling
        public ActionResult Index()
        {

            var listadeHerramentalTooling = _herramentalToolingBL.ObtenerHerramentalTooling();

            return View(listadeHerramentalTooling);
        }

        public ActionResult Crear()
        {
            var nuevoHerramentalTooling = new HerramentalTooling();
            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            ViewBag.UbicacionId = new SelectList(ubicaciones, "Id", "Area");

            return View(nuevoHerramentalTooling);
        }
        [HttpPost]
        public ActionResult Crear(HerramentalTooling herramentalTooling, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (herramentalTooling.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccionar Categoria");
                    return View(herramentalTooling);
                }

                if (imagen != null)
                {
                    herramentalTooling.UrlImagen = GuardarImagen(imagen);

                }

                _herramentalToolingBL.GuardarHerramentalTooling(herramentalTooling);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");
            ViewBag.ListadeUbicaciones = new SelectList(ubicaciones, "Id", "Area");
            
            return View(herramentalTooling);
        }

        public ActionResult Editar(int id)
        {
            var herramentalTooling = _herramentalToolingBL.ObtenerHerramentalTooling(id);
            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", herramentalTooling.CategoriaId);
            ViewBag.UbicacionId = new SelectList(ubicaciones, "Id", "Area", herramentalTooling.UbicacionId);
            return View(herramentalTooling);
        }

        [HttpPost]
        public ActionResult Editar(HerramentalTooling herramentalTooling, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (herramentalTooling.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccionar Categoria");
                    return View(herramentalTooling);
                }

                if (imagen != null)
                {
                    herramentalTooling.UrlImagen = GuardarImagen(imagen);

                }

                _herramentalToolingBL.GuardarHerramentalTooling(herramentalTooling);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");
            ViewBag.ListadeUbicaciones = new SelectList(ubicaciones, "Id", "Area");

            return View(herramentalTooling);
        }

        public ActionResult Detalle(int id)
        {
            var herramentalTooling = _herramentalToolingBL.ObtenerHerramentalTooling(id);

            return View(herramentalTooling);
        }


        public ActionResult Eliminar(int id)
        {
            var herramentalTooling = _herramentalToolingBL.ObtenerHerramentalTooling(id);

            return View(herramentalTooling);
        }

        [HttpPost]
        public ActionResult Eliminar(HerramentalTooling herramentalTooling)
        {
            _herramentalToolingBL.EliminarHerramentalTooling(herramentalTooling.Id);
            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }



        public ActionResult Mover(int id)
        {
            var herramental = _herramentalToolingBL.ObtenerHerramentalTooling(id);
            
            return View(herramental);
        }

        [HttpPost]
        public ActionResult Mover(HerramentalTooling herramentalTooling)
        {
            _herramentalToolingBL.MoverHerramentalTooling(herramentalTooling.Id);
            
            return RedirectToAction("Index");
        }

     


    }
}