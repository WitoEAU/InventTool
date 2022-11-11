using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class HerramentalBL
    {
        public List <Herramental> ObtenerHerramental()
        {
            var herramental1 = new Herramental();
            herramental1.Id = 1;
            herramental1.Descripcion = "Dado ";
            herramental1.Medida = 1.60;
            herramental1.Serie = "M1265";

            var herramental2 = new Herramental();
            herramental2.Id = 2;
            herramental2.Descripcion = "Dado ";
            herramental2.Medida = 1.65;
            herramental2.Serie = "M1266";


            var herramental3 = new Herramental();
            herramental3.Id = 3;
            herramental3.Descripcion = "Dado ";
            herramental3.Medida = 1.70;
            herramental3.Serie = "M1270";


            var listadeHerramental = new List<Herramental>();
                listadeHerramental.Add(herramental1);
                listadeHerramental.Add(herramental2);
                listadeHerramental.Add(herramental3);

            return listadeHerramental;
        }
    }
}
