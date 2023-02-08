using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Linq.Dynamic.Core;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Data.WcfLinq.Helpers;
using System.Data.Entity;



namespace InventTool.WebAdmin.Controllers
{
    public class HerramentalController : Controller
    {
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;



        //private readonly string cadenaSQL;

        HerramentalBL _herramentalBL;
        HerramentalToolingBL _herramentalToolingBL;
        CategoriasBL _categoriasBL;
        UbicacionesBL _ubicacionesBL;
       

        
        public HerramentalController()
        {
            
            _herramentalBL = new HerramentalBL();
            _herramentalToolingBL = new HerramentalToolingBL();
            _categoriasBL = new CategoriasBL();
            _ubicacionesBL = new UbicacionesBL();

        }



        //[HttpPost]
        //public JsonResult Json()
        //{



        //    List<BL.Herramental> lst = new List<BL.Herramental>();
        //    var datos = _herramentalBL.ListadeHerramental;

        //    var draw = Request.Form.GetValues("draw").FirstOrDefault();
        //    var start = Request.Form.GetValues("start").FirstOrDefault();
        //    var length = Request.Form.GetValues("length").FirstOrDefault();
        //    var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
        //    var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
        //    var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

        //    pageSize = length != null ? Convert.ToInt32(length) : 0;
        //    skip = start != null ? Convert.ToInt32(start) : 0;
        //    recordsTotal = 0;



        //    using (Contexto db = new Contexto())

        //    {

        //        IQueryable<Herramental> query = from d in db.Herramental
        //                                        select new Herramental
        //                                        {
        //                                            Descripcion = d.Descripcion,
        //                                            CategoriaId = d.CategoriaId,
        //                                            Precio = d.Precio,
        //                                            Medida = d.Medida,
        //                                            Serie = d.Serie,
        //                                            Modelo = d.Modelo,
        //                                            Existencia = d.Existencia,
        //                                            UbicacionId = d.UbicacionId,
        //                                            UrlImagen = d.UrlImagen,
        //                                            Activo = d.Activo,
        //                                            Opciones = d.Opciones,


        //                                        };



        //        if (searchValue != "")
        //            query = query.Where(d => d.Descripcion.Contains(searchValue));

        //        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
        //        {
        //            query = query.OrderBy(sortColumn + " " + sortColumnDir);
        //        }


        //        recordsTotal = lst.Count();

        //        query = query.Skip(skip).Take(pageSize).Select(d => new Herramental
        //        {
        //            Descripcion = d.Descripcion,
        //            CategoriaId = d.CategoriaId,
        //            Precio = d.Precio,
        //            Medida = d.Medida,
        //            Serie = d.Serie,
        //            Modelo = d.Modelo,
        //            Existencia = d.Existencia,
        //            UbicacionId = d.UbicacionId,
        //            UrlImagen = d.UrlImagen,
        //            Activo = d.Activo,
        //            Opciones = d.Opciones,

        //        });




        //    }
        //    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lst }, JsonRequestBehavior.AllowGet);
        //    //using (Contexto db = new Contexto())
        //    //{
        //    //    var emptList = db.Herramental.ToList<Herramental>();


        //    //    return Json(new { data = emptList }, JsonRequestBehavior.AllowGet);
        //    //}


        //}


        // GET: Herramental

        public ActionResult Index()
        {


            List<BL.Herramental> herramental = _herramentalBL.GetList();

            
            var datos = _herramentalBL.ListadeHerramental;
            ViewBag.herramental = new SelectList(herramental);





            return View(datos);
        }

        public ActionResult Crear()
        {
            var nuevoHerramental = new BL.Herramental();
            var categorias = _categoriasBL.ObtenerCategoria();
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();


            
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion");
            ViewBag.UbicacionId = new SelectList(ubicaciones, "Id", "Area");
            return View(nuevoHerramental);
        }
        [HttpPost]
        public ActionResult Crear(BL.Herramental herramental, HttpPostedFileBase imagen)
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
            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");

            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();         
            ViewBag.ListadeUbicaciones = new SelectList(ubicaciones, "Id", "Area");
            
            return View(herramental);
        }

        public ActionResult Editar(int id)
        {
            var herramental = _herramentalBL.ObtenerHerramental(id);
            var categorias = _categoriasBL.ObtenerCategoria();
            ViewBag.CategoriaId = new SelectList(categorias, "Id", "Descripcion", herramental.CategoriaId);
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();
            ViewBag.UbicacionId = new SelectList(ubicaciones, "Id", "Area", herramental.UbicacionId);

            return View(herramental);
        }
        
        [HttpPost]
        public ActionResult Editar(BL.Herramental herramental, HttpPostedFileBase imagen)
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
            ViewBag.ListadeCategorias = new SelectList(categorias, "Id", "Descripcion");
            var ubicaciones = _ubicacionesBL.ObtenerUbicacion();
            ViewBag.ListadeUbicaciones = new SelectList(ubicaciones, "Id", "Area");

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
        public ActionResult Eliminar (BL.Herramental herramental)
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
        public ActionResult Mover(BL.Herramental herramental)
        {
            _herramentalBL.MoverHerramental(herramental.Id);

            return RedirectToAction("Index");
        }


    }
}