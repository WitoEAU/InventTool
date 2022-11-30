using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class HerramentalToolingBL
    {
        

        Contexto _contexto;
        public List<HerramentalTooling> ListadeHerramentalTooling { get; set; }
        public List<Herramental> ListadeHerramental { get; set; }

        public HerramentalToolingBL()
        {
            _contexto = new Contexto();
            ListadeHerramentalTooling = new List<HerramentalTooling>();
            ListadeHerramental = new List<Herramental>();
            

        }

        public List<HerramentalTooling> ObtenerHerramentalTooling()
        {

            ListadeHerramentalTooling = _contexto.HerramentalTooling
                .Include("Categoria")
                .Include("Ubicacion")
                .OrderBy(r => r.Categoria.Descripcion)
                .ThenBy(r => r.Descripcion)
                .ToList();

            return ListadeHerramentalTooling;
        }


        public List<HerramentalTooling> ObtenerHerramentalToolingActivos()
        {

            ListadeHerramentalTooling = _contexto.HerramentalTooling
                .Include("Categoria")
                .Include("Ubicacion")
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Descripcion)
                .ToList();

            return ListadeHerramentalTooling;
        }

        public void GuardarHerramentalTooling(HerramentalTooling herramental)
        {
            if (herramental.Id == 0)
            {
                _contexto.HerramentalTooling.Add(herramental);
            }
            else
            {
                var herramentalExistente = _contexto.HerramentalTooling.Find(herramental.Id);
                herramentalExistente.Descripcion = herramental.Descripcion;
                herramentalExistente.CategoriaId = herramental.CategoriaId;
                herramentalExistente.Precio = herramental.Precio;
                herramentalExistente.Medida = herramental.Medida;
                herramentalExistente.Serie = herramental.Serie;
                herramentalExistente.Modelo = herramental.Modelo;
                herramentalExistente.Existencia = herramental.Existencia;
                herramentalExistente.AreaId = herramental.AreaId;
                herramentalExistente.Activo = herramental.Activo;
                herramentalExistente.UrlImagen = herramental.UrlImagen;

            }

            _contexto.SaveChanges();

        }

        public HerramentalTooling ObtenerHerramentalTooling(int id)
        {
            var herramental = _contexto.HerramentalTooling
                .Include("Categoria")
                .Include("Area")
                .FirstOrDefault(p => p.Id == id);
            return herramental;
        }

        public void EliminarHerramentalTooling(int id)
        {
            var herramental = _contexto.HerramentalTooling.Find(id);
            _contexto.HerramentalTooling.Remove(herramental);
            _contexto.SaveChanges();
        }

        public void MoverHerramentalTooling(int id)
        {

            //var herramentalTooling = _contexto.HerramentalTooling
            //   .Include("Categoria").FirstOrDefault(h => h.Id == id);

            var herramentalM = _contexto.HerramentalTooling.Find(id);
            

            herramentalM.Descripcion = herramentalM.Descripcion;
            herramentalM.CategoriaId = herramentalM.CategoriaId;
            herramentalM.Precio = herramentalM.Precio;
            herramentalM.Medida = herramentalM.Medida;
            herramentalM.Serie = herramentalM.Serie;
            herramentalM.Modelo = herramentalM.Modelo;
            herramentalM.Existencia = herramentalM.Existencia;
            herramentalM.AreaId = herramentalM.AreaId;
            herramentalM.Activo = herramentalM.Activo;
            herramentalM.UrlImagen = herramentalM.UrlImagen;






            var herramentalExistenteT = _contexto.Herramental.Find(id);

            herramentalExistenteT = new Herramental();
            herramentalExistenteT.Descripcion = herramentalM.Descripcion;
            herramentalExistenteT.CategoriaId = herramentalM.CategoriaId;
            herramentalExistenteT.Precio = herramentalM.Precio;
            herramentalExistenteT.Medida = herramentalM.Medida;
            herramentalExistenteT.Serie = herramentalM.Serie;
            herramentalExistenteT.Modelo = herramentalM.Modelo;
            herramentalExistenteT.Existencia = herramentalM.Existencia;
            herramentalExistenteT.AreaId = herramentalM.AreaId;
            herramentalExistenteT.Activo = herramentalM.Activo;
            herramentalExistenteT.UrlImagen = herramentalM.UrlImagen;
            _contexto.Herramental.Add(herramentalExistenteT);
           

            

            



            var herramentalS = _contexto.HerramentalTooling.Find(id);

            _contexto.HerramentalTooling.Remove(herramentalS);

           
           
            _contexto.SaveChanges();



        }


    }
    
}
