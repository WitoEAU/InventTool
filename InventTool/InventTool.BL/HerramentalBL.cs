using System;
using System.Collections.Generic;

namespace InventTool.BL
{
    public class HerramentalBL
    {
        public List<Herramental> ObtenerHerramental()
        {

            var herramental1 = new Herramental();
            herramental1.Id = 1;
            herramental1.Descripcion = "dado 1.60mm";

            var herramental2 = new Herramental();
            herramental2.Id = 2;
            herramental2.Descripcion = "dado 1.65mm";

            var herramental3 = new Herramental();
            herramental3.Id = 3;
            herramental3.Descripcion = "dado 1.70mm";

            var listadeHerramental = new List<Herramental>();
            listadeHerramental.Add(herramental1);
            listadeHerramental.Add(herramental2);
            listadeHerramental.Add(herramental3);

            return listadeHerramental;
        }


    }
}
