using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.DTO.Imagen
{
    public class AddImagenDto
    {
        public int IdArticulo { get; set; }
        public List<string> ImagenUrl { get; set; }
    }
}
