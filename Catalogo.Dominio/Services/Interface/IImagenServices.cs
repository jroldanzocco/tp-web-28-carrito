using Catalogo.Dominio.DTO.Imagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Dominio.Services.Interface
{
    public interface IImagenServices
    {
        void Insert(AddImagenDto addImagenDto);
        void Update(AddImagenDto imagenDto);
    }
}
