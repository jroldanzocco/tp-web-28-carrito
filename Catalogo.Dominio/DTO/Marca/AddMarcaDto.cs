using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.DTO.Marca
{
    public class AddMarcaDto
    {
        [MaxLength(50)]
        public string Descripcion { get; set; }

    }
}
