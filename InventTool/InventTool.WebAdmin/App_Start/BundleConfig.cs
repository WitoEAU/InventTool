using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace JqueryDataTableInMvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Plugin/css").Include(
                "~/Content/datatable/css/jquery.datatables.min.css",
                "~/Content/fontawesome-free/css/all.css"));

            bundles.Add(new StyleBundle("~/Content/Plugin/js").Include(
                "~/Content/datatable/js/jquery.datatables.min.js",
                "~/Content/fontawesome-free/js/all.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                    "~/Scripts/DataTables/jquery.dataTables.min.js",
                    "~/Scripts/DataTables/dataTables.bootstrap.js", "~/Scripts/DataTables/buttons.bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.css", "~/Content/DataTables/css/buttons.bootstrap.css"));


        }
    }
}