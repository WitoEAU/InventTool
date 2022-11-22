using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class Descarga
    {
        public int Id { get; set; }
        public int ToolUsersId { get; set; }
        public ToolUsers ToolUsers { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        public List<DescargaDetalle> ListadeDescargaDetalle { get; set; }
        public double Total { get; internal set; }

        public Descarga()
        {
            Activo = true;
            Fecha = DateTime.Now;

            ListadeDescargaDetalle = new List<DescargaDetalle>();
        }
    }

    public class DescargaDetalle
    {
        public int Id { get; set; }
        public int DescargaId { get; set; }
        public Descarga Descarga { get; set; }

        public int HerramentalId { get; set; }
        public Herramental Herramental { get; set; }
         
        public int Cantidad { get; set; }
        public double Precio{ get; set; }
        public double Total { get; set; }

    }
}
