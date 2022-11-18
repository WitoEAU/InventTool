using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class ToolUsers
    {
        public ToolUsers()
        {
            Activo = true;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresar Nombre de Usuario")]
        public String NombreUsuario { get; set; }

        [Required(ErrorMessage = "Ingresar Area de Usuario")]
        public String AreaUsuario { get; set; }
        public bool Activo { get; set; }

       
    }
}
