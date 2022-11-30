﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class Ubicacion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresar el Area")]
        public string Area { get; set; }

    }
}
