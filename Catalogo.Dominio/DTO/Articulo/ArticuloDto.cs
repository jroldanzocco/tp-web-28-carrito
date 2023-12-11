using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.DTO.Articulo
{
    public class ArticuloDto : AddArticuloDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }

        public int Cantidad { get; set; } = 0;
        public decimal PrecioTotal { get; set; }
    }
}
