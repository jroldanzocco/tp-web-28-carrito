using Infraestructure.Core.Repository.Interface.Actions;
using Infraestructure.Entity;
using System.Collections.Generic;

namespace Infraestructure.Core.Repository.Interface
{
    public interface IImagenRepository : IReadRepository<ImagenEntity,int>, ICreateRepository<ImagenEntity>, IUpdateRepository<ImagenEntity>, IRemoveRepository<int>
    {
        List<string> GetByIdArticulo(int idArticulo);
    }
}
