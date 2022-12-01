using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventTool.BL
{
    public class Herramental
    {

        public Herramental()
        {
            Activo = true;

        }
        public int Id { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Ingresar Descripcion")]
        [MinLength(3, ErrorMessage = "Ingresar minimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingresar maximo 20 caracteres")]
        public string Descripcion { get; set; }

        [Range(0, 1000, ErrorMessage = "Ingresar precio entre 0 y 1000")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "Ingresar Cantidad de existencias")]
        public int Existencia { get; set; }
        public double Medida { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
        public bool Activo { get; set; }
        public int UbicacionId { get; set; }
        public Ubicacion Ubicacion { get; set; }



    }
}
