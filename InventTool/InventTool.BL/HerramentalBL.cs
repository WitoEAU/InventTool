using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class HerramentalBL
    {

        public List<Herramental> ListadeHerramental { get; set; }

        Contexto _contexto;

        public HerramentalBL()
        {
            _contexto = new Contexto();
            ListadeHerramental = new List<Herramental>();
        }



        public List <Herramental> ObtenerHerramental()
        {

            ListadeHerramental = _contexto.Herramental.ToList();
            
            return ListadeHerramental;
        }
    }
}
