using Infraestructure.Core.Repository.Interface.Actions;
using Infraestructure.Entity;

namespace Infraestructure.Core.Repository.Interface
{
    public interface IImagenRepository : IReadRepository<ImagenEntity,int>, ICreateRepository<ImagenEntity>, IUpdateRepository<ImagenEntity>, IRemoveRepository<int>
    {
    }
}
