using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class DescargasBL
    {
        Contexto _contexto;
        public List<Descarga> ListadeDescargas { get; set; }
        public List<Herramental> ListadeHerramental { get; set; }
        public List<DescargaDetalle> ListadeDescargaDetalle { get; set; }
        public DescargasBL()
        {
            _contexto = new Contexto();
            ListadeDescargas = new List<Descarga>();
            ListadeHerramental = new List<Herramental>();
            ListadeDescargaDetalle = new List<DescargaDetalle>();
        }

        public List<Descarga> ObtenerDescargas()
        {
            ListadeDescargas = _contexto.Descarga
            .Include("ToolUsers")
            .Include("Herramental")
            .ToList();
                
            return ListadeDescargas;
        }

        public List<DescargaDetalle> ObtenerDescargaDetalle(int descargaId)
        {
            var listadeDescargasDetalle = _contexto.DescargaDetalle
                .Include("Herramental")
                .Include("Categoria")
                .Where(d => d.DescargaId == descargaId)
                .ToList();

            return listadeDescargasDetalle;
        }


        public DescargaDetalle ObtenerDescargaDetallePorId(int id)
        {
            var descargaDetalle = _contexto.DescargaDetalle
                .Include("Categoria")
                .Include("Herramental").FirstOrDefault(h => h.Id == id);

            return descargaDetalle;
        }


       
        public Descarga ObtenerDescarga(int id)
        {
            var descarga = _contexto.Descarga
            .Include("ToolUsers")
            .Include("Herramental").FirstOrDefault(h => h.Id == id);


            return descarga;
        }

        public void GuardarDescarga(Descarga descarga)
        {
           if (descarga.Id == 0)
            {
                _contexto.Descarga.Add(descarga);
            }else
            {
                var descargaExistente = _contexto.Descarga.Find(descarga.Id);
                descargaExistente.ToolUsersId = descarga.ToolUsersId;
                //descargaExistente.Herramental = descarga.Herramental;
                //descargaExistente.CategoriaId = descarga.CategoriaId;
                descargaExistente.Activo = descarga.Activo;
            }

            _contexto.SaveChanges();

        }

        public void GuardarDescargaDetalle(DescargaDetalle descargaDetalle)
        {
            var herramental = _contexto.Herramental.Find(descargaDetalle.HerramentalId);

            descargaDetalle.Precio = herramental.Precio;
            descargaDetalle.Descripcion = herramental.Descripcion;
            descargaDetalle.Medida = herramental.Medida;
            descargaDetalle.Total = descargaDetalle.Cantidad * descargaDetalle.Precio;
            _contexto.DescargaDetalle.Add(descargaDetalle);

            var descarga = _contexto.Descarga.Find(descargaDetalle.DescargaId);
            descarga.Total = descarga.Total + descargaDetalle.Total;

            _contexto.SaveChanges();
        }

        public void EliminarDescargaDetalle(int id)
        {
            var descargaDetalle = _contexto.DescargaDetalle.Find(id);
            _contexto.DescargaDetalle.Remove(descargaDetalle);

            var descarga = _contexto.Descarga.Find(descargaDetalle.DescargaId);
            descarga.Total = descarga.Total - descargaDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
