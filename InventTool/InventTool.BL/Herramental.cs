using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class Herramental
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public double Medida { get; set; }
        public string Serie { get; set; }
        public string  Modelo { get; set; }
    }
}
