using InventTool.Web.Models;
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
            var herramental1 = new HerramentalModel();
            herramental1.Id = 1;
            herramental1.Descripcion = "dado 1.60mm";

            var herramental2 = new HerramentalModel();
            herramental2.Id = 2;
            herramental2.Descripcion = "dado 1.65mm";

            var herramental3 = new HerramentalModel();
            herramental3.Id = 3;
            herramental3.Descripcion = "dado 1.70mm";

            var listadeHerramental = new List<HerramentalModel>();
            listadeHerramental.Add(herramental1);
            listadeHerramental.Add(herramental2);
            listadeHerramental.Add(herramental3);


            return View(listadeHerramental);
        }
    }
}