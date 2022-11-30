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
        HerramentalToolingBL _herramentalToolingBL;
        CategoriasBL _categoriasBL;
        UbicacionesBL _ubicacionesBL;
        Contexto _contexto;


        public HerramentalController()
        {
            _herramentalBL = new HerramentalBL();
            _herramentalToolingBL = new HerramentalToolingBL();
            _categoriasBL = new CategoriasBL();
            _ubicacionesBL = new UbicacionesBL();
        }

        // GET: Herramental
        public ActionResult Index(/*string buscar*/)
        {
            
            var listadeHerramental = _herramentalBL.ObtenerHerramental();


            //******************************Buscador*****************************************
            //var herramentalB = from herramental in _contexto.Herramental select herramental
            //if (!String.IsNullOrEmpty(buscar))
            //{
            //    herramentalB = Herramental.Where(s => s.Descripcion!.Contains(buscar));
            //}



            return View(listadeHerramental);
        }
        
        public ActionResult Crear()
        {
            var nuevoHerramental = new Herramental();
            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            ViewBag.AreaId = new SelectList(ubicaciones, "Id", "Area");
            return View(nuevoHerramental);
        }
        [HttpPost]
        public ActionResult Crear(Herramental herramental, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (herramental.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccionar Categoria");
                    return View(herramental);
                }

                if (imagen != null)
                {
                    herramental.UrlImagen = GuardarImagen(imagen);

                }  

                _herramentalBL.GuardarHerramental(herramental);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");
            ViewBag.AreaId = new SelectList(ubicaciones, "Id", "Area");
            
            return View(herramental);
        }

        public ActionResult Editar(int id)
        {
            var herramental = _herramentalBL.ObtenerHerramental(id);
            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", herramental.CategoriaId);
            ViewBag.AreaId = new SelectList(ubicaciones, "Id", "Area", herramental.AreaId);
            return View(herramental);
        }
        
        [HttpPost]
        public ActionResult Editar(Herramental herramental, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (herramental.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccionar Categoria");
                    return View(herramental);
                }

                if (imagen != null)
                {
                    herramental.UrlImagen = GuardarImagen(imagen);

                }

                _herramentalBL.GuardarHerramental(herramental);
                return RedirectToAction("Index");
            }

            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();

            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");
            ViewBag.AreaId = new SelectList(ubicaciones, "Id", "Area");

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


        public ActionResult Mover(int id)
        {
            var herramental = _herramentalBL.ObtenerHerramental(id);

            return View(herramental);
        }

        [HttpPost]
        public ActionResult Mover(Herramental herramental)
        {
            _herramentalBL.MoverHerramental(herramental.Id);

            return RedirectToAction("Index");
        }


    }
}