using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.DTO.Articulo
{
    public class AddArticuloDto
    {
        [Required(ErrorMessage = "El codigo es requerido")]
        [MaxLength(50, ErrorMessage ="La longitud maxima es de 50")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Solo se permiten letras y números")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(50, ErrorMessage = "La longitud maxima es de 50")]
        public string Nombre { get; set; }
        public int idCategoria { get; set; }
        public int idMarca { get; set; }
        public string Descripcion { get; set; }
        public List<string> Imagen { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0, 9999999.99,ErrorMessage = "El numero debe variar entre 0 y 9999999")]
        public decimal Precio { get; set; }
    }
}
