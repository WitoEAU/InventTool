using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    class ReporteDeInventariosBL
    {
        Contexto _contexto;
        public List<ReporteDeInventarios> ListadeVentasPorProducto { get; set; }

        public ReporteDeInventariosBL()
        {
            _contexto = new Contexto();
            ListadeVentasPorProducto = new List<ReporteDeInventarios>();
        }

        public List<ReporteDeInventarios> ObtenerVentasPorProducto()
        {
            //ListadeVentasPorProducto = _contexto.DescargaDetalle
            //    .Include("Herramental")
            //    .Where(r => r.Descarga.Activo)
            //    .GroupBy(r => r.Herramental.Descripcion)
            //    .Select(r => new ReporteDeInventarios()
            //    //{
            //    //    Herramental = r.Key,
            //    //    Cantidad = r.Sum(s => s.Cantidad),
            //    //    Medida = r.Sum(s => s.Total)
            //    //}).ToList();

            return ListadeVentasPorProducto;
        }
    }
}
