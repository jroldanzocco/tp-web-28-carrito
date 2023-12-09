using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.DTO.Categoria
{
    public class AddCategoriaDto
    {
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
