using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.DTO.Articulo
{
    public class AddArticuloDto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int idCategoria { get; set; }
        public int idMarca { get; set; }
        public string Descripcion { get; set; }
        public List<string> Imagen { get; set; }
        public decimal Precio { get; set; }
    }
}
