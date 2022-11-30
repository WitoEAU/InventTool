using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class UbicacionesBL
    {

        Contexto _contexto;
        public List<Ubicacion> ListadeUbicaciones { get; set; }

        public UbicacionesBL()
        {
            _contexto = new Contexto();
            ListadeUbicaciones = new List<Ubicacion>();
        }



        public List<Ubicacion> ObtenerUbicacion()
        {

            ListadeUbicaciones = _contexto.Ubicaciones.ToList();

            return ListadeUbicaciones;
        }

        public void GuardarUbicacion(Ubicacion ubicacion)
        {
            if (ubicacion.Id == 0)
            {
                _contexto.Ubicaciones.Add(ubicacion);
            }
            else
            {
                var ubicacionExistente = _contexto.Ubicaciones.Find(ubicacion.Id);
                ubicacionExistente.Area = ubicacion.Area;


            }

            _contexto.SaveChanges();

        }

        public Ubicacion ObtenerUbicacion(int id)
        {
            var ubicacion = _contexto.Ubicaciones.Find(id);
            return ubicacion;
        }

        public void EliminarUbicacion(int id)
        {
            var ubicacion = _contexto.Ubicaciones.Find(id);
            _contexto.Ubicaciones.Remove(ubicacion);
            _contexto.SaveChanges();
        }

    }
}
