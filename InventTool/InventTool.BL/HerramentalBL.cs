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
        public List<HerramentalTooling> ListadeHerramentalTooling { get; set; }

        public HerramentalBL()
        {
            _contexto = new Contexto();
            ListadeHerramental = new List<Herramental>();
            ListadeHerramentalTooling = new List<HerramentalTooling>();
        }

        public List<Herramental> ObtenerHerramental()
        {

           
            ListadeHerramental = _contexto.Herramental
                .Include("Ubicacion")
                .Include("Categoria")
                .OrderBy(r => r.Categoria.Descripcion)
                .ThenBy(r => r.Descripcion)
                .ToList();

            return ListadeHerramental;

           
        }

        public List<Herramental> GetList()
        {
           
            ListadeHerramental = _contexto.Herramental
                .Include("Ubicacion")
                .Include("Categoria")
                .OrderBy(r => r.Categoria.Descripcion)
                .ThenBy(r => r.Descripcion)
                .ToList();

            return ListadeHerramental;

        }



        public List<Herramental> ObtenerHerramentalActivos()
        {

            ListadeHerramental = _contexto.Herramental
                .Include("Ubicacion")
                .Include("Categoria")
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Descripcion)
                .ToList();

            return ListadeHerramental;
        }

        public void GuardarHerramental(Herramental herramental)
        {
            if (herramental.Id == 0)
            {
                _contexto.Herramental.Add(herramental);
                var CantHer = 0;
                CantHer = CantHer + 1;
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
                herramentalExistente.UbicacionId = herramental.UbicacionId;
                herramentalExistente.Activo = herramental.Activo;
                herramentalExistente.UrlImagen = herramental.UrlImagen;
                

            }
            
            _contexto.SaveChanges();
            


        }

        public Herramental ObtenerHerramental(int id)
        {
            var herramental = _contexto.Herramental
                .Include("Ubicacion")
                .Include("Categoria")
                .FirstOrDefault(p => p.Id == id);
            return herramental;
        }

        public void EliminarHerramental (int id)
        {
            var herramental = _contexto.Herramental.Find(id);
            _contexto.Herramental.Remove(herramental);
            _contexto.SaveChanges();

            
        }


        public void MoverHerramental(int id)
        {

            

            var herramentalM = _contexto.Herramental.Find(id);


            herramentalM.Descripcion = herramentalM.Descripcion;
            herramentalM.CategoriaId = herramentalM.CategoriaId;
            herramentalM.Precio = herramentalM.Precio;
            herramentalM.Medida = herramentalM.Medida;
            herramentalM.Serie = herramentalM.Serie;
            herramentalM.Modelo = herramentalM.Modelo;
            herramentalM.Existencia = herramentalM.Existencia;
            herramentalM.UbicacionId = herramentalM.UbicacionId;
            herramentalM.Activo = herramentalM.Activo;
            herramentalM.UrlImagen = herramentalM.UrlImagen;
            





            HerramentalTooling herramentalExistente = _contexto.HerramentalTooling
                .Find(id);

            herramentalExistente = new HerramentalTooling();
            herramentalExistente.Descripcion = herramentalM.Descripcion;
            herramentalExistente.CategoriaId = herramentalM.CategoriaId;
            herramentalExistente.Precio = herramentalM.Precio;
            herramentalExistente.Medida = herramentalM.Medida;
            herramentalExistente.Serie = herramentalM.Serie;
            herramentalExistente.Modelo = herramentalM.Modelo;
            herramentalExistente.Existencia = herramentalM.Existencia;
            herramentalExistente.UbicacionId = herramentalM.UbicacionId;
            herramentalExistente.Activo = herramentalM.Activo;
            herramentalExistente.UrlImagen = herramentalM.UrlImagen;
           
            _contexto.HerramentalTooling.Add(herramentalExistente);

            var CantHer = 0;
            CantHer = CantHer - 1;


            _contexto.SaveChanges();



            var herramentalS = _contexto.Herramental.Find(id);

            _contexto.Herramental.Remove(herramentalS);



            _contexto.SaveChanges();
            


        }
    }
}
