using Catalogo.Dominio.DTO.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.Services.Interface
{
    public interface IArticuloServices
    {
        List<ArticuloDto> GetAll();
        ArticuloDto GetById(int id);
        void Insert(ArticuloDto articulo);
        void Update(ArticuloDto articulo);
    }
}
