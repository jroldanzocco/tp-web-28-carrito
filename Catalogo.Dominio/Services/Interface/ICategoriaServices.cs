using Catalogo.Dominio.DTO.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.Services.Interface
{
    public interface ICategoriaServices
    {
        List<CategoriaDto> GetAll();
        void Insert(AddCategoriaDto addCategoriaDto);
    }
}
