using Catalogo.Dominio.DTO.Marca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.Services.Interface
{
    public interface IMarcaServices
    {
        List<MarcaDto> GetAll();
    }
}
