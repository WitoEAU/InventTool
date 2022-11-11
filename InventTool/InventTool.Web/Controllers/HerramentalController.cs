using InventTool.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventTool.Web.Controllers
{
    public class HerramentalController : Controller
    {
        // GET: Herramental
        public ActionResult Index()
        {
            var herramentalBL = new HerramentalBL();
            var listadeHerramental = herramentalBL.ObtenerHerramental();

            return View(listadeHerramental);
        }
    }
}