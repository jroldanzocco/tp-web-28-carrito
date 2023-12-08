using Infraestructure.Core.Repository.Interface.Actions;
using Infraestructure.Entity;

namespace Infraestructure.Core.Repository.Interface
{
    public interface IArticuloRepository : IReadRepository<ArticuloEntity,int>, ICreateRepository<ArticuloEntity>, IUpdateRepository<ArticuloEntity>, IRemoveRepository<int> 
    {
    }
}
