using Infraestructure.Core.Repository.Interface.Actions;
using Infraestructure.Entity;
using System.Collections.Generic;

namespace Infraestructure.Core.Repository.Interface
{
    public interface IImagenRepository : IReadRepository<ImagenEntity,int>, ICreateRepository<ImagenEntity>, IUpdateRepository<ImagenEntity>
    {
        List<string> GetByIdArticulo(int idArticulo);
        void Delete(int idArticulo);
    }
}
