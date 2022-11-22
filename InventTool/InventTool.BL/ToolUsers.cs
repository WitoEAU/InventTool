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

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Ingresar Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "Ingresar Area de Usuario")]
        public string AreaUsuario { get; set; }
        public bool Activo { get; set; }

       
    }
}
