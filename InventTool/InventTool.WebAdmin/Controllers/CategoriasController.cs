using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.WebAdmin.Controllers
{
    public class CategoriasController : Controller
    {
           CategoriasBL _categoriasBL;

            public CategoriasController()
            {
            _categoriasBL = new CategoriasBL();
            }

            // GET: Categorias
            public ActionResult Index()
            {
                
                var listadeCategorias = _categoriasBL.ObtenerCategoria();

                return View(listadeCategorias);
            }

            public ActionResult Crear()
            {
                var nuevaCategoria = new Categoria();

                return View(nuevaCategoria);
            }
            [HttpPost]
            public ActionResult Crear(Categoria categoria)
            {

            if (ModelState.IsValid){ 
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No dejar espacios al inicio, ni al final");
                    return View(categoria);
                }

            _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");

            }
            else
            {
                return View(categoria);
            }
        }

            public ActionResult Editar(int id)
            {
                var herramental = _categoriasBL.ObtenerCategoria(id);
                return View(herramental);
            }

            [HttpPost]
            public ActionResult Editar(Categoria categoria)
            {
            if (ModelState.IsValid)
            {
                if (categoria.Descripcion != categoria.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "No dejar espacios al inicio, ni al final");
                    return View(categoria);
                }

                _categoriasBL.GuardarCategoria(categoria);
                return RedirectToAction("Index");

            }
            else
            {
                return View(categoria);
            }
        }

            public ActionResult Detalle(int id)
            {
                var herramental = _categoriasBL.ObtenerCategoria(id);
                return View(herramental);
            }


            public ActionResult Eliminar(int id)
            {
                var herramental = _categoriasBL.ObtenerCategoria(id);
                return View(herramental);
            }

            [HttpPost]
            public ActionResult Eliminar(Categoria herramental)
            {
            _categoriasBL.EliminarCategoria(herramental.Id);
                return RedirectToAction("Index");
            }

        }
    }