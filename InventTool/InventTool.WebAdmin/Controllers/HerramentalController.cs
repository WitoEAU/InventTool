using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.WebAdmin.Controllers
{
    public class HerramentalController : Controller
    {
        HerramentalBL _herramentalBL;
        CategoriasBL _categoriasBL;

        public HerramentalController()
        {
            _herramentalBL = new HerramentalBL();
            _categoriasBL = new CategoriasBL();
        }

        // GET: Herramental
        public ActionResult Index()
        {
            
            var listadeHerramental = _herramentalBL.ObtenerHerramental();

            return View(listadeHerramental);
        }
        
        public ActionResult Crear()
        {
            var nuevoHerramental = new Herramental();
            var categorias = _categoriasBL.ObtenerCategoria();

            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");

            return View(nuevoHerramental);
        }
        [HttpPost]
        public ActionResult Crear(Herramental herramental, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                //if(herramental.CategoriaId == 0)
                //{
                //    ModelState.AddModelError("CategoriaId, Seleccionar Categoria");
                //    return View(herramental);
                //}

                if (imagen != null)
                {
                    herramental.UrlImagen = GuardarImagen(imagen);

                }  

                _herramentalBL.GuardarHerramental(herramental);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategoria();

            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");

            return View(herramental);
        }

        public ActionResult Editar(int id)
        {
            var herramental = _herramentalBL.ObtenerHerramental(id);
            var categorias = _categoriasBL.ObtenerCategoria();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", herramental.CategoriaId);
            return View(herramental);
        }
        
        [HttpPost]
        public ActionResult Editar(Herramental herramental, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                //if(herramental.CategoriaId == 0)
                //{
                //    ModelState.AddModelError("CategoriaId, Seleccionar Categoria");
                //    return View(herramental);
                //}

                if (imagen != null)
                {
                    herramental.UrlImagen = GuardarImagen(imagen);

                }

                _herramentalBL.GuardarHerramental(herramental);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategoria();

            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");

            return View(herramental);
        }

        public ActionResult Detalle(int id)
        {
            var herramental = _herramentalBL.ObtenerHerramental(id);
            
            return View(herramental);
        }


        public ActionResult Eliminar(int id)
        {
            var herramental = _herramentalBL.ObtenerHerramental(id);
           
            return View(herramental);
        }

        [HttpPost]
        public ActionResult Eliminar (Herramental herramental)
        {
            _herramentalBL.EliminarHerramental(herramental.Id);
            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }

    }
}