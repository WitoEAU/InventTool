using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class HerramentalBL
    {
        Contexto _contexto;
        public List<Herramental> ListadeHerramental { get; set; }

        public HerramentalBL()
        {
            _contexto = new Contexto();
            ListadeHerramental = new List<Herramental>();
        }



        public List <Herramental> ObtenerHerramental()
        {

            ListadeHerramental = _contexto.Herramental
                .Include("Categoria")
                .ToList();
            
            return ListadeHerramental;
        }

        public void GuardarHerramental(Herramental herramental)
        {
            if (herramental.Id == 0) 
            { 
                _contexto.Herramental.Add(herramental); 
            }
            else
            {
                var herramentalExistente = _contexto.Herramental.Find(herramental.Id);
                herramentalExistente.Descripcion = herramental.Descripcion;
                herramentalExistente.CategoriaId = herramental.CategoriaId;
                herramentalExistente.Precio = herramental.Precio;
                herramentalExistente.Medida = herramental.Medida;
                herramentalExistente.Serie = herramental.Serie;
                herramentalExistente.Modelo = herramental.Modelo;
                herramentalExistente.Existencia = herramental.Existencia;
                herramentalExistente.Activo = herramental.Activo;
                herramentalExistente.UrlImagen = herramental.UrlImagen;

            }
            
            _contexto.SaveChanges();

        }

        public Herramental ObtenerHerramental(int id)
        {
            var herramental = _contexto.Herramental
                .Include("Categoria").FirstOrDefault(p => p.Id == id);
            return herramental;
        }

        public void EliminarHerramental (int id)
        {
            var herramental = _contexto.Herramental.Find(id);
            _contexto.Herramental.Remove(herramental);
            _contexto.SaveChanges();
        }
    }
}
